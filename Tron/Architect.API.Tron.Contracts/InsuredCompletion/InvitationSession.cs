using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Represents the indistinguishable public result of exchanging an invitation capability.
    /// The session secret is transient and must be written only to the secure HTTP-only cookie.
    /// </summary>
    public sealed class InvitationSession
    {
        /// <summary>Gets whether a valid invitation was exchanged for a restricted session.</summary>
        public bool Found { get; private set; }

        /// <summary>Gets the transient plain-text session secret when <see cref="Found"/> is <c>true</c>.</summary>
        public string SessionSecret { get; private set; }

        /// <summary>Gets the UTC instant at which the session must no longer be accepted.</summary>
        public DateTime? ExpiresAtUtc { get; private set; }

        private InvitationSession()
        {
        }

        /// <summary>
        /// Creates the generic result returned for unknown, expired, revoked, and otherwise unusable invitations.
        /// </summary>
        /// <returns>A result that reveals no invitation state or proposal data.</returns>
        public static InvitationSession NotFound()
        {
            return new InvitationSession { Found = false };
        }

        /// <summary>
        /// Creates the transient result used by the HTTP edge to set the restricted session cookie.
        /// </summary>
        /// <param name="sessionSecret">Plain-text secret that will be placed only in the secure cookie.</param>
        /// <param name="expiresAtUtc">UTC session expiration instant.</param>
        /// <returns>A successful restricted-session result.</returns>
        public static InvitationSession Granted(string sessionSecret, DateTime expiresAtUtc)
        {
            return new InvitationSession
            {
                Found = true,
                SessionSecret = sessionSecret,
                ExpiresAtUtc = expiresAtUtc
            };
        }
    }
}
