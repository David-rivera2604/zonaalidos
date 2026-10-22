using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que el formulario heredado reciba Roles y Tenant sin sobrescribir el almacenamiento compartido del agente.
    /// </summary>
    [TestClass]
    public class InsuredCompletionBrowserContextSourceTests
    {
        /// <summary>Exige que la entrada pública redirija al destino devuelto por el canje y no a un formulario fijo.</summary>
        [TestMethod]
        public void Start_NoConoceUnFormularioYRedirigeAlDestinoCanjeado()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "WebApp", "Views", "InsuredCompletion", "Start.cshtml"));

            Assert.IsFalse(source.Contains("~/form/EmitirPoliza"));
            StringAssert.Contains(source, "result.CompletionPath");
            StringAssert.Contains(source, "InsuredCompletionPath");
            StringAssert.Contains(source, "Url.Content(\"~/\")");
            StringAssert.Contains(source, "completionBasePath + result.CompletionPath.substring(1)");
        }
        /// <summary>
        /// Exige que el canje conserve el contexto técnico por pestaña y que core.js lo exponga al formulario heredado.
        /// </summary>
        [TestMethod]
        public void CompletionStart_ProvidesRolesAndTenantWithoutWritingSharedLocalStorage()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string startSource = File.ReadAllText(Path.Combine(root, "WebApp", "Views", "InsuredCompletion", "Start.cshtml"));
            string coreSource = File.ReadAllText(Path.Combine(root, "WebApp", "app", "js", "core.js"));

            StringAssert.Contains(startSource, "InsuredCompletionRoles");
            StringAssert.Contains(startSource, "InsuredCompletionTenant");
            StringAssert.Contains(startSource, "sessionStorage.setItem");
            StringAssert.Contains(coreSource, "InsuredCompletionRoles");
            StringAssert.Contains(coreSource, "InsuredCompletionTenant");
            StringAssert.Contains(coreSource, "key === 'Token'");
            StringAssert.Contains(coreSource, "completionPath.substring(1), window.location.origin + app.setting.basepath");
            Assert.IsFalse(startSource.Contains("localStorage.setItem('Roles'"), "La invitación no debe reemplazar los roles compartidos del agente.");
        }
    }
}
