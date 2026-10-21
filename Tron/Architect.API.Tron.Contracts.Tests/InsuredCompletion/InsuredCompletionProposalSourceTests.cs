using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Protege la carga de la instantánea de solicitud limitada por la sesión de invitación.
    /// </summary>
    [TestClass]
    public class InsuredCompletionProposalSourceTests
    {
        /// <summary>
        /// Exige un endpoint protegido que recupere únicamente la solicitud y compañía resueltas por la invitación.
        /// </summary>
        [TestMethod]
        public void ProposalEndpoint_UsaSesionDeInvitacionYNoAceptaIdentificadorDesdeLaUrl()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron", "Controllers", "InsuredCompletionController.cs"));

            StringAssert.Contains(source, "[Route(\"proposal\")]");
            StringAssert.Contains(source, "[InvitationSessionAuthorize]");
            StringAssert.Contains(source, "InvitationSessionAuthorizeAttribute.SessionAccessProperty");
            StringAssert.Contains(source, "access.PolicyProposalId <= 0");
            Assert.IsFalse(source.Contains("int.TryParse(access.ProposalId"));
            StringAssert.Contains(source, "PolicyProposalWorkflow.RetrieveInsuredForm(access)");
        }
    }
}
