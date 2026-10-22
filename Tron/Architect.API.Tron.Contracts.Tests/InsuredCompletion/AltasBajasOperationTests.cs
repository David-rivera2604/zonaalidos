using Architect.API.Tron.Business.Backoffice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents how legacy alta/baja requests are routed before any database write or policy-emission call occurs.
    /// </summary>
    [TestClass]
    public class AltasBajasOperationTests
    {
        /// <summary>
        /// Protects the insured-completion path by requiring an explicit <c>SendLink</c> alta to issue an invitation,
        /// rather than issue or cancel a policy.
        /// </summary>
        [TestMethod]
        public void Resolve_AltaSendLink_ReturnsSendInvitation()
        {
            AltasBajasOperation operation = AltasBajasOperationResolver.Resolve(true, "SendLink");

            Assert.AreEqual(AltasBajasOperation.SendInvitation, operation);
        }

        /// <summary>
        /// Preserves the existing issue action when the alta request has no mode, as older clients do not send one.
        /// </summary>
        [TestMethod]
        public void Resolve_AltaWithoutMode_ReturnsIssue()
        {
            AltasBajasOperation operation = AltasBajasOperationResolver.Resolve(true, null);

            Assert.AreEqual(AltasBajasOperation.Issue, operation);
        }

        /// <summary>
        /// Protects cancellation semantics by ignoring a client mode when the endpoint explicitly requested a baja.
        /// </summary>
        [TestMethod]
        public void Resolve_BajaWithSendLink_ReturnsCancel()
        {
            AltasBajasOperation operation = AltasBajasOperationResolver.Resolve(false, "SendLink");

            Assert.AreEqual(AltasBajasOperation.Cancel, operation);
        }

        /// <summary>
        /// Exige la operación explícita que permite al agente entregar una solicitud completa al proveedor de firma.
        /// </summary>
        [TestMethod]
        public void Resolve_AltaSendSignature_DeclaraOperacionDeFirma()
        {
            bool exists = System.Enum.TryParse("SendSignature", out AltasBajasOperation operation);

            Assert.IsTrue(exists, "Debe existir la operación SendSignature.");
            Assert.AreEqual("SendSignature", operation.ToString());
        }

        /// <summary>
        /// Exige la operación final exclusiva para el asegurado que confirma sus datos antes de firma.
        /// </summary>
        [TestMethod]
        public void Resolve_AltaComplete_DeclaraOperacionDeCompletado()
        {
            bool exists = System.Enum.TryParse("Complete", out AltasBajasOperation operation);

            Assert.IsTrue(exists, "Debe existir la operación Complete.");
            Assert.AreEqual("Complete", operation.ToString());
        }
    }
}
