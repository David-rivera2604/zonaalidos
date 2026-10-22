using System;
using Architect.API.Tron.Business.InsuredCompletion;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents validation and sliding renewal of the restricted insured-completion session.
    /// </summary>
    [TestClass]
    public class InvitationSessionServiceTests
    {
        /// <summary>Protects renewal of only an active, unexpired invitation session using its hash verifier.</summary>
        [TestMethod]
        public void ValidateAndRenew_UsesHashAndExtendsOnlyTheRestrictedSession()
        {
            DateTime now = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);
            string sessionSecret = "session-secret";
            RecordingStore store = new RecordingStore
            {
                SessionInvitation = PolicyProposalInvitation.Restore(
                    1001, 12, 2109, "P-001", "insured@example.test", "invite-hash",
                    InvitationSecret.Hash(sessionSecret), InvitationStatus.Active, now.AddHours(1), now.AddMinutes(5),
                    now.AddHours(-1), null, null, 1, 4,
                    "/form/EmitirPoliza?proposal=P-001", CompletionFlow.PolicyProposal)
            };
            InvitationSessionService service = new InvitationSessionService(store, () => now);

            InvitationSessionAccess result = service.ValidateAndRenew(sessionSecret);

            Assert.IsTrue(result.Found);
            Assert.AreEqual(store.SessionInvitation.Id, result.InvitationId);
            Assert.AreEqual(2109, result.PolicyProposalId);
            Assert.AreEqual(InvitationSecret.Hash(sessionSecret), store.RenewedSessionHash);
            Assert.AreEqual(now.AddMinutes(30), store.RenewedExpiresAtUtc);
            Assert.AreEqual("/form/EmitirPoliza?proposal=P-001", result.CompletionPath);
            Assert.AreEqual(CompletionFlow.PolicyProposal, result.CompletionFlow);
        }

        /// <summary>Provides a deterministic in-memory store for the session security contract.</summary>
        private sealed class RecordingStore : IInvitationStore
        {
            /// <summary>Returns a fixed numeric identifier because this test does not issue invitations.</summary>
            public int NextInvitationId() { return 1001; }

            /// <summary>Gets or sets the invitation returned by a session-hash lookup.</summary>
            public PolicyProposalInvitation SessionInvitation { get; set; }

            /// <summary>Gets the verifier supplied to the sliding-renewal operation.</summary>
            public string RenewedSessionHash { get; private set; }

            /// <summary>Gets the renewed expiration supplied to the sliding-renewal operation.</summary>
            public DateTime? RenewedExpiresAtUtc { get; private set; }

            /// <summary>Does nothing because invitation issuance is outside this session-focused test.</summary>
            public void CreateActiveAndRevokePrior(PolicyProposalInvitation invitation) { }

            /// <summary>Returns no invitation because this test does not exchange an email capability.</summary>
            public PolicyProposalInvitation RetrieveBySecretHash(string secretHash) { return null; }

            /// <summary>Returns the configured invitation for the hashed cookie capability.</summary>
            public PolicyProposalInvitation RetrieveBySessionHash(string sessionHash) { return SessionInvitation; }

            /// <summary>Returns success because this test does not exercise initial session creation.</summary>
            public bool CreateOrRenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc) { return true; }

            /// <summary>Records a successful sliding renewal.</summary>
            public bool RenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc)
            {
                RenewedSessionHash = sessionHash;
                RenewedExpiresAtUtc = sessionExpiresAtUtc;
                return true;
            }

            /// <summary>Devuelve falso porque esta prueba no ejecuta la emisión que completa una invitación.</summary>
            public bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc) { return false; }

            /// <summary>Devuelve falso porque esta prueba no abre una transacción de completado.</summary>
            public bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc, System.Data.IDbConnection connection) { return false; }
        }
    }
}
