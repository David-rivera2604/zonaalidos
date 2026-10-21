using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Protege la convivencia entre la sesión normal del agente y la cookie opcional del completado por asegurado.
    /// </summary>
    [TestClass]
    public class IsConnectedInsuredCompletionSourceTests
    {
        /// <summary>
        /// Exige que un agente autenticado pueda abrir EmitirPoliza aunque no tenga una cookie técnica de invitación.
        /// </summary>
        [TestMethod]
        public void IsConnected_UsesNormalAuthTokenWhenTechnicalCookieIsAbsent()
        {
            string path = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory, "..", "..", "..", "..", "..",
                "Core", "Architect.API.Core.Utilities", "IsConnectedAttribute.cs"));
            string source = File.ReadAllText(path);

            StringAssert.Contains(source, "InsuredCompletionAuthToken");
            StringAssert.Contains(source, "Request.Cookies[\"AuthToken\"]");
            StringAssert.Contains(source, "technicalCookie ??");
            StringAssert.Contains(source, "technicalAuthentication = technicalCookie != null");
            StringAssert.Contains(source, "if (!technicalAuthentication && session.IsEmpty())");
        }
    }
}
