using System;
using Architect.API.Tron.Contracts.InsuredCompletion;

namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Valida y renueva una sesión de completado por asegurado ya canjeada sin usar autenticación de agente.
    /// </summary>
    public sealed class InvitationSessionService
    {
        private const int SessionLifetimeMinutes = 30;
        private readonly IInvitationStore store;
        private readonly Func<DateTime> utcNow;

        /// <summary>Inicializa el validador de sesión con persistencia y un reloj UTC.</summary>
        /// <param name="store">Puerta de persistencia de invitaciones.</param>
        /// <param name="utcNow">Reloj UTC usado para aplicar el vencimiento de invitación y sesión.</param>
        public InvitationSessionService(IInvitationStore store, Func<DateTime> utcNow)
        {
            this.store = store;
            this.utcNow = utcNow;
        }

        /// <summary>
        /// Valida una capacidad de cookie y renueva su vencimiento mientras conserva su alcance de una sola propuesta.
        /// </summary>
        /// <param name="sessionSecret">Valor en texto plano leído de la cookie de sesión HTTP-only.</param>
        /// <returns>Alcance interno de sesión o resultado genérico que no revela el motivo de falla.</returns>
        public InvitationSessionAccess ValidateAndRenew(string sessionSecret)
        {
            if (string.IsNullOrWhiteSpace(sessionSecret))
            {
                return InvitationSessionAccess.NotFound();
            }

            DateTime now = utcNow();
            string sessionHash = InvitationSecret.Hash(sessionSecret);
            PolicyProposalInvitation invitation = store.RetrieveBySessionHash(sessionHash);
            if (invitation == null || invitation.Status != InvitationStatus.Active ||
                invitation.ExpiresAtUtc <= now || !invitation.SessionExpiresAtUtc.HasValue || invitation.SessionExpiresAtUtc.Value <= now)
            {
                return InvitationSessionAccess.NotFound();
            }

            if (!store.RenewSession(invitation, sessionHash, now, now.AddMinutes(SessionLifetimeMinutes)))
            {
                return InvitationSessionAccess.NotFound();
            }

            return InvitationSessionAccess.Granted(invitation);
        }
    }
}
