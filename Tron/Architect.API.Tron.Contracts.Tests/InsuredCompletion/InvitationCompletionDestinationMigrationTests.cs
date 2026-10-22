using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que la migración documente el destino y el flujo necesarios para reanudar una invitación válida.
    /// </summary>
    [TestClass]
    public class InvitationCompletionDestinationMigrationTests
    {
        /// <summary>Exige columnas Oracle documentadas y una restricción que impida invitaciones activas sin destino.</summary>
        [TestMethod]
        public void Migration_AgregaDestinoYFlujoConComentariosEnEspanol()
        {
            string migrationPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", "..", "..", "..", "dbscripts",
                "20260817c.policy-proposal-invitation-completion-destination.sql"));
            string sql = File.ReadAllText(migrationPath);

            StringAssert.Contains(sql, "CompletionPath VARCHAR2(512 CHAR)");
            StringAssert.Contains(sql, "CompletionFlow VARCHAR2(64 CHAR)");
            StringAssert.Contains(sql, "COMMENT ON COLUMN PolicyProposalInvitation.CompletionPath IS");
            StringAssert.Contains(sql, "COMMENT ON COLUMN PolicyProposalInvitation.CompletionFlow IS");
            StringAssert.Contains(sql, "CK_PolicyProposalInvitation_ActiveDestination");
        }
    }
}
