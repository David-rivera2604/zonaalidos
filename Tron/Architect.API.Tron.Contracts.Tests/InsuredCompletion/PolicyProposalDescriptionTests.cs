using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Architect.API.Tron.Business.Backoffice;
using Architect.API.Tron.Contracts.AltasBajas.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica la persistencia de los textos visibles de catálogos sin sustituir los códigos de emisión.
    /// </summary>
    [TestClass]
    public class PolicyProposalDescriptionTests
    {
        private static readonly string[] PolicyDescriptions =
        {
            "RAMODesc", "COD_DOCUM_ASEGTypeDesc", "MCA_SEXO_ASEGDesc", "OCUPACION_ASEGDesc",
            "NACIONALIDAD_ASEGDesc", "COD_ESTADODesc", "COD_PROVINCIADesc", "COD_LOCALIDADDesc",
            "IMP_PRIMA_FACTDesc", "MCA_ASISTENCIADesc", "COD_PLAN_APDesc"
        };

        private static readonly string[] BeneficiaryDescriptions =
        {
            "COD_DOCUM_BENEFTypeDesc", "MCA_SEXO_BENEFDesc", "TIP_RELACDesc",
            "ESTADO_BENEFDesc", "PROVINCIA_BENEFDesc", "LOCALIDAD_BENEFDesc"
        };

        /// <summary>
        /// Reproduce el JSON de la página y su recuperación repetida desde ProposalData con el serializador real.
        /// </summary>
        [TestMethod]
        public void Snapshot_ConservaDescripcionesDePaginaYBeneficiarios()
        {
            JObject posted = CreatePostedPolicy();
            Poliza policy = JsonConvert.DeserializeObject<Poliza>(posted.ToString());

            for (int step = 0; step < 3; step++)
            {
                string snapshot = JsonConvert.SerializeObject(policy);
                JObject persisted = JObject.Parse(snapshot);
                foreach (string name in PolicyDescriptions)
                    Assert.AreEqual((string)posted[name], (string)persisted[name], "Descripción perdida: " + name);
                foreach (string name in BeneficiaryDescriptions)
                    Assert.AreEqual((string)posted["beneficiarios"][0][name], (string)persisted["Beneficiarios"][0][name], "Descripción perdida del beneficiario: " + name);

                Assert.AreEqual("Contrato de ejemplo", (string)persisted["NUM_CONTRATODesc"]);
                Assert.IsNull(persisted["NUM_CONTRATODESC"], "Se debe emitir únicamente el nombre CampoDesc.");
                Assert.AreEqual(117, (int)persisted["RAMO"]);
                Assert.AreEqual(100, (int)persisted["Beneficiarios"][0]["PCT_PARTICIPACION"]);
                Assert.IsNull(persisted["proposalWorkflowStatus"], "El estado visual no es parte del contrato persistido.");
                policy = JsonConvert.DeserializeObject<Poliza>(snapshot);
                policy.EMAIL_ASEG = "correo-actualizado@example.com";
            }
        }

        /// <summary>
        /// Mantiene compatibles las instantáneas anteriores que nunca almacenaron las descripciones.
        /// </summary>
        [TestMethod]
        public void SnapshotAntiguo_ConservaCodigosSinExigirDescripciones()
        {
            Poliza policy = JsonConvert.DeserializeObject<Poliza>("{\"RAMO\":117,\"NACIONALIDAD_ASEG\":\"CRI\",\"NUM_CONTRATODESC\":\"Contrato anterior\",\"Beneficiarios\":[{\"TIP_RELAC\":1}]}");
            JObject serialized = JObject.FromObject(policy);

            Assert.AreEqual(117, policy.RAMO);
            Assert.AreEqual("Contrato anterior", policy.NUM_CONTRATODesc);
            Assert.AreEqual("Contrato anterior", (string)serialized["NUM_CONTRATODesc"], "Los JSON anteriores deben recuperarse y normalizarse al guardar.");
            Assert.IsNull(serialized["NUM_CONTRATODESC"]);
            Assert.AreEqual(1, policy.Beneficiarios[0].TIP_RELAC);
            foreach (string name in PolicyDescriptions)
            {
                Assert.IsNotNull(typeof(Poliza).GetProperty(name), "Falta la propiedad opcional " + name);
                Assert.AreEqual(JTokenType.Null, serialized[name].Type);
            }
            foreach (string name in BeneficiaryDescriptions)
                Assert.AreEqual(JTokenType.Null, serialized["Beneficiarios"][0][name].Type);
        }

        /// <summary>
        /// Las descripciones nuevas pertenecen al snapshot y no alteran el JSON del procedimiento de emisión.
        /// </summary>
        [TestMethod]
        public void Emision_ConservaCodigosSinDescripcionesDePresentacionNuevas()
        {
            JObject posted = CreatePostedPolicy();
            SPCall emission = JsonConvert.DeserializeObject<SPCall>(posted.ToString());
            JObject serialized = JObject.FromObject(emission);

            Assert.AreEqual(117, emission.RAMO);
            Assert.AreEqual(101, emission.OCUPACION_ASEG);
            foreach (string name in PolicyDescriptions)
                Assert.IsNull(serialized[name], "El procedimiento no debe recibir " + name);
            foreach (string name in BeneficiaryDescriptions)
                Assert.IsNull(serialized["BENEFICIARIOS"][0][name], "El procedimiento no debe recibir " + name);
        }

        /// <summary>
        /// El asegurado no puede sobrescribir ni eliminar los textos de riesgo que preparó el agente.
        /// </summary>
        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void Asegurado_ConservaDescripcionesComercialesDesdeLaInstantanea(bool omitirDescripciones)
        {
            Poliza stored = JsonConvert.DeserializeObject<Poliza>(CreatePostedPolicy().ToString());
            JObject incoming = CreatePostedPolicy();
            foreach (string name in new[] { "RAMODesc", "IMP_PRIMA_FACTDesc", "MCA_ASISTENCIADesc", "COD_PLAN_APDesc" })
            {
                if (omitirDescripciones) incoming.Remove(name);
                else incoming[name] = "Texto cambiado por el asegurado";
            }
            Poliza received = JsonConvert.DeserializeObject<Poliza>(incoming.ToString());

            PolicyProposalInvitationRiskValidator.PreserveAgentDescriptions(stored, received);
            JObject expected = JObject.FromObject(stored);
            JObject actual = JObject.FromObject(received);
            foreach (string name in new[] { "RAMODesc", "IMP_PRIMA_FACTDesc", "MCA_ASISTENCIADesc", "COD_PLAN_APDesc" })
                Assert.AreEqual((string)expected[name], (string)actual[name]);
            Assert.AreEqual(stored.RAMO, received.RAMO);
            Assert.AreEqual(stored.IMP_PRIMA_FACT, received.IMP_PRIMA_FACT);
            Assert.AreEqual((string)incoming["OCUPACION_ASEGDesc"], (string)actual["OCUPACION_ASEGDesc"]);
        }

        /// <summary>
        /// El guardado y la confirmación restauran las descripciones comerciales antes de serializar.
        /// </summary>
        [TestMethod]
        public void FlujoAsegurado_ConservaDescripcionesEnBorradorYConfirmacion()
        {
            string source = File.ReadAllText(Path.Combine(Root(), "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs"));
            foreach (string method in new[] { "SaveInsuredDraft", "CompleteInsured" })
            {
                int start = source.IndexOf("public static Contracts.PolicyProposal " + method, StringComparison.Ordinal);
                int serialization = source.IndexOf("JsonConvert.SerializeObject(poliza)", start, StringComparison.Ordinal);
                string beforeSerialization = source.Substring(start, serialization - start);
                StringAssert.Contains(beforeSerialization, "PolicyProposalInvitationRiskValidator.PreserveAgentDescriptions(almacenada, poliza)");
            }
        }

        /// <summary>
        /// Las celdas descriptivas no deben volver a imprimir códigos numéricos o ISO como si fueran nombres.
        /// </summary>
        [TestMethod]
        public void Repx_UtilizaDescripcionesDeNacionalidadOcupacionYUbicacion()
        {
            XElement report = XElement.Load(Path.Combine(Root(), "WebApp", "Reports", "117_seguro_vida_colectivo_solicitud_inclusion.repx"));
            string expressions = string.Join("\n", report.Descendants().Attributes("Expression").Select(a => a.Value));
            foreach (string name in new[] { "NACIONALIDAD_ASEG", "OCUPACION_ASEG", "COD_ESTADO", "COD_PROVINCIA", "COD_LOCALIDAD" })
            {
                StringAssert.Contains(expressions, "[" + name + "Desc]");
                Assert.IsFalse(expressions.Contains("[" + name + "]"), "Debe usar la descripción de " + name);
            }
        }

        private static JObject CreatePostedPolicy()
        {
            JObject policy = JObject.Parse("{\"RAMO\":117,\"NUM_CONTRATO\":99340,\"NUM_CONTRATODesc\":\"Contrato de ejemplo\",\"OCUPACION_ASEG\":101,\"MCA_SEXO_ASEG\":1,\"MCA_ASISTENCIA\":2,\"COD_DOCUM_ASEGType\":\"1\",\"NACIONALIDAD_ASEG\":\"CRI\",\"COD_ESTADO\":1,\"COD_PROVINCIA\":101,\"COD_LOCALIDAD\":10101,\"IMP_PRIMA_FACT\":0.0,\"COD_PLAN_AP\":null,\"beneficiarios\":[{\"COD_DOCUM_BENEFType\":\"1\",\"MCA_SEXO_BENEF\":\"M\",\"TIP_RELAC\":1,\"ESTADO_BENEF\":1,\"PROVINCIA_BENEF\":101,\"LOCALIDAD_BENEF\":10101,\"PCT_PARTICIPACION\":100}],\"proposalWorkflowStatus\":\"Solo presentación\"}");
            foreach (string name in PolicyDescriptions) policy[name] = "Descripción de " + name;
            foreach (string name in BeneficiaryDescriptions) policy["beneficiarios"][0][name] = "Descripción de " + name;
            return policy;
        }

        private static string Root()
        {
            return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
        }
    }
}
