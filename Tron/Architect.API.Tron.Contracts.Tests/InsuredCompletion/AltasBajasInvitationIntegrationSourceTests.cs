using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents the protected integration point between legacy proposal storage and the scoped invitation mechanism.
    /// </summary>
    [TestClass]
    public class AltasBajasInvitationIntegrationSourceTests
    {
        /// <summary>
        /// Protects send-link requests from reintroducing the legacy template, and requires the stored proposal to be
        /// addressed through <see cref="Architect.API.Tron.Business.InsuredCompletion.InvitationService"/> instead.
        /// </summary>
        [TestMethod]
        public void SendLink_UsesTheScopedInvitationServiceInsteadOfTheLegacyTemplate()
        {
            string sourcePath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                "..",
                "..",
                "..",
                "Tron",
                "Architect.API.Tron.Business",
                "Backoffice",
                "v2",
                "AltasBajasPoliza.cs"));

            Assert.IsTrue(File.Exists(sourcePath), "Debe existir el coordinador de altas y bajas de pólizas.");

            string source = File.ReadAllText(sourcePath);
            StringAssert.Contains(source, "AltasBajasOperationResolver.Resolve");
            StringAssert.Contains(source, "new CreateInvitationRequest");
            StringAssert.Contains(source, "CreateOrResend");
            StringAssert.Contains(source, "UserId = tokenInfo.UserId");
            StringAssert.Contains(source, "OwnerId = tokenInfo.UserId");
            StringAssert.Contains(source, "Aliados.URL.Base");
            Assert.IsFalse(source.Contains("InsuredCompletion.PortalBaseUrl"),
                "El mecanismo debe reutilizar la URL pública existente y no introducir una segunda configuración de portal.");
            Assert.IsFalse(source.Contains("Notify_ApplicationToComplete"),
                "La invitación no debe volver a usar la plantilla heredada que recibe el payload completo de la póliza.");
        }

        /// <summary>
        /// Exige que el riesgo del ramo se valide antes de persistir una propuesta o crear una invitación de completado.
        /// </summary>
        [TestMethod]
        public void SendLink_ValidaElRiesgoAntesDeGuardarLaPropuestaOCrearLaInvitacion()
        {
            string sourcePath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                "..",
                "..",
                "..",
                "Tron",
                "Architect.API.Tron.Business",
                "Backoffice",
                "v2",
                "AltasBajasPoliza.cs"));

            string source = File.ReadAllText(sourcePath);
            int validation = source.IndexOf("PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza)", StringComparison.Ordinal);
            int save = source.IndexOf("PolicyProposalWorkflow.SendInvitation(poliza, tokenInfo)", StringComparison.Ordinal);

            Assert.IsTrue(validation >= 0 && validation < save,
                "SendLink debe validar el riesgo antes de guardar la propuesta.");
        }
    }
}
