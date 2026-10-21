using System;
using System.Data;
using Architect.API.Tron.Contracts.InsuredCompletion;

namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Adapts the insured-completion service port to the transactional Research data-access operations.
    /// </summary>
    public sealed class InvitationStore : IInvitationStore
    {
        /// <summary>Obtains the next numeric invitation identifier from Research.</summary>
        /// <returns>A <c>NUMBER(9)</c>-compatible invitation identifier.</returns>
        public int NextInvitationId()
        {
            return DataAccess.PolicyProposalInvitation.NextId();
        }

        /// <summary>
        /// Persists an active replacement while revoking every previous active invitation for the proposal.
        /// </summary>
        /// <param name="invitation">Hash-only invitation to persist.</param>
        public void CreateActiveAndRevokePrior(PolicyProposalInvitation invitation)
        {
            DataAccess.PolicyProposalInvitation.CreateActiveAndRevokePrior(invitation);
        }

        /// <summary>
        /// Looks up an invitation by the hash of the capability submitted by the public portal.
        /// </summary>
        /// <param name="secretHash">SHA-256 verifier of the invitation capability.</param>
        /// <returns>The matching invitation, or <c>null</c> if it was not found.</returns>
        public PolicyProposalInvitation RetrieveBySecretHash(string secretHash)
        {
            return DataAccess.PolicyProposalInvitation.RetrieveBySecretHash(secretHash);
        }

        /// <summary>
        /// Looks up an invitation by the hash verifier of a restricted-session cookie.
        /// </summary>
        /// <param name="sessionHash">SHA-256 verifier of the cookie capability.</param>
        /// <returns>The matching invitation, or <c>null</c> if it was not found.</returns>
        public PolicyProposalInvitation RetrieveBySessionHash(string sessionHash)
        {
            return DataAccess.PolicyProposalInvitation.RetrieveBySessionHash(sessionHash);
        }

        /// <summary>
        /// Atomically records a new session verifier if the invitation stayed active and unexpired during the exchange.
        /// </summary>
        /// <param name="invitation">Invitation snapshot used for optimistic concurrency.</param>
        /// <param name="sessionHash">SHA-256 verifier of the session capability.</param>
        /// <param name="utcNow">UTC instant of the exchange.</param>
        /// <param name="sessionExpiresAtUtc">UTC session expiration instant.</param>
        /// <returns><c>true</c> when the session was persisted.</returns>
        public bool CreateOrRenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc)
        {
            return DataAccess.PolicyProposalInvitation.CreateOrRenewSession(invitation, sessionHash, utcNow, sessionExpiresAtUtc);
        }

        /// <summary>
        /// Slides the expiration for the matching restricted session while enforcing active invitation state in storage.
        /// </summary>
        /// <param name="invitation">Invitation snapshot that owns the session.</param>
        /// <param name="sessionHash">SHA-256 verifier of the cookie capability.</param>
        /// <param name="utcNow">UTC instant of the request.</param>
        /// <param name="sessionExpiresAtUtc">New UTC session expiration instant.</param>
        /// <returns><c>true</c> when the session was renewed.</returns>
        public bool RenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc)
        {
            return DataAccess.PolicyProposalInvitation.RenewSession(invitation, sessionHash, utcNow, sessionExpiresAtUtc);
        }

        /// <summary>
        /// Completa de forma atómica la invitación asociada al alcance de sesión ya validado.
        /// </summary>
        /// <param name="access">Alcance interno autorizado para la solicitud actual.</param>
        /// <param name="completedAtUtc">Instante UTC de la respuesta exitosa de emisión.</param>
        /// <returns><c>true</c> si se completó una única invitación activa y vigente.</returns>
        public bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc)
        {
            return CompleteActiveInvitation(access, completedAtUtc, null);
        }

        /// <summary>
        /// Completa de forma atómica la invitación dentro de la transacción compartida con la solicitud confirmada.
        /// </summary>
        /// <param name="access">Alcance interno autorizado para la solicitud actual.</param>
        /// <param name="completedAtUtc">Instante UTC de confirmación del asegurado.</param>
        /// <param name="connection">Conexión transaccional abierta hacia Research.</param>
        /// <returns><c>true</c> si se completó una única invitación activa y vigente.</returns>
        public bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc, IDbConnection connection)
        {
            if (access == null || !access.Found)
            {
                return false;
            }

            return DataAccess.PolicyProposalInvitation.CompleteActiveInvitation(
                access.InvitationId,
                access.CompanyId,
                access.ProposalId,
                completedAtUtc,
                connection);
        }
    }
}
