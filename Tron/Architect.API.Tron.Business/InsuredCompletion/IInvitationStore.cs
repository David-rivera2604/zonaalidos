using System;
using System.Data;
using Architect.API.Tron.Contracts.InsuredCompletion;

namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Persists invitation lifecycle changes as one atomic operation.
    /// </summary>
    public interface IInvitationStore
    {
        /// <summary>Obtains the next numeric identifier from the invitation Oracle sequence.</summary>
        /// <returns>A new <c>NUMBER(9)</c>-compatible invitation identifier.</returns>
        int NextInvitationId();

        /// <summary>
        /// Stores the supplied active invitation after revoking any active invitation for the same proposal.
        /// </summary>
        /// <param name="invitation">Invitation whose secret has already been reduced to a hash.</param>
        void CreateActiveAndRevokePrior(PolicyProposalInvitation invitation);

        /// <summary>
        /// Retrieves an invitation by its persisted invitation-secret verifier.
        /// </summary>
        /// <param name="secretHash">SHA-256 hash of the capability presented for exchange.</param>
        /// <returns>The matching invitation, or <c>null</c> when no record exists.</returns>
        PolicyProposalInvitation RetrieveBySecretHash(string secretHash);

        /// <summary>
        /// Retrieves an invitation by the verifier stored for its restricted session cookie.
        /// </summary>
        /// <param name="sessionHash">SHA-256 hash of the cookie capability.</param>
        /// <returns>The matching invitation, or <c>null</c> when no record exists.</returns>
        PolicyProposalInvitation RetrieveBySessionHash(string sessionHash);

        /// <summary>
        /// Persists a session verifier only while the invitation is still active and its expected version is current.
        /// </summary>
        /// <param name="invitation">Current invitation snapshot used for optimistic concurrency.</param>
        /// <param name="sessionHash">SHA-256 verifier of the transient session secret.</param>
        /// <param name="utcNow">UTC instant used to reject an invitation that expires during the exchange race.</param>
        /// <param name="sessionExpiresAtUtc">UTC session expiration instant.</param>
        /// <returns><c>true</c> when the restricted session was stored; otherwise <c>false</c>.</returns>
        bool CreateOrRenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc);

        /// <summary>
        /// Extends a matching restricted session while it remains active and unexpired.
        /// </summary>
        /// <param name="invitation">Invitation snapshot that owns the session.</param>
        /// <param name="sessionHash">SHA-256 hash of the cookie capability.</param>
        /// <param name="utcNow">UTC instant used to reject an expired invitation or session.</param>
        /// <param name="sessionExpiresAtUtc">New UTC sliding expiration instant.</param>
        /// <returns><c>true</c> when exactly one current session was renewed.</returns>
        bool RenewSession(PolicyProposalInvitation invitation, string sessionHash, DateTime utcNow, DateTime sessionExpiresAtUtc);

        /// <summary>
        /// Completa la invitación activa que coincide con el alcance de sesión validado e invalida su sesión técnica.
        /// </summary>
        /// <param name="access">Alcance interno de la invitación validado por el filtro de seguridad.</param>
        /// <param name="completedAtUtc">Instante UTC en que la emisión fue aceptada.</param>
        /// <returns><c>true</c> cuando una única invitación activa y vigente cambió a completada.</returns>
        bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc);

        /// <summary>
        /// Completa la invitación activa dentro de una transacción compartida con la solicitud que el asegurado confirmó.
        /// </summary>
        /// <param name="access">Alcance interno de la invitación validado por el filtro de seguridad.</param>
        /// <param name="completedAtUtc">Instante UTC en que el asegurado confirmó los datos.</param>
        /// <param name="connection">Conexión transaccional abierta hacia Research.</param>
        /// <returns><c>true</c> cuando una única invitación activa y vigente cambió a completada.</returns>
        bool CompleteActiveInvitation(InvitationSessionAccess access, DateTime completedAtUtc, IDbConnection connection);
    }
}
