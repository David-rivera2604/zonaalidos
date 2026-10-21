using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que las invitaciones se relacionen con la solicitud mediante una clave foránea técnica
    /// y que el borrado de una solicitud elimine sus datos dependientes.
    /// </summary>
    [TestClass]
    public class PolicyProposalInvitationIntegrityMigrationTests
    {
        /// <summary>
        /// Exige que las instalaciones nuevas y las ya inicializadas apliquen la misma integridad referencial.
        /// </summary>
        [TestMethod]
        public void Migration_CreaRelacionTecnicaYCascadasDeInvitacion()
        {
            string scriptsDirectory = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", "..", "..", "..", "dbscripts"));
            string initial = File.ReadAllText(Path.Combine(
                scriptsDirectory,
                "20260817a.policy-proposal-invitation.sql"));
            string upgrade = File.ReadAllText(Path.Combine(
                scriptsDirectory,
                "20261006a.policy-proposal-invitation-integrity.sql"));

            StringAssert.Contains(initial, "PolicyProposalId      NUMBER(9)          NOT NULL");
            Assert.IsFalse(initial.Contains("AgentCode"));
            StringAssert.Contains(initial, "FOREIGN KEY (PolicyProposalId) REFERENCES PolicyProposal (Id) ON DELETE CASCADE");
            StringAssert.Contains(initial, "FOREIGN KEY (InvitationId) REFERENCES PolicyProposalInvitation (Id) ON DELETE CASCADE");
            StringAssert.Contains(upgrade, "DELETE FROM PolicyProposalCompletionAudit");
            StringAssert.Contains(upgrade, "DELETE FROM PolicyProposalCompletion");
            StringAssert.Contains(upgrade, "DELETE FROM PolicyProposalInvitation");
            StringAssert.Contains(upgrade, "ALTER TABLE PolicyProposalInvitation DROP COLUMN AgentCode");
            StringAssert.Contains(upgrade, "COMMENT ON COLUMN PolicyProposalInvitation.PolicyProposalId");
        }
    }
}
