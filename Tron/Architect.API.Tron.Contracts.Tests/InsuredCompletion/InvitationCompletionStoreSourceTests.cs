using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que el cierre de una invitación emitida sea atómico, limitado a su alcance y destruya su sesión técnica.
    /// </summary>
    [TestClass]
    public class InvitationCompletionStoreSourceTests
    {
        /// <summary>
        /// Exige que la persistencia complete únicamente una invitación activa, vigente y asociada a la propuesta validada.
        /// </summary>
        [TestMethod]
        public void Store_CompletaInvitacionActivaDentroDelAlcanceYEliminaSesion()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposalInvitation.cs"));

            StringAssert.Contains(source, "public static bool CompleteActiveInvitation(");
            StringAssert.Contains(source, "SET Status=:Status, CompletedAtUtc=:CompletedAtUtc, SessionHash=:SessionHash, SessionExpiresAtUtc=:SessionExpiresAtUtc");
            StringAssert.Contains(source, "WHERE Id=:Id AND CompanyId=:CompanyId AND ProposalId=:ProposalId AND Status='Active' AND ExpiresAtUtc>:CompletedAtUtc");
            StringAssert.Contains(source, "InvitationStatus.Completed.ToString()");
            StringAssert.Contains(source, "return updated == 1");
        }
    }
}
