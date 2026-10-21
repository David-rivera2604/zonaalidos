using System;
using System.Configuration;
using System.Net.Mail;
using Architect.API.Tron.Business.InsuredCompletion;
using Architect.API.Tron.Contracts;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Architect.DataFactory;
using Newtonsoft.Json;
using RequestPoliza = Architect.API.Tron.Contracts.AltasBajas.Request.Poliza;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Coordina el seguimiento que puede realizar el agente después de enviar una solicitud al asegurado.
    /// </summary>
    public static class PolicyProposalAgentWorkflow
    {
        /// <summary>
        /// Recupera una solicitud del agente junto con la última invitación y las acciones autorizadas.
        /// </summary>
        /// <param name="proposalId">Identificador técnico de la solicitud.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente.</param>
        /// <returns>Vista segura de seguimiento.</returns>
        public static AgentPolicyProposalView Retrieve(int proposalId, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = RetrieveOwned(proposalId, tokenInfo);
            return CreateView(proposal, DataAccess.PolicyProposalInvitation.RetrieveLatestByPolicyProposalId(tokenInfo.CompanyId, proposal.Id));
        }

        /// <summary>
        /// Reenvía una invitación y permite cambiar solamente el correo electrónico del destinatario.
        /// </summary>
        /// <param name="proposalId">Identificador técnico de la solicitud.</param>
        /// <param name="recipientEmail">Correo actualizado del asegurado.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente.</param>
        /// <returns>Vista actualizada de seguimiento.</returns>
        public static AgentPolicyProposalView ResendInvitation(int proposalId, string recipientEmail, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = RequirePendingProposal(proposalId, tokenInfo);
            string normalizedEmail = ValidateEmail(recipientEmail);
            RequestPoliza form = DeserializeForm(proposal);
            form.EMAIL_ASEG = normalizedEmail;
            string proposalData = JsonConvert.SerializeObject(form);
            if (!DataAccess.PolicyProposal.TryUpdateRecipientEmailAndSnapshot(proposal.Id, proposal.CompanyId, proposalData, normalizedEmail, tokenInfo.UserId))
            {
                throw new InvalidOperationException("La solicitud cambió antes de reenviar la invitación.");
            }

            proposal.ProposalData = proposalData;
            proposal.PrimaryEmailAddress = normalizedEmail;
            CreateInvitationService().CreateOrResend(new CreateInvitationRequest
            {
                CompanyId = proposal.CompanyId,
                PolicyProposalId = proposal.Id,
                ProposalId = proposal.ProposalId,
                RecipientEmail = normalizedEmail,
                UserId = tokenInfo.UserId,
                OwnerId = tokenInfo.UserId,
                CompletionPath = "/form/EmitirPoliza?proposal=" + proposal.ProposalId,
                CompletionFlow = CompletionFlow.PolicyProposal
            });
            PolicyProposalAudit.Create(proposal, tokenInfo, "Invitación reenviada al asegurado", "El agente reenvió la invitación al asegurado.");
            return CreateView(proposal, DataAccess.PolicyProposalInvitation.RetrieveLatestByPolicyProposalId(proposal.CompanyId, proposal.Id));
        }

        /// <summary>
        /// Anula la invitación vigente sin habilitar la modificación de la solicitud.
        /// </summary>
        /// <param name="proposalId">Identificador técnico de la solicitud.</param>
        /// <param name="reason">Motivo opcional de máximo 200 caracteres.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente.</param>
        /// <returns>Vista actualizada de seguimiento.</returns>
        public static AgentPolicyProposalView RevokeInvitation(int proposalId, string reason, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = RequirePendingProposal(proposalId, tokenInfo);
            string safeReason = string.IsNullOrWhiteSpace(reason) ? string.Empty : reason.Trim();
            if (safeReason.Length > 200)
            {
                throw new ArgumentException("El motivo de anulación no puede superar 200 caracteres.", nameof(reason));
            }

            DataAccess.PolicyProposalInvitation.RevokeActiveForPolicyProposal(proposal.CompanyId, proposal.Id, DateTime.UtcNow);
            // El motivo puede contener datos personales; la auditoría solo conserva el hecho de la acción.
            PolicyProposalAudit.Create(proposal, tokenInfo, "Invitación anulada", "El agente anuló la invitación activa.");
            return CreateView(proposal, DataAccess.PolicyProposalInvitation.RetrieveLatestByPolicyProposalId(proposal.CompanyId, proposal.Id));
        }

        /// <summary>
        /// Invalida la invitación y devuelve la solicitud al estado de borrador editable por el agente.
        /// </summary>
        /// <param name="proposalId">Identificador técnico de la solicitud.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente.</param>
        /// <returns>Vista actualizada de seguimiento.</returns>
        public static AgentPolicyProposalView ResumeEditing(int proposalId, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = RequirePendingProposal(proposalId, tokenInfo);
            using (Session session = new Session("Research"))
            {
                try
                {
                    DataAccess.PolicyProposalInvitation.RevokeActiveForPolicyProposal(proposal.CompanyId, proposal.Id, DateTime.UtcNow, session.dbConnection);
                    if (!DataAccess.PolicyProposal.TryTransition(proposal.Id, proposal.CompanyId,
                        PolicyProposalStatus.PendientePorComplementos, PolicyProposalStatus.Incompleta, tokenInfo.UserId, connection: session.dbConnection))
                    {
                        throw new InvalidOperationException("La solicitud cambió antes de retomar la corrección.");
                    }

                    session.CommitAndClose();
                }
                catch
                {
                    session.RollbackAndClose();
                    throw;
                }
            }

            proposal.Status = PolicyProposalStatus.Incompleta;
            PolicyProposalAudit.Create(proposal, tokenInfo, "Solicitud retomada para corrección", "El agente anuló la invitación y retomó la solicitud para corrección.");
            return CreateView(proposal, DataAccess.PolicyProposalInvitation.RetrieveLatestByPolicyProposalId(proposal.CompanyId, proposal.Id));
        }

        private static Contracts.PolicyProposal RequirePendingProposal(int proposalId, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = RetrieveOwned(proposalId, tokenInfo);
            if (proposal.Status != PolicyProposalStatus.PendientePorComplementos)
            {
                throw new InvalidOperationException("La solicitud no está disponible para administrar la invitación.");
            }

            return proposal;
        }

        private static Contracts.PolicyProposal RetrieveOwned(int proposalId, Core.Contracts.Security.Token tokenInfo)
        {
            if (tokenInfo == null || proposalId <= 0)
            {
                throw new InvalidOperationException("La solicitud indicada no está disponible.");
            }

            Contracts.PolicyProposal proposal = ProposalOwnership.RetrieveOwnedByAgent(proposalId, tokenInfo.CompanyId, tokenInfo.AgentCode);
            if (proposal == null)
            {
                throw new InvalidOperationException("La solicitud indicada no está disponible.");
            }

            return proposal;
        }

        private static InvitationService CreateInvitationService()
        {
            return new InvitationService(new InvitationStore(), new InvitationMailSender(), () => DateTime.UtcNow,
                InvitationSecret.Generate, ConfigurationManager.AppSettings["Aliados.URL.Base"]);
        }

        private static RequestPoliza DeserializeForm(Contracts.PolicyProposal proposal)
        {
            RequestPoliza form = string.IsNullOrWhiteSpace(proposal.ProposalData) ? null : JsonConvert.DeserializeObject<RequestPoliza>(proposal.ProposalData);
            if (form == null)
            {
                throw new InvalidOperationException("La solicitud no contiene una instantánea válida para reenviar la invitación.");
            }

            return form;
        }

        private static string ValidateEmail(string recipientEmail)
        {
            try
            {
                return new MailAddress(recipientEmail ?? string.Empty).Address;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Debe indicar un correo electrónico válido para el asegurado.", nameof(recipientEmail));
            }
        }

        private static AgentPolicyProposalView CreateView(Contracts.PolicyProposal proposal, PolicyProposalInvitation invitation)
        {
            bool pending = proposal.Status == PolicyProposalStatus.PendientePorComplementos;
            bool active = invitation != null && invitation.Status == InvitationStatus.Active && invitation.ExpiresAtUtc > DateTime.UtcNow;
            return new AgentPolicyProposalView
            {
                Id = proposal.Id,
                ProposalId = proposal.ProposalId,
                Status = proposal.Status,
                StatusDesc = DescribeStatus(proposal.Status),
                ProposalData = proposal.ProposalData,
                Invitation = invitation == null ? null : new InvitationSummaryView
                {
                    Id = invitation.Id,
                    Status = invitation.Status == InvitationStatus.Active && !active ? InvitationStatus.Expired : invitation.Status,
                    CreatedAtUtc = invitation.CreatedAtUtc,
                    ExpiresAtUtc = invitation.ExpiresAtUtc,
                    CompletedAtUtc = invitation.CompletedAtUtc,
                    RevokedAtUtc = invitation.RevokedAtUtc,
                    SendCount = invitation.SendCount,
                    RecipientEmailMasked = MaskEmail(invitation.RecipientEmail)
                },
                CanResend = pending,
                CanRevoke = pending && active,
                CanResumeEditing = pending
            };
        }

        private static string DescribeStatus(int status)
        {
            switch (status)
            {
                case PolicyProposalStatus.Incompleta: return "Incompleta";
                case PolicyProposalStatus.PendientePorComplementos: return "Pendiente por complementos";
                case PolicyProposalStatus.PendientePorFirma: return "Pendiente por firma";
                case PolicyProposalStatus.PorAceptar: return "Por aceptar";
                case PolicyProposalStatus.ParaEmitir: return "Para emitir";
                case PolicyProposalStatus.EnRevisionPorMapfre: return "En revisión por Mapfre";
                case PolicyProposalStatus.Alta: return "Alta";
                case PolicyProposalStatus.DeclinadaPorExpiracion: return "Declinada por expiración";
                case PolicyProposalStatus.Rechazada: return "Rechazada";
                default: return "En proceso";
            }
        }

        private static string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) return string.Empty;
            int at = email.IndexOf('@');
            return email.Substring(0, 1) + "***" + email.Substring(at);
        }
    }
}
