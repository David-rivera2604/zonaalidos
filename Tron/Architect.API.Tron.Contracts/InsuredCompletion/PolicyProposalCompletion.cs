using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Captures the submitted insured-completion payload and its explicit consent evidence.
    /// </summary>
    public sealed class PolicyProposalCompletion
    {
        /// <summary>Gets the invitation that authorized the submission.</summary>
        public int InvitationId { get; private set; }
        /// <summary>Gets the version of the form rendered to the insured.</summary>
        public string FormVersion { get; private set; }
        /// <summary>Gets the serialized completed payload for the restricted workflow.</summary>
        public string PayloadJson { get; private set; }
        /// <summary>Gets the version of the consent text accepted by the insured.</summary>
        public string ConsentTextVersion { get; private set; }
        /// <summary>Gets whether explicit consent was recorded.</summary>
        public bool ConsentAccepted { get; private set; }
        /// <summary>Gets the UTC submission instant.</summary>
        public DateTime CompletedAtUtc { get; private set; }
        /// <summary>Gets the optimistic-concurrency version of this record.</summary>
        public int RowVersion { get; private set; }

        private PolicyProposalCompletion()
        {
        }

        /// <summary>
        /// Creates a completion record only after the insured has accepted the applicable consent text.
        /// </summary>
        /// <returns>A completion record ready for transactional persistence.</returns>
        /// <exception cref="ArgumentException">Thrown when explicit consent was not accepted.</exception>
        public static PolicyProposalCompletion Create(
            int invitationId,
            string formVersion,
            string payloadJson,
            string consentTextVersion,
            bool consentAccepted,
            DateTime completedAtUtc)
        {
            if (!consentAccepted)
            {
                throw new ArgumentException("La entrega requiere consentimiento explícito.", nameof(consentAccepted));
            }

            return new PolicyProposalCompletion
            {
                InvitationId = invitationId,
                FormVersion = formVersion,
                PayloadJson = payloadJson,
                ConsentTextVersion = consentTextVersion,
                ConsentAccepted = true,
                CompletedAtUtc = completedAtUtc,
                RowVersion = 1
            };
        }
    }
}
