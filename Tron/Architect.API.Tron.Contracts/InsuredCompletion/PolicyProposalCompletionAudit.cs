using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Represents a security-relevant event in the insured-completion workflow.
    /// </summary>
    public sealed class PolicyProposalCompletionAudit
    {
        /// <summary>Gets the audit-event identifier.</summary>
        public int Id { get; private set; }
        /// <summary>Gets the invitation associated with this event.</summary>
        public int InvitationId { get; private set; }
        /// <summary>Gets the controlled event name.</summary>
        public string EventType { get; private set; }
        /// <summary>Gets the actor category, without recording a special account identity.</summary>
        public string ActorType { get; private set; }
        /// <summary>Gets the UTC instant when the event occurred.</summary>
        public DateTime OccurredAtUtc { get; private set; }
        /// <summary>Gets the recorded remote address, if available.</summary>
        public string RemoteAddress { get; private set; }
        /// <summary>Gets the recorded user-agent value, if available.</summary>
        public string UserAgent { get; private set; }
        /// <summary>Gets the request correlation identifier.</summary>
        public string CorrelationId { get; private set; }

        private PolicyProposalCompletionAudit()
        {
        }

        /// <summary>
        /// Creates an immutable audit-event value for later persistence.
        /// </summary>
        /// <returns>An audit event linked to the supplied invitation.</returns>
        public static PolicyProposalCompletionAudit Create(
            int id,
            int invitationId,
            string eventType,
            string actorType,
            DateTime occurredAtUtc,
            string remoteAddress,
            string userAgent,
            string correlationId)
        {
            return new PolicyProposalCompletionAudit
            {
                Id = id,
                InvitationId = invitationId,
                EventType = eventType,
                ActorType = actorType,
                OccurredAtUtc = occurredAtUtc,
                RemoteAddress = remoteAddress,
                UserAgent = userAgent,
                CorrelationId = correlationId
            };
        }
    }
}
