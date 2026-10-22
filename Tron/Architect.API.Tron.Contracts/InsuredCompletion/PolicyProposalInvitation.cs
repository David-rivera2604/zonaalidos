using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Represents a time-limited capability to complete exactly one policy proposal.
    /// Plain-text invitation and session secrets are intentionally never retained here.
    /// </summary>
    public sealed class PolicyProposalInvitation
    {
        /// <summary>Gets the invitation identifier.</summary>
        public int Id { get; private set; }
        /// <summary>Gets the company that owns the proposal.</summary>
        public int CompanyId { get; private set; }
        /// <summary>Obtiene el identificador técnico NUMBER(9) de la solicitud autorizada.</summary>
        public int PolicyProposalId { get; private set; }
        /// <summary>Obtiene el identificador de negocio de la solicitud dentro de la compañía.</summary>
        public string ProposalId { get; private set; }
        /// <summary>Gets the recipient address selected by the agent.</summary>
        public string RecipientEmail { get; private set; }
        /// <summary>Obtiene la ruta relativa y los parámetros del formulario autorizado para esta invitación.</summary>
        public string CompletionPath { get; private set; }
        /// <summary>Obtiene el código de flujo servidor que limita los recursos de la sesión técnica.</summary>
        public string CompletionFlow { get; private set; }
        /// <summary>Gets the SHA-256 verifier for the invitation secret, never the secret itself.</summary>
        public string SecretHash { get; private set; }
        /// <summary>Gets the verifier for a short-lived restricted session, when one exists.</summary>
        public string SessionHash { get; private set; }
        /// <summary>Gets the current lifecycle status.</summary>
        public InvitationStatus Status { get; private set; }
        /// <summary>Gets the UTC instant when the invitation was issued.</summary>
        public DateTime CreatedAtUtc { get; private set; }
        /// <summary>Gets the UTC instant after which the invitation cannot be exchanged.</summary>
        public DateTime ExpiresAtUtc { get; private set; }
        /// <summary>Gets the UTC instant after which the restricted session cannot be used.</summary>
        public DateTime? SessionExpiresAtUtc { get; private set; }
        /// <summary>Gets the UTC instant at which completion was accepted.</summary>
        public DateTime? CompletedAtUtc { get; private set; }
        /// <summary>Gets the UTC instant at which the invitation was revoked.</summary>
        public DateTime? RevokedAtUtc { get; private set; }
        /// <summary>Gets the number of emails issued for this invitation record.</summary>
        public int SendCount { get; private set; }
        /// <summary>Gets the optimistic-concurrency version persisted for this invitation.</summary>
        public int RowVersion { get; private set; }

        private PolicyProposalInvitation()
        {
        }

        /// <summary>
        /// Creates an active invitation when recipient information is not available to the caller.
        /// </summary>
        /// <param name="id">Unique invitation identifier.</param>
        /// <param name="companyId">Owning company identifier.</param>
        /// <param name="policyProposalId">Identificador técnico NUMBER(9) de la solicitud autorizada.</param>
        /// <param name="proposalId">Identificador de negocio de la solicitud autorizada.</param>
        /// <param name="secretHash">Hash verifier for the secret sent by email.</param>
        /// <param name="createdAtUtc">UTC issuance instant.</param>
        /// <param name="expiresAtUtc">UTC expiration instant.</param>
        /// <param name="completionPath">Ruta relativa y parámetros del formulario autorizado.</param>
        /// <param name="completionFlow">Código del flujo servidor que restringe los recursos disponibles.</param>
        /// <returns>A new active invitation.</returns>
        public static PolicyProposalInvitation CreateActive(
            int id,
            int companyId,
            int policyProposalId,
            string proposalId,
            string secretHash,
            DateTime createdAtUtc,
            DateTime expiresAtUtc)
        {
            return CreateActive(
                id,
                companyId,
                policyProposalId,
                proposalId,
                null,
                secretHash,
                createdAtUtc,
                expiresAtUtc);
        }

        /// <summary>
        /// Creates an active invitation bound to a recipient and one policy proposal.
        /// </summary>
        /// <param name="id">Unique invitation identifier.</param>
        /// <param name="companyId">Owning company identifier.</param>
        /// <param name="policyProposalId">Identificador técnico NUMBER(9) de la solicitud autorizada.</param>
        /// <param name="proposalId">Identificador de negocio de la solicitud autorizada.</param>
        /// <param name="recipientEmail">Email address receiving the capability link.</param>
        /// <param name="secretHash">Hash verifier for the secret sent by email.</param>
        /// <param name="createdAtUtc">UTC issuance instant.</param>
        /// <param name="expiresAtUtc">UTC expiration instant.</param>
        /// <returns>A new active invitation.</returns>
        /// <exception cref="ArgumentException">Thrown when the expiration is not after issuance.</exception>
        public static PolicyProposalInvitation CreateActive(
            int id,
            int companyId,
            int policyProposalId,
            string proposalId,
            string recipientEmail,
            string secretHash,
            DateTime createdAtUtc,
            DateTime expiresAtUtc,
            string completionPath = null,
            string completionFlow = null)
        {
            if (policyProposalId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(policyProposalId), "Debe indicar una solicitud técnica válida.");
            }

            if (expiresAtUtc <= createdAtUtc)
            {
                throw new ArgumentException("La invitación debe vencer después de su creación.", nameof(expiresAtUtc));
            }

            return new PolicyProposalInvitation
            {
                Id = id,
                CompanyId = companyId,
                PolicyProposalId = policyProposalId,
                ProposalId = proposalId,
                RecipientEmail = recipientEmail,
                CompletionPath = completionPath,
                CompletionFlow = completionFlow,
                SecretHash = secretHash,
                Status = InvitationStatus.Active,
                CreatedAtUtc = createdAtUtc,
                ExpiresAtUtc = expiresAtUtc,
                SendCount = 1,
                RowVersion = 1
            };
        }

        /// <summary>
        /// Rehydrates an invitation exactly as it was persisted by the data-access layer.
        /// </summary>
        /// <param name="policyProposalId">Identificador técnico NUMBER(9) de la solicitud autorizada.</param>
        /// <param name="proposalId">Identificador de negocio de la solicitud autorizada.</param>
        /// <param name="completionPath">Ruta relativa persistida para continuar después del canje.</param>
        /// <param name="completionFlow">Código persistido del flujo de completado aprobado.</param>
        /// <returns>The rehydrated invitation.</returns>
        public static PolicyProposalInvitation Restore(
            int id,
            int companyId,
            int policyProposalId,
            string proposalId,
            string recipientEmail,
            string secretHash,
            string sessionHash,
            InvitationStatus status,
            DateTime expiresAtUtc,
            DateTime? sessionExpiresAtUtc,
            DateTime createdAtUtc,
            DateTime? completedAtUtc,
            DateTime? revokedAtUtc,
            int sendCount,
            int rowVersion,
            string completionPath = null,
            string completionFlow = null)
        {
            if (policyProposalId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(policyProposalId), "Debe indicar una solicitud técnica válida.");
            }

            return new PolicyProposalInvitation
            {
                Id = id,
                CompanyId = companyId,
                PolicyProposalId = policyProposalId,
                ProposalId = proposalId,
                RecipientEmail = recipientEmail,
                CompletionPath = completionPath,
                CompletionFlow = completionFlow,
                SecretHash = secretHash,
                SessionHash = sessionHash,
                Status = status,
                ExpiresAtUtc = expiresAtUtc,
                SessionExpiresAtUtc = sessionExpiresAtUtc,
                CreatedAtUtc = createdAtUtc,
                CompletedAtUtc = completedAtUtc,
                RevokedAtUtc = revokedAtUtc,
                SendCount = sendCount,
                RowVersion = rowVersion
            };
        }

        /// <summary>
        /// Revokes an active invitation; calling it on a non-active invitation has no effect.
        /// </summary>
        /// <param name="revokedAtUtc">UTC instant of revocation.</param>
        public void Revoke(DateTime revokedAtUtc)
        {
            if (Status == InvitationStatus.Active)
            {
                Status = InvitationStatus.Revoked;
                RevokedAtUtc = revokedAtUtc;
            }
        }

        /// <summary>
        /// Marks this active invitation as completed.
        /// </summary>
        /// <param name="completedAtUtc">UTC instant when the form submission was accepted.</param>
        /// <exception cref="InvalidOperationException">Thrown unless the invitation is active.</exception>
        public void Complete(DateTime completedAtUtc)
        {
            if (Status != InvitationStatus.Active)
            {
                throw new InvalidOperationException("Solo una invitación activa puede completarse.");
            }

            Status = InvitationStatus.Completed;
            CompletedAtUtc = completedAtUtc;
        }

        /// <summary>
        /// Associates a short-lived restricted-session verifier with this active invitation.
        /// </summary>
        /// <param name="sessionHash">Hash verifier for the transient session secret.</param>
        /// <param name="sessionExpiresAtUtc">UTC instant after which the session is unusable.</param>
        /// <exception cref="InvalidOperationException">Thrown unless the invitation remains active.</exception>
        public void CreateOrRenewSession(string sessionHash, DateTime sessionExpiresAtUtc)
        {
            if (Status != InvitationStatus.Active)
            {
                throw new InvalidOperationException("Solo una invitación activa puede tener sesión.");
            }

            SessionHash = sessionHash;
            SessionExpiresAtUtc = sessionExpiresAtUtc;
        }
    }
}
