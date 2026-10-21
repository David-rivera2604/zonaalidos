using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documenta el contrato de seguridad a nivel de código fuente para la ruta pública de canje de invitaciones.
    /// </summary>
    [TestClass]
    public class InsuredCompletionApiSourceTests
    {
        /// <summary>Protege el canje anónimo, el token técnico derivado y la validación posterior de su alcance.</summary>
        [TestMethod]
        public void ExchangeEndpoint_IsAnonymousAndIssuesTechnicalTokenBoundToTheInvitationSession()
        {
            string controllerPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                "..",
                "..",
                "..",
                "Tron",
                "Architect.API.Tron",
                "Controllers",
                "InsuredCompletionController.cs"));

            Assert.IsTrue(File.Exists(controllerPath), "Debe existir el controlador de canje de invitaciones.");

            string source = File.ReadAllText(controllerPath);
            StringAssert.Contains(source, "[AllowAnonymous]");
            StringAssert.Contains(source, "return NotFound()");
            StringAssert.Contains(source, "HttpOnly = true");
            StringAssert.Contains(source, "SameSite = SameSiteMode.Strict");
            StringAssert.Contains(source, "CreateTechnicalAuthentication");
            StringAssert.Contains(source, "InsuredCompletionAuthToken");
            StringAssert.Contains(source, "PolicyProposal.InsuredCompletion.Tenant.{0}.UserId");
            StringAssert.Contains(source, "settingKey.StringValue(access.CompanyId)");
            Assert.IsFalse(source.Contains("ConfigurationManager.AppSettings[settingKey]"),
                "La cuenta técnica del asegurado debe obtenerse desde SETTINGS y no desde Web.config.");
            StringAssert.Contains(source, "[InvitationSessionAuthorize]");
            StringAssert.Contains(source, "ProposalOwnership.RetrieveOwnedByAgent");
            StringAssert.Contains(source, "PolicyProposalId = proposal.Id");

            string filterPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..", "..", "..", "..", "..",
                "Tron", "Architect.API.Tron", "Filters", "InsuredCompletionTokenAuthorizeAttribute.cs"));
            Assert.IsTrue(File.Exists(filterPath), "Debe existir el filtro de alcance del token técnico.");

            string filterSource = File.ReadAllText(filterPath);
            StringAssert.Contains(filterSource, "InsuredCompletionTokenScope.TryParse");
            StringAssert.Contains(filterSource, "ValidateAndRenew");
            StringAssert.Contains(filterSource, "CreateResponse(HttpStatusCode.NotFound)");
            StringAssert.Contains(filterSource, "scope.Authorizes(access.InvitationId, access.CompanyId, access.ProposalId)");
            StringAssert.DoesNotMatch(filterSource, new Regex("EndsWith\\(\\\"/v1/", RegexOptions.CultureInvariant));
            Assert.IsFalse(filterSource.Contains("IsAllowedRoute"), "El filtro genérico no debe conocer rutas HTTP.");
        }

        /// <summary>
        /// Exige el script documentado de la cuenta técnica por tenant utilizada durante el canje de invitaciones.
        /// </summary>
        [TestMethod]
        public void CuentaTecnicaDelAsegurado_SeConfiguraEnSettingsPorTenant()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string migrationPath = Path.Combine(root, "dbscripts", "20261020c.policy-proposal-insured-completion-user.sql");
            string webConfigPath = Path.Combine(root, "WebApp", "Web.config");

            Assert.IsTrue(File.Exists(migrationPath), "Debe existir el script de configuración de la cuenta técnica del asegurado.");
            string migration = File.ReadAllText(migrationPath);
            StringAssert.Contains(migration, "PolicyProposal.InsuredCompletion.Tenant.100.UserId");
            StringAssert.Contains(migration, "Descripción funcional");
            Assert.IsFalse(File.ReadAllText(webConfigPath).Contains("Tenant.Settings.100.InsuredCompletion.UserId"),
                "Web.config no debe conservar la cuenta técnica específica del tenant.");
        }
    }
}
