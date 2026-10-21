using System;
using Architect.API.Tron.Business.InsuredCompletion;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents the issuance behavior at the service boundary before real storage and email adapters are connected.
    /// </summary>
    [TestClass]
    public class InvitationServiceTests
    {
        /// <summary>Protects hash-only persistence and placement of the plain-text secret solely in the URL fragment.</summary>
        [TestMethod]
        public void CreateOrResend_PersistsOnlyHashAndEmailsFragmentLink()
        {
            DateTime now = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);
            RecordingStore store = new RecordingStore();
            RecordingMailSender mailSender = new RecordingMailSender();
            InvitationService service = new InvitationService(
                store,
                mailSender,
                () => now,
                () => "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                "https://portal.example.test");

            InvitationView result = service.CreateOrResend(new CreateInvitationRequest
            {
                CompanyId = 12,
                PolicyProposalId = 2109,
                ProposalId = "P-001",
                RecipientEmail = "insured@example.test",
                UserId = 701,
                OwnerId = 701,
                CompletionPath = "/form/EmitirPoliza?proposal=P-001",
                CompletionFlow = CompletionFlow.PolicyProposal
            });

            Assert.AreEqual(InvitationSecret.Hash("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"), store.LastInvitation.SecretHash);
            Assert.AreNotEqual("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", store.LastInvitation.SecretHash);
            Assert.AreEqual("https://portal.example.test/Completar#invite=AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", mailSender.LastUrl);
            Assert.AreEqual(12, mailSender.LastCompanyId);
            Assert.AreEqual(701, mailSender.LastUserId);
            Assert.AreEqual(701, mailSender.LastOwnerId);
            Assert.AreEqual(2109, store.LastInvitation.PolicyProposalId);
            Assert.AreEqual(store.LastInvitation.Id, result.InvitationId);
            Assert.AreEqual(now.AddHours(48), result.ExpiresAtUtc);
            Assert.AreEqual("/form/EmitirPoliza?proposal=P-001", store.LastInvitation.CompletionPath);
            Assert.AreEqual(CompletionFlow.PolicyProposal, store.LastInvitation.CompletionFlow);
        }

        /// <summary>Protects against creating state or sending email when the recipient is missing.</summary>
        [TestMethod]
        public void CreateOrResend_RejectsMissingRecipientBeforePersisting()
        {
            RecordingStore store = new RecordingStore();
            RecordingMailSender mailSender = new RecordingMailSender();
            InvitationService service = new InvitationService(
                store,
                mailSender,
                () => DateTime.UtcNow,
                () => "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                "https://portal.example.test");

            Assert.ThrowsException<ArgumentException>(() => service.CreateOrResend(new CreateInvitationRequest
            {
                CompanyId = 12,
                PolicyProposalId = 2109,
                ProposalId = "P-001",
                RecipientEmail = ""
            }));

            Assert.IsNull(store.LastInvitation);
            Assert.IsNull(mailSender.LastUrl);
        }

        /// <summary>Impide crear una capacidad que no tenga un destino relativo seguro asociado por el flujo servidor.</summary>
        [TestMethod]
        public void CreateOrResend_SinCompletionPath_NoPersisteNiEnviaCorreo()
        {
            RecordingStore store = new RecordingStore();
            RecordingMailSender mailSender = new RecordingMailSender();
            InvitationService service = new InvitationService(
                store,
                mailSender,
                () => DateTime.UtcNow,
                () => "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                "https://portal.example.test");

            Assert.ThrowsException<ArgumentException>(() => service.CreateOrResend(new CreateInvitationRequest
            {
                CompanyId = 12,
                PolicyProposalId = 2109,
                ProposalId = "P-001",
                RecipientEmail = "insured@example.test",
                CompletionFlow = CompletionFlow.PolicyProposal
            }));

            Assert.IsNull(store.LastInvitation);
            Assert.IsNull(mailSender.LastUrl);
        }

        /// <summary>Protects exchange of an active invitation into a session whose plain-text secret is never persisted.</summary>
        [TestMethod]
        public void Exchange_CreatesShortLivedHashOnlySessionForActiveInvitation()
        {
            DateTime now = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);
            RecordingStore store = new RecordingStore();
            store.InvitationToReturn = PolicyProposalInvitation.CreateActive(
                1001,
                12,
                2109,
                "P-001",
                "insured@example.test",
                InvitationSecret.Hash("invitation-secret"),
                now.AddMinutes(-1),
                now.AddHours(47));
            InvitationService service = new InvitationService(
                store,
                new RecordingMailSender(),
                () => now,
                () => "session-secret",
                "https://portal.example.test");

            InvitationSession result = service.Exchange("invitation-secret");

            Assert.IsTrue(result.Found);
            Assert.AreEqual("session-secret", result.SessionSecret);
            Assert.AreEqual(InvitationSecret.Hash("session-secret"), store.LastSessionHash);
            Assert.AreNotEqual("session-secret", store.LastSessionHash);
            Assert.AreEqual(now.AddMinutes(30), store.LastSessionExpiresAtUtc);
        }

        /// <summary>Records persistence requests so the service contract can be asserted without a database.</summary>
        private sealed class RecordingStore : IInvitationStore
        {
            /// <summary>Returns the deterministic numeric identifier used by this test store.</summary>
            public int NextInvitationId() { return 1001; }

            /// <summary>Gets or sets the invitation returned by the secret-hash lookup.</summary>
            public PolicyProposalInvitation InvitationToReturn { get; set; }

            /// <summary>Gets the last invitation persisted as an active replacement.</summary>
            public PolicyProposalInvitation LastInvitation { get; private set; }

            /// <summary>Gets the last session verifier persisted by the exchange workflow.</summary>
            public string LastSessionHash { get; private set; }

            /// <summary>Gets the last session-expiration instant persisted by the exchange workflow.</summary>
            public DateTime? LastSessionExpiresAtUtc { get; private set; }

            public void CreateActiveAndRevokePrior(PolicyProposalInvitation invitation)
            {
                LastInvitation = invitation;
            }

            /// <summary>Returns the configured invitation for a secret verifier lookup.</summary>
            public PolicyProposalInvitation RetrieveBySecretHash(string secretHash)
            {
                return InvitationToReturn;
            }

            /// <summary>Returns no invitation because cookie-session validation is outside this issuance-focused test.</summary>
            public PolicyProposalInvitation RetrieveBySessionHash(string sessionHash)
            {
                return null;
            }

            /// <summary>Records session persistence and simulates a successful optimistic-concurrency update.</summary>
            public bool CreateOrRenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc)
            {
                LastSessionHash = sessionHash;
                LastSessionExpiresAtUtc = sessionExpiresAtUtc;
                return true;
            }

            /// <summary>Returns success because this issuance-focused test does not exercise sliding session renewal.</summary>
            public bool RenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc)
            {
                return true;
            }

            /// <summary>Devuelve falso porque esta prueba no ejecuta la emisión que completa una invitación.</summary>
            public bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc) { return false; }

            /// <summary>Devuelve falso porque esta prueba no abre una transacción de completado.</summary>
            public bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc, System.Data.IDbConnection connection) { return false; }
        }

        /// <summary>Records delivery requests so the service contract can be asserted without an SMTP transport.</summary>
        private sealed class RecordingMailSender : IInvitationMailSender
        {
            public string LastUrl { get; private set; }

            /// <summary>Obtiene la empresa usada para crear el contexto de correo.</summary>
            public int LastCompanyId { get; private set; }

            /// <summary>Obtiene el usuario actual usado para crear el contexto de correo.</summary>
            public int LastUserId { get; private set; }

            /// <summary>Obtiene el propietario usado para crear el contexto de correo.</summary>
            public int LastOwnerId { get; private set; }

            /// <summary>Registra una solicitud de entrega sin enviar correo.</summary>
            public void Send(string recipientEmail, string invitationUrl, int companyId, int userId, int ownerId)
            {
                LastUrl = invitationUrl;
                LastCompanyId = companyId;
                LastUserId = userId;
                LastOwnerId = ownerId;
            }
        }
    }
}
