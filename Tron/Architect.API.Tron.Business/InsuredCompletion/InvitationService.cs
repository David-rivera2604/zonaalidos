using System;
using Architect.API.Tron.Contracts.InsuredCompletion;

namespace Architect.API.Tron.Business.InsuredCompletion
{
    /// <summary>
    /// Emite una capacidad de completado limitada y temporal, y la envía al asegurado.
    /// El servicio solo persiste el hash de la capacidad; el enlace de correo lleva el secreto en su fragmento.
    /// </summary>
    public sealed class InvitationService
    {
        private const int InvitationLifetimeHours = 48;
        private readonly IInvitationStore store;
        private readonly IInvitationMailSender mailSender;
        private readonly Func<DateTime> utcNow;
        private readonly Func<string> secretGenerator;
        private readonly string portalBaseUrl;

        /// <summary>
        /// Inicializa el flujo de invitaciones con sus dependencias de persistencia, entrega, reloj, entropía y portal.
        /// </summary>
        /// <param name="store">Puerta de persistencia atómica de invitaciones.</param>
        /// <param name="mailSender">Emisor de correo saliente aprobado.</param>
        /// <param name="utcNow">Reloj UTC usado para cálculos deterministas de vencimiento.</param>
        /// <param name="secretGenerator">Generador de secretos criptográficamente seguro.</param>
        /// <param name="portalBaseUrl">URL base absoluta del portal restringido de completado.</param>
        public InvitationService(
            IInvitationStore store,
            IInvitationMailSender mailSender,
            Func<DateTime> utcNow,
            Func<string> secretGenerator,
            string portalBaseUrl)
        {
            this.store = store;
            this.mailSender = mailSender;
            this.utcNow = utcNow;
            this.secretGenerator = secretGenerator;
            this.portalBaseUrl = portalBaseUrl;
        }

        /// <summary>
        /// Crea una invitación de reemplazo, invalida las invitaciones activas previas y envía por correo el nuevo enlace de capacidad.
        /// </summary>
        /// <param name="request">Alcance de propuesta autorizado por el agente y dirección destinataria.</param>
        /// <returns>Estado de invitación sin secretos para el llamador del agente.</returns>
        /// <exception cref="ArgumentException">Se produce cuando no se proporciona una dirección destinataria.</exception>
        public InvitationView CreateOrResend(CreateInvitationRequest request)
        {
            if (request == null || request.PolicyProposalId <= 0 || string.IsNullOrWhiteSpace(request.RecipientEmail))
            {
                throw new ArgumentException("Debe indicar una solicitud y el correo del asegurado.", nameof(request));
            }

            string completionPath = CompletionDestination.Validate(request.CompletionPath);
            if (!CompletionFlow.IsKnown(request.CompletionFlow))
            {
                throw new ArgumentException("Debe indicar un flujo de completado aprobado.", nameof(request));
            }

            DateTime createdAtUtc = utcNow();
            DateTime expiresAtUtc = createdAtUtc.AddHours(InvitationLifetimeHours);
            string secret = secretGenerator();
            PolicyProposalInvitation invitation = PolicyProposalInvitation.CreateActive(
                store.NextInvitationId(),
                request.CompanyId,
                request.PolicyProposalId,
                request.ProposalId,
                request.RecipientEmail,
                InvitationSecret.Hash(secret),
                createdAtUtc,
                expiresAtUtc,
                completionPath,
                request.CompletionFlow);

            store.CreateActiveAndRevokePrior(invitation);
            mailSender.Send(request.RecipientEmail, BuildInvitationUrl(secret), request.CompanyId, request.UserId, request.OwnerId);

            return new InvitationView
            {
                InvitationId = invitation.Id,
                ExpiresAtUtc = invitation.ExpiresAtUtc,
                Status = invitation.Status
            };
        }

        /// <summary>
        /// Canjea una capacidad de invitación por un secreto temporal de sesión restringida sin revelar la causa de una falla.
        /// </summary>
        /// <param name="secret">Capacidad de invitación en texto plano enviada por el portal público.</param>
        /// <returns>Resultado genérico no encontrado o el secreto temporal requerido para crear la cookie de sesión segura.</returns>
        public InvitationSession Exchange(string secret)
        {
            if (string.IsNullOrWhiteSpace(secret))
            {
                return InvitationSession.NotFound();
            }

            DateTime now = utcNow();
            PolicyProposalInvitation invitation = store.RetrieveBySecretHash(InvitationSecret.Hash(secret));
            if (invitation == null || invitation.Status != InvitationStatus.Active || invitation.ExpiresAtUtc <= now)
            {
                return InvitationSession.NotFound();
            }

            DateTime sessionExpiresAtUtc = now.AddMinutes(30);
            string sessionSecret = secretGenerator();
            string sessionHash = InvitationSecret.Hash(sessionSecret);
            if (!store.CreateOrRenewSession(invitation, sessionHash, now, sessionExpiresAtUtc))
            {
                return InvitationSession.NotFound();
            }

            return InvitationSession.Granted(sessionSecret, sessionExpiresAtUtc);
        }

        private string BuildInvitationUrl(string secret)
        {
            return portalBaseUrl.TrimEnd('/') + "/Completar#invite=" + secret;
        }
    }
}
