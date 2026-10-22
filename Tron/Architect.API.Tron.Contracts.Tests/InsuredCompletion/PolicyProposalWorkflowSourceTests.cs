using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica los límites de actor del flujo de solicitudes persistidas.
    /// </summary>
    [TestClass]
    public class PolicyProposalWorkflowSourceTests
    {
        /// <summary>
        /// Exige que el flujo del asegurado limite su acceso a la compañía y propuesta entregadas por la invitación validada.
        /// </summary>
        [TestMethod]
        public void FlujoAsegurado_ExigeEstadoPendientePorComplementosYAlcanceDeInvitacion()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string workflowPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs");

            Assert.IsTrue(File.Exists(workflowPath), "Debe existir el flujo de solicitudes persistidas.");

            string source = File.ReadAllText(workflowPath);
            StringAssert.Contains(source, "PolicyProposalStatus.PendientePorComplementos");
            StringAssert.Contains(source, "invitationAccess.CompanyId");
            StringAssert.Contains(source, "invitationAccess.ProposalId");
            StringAssert.Contains(source, "PolicyProposalIdentifier.Create(poliza.RAMO, id)");
            StringAssert.Contains(source, "DataAccess.PolicyProposal.Retrieve(invitationAccess.PolicyProposalId, invitationAccess.CompanyId)");
            StringAssert.Contains(source, "proposal.ProposalId != invitationAccess.ProposalId");
        }

        /// <summary>
        /// Exige validar la inmutabilidad de datos del agente antes de guardar borrador o confirmar por invitación.
        /// </summary>
        [TestMethod]
        public void FlujoAsegurado_ProtegeDatosDelAgenteAntesDeGuardarOConfirmar()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string workflowPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs");
            string source = File.ReadAllText(workflowPath);

            Assert.AreEqual(2, Regex.Matches(source,
                "PolicyProposalInvitationRiskValidator.ValidateInsuredMayNotChangeAgentData").Count,
                "El control debe ejecutarse al guardar borrador y al confirmar la solicitud del asegurado.");
        }

        /// <summary>
        /// Exige conservar de forma opcional el código de ramo de las solicitudes originadas por Altas/Bajas.
        /// </summary>
        [TestMethod]
        public void SolicitudDePoliza_PersisteCodigoDeRamoOpcionalSoloDesdeAltasBajas()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string contractPath = Path.Combine(root, "Tron", "Architect.API.Tron.Contracts", "PolicyProposal.cs");
            string accessPath = Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposal.cs");
            string workflowPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs");
            string migrationPath = Path.Combine(root, "dbscripts", "20261020a.policy-proposal-branch-code.sql");

            Assert.IsTrue(File.Exists(migrationPath), "Debe existir la migración que agrega el código de ramo.");

            string contract = File.ReadAllText(contractPath);
            string access = File.ReadAllText(accessPath);
            string workflow = File.ReadAllText(workflowPath);
            string migration = File.ReadAllText(migrationPath);

            StringAssert.Contains(contract, "int? BranchCode");
            StringAssert.Contains(access, "BranchCode");
            StringAssert.Contains(workflow, "BranchCode = poliza.RAMO > 0 ? (int?)poliza.RAMO : null");
            StringAssert.Contains(migration, "BranchCode NUMBER(5,0) NULL");
            StringAssert.Contains(migration, "COMMENT ON COLUMN PolicyProposal.BranchCode IS");
        }

        /// <summary>
        /// Exige que Altas/Bajas mantenga sincronizada la proyección relacional del asegurado,
        /// sin exigir que otros productos interpreten su JSON de propuesta.
        /// </summary>
        [TestMethod]
        public void FlujoAltasBajas_SincronizaColumnasDelAseguradoSinInterpretarElJsonDeOtrosProductos()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string workflowPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs");
            string accessPath = Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposalEx.cs");
            string workflow = File.ReadAllText(workflowPath);
            string access = File.ReadAllText(accessPath);

            StringAssert.Contains(workflow, "TrySaveAltasBajasSnapshotAndTransition(");
            StringAssert.Contains(workflow, "poliza.COD_DOCUM_ASEG");
            StringAssert.Contains(workflow, "poliza.EMAIL_ASEG");
            StringAssert.Contains(access, "public static bool TrySaveAltasBajasSnapshotAndTransition(");
            StringAssert.Contains(access, "InsuredId=:InsuredId");
            StringAssert.Contains(access, "InsuredName=:InsuredName");
            StringAssert.Contains(access, "PrimaryEmailAddress=:PrimaryEmailAddress");
        }

        /// <summary>
        /// Verifica que la fecha de nacimiento sea opcional para el asegurado, sin relajar el dato obligatorio de los beneficiarios.
        /// </summary>
        [TestMethod]
        public void ValidacionDeFirma_NoExigeFechaNacimientoDelAsegurado()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string workflowPath = Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs");
            string source = File.ReadAllText(workflowPath);
            Match validation = Regex.Match(source,
                @"private static void ValidateForSignature\(RequestPoliza poliza\)\s*\{(?<body>[\s\S]*?)\n        \}",
                RegexOptions.CultureInvariant);

            Assert.IsTrue(validation.Success, "Debe existir la validación previa al envío a firma o a emisión.");
            Assert.IsFalse(validation.Groups["body"].Value.Contains("poliza.NAC_ASEG == DateTime.MinValue"),
                "La fecha de nacimiento del asegurado no debe ser requerida para enviar a firma o emitir.");
            StringAssert.Contains(validation.Groups["body"].Value, "beneficiario.FEC_NAC_BENEF == DateTime.MinValue");
        }
    }
}
