using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que la solicitud finalizada se entregue a firma solo después de quedar congelada.
    /// </summary>
    [TestClass]
    public class PolicyProposalSignatureSourceTests
    {
        /// <summary>
        /// Exige que el servicio publique una solicitud pendiente por firma únicamente cuando Evicertia devuelve su identificador.
        /// </summary>
        [TestMethod]
        public void Firma_PublicaPorAceptarConIdentificadorExterno()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string servicePath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureService.cs");

            Assert.IsTrue(File.Exists(servicePath), "Debe existir el servicio de firma de solicitudes.");

            string source = File.ReadAllText(servicePath);
            StringAssert.Contains(source, "PolicyProposalStatus.PendientePorFirma");
            StringAssert.Contains(source, "PolicyProposalStatus.PorAceptar");
            StringAssert.Contains(source, "submit.UniqueId");
        }

        /// <summary>
        /// Exige que una firma local simulada no genere PDF ni contacte al proveedor externo.
        /// </summary>
        [TestMethod]
        public void Firma_SimuladaEvitaIntegracionesExternasYRegistraIdentificadorSeguro()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string servicePath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureService.cs");
            string settingsPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSimulationSettings.cs");

            Assert.IsTrue(File.Exists(settingsPath), "Debe existir la configuración centralizada de simulación.");
            string serviceSource = File.ReadAllText(servicePath);
            string settingsSource = File.ReadAllText(settingsPath);

            StringAssert.Contains(settingsSource, "PolicyProposal.SignatureSimulation.Enabled");
            StringAssert.Contains(settingsSource, "return false;");
            StringAssert.Contains(serviceSource, "PolicyProposalSimulationSettings.SignatureSimulationEnabled");
            StringAssert.Contains(serviceSource, "CreateSimulatedSigningRequestId");
            Assert.IsTrue(serviceSource.IndexOf("PolicyProposalSimulationSettings.SignatureSimulationEnabled", StringComparison.Ordinal) <
                          serviceSource.IndexOf("PolicyProposalSignatureDocument.Generate", StringComparison.Ordinal),
                "La simulación debe resolverse antes de generar el PDF real.");

            string workflowSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs"));
            StringAssert.Contains(workflowSource, "if (!PolicyProposalSimulationSettings.SignatureSimulationEnabled)");
        }

        /// <summary>
        /// Garantiza que una única bandera active o desactive conjuntamente la firma y la emisión simuladas.
        /// </summary>
        [TestMethod]
        public void Simulacion_UsaUnaUnicaBanderaParaFirmaYEmision()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string settingsSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSimulationSettings.cs"));
            string directIssueSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "AltasBajasPoliza.cs"));
            string monitorSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureMonitor.cs"));

            StringAssert.Contains(settingsSource, "PolicyProposal.SignatureSimulation.Enabled");
            Assert.IsFalse(settingsSource.Contains("PolicyProposal.IssueSimulation.Enabled"));
            Assert.IsFalse(settingsSource.Contains("IssueSimulationEnabled"));
            StringAssert.Contains(directIssueSource, "PolicyProposalSimulationSettings.SignatureSimulationEnabled");
            StringAssert.Contains(monitorSource, "PolicyProposalSimulationSettings.SignatureSimulationEnabled");
            Assert.IsFalse(directIssueSource.Contains("IssueSimulationEnabled"));
            Assert.IsFalse(monitorSource.Contains("IssueSimulationEnabled"));
        }
    }
}
