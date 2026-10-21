using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Architect.API.Tron.Business.Backoffice;
using Architect.API.Tron.Contracts.AltasBajas.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Protege el contrato real de impresión y evita perder datos al preparar el documento de firma.
    /// </summary>
    [TestClass]
    public class PolicyProposalReportTests
    {
        private const string ReportName = "117_seguro_vida_colectivo_solicitud_inclusion";

        /// <summary>
        /// Reinicia el doble del transporte HTTP de reportes antes de cada escenario.
        /// </summary>
        [TestInitialize]
        public void Inicializar()
        {
            Core.Business.General.Report.Reset();
        }

        /// <summary>
        /// Entrega al transporte la misma instancia completa de Poliza, incluyendo sus beneficiarios.
        /// </summary>
        [DataTestMethod]
        [DataRow(117, ReportName)]
        [DataRow(401, "401_saldo_deudor")]
        public void Generate_ConservaPolizaCompletaComoContratoDelReporte(int ramo, string reportName)
        {
            Poliza poliza = new Poliza
            {
                RAMO = ramo,
                NUM_CONTRATO = 99340,
                COD_DOCUM_ASEG = "DOCUMENTO-DEMO",
                Beneficiarios = new List<Beneficiario>
                {
                    new Beneficiario { NOM_TERCERO_BENEF = "PERSONA", PCT_PARTICIPACION = 100 }
                }
            };

            string path = PolicyProposalSignatureDocument.Generate(poliza, new Core.Contracts.Security.Token { CompanyId = 12 });

            Assert.AreEqual("reporte-de-prueba.pdf", path);
            Assert.AreEqual(12, Core.Business.General.Report.CompanyId);
            Assert.AreEqual(reportName, Core.Business.General.Report.ReportName);
            Assert.AreSame(poliza, Core.Business.General.Report.Data);
            Assert.AreSame(poliza.Beneficiarios, ((Poliza)Core.Business.General.Report.Data).Beneficiarios);
        }

        /// <summary>
        /// Rechaza entradas ausentes antes de llamar al servicio externo.
        /// </summary>
        [TestMethod]
        public void Generate_RechazaSolicitudOContextoNulos()
        {
            Assert.ThrowsException<ArgumentNullException>(() => PolicyProposalSignatureDocument.Generate(null, new Core.Contracts.Security.Token()));
            Assert.ThrowsException<ArgumentNullException>(() => PolicyProposalSignatureDocument.Generate(new Poliza { RAMO = 117 }, null));
            Assert.AreEqual(0, Core.Business.General.Report.Calls);
        }

        /// <summary>
        /// Impide enviar a firma una plantilla de otro ramo o una copia de Bayer aún no adaptada.
        /// </summary>
        [DataTestMethod]
        [DataRow(194)]
        [DataRow(999)]
        public void Generate_RechazaRamosSinPlantillaAdaptada(int ramo)
        {
            Assert.ThrowsException<NotSupportedException>(() =>
                PolicyProposalSignatureDocument.Generate(new Poliza { RAMO = ramo }, new Core.Contracts.Security.Token()));
            Assert.AreEqual(0, Core.Business.General.Report.Calls);
        }

        /// <summary>
        /// Comprueba que el JSON de muestra se pueda deserializar sin propiedades ajenas al DTO real.
        /// </summary>
        [DataTestMethod]
        [DataRow(117, ReportName)]
        [DataRow(401, "401_saldo_deudor")]
        public void JsonDeEjemplo_UsaExclusivamentePropiedadesDePoliza(int ramo, string reportName)
        {
            string json = File.ReadAllText(Path.Combine(Root(), "docs", "reports", reportName + ".sample.json"));
            Poliza poliza = DeserializePolicy(json);

            Assert.AreEqual(ramo, poliza.RAMO);
            Assert.AreEqual("IDENTIFICACION-DEMO", poliza.COD_DOCUM_ASEG);
            Assert.AreEqual(2, poliza.Beneficiarios.Count);
            Assert.AreEqual(100, poliza.Beneficiarios.Sum(b => b.PCT_PARTICIPACION));
        }

        /// <summary>
        /// Valida también el JSON incrustado para el diseñador, que debe respetar el mismo contrato.
        /// </summary>
        [DataTestMethod]
        [DataRow(117, ReportName)]
        [DataRow(401, "401_saldo_deudor")]
        public void JsonIncrustado_UsaElContratoPoliza(int ramo, string reportName)
        {
            XElement component = Report(reportName).Descendants("ComponentStorage").Elements().Single();
            XElement source = XElement.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(component.Attribute("Base64").Value)));
            Poliza poliza = DeserializePolicy(source.Element("Source").Attribute("Json").Value);

            Assert.AreEqual(ramo, poliza.RAMO);
            Assert.AreEqual(2, poliza.Beneficiarios.Count);
        }

        /// <summary>
        /// Recorre las expresiones del reporte y sus bandas para detectar campos inventados o nombres de Bayer.
        /// </summary>
        [DataTestMethod]
        [DataRow(ReportName)]
        [DataRow("401_saldo_deudor")]
        public void Repx_EnlazaPolizaYBeneficiariosSinContratoAlternativo(string reportName)
        {
            XElement report = Report(reportName);
            ValidateExpressions(report, typeof(Poliza));
            XElement beneficiaries = report.Descendants().Single(e => (string)e.Attribute("Name") == "Beneficiarios");
            Assert.AreEqual("Beneficiarios", (string)beneficiaries.Attribute("DataMember"));
            Assert.IsTrue(report.Descendants().Attributes("Expression").Any(a => a.Value.Contains("[COD_DOCUM_ASEG]")));
            Assert.IsTrue(report.Descendants().Attributes("Expression").Any(a => a.Value.Contains("[PCT_PARTICIPACION]")));
        }

        /// <summary>
        /// El integrador de Evicertia recibe la ruta generada, pues él mismo lee y codifica el archivo.
        /// </summary>
        [TestMethod]
        public void Firma_EntregaLaRutaDelMismoPdfAdjuntado()
        {
            string source = File.ReadAllText(Path.Combine(Root(), "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureService.cs"));
            Match submit = Regex.Match(source, @"DocuSign\.Submit\((?<args>[\s\S]*?)\)\.GetAwaiter\(\)");

            Assert.IsTrue(submit.Success);
            StringAssert.Contains(submit.Groups["args"].Value, "pdfPath");
            Assert.IsFalse(source.Contains("Convert.ToBase64String"), "El proveedor ya codifica el archivo recibido por ruta.");
        }

        /// <summary>
        /// La falta de una plantilla se detecta antes de congelar la solicitud o invalidar la invitación.
        /// </summary>
        [TestMethod]
        public void Flujo_ValidaPlantillaAntesDePersistirOCompletarInvitacion()
        {
            string source = File.ReadAllText(Path.Combine(Root(), "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs"));
            int agentStart = source.IndexOf("public static Contracts.PolicyProposal BeginAgentSignature", StringComparison.Ordinal);
            int insuredStart = source.IndexOf("public static Contracts.PolicyProposal CompleteInsured", StringComparison.Ordinal);
            string agent = source.Substring(agentStart, insuredStart - agentStart);
            string insured = source.Substring(insuredStart);
            const string validation = "PolicyProposalSignatureDocument.ValidateTemplate(poliza)";

            Assert.IsTrue(agent.IndexOf(validation, StringComparison.Ordinal) >= 0, "Debe validar la plantilla antes de procesar el envío del agente.");
            Assert.IsTrue(agent.IndexOf(validation, StringComparison.Ordinal) < agent.IndexOf("SaveAgentDraft", StringComparison.Ordinal));
            Assert.IsTrue(insured.IndexOf(validation, StringComparison.Ordinal) >= 0, "Debe validar la plantilla antes de completar la invitación.");
            Assert.IsTrue(insured.IndexOf(validation, StringComparison.Ordinal) < insured.IndexOf("new Session", StringComparison.Ordinal));
        }

        private static Poliza DeserializePolicy(string json)
        {
            return JsonSerializer.Deserialize<Poliza>(json, new JsonSerializerOptions
            {
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
            });
        }

        private static void ValidateExpressions(XElement element, Type context)
        {
            if ((string)element.Attribute("ControlType") == "DetailReportBand")
            {
                string member = (string)element.Attribute("DataMember");
                if (!string.IsNullOrEmpty(member))
                {
                    var property = context.GetProperty(member);
                    Assert.IsNotNull(property, "Colección ajena al DTO: " + member);
                    context = property.PropertyType.GetGenericArguments().Single();
                }
            }

            string expression = (string)element.Attribute("Expression");
            if (expression != null)
            {
                foreach (Match match in Regex.Matches(expression, @"\[([A-Za-z_][A-Za-z0-9_]*)\]"))
                {
                    string property = match.Groups[1].Value;
                    Assert.IsNotNull(context.GetProperty(property), context.Name + " no declara " + property);
                }
            }

            foreach (XElement child in element.Elements()) ValidateExpressions(child, context);
        }

        private static XElement Report(string reportName)
        {
            return XElement.Load(Path.Combine(Root(), "WebApp", "Reports", reportName + ".repx"));
        }

        private static string Root()
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
        }
    }
}

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Contexto mínimo del límite externo; los contratos de póliza enlazados son los de producción.
    /// </summary>
    public sealed class Token
    {
        public int CompanyId { get; set; }
    }
}

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Doble del transporte HTTP que captura el objeto entregado sin llamar a servicios externos.
    /// </summary>
    public static class Report
    {
        public static int CompanyId { get; private set; }
        public static string ReportName { get; private set; }
        public static object Data { get; private set; }
        public static int Calls { get; private set; }

        public static void Reset()
        {
            CompanyId = 0;
            ReportName = null;
            Data = null;
            Calls = 0;
        }

        public static Task<string> Generate(int companyId, string reportName, object data, string outputFileName = "")
        {
            Calls++;
            CompanyId = companyId;
            ReportName = reportName;
            Data = data;
            return Task.FromResult("reporte-de-prueba.pdf");
        }
    }
}
