using System;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents the invitation lifecycle rules that must hold before persistence is invoked.
    /// </summary>
    [TestClass]
    public class InvitationStateMachineTests
    {
        /// <summary>Protects the replacement rule: only the new invitation remains active.</summary>
        [TestMethod]
        public void CreateActiveAndRevokePrior_RevokesExistingActiveInvitation()
        {
            DateTime createdAtUtc = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);
            PolicyProposalInvitation previous = PolicyProposalInvitation.CreateActive(
                1001,
                12,
                2109,
                "P-001",
                "secret-hash-1",
                createdAtUtc,
                createdAtUtc.AddHours(48));

            PolicyProposalInvitation next = InvitationStateMachine.CreateActiveAndRevokePrior(
                previous,
                1002,
                12,
                2109,
                "P-001",
                "secret-hash-2",
                createdAtUtc.AddMinutes(1),
                createdAtUtc.AddHours(48).AddMinutes(1));

            Assert.AreEqual(InvitationStatus.Revoked, previous.Status);
            Assert.AreEqual(createdAtUtc.AddMinutes(1), previous.RevokedAtUtc);
            Assert.AreEqual(InvitationStatus.Active, next.Status);
            Assert.IsNull(next.RevokedAtUtc);
        }

        /// <summary>Protects the invariant that an invitation expires strictly after it is created.</summary>
        [TestMethod]
        public void CreateActive_RejectsExpirationAtOrBeforeCreation()
        {
            DateTime createdAtUtc = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);

            Assert.ThrowsException<ArgumentException>(() => PolicyProposalInvitation.CreateActive(
                1001,
                12,
                2109,
                "P-001",
                "secret-hash",
                createdAtUtc,
                createdAtUtc));
        }

        /// <summary>Protects lossless rehydration of persisted invitation state.</summary>
        [TestMethod]
        public void Restore_PreservesPersistedInvitationState()
        {
            DateTime createdAtUtc = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);
            DateTime expiresAtUtc = createdAtUtc.AddHours(48);
            int id = 1001;

            PolicyProposalInvitation invitation = PolicyProposalInvitation.Restore(
                id,
                12,
                2109,
                "P-001",
                "insured@example.test",
                "secret-hash",
                "session-hash",
                InvitationStatus.Completed,
                expiresAtUtc,
                createdAtUtc.AddMinutes(30),
                createdAtUtc,
                createdAtUtc.AddMinutes(10),
                null,
                2,
                7);

            Assert.AreEqual(id, invitation.Id);
            Assert.AreEqual("insured@example.test", invitation.RecipientEmail);
            Assert.AreEqual("session-hash", invitation.SessionHash);
            Assert.AreEqual(InvitationStatus.Completed, invitation.Status);
            Assert.AreEqual(2, invitation.SendCount);
            Assert.AreEqual(7, invitation.RowVersion);
        }

        /// <summary>Protects retention of the delivery recipient without retaining a plain-text secret.</summary>
        [TestMethod]
        public void CreateActive_PreservesRecipientEmailForDelivery()
        {
            DateTime createdAtUtc = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);

            PolicyProposalInvitation invitation = PolicyProposalInvitation.CreateActive(
                1001,
                12,
                2109,
                "P-001",
                "insured@example.test",
                "secret-hash",
                createdAtUtc,
                createdAtUtc.AddHours(48));

            Assert.AreEqual("insured@example.test", invitation.RecipientEmail);
            Assert.AreEqual(1, invitation.SendCount);
            Assert.AreEqual(1, invitation.RowVersion);
        }

        /// <summary>Protects the valid active-to-completed lifecycle transition.</summary>
        [TestMethod]
        public void Complete_TransitionsActiveInvitationAndRecordsCompletionTime()
        {
            DateTime createdAtUtc = new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc);
            PolicyProposalInvitation invitation = PolicyProposalInvitation.CreateActive(
                1001,
                12,
                2109,
                "P-001",
                "insured@example.test",
                "secret-hash",
                createdAtUtc,
                createdAtUtc.AddHours(48));

            invitation.Complete(createdAtUtc.AddMinutes(5));

            Assert.AreEqual(InvitationStatus.Completed, invitation.Status);
            Assert.AreEqual(createdAtUtc.AddMinutes(5), invitation.CompletedAtUtc);
        }
    }
}
