using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica la base de datos y el acceso requerido por el ciclo de solicitud, firma y emisión.
    /// </summary>
    [TestClass]
    public class PolicyProposalWorkflowMigrationTests
    {
        /// <summary>
        /// Exige la documentación en español de los campos del ciclo sin introducir una secuencia en este despliegue.
        /// </summary>
        [TestMethod]
        public void Migracion_DocumentaLosCamposDelFlujoSinCrearSecuencia()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string migrationPath = Path.Combine(root, "dbscripts", "20260824a.policy-proposal-workflow.sql");

            Assert.IsTrue(File.Exists(migrationPath), "Debe existir la migración del ciclo de solicitud.");

            string migration = File.ReadAllText(migrationPath);
            StringAssert.Contains(migration, "MAX(Id) + 1");
            Assert.IsFalse(migration.Contains("CREATE SEQUENCE SEQ_POLICYPROPOSAL"));
            StringAssert.Contains(migration, "NUMBER(9)");
            StringAssert.Contains(migration, "COMMENT ON TABLE PolicyProposal");
            StringAssert.Contains(migration, "COMMENT ON COLUMN PolicyProposal.Status");
            StringAssert.Contains(migration, "COMMENT ON COLUMN PolicyProposal.SigningRequestId");
        }

        /// <summary>
        /// Exige el patrón temporal de identificador histórico y protege la transición con el estado anterior.
        /// </summary>
        [TestMethod]
        public void Acceso_UsaIdentificadorHistoricoYTransicionConEstadoEsperado()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string proposalSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposal.cs"));
            string proposalExSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.DataAccess", "PolicyProposalEx.cs"));

            String workflowSource = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron.Business", "Backoffice", "v2", "PolicyProposalWorkflow.cs"));
            StringAssert.Contains(workflowSource, "RetrieveLastKey() + 1");
            StringAssert.Contains(proposalExSource, "WHERE Id=:Id AND CompanyId=:CompanyId AND Status=:ExpectedStatus");
            Assert.IsFalse(proposalSource.Contains("SEQ_POLICYPROPOSAL.NEXTVAL"));
        }
    }
}
