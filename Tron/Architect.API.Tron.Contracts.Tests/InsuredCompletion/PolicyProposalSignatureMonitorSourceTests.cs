using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Protege el monitoreo que convierte las respuestas de firma en emisión automática de solicitudes.
    /// </summary>
    [TestClass]
    public class PolicyProposalSignatureMonitorSourceTests
    {
        /// <summary>
        /// Exige transiciones condicionadas para firma aceptada, expirada, rechazada y emisión posterior.
        /// </summary>
        [TestMethod]
        public void Monitor_ProcesaFirmaYEmisionConEstadosCondicionados()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string monitorPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureMonitor.cs");

            Assert.IsTrue(File.Exists(monitorPath), "Debe existir el monitor de firma y emisión de solicitudes.");

            string source = File.ReadAllText(monitorPath);
            StringAssert.Contains(source, "PolicyProposalStatus.PorAceptar");
            StringAssert.Contains(source, "PolicyProposalStatus.ParaEmitir");
            StringAssert.Contains(source, "PolicyProposalStatus.EnRevisionPorMapfre");
            StringAssert.Contains(source, "PolicyProposalStatus.Alta");
            StringAssert.Contains(source, "PolicyProposalStatus.DeclinadaPorExpiracion");
            StringAssert.Contains(source, "PolicyProposalStatus.Rechazada");
            StringAssert.Contains(source, "AltasBajasPoliza.EmitirPropuesta");
        }

        /// <summary>
        /// Exige que el programador existente de Evicertia también ejecute el monitor del nuevo ciclo.
        /// </summary>
        [TestMethod]
        public void Global_ProgramaMonitorConElIntervaloExistenteDeEvicertia()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string globalSource = File.ReadAllText(Path.Combine(root, "WebApp", "Global.asax.cs"));

            StringAssert.Contains(globalSource, "PolicyProposalSignatureMonitor.Run");
            StringAssert.Contains(globalSource, "Evicertia.Interval.Review");
        }

        /// <summary>
        /// Garantiza que una ejecución local con simulación habilitada programe solo el monitor
        /// de propuestas, aun cuando el resto de trabajos externos permanezca deshabilitado en Development.
        /// </summary>
        [TestMethod]
        public void Global_ProgramaMonitorLocalCuandoLaSimulacionDeFirmaEstaHabilitada()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string globalSource = File.ReadAllText(Path.Combine(root, "WebApp", "Global.asax.cs"));

            StringAssert.Contains(globalSource, "PolicyProposal.SignatureSimulation.Enabled");
            StringAssert.Contains(globalSource, "SchedulePolicyProposalSignatureMonitor");
            StringAssert.Contains(globalSource, "enableLocalSimulation");
        }

        /// <summary>
        /// Exige que el monitor confirme y emita solicitudes simuladas sin consultar ni emitir mediante integraciones reales.
        /// </summary>
        [TestMethod]
        public void Monitor_ProcesaSolicitudSimuladaSinInvocarServiciosExternos()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string monitorPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureMonitor.cs");
            string source = File.ReadAllText(monitorPath);

            StringAssert.Contains(source, "PolicyProposalSimulationSettings.IsSimulatedSignature");
            StringAssert.Contains(source, "Firma simulada completada");
            StringAssert.Contains(source, "PolicyProposalSimulationSettings.SignatureSimulationEnabled");
            StringAssert.Contains(source, "CreateSimulatedPolicyId");
            Assert.IsFalse(source.Contains("IssueSimulationEnabled"));
            Assert.IsTrue(source.IndexOf("PolicyProposalSimulationSettings.IsSimulatedSignature", StringComparison.Ordinal) <
                          source.IndexOf("Architect.DocuSign.Integrations.DocuSign", StringComparison.Ordinal),
                "El monitor debe detectar primero la solicitud simulada para evitar consultar el proveedor real.");
        }

        /// <summary>
        /// Garantiza que el monitor use una configuración exclusiva de compañías para el ciclo de solicitudes.
        /// </summary>
        [TestMethod]
        public void Monitor_UsaElSettingDeRevisionDeSolicitudes()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string monitorPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureMonitor.cs");
            string migrationPath = Path.Combine(root, "dbscripts", "20261020b.policy-proposal-request-tenant-review.sql");
            string source = File.ReadAllText(monitorPath);

            StringAssert.Contains(source, "PolicyProposal.Request.Tenant.Review");
            Assert.IsFalse(source.Contains("Security.Tenant.Tron.Agent.Information"),
                "El monitor no debe depender de una configuración destinada a la información de agentes.");
            Assert.IsTrue(File.Exists(migrationPath), "Debe existir el script que registra la configuración del monitor.");
            StringAssert.Contains(File.ReadAllText(migrationPath), "PolicyProposal.Request.Tenant.Review");
            StringAssert.Contains(File.ReadAllText(migrationPath), "'100' AS VALUE");
            StringAssert.Contains(File.ReadAllText(migrationPath), "Descripción funcional");
        }

        /// <summary>
        /// Garantiza que las solicitudes nuevas de Altas/Bajas se separen de las solicitudes
        /// históricas que el monitor existente continúa revisando sin código de ramo.
        /// </summary>
        [TestMethod]
        public void Monitores_DeFirma_SeparanLosRamosDeAltasBajasDeLasSolicitudesHistoricas()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string monitorSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalSignatureMonitor.cs"));
            string legacyMonitorSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Emision", "MapfreMas.cs"));
            string dataAccessSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposalEx.cs"));
            string persistenceSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposal.cs"));

            StringAssert.Contains(monitorSource, "PolicyProposalWorkflow.AltasBajasBranchCodes");
            StringAssert.Contains(legacyMonitorSource, "PolicyProposalWorkflow.AltasBajasBranchCodes");
            StringAssert.Contains(legacyMonitorSource, "excludeBranchCodes: true");
            StringAssert.Contains(dataAccessSource, "IEnumerable<int> branchCodes = null");
            StringAssert.Contains(dataAccessSource, "BranchCode IN");
            StringAssert.Contains(dataAccessSource, "BranchCode IS NULL OR BranchCode NOT IN");
            StringAssert.Contains(persistenceSource, "BranchCode=NVL(:BranchCode, BranchCode)");
        }
    }
}
