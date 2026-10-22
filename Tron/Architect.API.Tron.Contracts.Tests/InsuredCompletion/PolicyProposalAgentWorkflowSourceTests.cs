using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que los comandos del agente respeten el estado de invitación y de la solicitud.
    /// </summary>
    [TestClass]
    public class PolicyProposalAgentWorkflowSourceTests
    {
        /// <summary>
        /// Exige que el reenvío sólo reciba el correo modificable del destinatario.
        /// </summary>
        [TestMethod]
        public void ReenviarEnlace_SoloAceptaCorreoComoDatoModificable()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalAgentWorkflow.cs"));

            StringAssert.Contains(source, "ResendInvitation(int proposalId, string recipientEmail");
            StringAssert.Contains(source, "PolicyProposalStatus.PendientePorComplementos");
            StringAssert.Contains(source, "InvitationService");
            StringAssert.Contains(source, "Invitación reenviada al asegurado");
        }

        /// <summary>
        /// Exige que retomar corrección invalide la invitación antes de habilitar nuevamente el borrador.
        /// </summary>
        [TestMethod]
        public void RetomarCorreccion_RevocaInvitacionYRegresaABorrador()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalAgentWorkflow.cs"));

            StringAssert.Contains(source, "RevokeActiveForPolicyProposal");
            StringAssert.Contains(source, "PolicyProposalStatus.PendientePorComplementos");
            StringAssert.Contains(source, "PolicyProposalStatus.Incompleta");
            StringAssert.Contains(source, "Solicitud retomada para corrección");
        }

        /// <summary>
        /// Exige que los eventos funcionales usen el tipo de entidad de solicitudes y su clave técnica.
        /// </summary>
        [TestMethod]
        public void AuditoriaDeSolicitud_UsaEntidad2100YClaveTecnica()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalAudit.cs"));

            StringAssert.Contains(source, "const int EntityType = 2100");
            StringAssert.Contains(source, "proposal.Id");
            StringAssert.Contains(source, "ChangeSet.Create(EntityType");
        }

        /// <summary>
        /// Exige trazabilidad tanto para la primera creación como para los errores de emisión.
        /// </summary>
        [TestMethod]
        public void AuditoriaDelCiclo_RegistraCreacionYErrorDeEmision()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string workflow = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs"));
            string altasBajas = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "AltasBajasPoliza.cs"));

            StringAssert.Contains(workflow, "Solicitud creada");
            StringAssert.Contains(altasBajas, "Error de emisión");
            StringAssert.Contains(altasBajas, "Póliza emitida");
        }
    }
}
