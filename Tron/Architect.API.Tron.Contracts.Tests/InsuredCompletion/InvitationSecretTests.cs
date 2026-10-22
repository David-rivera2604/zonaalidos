using Architect.API.Tron.Business.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents the capability-secret encoding and verification guarantees.
    /// </summary>
    [TestClass]
    public class InvitationSecretTests
    {
        /// <summary>Protects generation of a URL-fragment-safe 256-bit secret and its stored verifier.</summary>
        [TestMethod]
        public void Generate_CreatesUrlSafeSecretAndHashVerifiesIt()
        {
            string secret = InvitationSecret.Generate();
            string hash = InvitationSecret.Hash(secret);

            Assert.AreEqual(43, secret.Length);
            Assert.IsFalse(secret.Contains("+"));
            Assert.IsFalse(secret.Contains("/"));
            Assert.IsFalse(secret.Contains("="));
            Assert.IsTrue(InvitationSecret.Matches(secret, hash));
        }

        /// <summary>Protects rejection of a capability that differs from the stored verifier.</summary>
        [TestMethod]
        public void Matches_ReturnsFalseForDifferentSecret()
        {
            string hash = InvitationSecret.Hash("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

            Assert.IsFalse(InvitationSecret.Matches("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB", hash));
        }
    }
}
