using System;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Documents consent and audit invariants for an accepted insured submission.
    /// </summary>
    [TestClass]
    public class CompletionContractsTests
    {
        /// <summary>Protects the requirement for an explicit consent action before persistence.</summary>
        [TestMethod]
        public void CreateCompletion_RequiresExplicitConsent()
        {
            Assert.ThrowsException<ArgumentException>(() => PolicyProposalCompletion.Create(
                1001,
                "2026-08-17",
                "{\"field\":\"value\"}",
                "consent-v1",
                false,
                new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc)));
        }

        /// <summary>Protects the association between each audit event and its authorizing invitation.</summary>
        [TestMethod]
        public void CreateAudit_AssociatesTheEventWithItsInvitation()
        {
            int invitationId = 1001;
            PolicyProposalCompletionAudit audit = PolicyProposalCompletionAudit.Create(
                2001,
                invitationId,
                "InvitationCreated",
                "Agent",
                new DateTime(2026, 8, 17, 12, 0, 0, DateTimeKind.Utc),
                "203.0.113.10",
                "test-agent",
                "request-123");

            Assert.AreEqual(invitationId, audit.InvitationId);
            Assert.AreEqual("Agent", audit.ActorType);
        }
    }
}
