using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>Protege que el flujo emisor, no el navegador, construya la ruta de la solicitud almacenada.</summary>
    [TestClass]
    public class AltasBajasCompletionDestinationSourceTests
    {
        /// <summary>Exige que el enlace de altas conserve propuesta y flujo aprobados.</summary>
        [TestMethod]
        public void SendLink_ConstruyeDestinoRelativoConSolicitudAlmacenada()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "AltasBajasPoliza.cs"));

            StringAssert.Contains(source, "PolicyProposalId = proposal.Id");
            StringAssert.Contains(source, "CompletionPath = \"/form/EmitirPoliza?proposal=\" + proposal.ProposalId");
            StringAssert.Contains(source, "CompletionFlow = CompletionFlow.PolicyProposal");
        }

        /// <summary>
        /// Exige que la fachada heredada delegue las operaciones de alta al flujo persistido,
        /// sin volver a calcular identificadores desde la última fila de la tabla.
        /// </summary>
        [TestMethod]
        public void Altas_UsaFlujoDeSolicitudYNoCalculaElSiguienteIdentificador()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "AltasBajasPoliza.cs"));

            StringAssert.Contains(source, "PolicyProposalWorkflow.SendInvitation");
            StringAssert.Contains(source, "PolicyProposalWorkflow.SaveAgentDraft");
            StringAssert.Contains(source, "PolicyProposalWorkflow.SaveInsuredDraft");
            StringAssert.Contains(source, "PolicyProposalWorkflow.BeginAgentSignature");
            StringAssert.Contains(source, "PolicyProposalWorkflow.CompleteInsured");
            Assert.IsFalse(source.Contains("RetrieveLastKey() + 1"));
        }

        /// <summary>
        /// Exige que la emisión ya no cierre invitaciones, porque el asegurado las finaliza antes de enviar a firma.
        /// </summary>
        [TestMethod]
        public void Issue_NoCompletaLaInvitacionDelAsegurado()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string businessSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "AltasBajasPoliza.cs"));
            string controllerSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron", "Controllers", "PolizaController.cs"));

            StringAssert.Contains(controllerSource, "InvitationSessionAuthorizeAttribute.SessionAccessProperty");
            Assert.IsFalse(businessSource.Contains("CompleteActiveInvitation(invitationAccess"));
        }
    }
}
