using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica la superficie autenticada de seguimiento exclusiva para el agente.
    /// </summary>
    [TestClass]
    public class PolicyProposalAgentApiSourceTests
    {
        /// <summary>
        /// Exige rutas de comandos tipados y evita exposición anónima.
        /// </summary>
        [TestMethod]
        public void ApiDeSeguimiento_ExponeSoloComandosTipadosDeAgente()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Tron", "Architect.API.Tron", "Controllers", "PolicyProposalController.cs"));

            StringAssert.Contains(source, "[RoutePrefix(\"api/v{version:apiVersion}/PolicyProposals\")]" );
            StringAssert.Contains(source, "[Route(\"{id:int}/Invitation/Resend\")]" );
            StringAssert.Contains(source, "[Route(\"{id:int}/Invitation/Revoke\")]" );
            StringAssert.Contains(source, "[Route(\"{id:int}/ResumeEditing\")]" );
            StringAssert.Contains(source, "PolicyProposalAgentWorkflow");
            StringAssert.Contains(source, "CommandFailure(exception)");
            StringAssert.Contains(source, "BadRequest(exception.Message)");
            Assert.IsFalse(source.Contains("[AllowAnonymous]"));
        }
    }
}
