using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents the source-level privacy guard required for mail carrying insured-completion capabilities.
    /// </summary>
    [TestClass]
    public class SensitiveMailSourceTests
    {
        /// <summary>Protects the dedicated send path from logging recipient addresses or serialized sensitive context.</summary>
        [TestMethod]
        public void SensitiveTemplateSender_SuppressesRecipientAndContextLogging()
        {
            string mailPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                "..",
                "..",
                "..",
                "Core",
                "Architect.API.Core.Business",
                "General",
                "Mail.cs"));

            Assert.IsTrue(File.Exists(mailPath), "Debe existir el transporte de correo sensible.");

            string source = File.ReadAllText(mailPath);
            StringAssert.Contains(source, "SendSensitiveByTemplate");
            StringAssert.Contains(source, "if (!suppressSensitiveLogging)");
            StringAssert.Contains(source, "testEmail.IsNotEmpty() && !suppressSensitiveLogging");
        }
    }
}
