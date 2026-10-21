using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents the minimum database objects required to persist the insured-completion security boundary.
    /// </summary>
    [TestClass]
    public class InvitationMigrationTests
    {
        /// <summary>Protects creation of all records, numeric sequences, and the unique invitation-secret verifier constraint.</summary>
        [TestMethod]
        public void Migration_CreatesInvitationCompletionAndAuditTables()
        {
            string migrationPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                "..",
                "..",
                "..",
                "dbscripts",
                "20260817a.policy-proposal-invitation.sql"));

            Assert.IsTrue(File.Exists(migrationPath), "Debe existir la migración de invitaciones.");

            string migration = File.ReadAllText(migrationPath);
            StringAssert.Contains(migration, "CREATE TABLE PolicyProposalInvitation");
            StringAssert.Contains(migration, "CREATE TABLE PolicyProposalCompletion");
            StringAssert.Contains(migration, "CREATE TABLE PolicyProposalCompletionAudit");
            StringAssert.Contains(migration, "CREATE SEQUENCE SEQ_POLICYPROPOSALINVITATION");
            StringAssert.Contains(migration, "CREATE SEQUENCE SEQ_POLICYPROPOSALCOMPLETIONAUDIT");
            StringAssert.Contains(migration, "Id                    NUMBER(9)");
            StringAssert.Contains(migration, "UNIQUE (SecretHash)");
            StringAssert.Contains(migration, "COMMENT ON TABLE PolicyProposalInvitation");
            StringAssert.Contains(migration, "COMMENT ON COLUMN PolicyProposalInvitation.SecretHash");
            StringAssert.Contains(migration, "COMMENT ON TABLE PolicyProposalCompletion");
            StringAssert.Contains(migration, "COMMENT ON TABLE PolicyProposalCompletionAudit");
        }

        /// <summary>Protects the idempotent, generic template required to deliver a capability link without PII in its subject.</summary>
        [TestMethod]
        public void TemplateMigration_CreatesGenericInsuredCompletionInvitationTemplate()
        {
            string migrationPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", "..", "..", "..", "dbscripts",
                "20260817b.insured-completion-template.sql"));

            Assert.IsTrue(File.Exists(migrationPath), "Debe existir la migración de la plantilla de correo.");

            string migration = File.ReadAllText(migrationPath);
            StringAssert.Contains(migration, "MERGE INTO Template");
            StringAssert.Contains(migration, "InsuredCompletionInvitation");
            StringAssert.Contains(migration, "{Data.InvitationUrl}");
            StringAssert.Contains(migration, "{CurrentUser.FirstName}");
            StringAssert.Contains(migration, "{CurrentUser.LastName}");
            Assert.IsFalse(migration.Contains("{Data.ProposalId}"), "La plantilla no debe incluir el identificador de propuesta.");
        }
    }
}
