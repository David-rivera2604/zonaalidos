using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Exposes the non-secret result of issuing or querying an invitation.
    /// </summary>
    public sealed class InvitationView
    {
        /// <summary>Gets or sets the invitation identifier.</summary>
        public int InvitationId { get; set; }
        /// <summary>Gets or sets the UTC expiration instant.</summary>
        public DateTime ExpiresAtUtc { get; set; }
        /// <summary>Gets or sets the invitation lifecycle status.</summary>
        public InvitationStatus Status { get; set; }
    }
}
