using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Provides internal authorization context for an already exchanged restricted session.
    /// It is for server-side filters only and must never be serialized to the public browser.
    /// </summary>
    public sealed class InvitationSessionAccess
    {
        /// <summary>Gets whether the cookie represents an active, unexpired restricted session.</summary>
        public bool Found { get; private set; }

        /// <summary>Gets the authorizing invitation identifier when the session is valid.</summary>
        public int InvitationId { get; private set; }

        /// <summary>Gets the company scope associated with the invitation.</summary>
        public int CompanyId { get; private set; }

        /// <summary>Obtiene el identificador técnico NUMBER(9) de la única solicitud disponible para la sesión.</summary>
        public int PolicyProposalId { get; private set; }

        /// <summary>Obtiene el identificador de negocio de la única solicitud disponible para la sesión.</summary>
        public string ProposalId { get; private set; }
        /// <summary>Obtiene la ruta relativa autorizada para continuar después del canje de la invitación.</summary>
        public string CompletionPath { get; private set; }
        /// <summary>Obtiene el flujo servidor que determina los recursos disponibles para la sesión técnica.</summary>
        public string CompletionFlow { get; private set; }

        private InvitationSessionAccess()
        {
        }

        /// <summary>Creates the generic result for a missing, invalid, revoked, or expired session.</summary>
        /// <returns>A result containing no identifying scope.</returns>
        public static InvitationSessionAccess NotFound()
        {
            return new InvitationSessionAccess { Found = false };
        }

        /// <summary>Creates the internal authorization context for an active restricted session.</summary>
        /// <param name="invitation">Invitation that owns the valid session.</param>
        /// <returns>A session access value scoped to exactly one proposal.</returns>
        public static InvitationSessionAccess Granted(PolicyProposalInvitation invitation)
        {
            return new InvitationSessionAccess
            {
                Found = true,
                InvitationId = invitation.Id,
                CompanyId = invitation.CompanyId,
                PolicyProposalId = invitation.PolicyProposalId,
                ProposalId = invitation.ProposalId,
                CompletionPath = invitation.CompletionPath,
                CompletionFlow = invitation.CompletionFlow
            };
        }
    }
}
