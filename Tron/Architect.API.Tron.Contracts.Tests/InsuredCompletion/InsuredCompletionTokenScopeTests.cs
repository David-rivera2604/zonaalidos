using System;
using System.Collections.Generic;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Define el contrato de alcance que impide que un token técnico acceda a una solicitud distinta de la invitada.
    /// </summary>
    [TestClass]
    public class InsuredCompletionTokenScopeTests
    {
        /// <summary>
        /// Exige que el alcance serializado vincule conjuntamente invitación, compañía y solicitud, y que rechace cualquier alteración.
        /// </summary>
        [TestMethod]
        public void TryParse_AcceptsOnlyTheExactInvitationCompanyAndProposal()
        {
            Type scopeType = typeof(InvitationSessionAccess).Assembly.GetType(
                "Architect.API.Tron.Contracts.InsuredCompletion.InsuredCompletionTokenScope");

            Assert.IsNotNull(scopeType, "El alcance del token técnico todavía no está implementado.");

            object scope = scopeType.GetMethod("Create").Invoke(null, new object[] { 1001, 12, "P-001" });
            Dictionary<string, string> values = (Dictionary<string, string>)scopeType.GetMethod("ToSettings").Invoke(scope, null);
            object[] parseArguments = { values, null };

            bool parsed = (bool)scopeType.GetMethod("TryParse").Invoke(null, parseArguments);
            object restored = parseArguments[1];

            Assert.IsTrue(parsed);
            Assert.IsTrue((bool)scopeType.GetMethod("Authorizes").Invoke(restored, new object[] { 1001, 12, "P-001" }));
            Assert.IsFalse((bool)scopeType.GetMethod("Authorizes").Invoke(restored, new object[] { 1002, 12, "P-001" }));
            Assert.IsFalse((bool)scopeType.GetMethod("Authorizes").Invoke(restored, new object[] { 1001, 12, "P-002" }));
        }
    }
}
