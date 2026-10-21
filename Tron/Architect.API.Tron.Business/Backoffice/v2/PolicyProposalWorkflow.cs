using Architect.API.Tron.Contracts;
using Architect.API.Tron.Contracts.AltasBajas.Request;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Architect.API.Tron.Business.InsuredCompletion;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using System;
using RequestPoliza = Architect.API.Tron.Contracts.AltasBajas.Request.Poliza;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Coordina los borradores y las transiciones previas a firma o emisión de solicitudes de póliza.
    /// </summary>
    public static class PolicyProposalWorkflow
    {
        /// <summary>
        /// Guarda un borrador que pertenece al agente o empleado autenticado.
        /// </summary>
        /// <param name="poliza">Datos de la solicitud que se guardará.</param>
        /// <param name="tokenInfo">Contexto autenticado propietario de la compañía y agente.</param>
        /// <returns>Solicitud persistida.</returns>
        public static Contracts.PolicyProposal SaveAgentDraft(RequestPoliza poliza, Core.Contracts.Security.Token tokenInfo)
        {
            if (poliza == null)
            {
                throw new ArgumentNullException(nameof(poliza));
            }

            bool creatingProposal = !poliza.ProposalId.HasValue || poliza.ProposalId.Value <= 0;
            Contracts.PolicyProposal proposal = RetrieveOrCreate(poliza, tokenInfo);
            string proposalData = JsonConvert.SerializeObject(poliza);

            if (proposal.Status == PolicyProposalStatus.Incompleta ||
                proposal.Status == PolicyProposalStatus.PendientePorComplementos)
            {
                if (!DataAccess.PolicyProposal.TrySaveSnapshotAndTransition(
                    proposal.Id,
                    tokenInfo.CompanyId,
                    proposal.Status,
                    proposal.Status,
                    proposalData,
                    tokenInfo.UserId,
                    null))
                {
                    throw new InvalidOperationException("La solicitud cambió antes de guardar el borrador.");
                }
            }
            else
            {
                throw new InvalidOperationException("La solicitud no permite guardar borradores en su estado actual.");
            }

            proposal.ProposalData = proposalData;
            if (creatingProposal)
            {
                PolicyProposalAudit.Create(proposal, tokenInfo, "Solicitud creada", "El agente creó una nueva solicitud de póliza.");
            }
            PolicyProposalAudit.Create(proposal, tokenInfo, "Borrador actualizado", "El agente guardó la solicitud como borrador.");
            return proposal;
        }

        /// <summary>
        /// Guarda un borrador limitado al alcance de la invitación del asegurado.
        /// </summary>
        /// <param name="poliza">Datos que el asegurado puede completar.</param>
        /// <param name="invitationAccess">Alcance validado de la sesión restringida.</param>
        /// <param name="tokenInfo">Contexto técnico creado para la sesión restringida.</param>
        /// <returns>Solicitud actualizada.</returns>
        public static Contracts.PolicyProposal SaveInsuredDraft(
            RequestPoliza poliza,
            InvitationSessionAccess invitationAccess,
            Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = RetrieveInsuredProposal(poliza, invitationAccess);
            RequestPoliza almacenada = DeserializeStoredForm(proposal);
            PolicyProposalInvitationRiskValidator.ValidateInsuredMayNotChangeAgentData(almacenada, poliza);
            PolicyProposalInvitationRiskValidator.PreserveAgentDescriptions(almacenada, poliza);
            PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza);
            string proposalData = JsonConvert.SerializeObject(poliza);

            if (!DataAccess.PolicyProposal.TrySaveSnapshotAndTransition(
                proposal.Id,
                invitationAccess.CompanyId,
                PolicyProposalStatus.PendientePorComplementos,
                PolicyProposalStatus.PendientePorComplementos,
                proposalData,
                tokenInfo.UserId,
                null))
            {
                throw new InvalidOperationException("La solicitud ya no está disponible para guardar datos.");
            }

            proposal.ProposalData = proposalData;
            PolicyProposalAudit.Create(proposal, tokenInfo, "Información del asegurado guardada", "El asegurado invitado guardó la información completada.");
            return proposal;
        }

        /// <summary>
        /// Recupera la instantánea que puede visualizar el asegurado dentro de su única invitación activa.
        /// </summary>
        /// <param name="invitationAccess">Alcance validado de la sesión restringida.</param>
        /// <returns>Datos del formulario sin exponer estado, firma ni información de otras solicitudes.</returns>
        public static RequestPoliza RetrieveInsuredForm(InvitationSessionAccess invitationAccess)
        {
            Contracts.PolicyProposal proposal = RetrieveInsuredProposal(new RequestPoliza(), invitationAccess);
            RequestPoliza form = DeserializeStoredForm(proposal);

            form.ProposalId = proposal.Id;
            return form;
        }

        /// <summary>
        /// Prepara la solicitud para que el agente envíe una invitación de completado al asegurado.
        /// </summary>
        /// <param name="poliza">Datos mínimos de la solicitud.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente o empleado.</param>
        /// <returns>Solicitud en estado pendiente por complementos.</returns>
        public static Contracts.PolicyProposal SendInvitation(RequestPoliza poliza, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = SaveAgentDraft(poliza, tokenInfo);
            if (proposal.Status == PolicyProposalStatus.Incompleta &&
                !DataAccess.PolicyProposal.TryTransition(
                    proposal.Id,
                    tokenInfo.CompanyId,
                    PolicyProposalStatus.Incompleta,
                    PolicyProposalStatus.PendientePorComplementos,
                    tokenInfo.UserId))
            {
                throw new InvalidOperationException("La solicitud cambió antes de enviar la invitación.");
            }

            proposal.Status = PolicyProposalStatus.PendientePorComplementos;
            PolicyProposalAudit.Create(proposal, tokenInfo, "Invitación enviada al asegurado", "La solicitud quedó pendiente de datos del asegurado.");
            return proposal;
        }

        /// <summary>
        /// Congela una solicitud del agente antes de iniciar el envío al proveedor de firma.
        /// </summary>
        /// <param name="poliza">Datos completos de la solicitud.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente o empleado.</param>
        /// <returns>Solicitud en estado pendiente por firma.</returns>
        public static Contracts.PolicyProposal BeginAgentSignature(RequestPoliza poliza, Core.Contracts.Security.Token tokenInfo)
        {
            if (!PolicyProposalSimulationSettings.SignatureSimulationEnabled)
            {
                PolicyProposalSignatureDocument.ValidateTemplate(poliza);
            }

            Contracts.PolicyProposal proposal = SaveAgentDraft(poliza, tokenInfo);
            ValidateForSignature(poliza);
            bool transitioned = DataAccess.PolicyProposal.TryTransition(
                proposal.Id,
                tokenInfo.CompanyId,
                PolicyProposalStatus.Incompleta,
                PolicyProposalStatus.PendientePorFirma,
                tokenInfo.UserId);

            if (!transitioned)
            {
                transitioned = DataAccess.PolicyProposal.TryTransition(
                    proposal.Id,
                    tokenInfo.CompanyId,
                    PolicyProposalStatus.PendientePorComplementos,
                    PolicyProposalStatus.PendientePorFirma,
                    tokenInfo.UserId);
            }

            if (!transitioned)
            {
                throw new InvalidOperationException("La solicitud no está disponible para enviar a firma.");
            }

            DataAccess.PolicyProposalInvitation.RevokeActiveForProposal(tokenInfo.CompanyId, proposal.ProposalId, DateTime.UtcNow);
            proposal.Status = PolicyProposalStatus.PendientePorFirma;
            PolicyProposalAudit.Create(proposal, tokenInfo, "Solicitud preparada para firma", "El agente dejó la solicitud lista para ser enviada al proveedor de firma.");
            return proposal;
        }

        /// <summary>
        /// Guarda los datos definitivos del asegurado, bloquea la solicitud y completa su invitación antes de enviar a firma.
        /// </summary>
        /// <param name="poliza">Datos definitivos entregados por el asegurado.</param>
        /// <param name="invitationAccess">Alcance validado de la sesión restringida.</param>
        /// <param name="tokenInfo">Contexto técnico de la sesión restringida.</param>
        /// <returns>Solicitud congelada y entregada al servicio de firma.</returns>
        public static Contracts.PolicyProposal CompleteInsured(
            RequestPoliza poliza,
            InvitationSessionAccess invitationAccess,
            Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = RetrieveInsuredProposal(poliza, invitationAccess);
            RequestPoliza almacenada = DeserializeStoredForm(proposal);
            PolicyProposalInvitationRiskValidator.ValidateInsuredMayNotChangeAgentData(almacenada, poliza);
            PolicyProposalInvitationRiskValidator.PreserveAgentDescriptions(almacenada, poliza);
            PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza);
            ValidateForSignature(poliza);
            if (!PolicyProposalSimulationSettings.SignatureSimulationEnabled)
            {
                PolicyProposalSignatureDocument.ValidateTemplate(poliza);
            }
            string proposalData = JsonConvert.SerializeObject(poliza);

            using (Session session = new Session("Research"))
            {
                try
                {
                    if (!DataAccess.PolicyProposal.TrySaveSnapshotAndTransition(
                        proposal.Id,
                        invitationAccess.CompanyId,
                        PolicyProposalStatus.PendientePorComplementos,
                        PolicyProposalStatus.PendientePorFirma,
                        proposalData,
                        tokenInfo.UserId,
                        session.dbConnection))
                    {
                        throw new InvalidOperationException("La solicitud cambió antes de confirmar los datos.");
                    }

                    if (!new InvitationStore().CompleteActiveInvitation(invitationAccess, DateTime.UtcNow, session.dbConnection))
                    {
                        throw new InvalidOperationException("La invitación ya no está disponible para confirmar la solicitud.");
                    }

                    session.CommitAndClose();
                }
                catch
                {
                    session.RollbackAndClose();
                    throw;
                }
            }

            proposal.ProposalData = proposalData;
            proposal.Status = PolicyProposalStatus.PendientePorFirma;
            PolicyProposalAudit.Create(proposal, tokenInfo, "Datos confirmados por el asegurado", "El asegurado invitado confirmó los datos definitivos.");
            PolicyProposalSignatureService.DeliverPending(proposal.Id, invitationAccess.CompanyId, tokenInfo);
            return proposal;
        }

        /// <summary>
        /// Verifica y obtiene la solicitud que se emitirá directamente por el agente o empleado.
        /// </summary>
        /// <param name="poliza">Datos completos de la solicitud.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente o empleado.</param>
        /// <returns>Solicitud en estado incompleta o pendiente por complementos lista para emisión.</returns>
        public static Contracts.PolicyProposal PrepareDirectIssue(RequestPoliza poliza, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = SaveAgentDraft(poliza, tokenInfo);
            ValidateForSignature(poliza);
            if (proposal.Status != PolicyProposalStatus.Incompleta &&
                proposal.Status != PolicyProposalStatus.PendientePorComplementos)
            {
                throw new InvalidOperationException("La solicitud no está disponible para emisión directa.");
            }

            return proposal;
        }

        /// <summary>
        /// Recupera la solicitud limitada por la invitación activa del asegurado.
        /// </summary>
        /// <param name="poliza">Datos del formulario que deben corresponder a la propuesta autorizada.</param>
        /// <param name="invitationAccess">Alcance validado de la sesión restringida.</param>
        /// <returns>Solicitud autorizada.</returns>
        private static Contracts.PolicyProposal RetrieveInsuredProposal(RequestPoliza poliza, InvitationSessionAccess invitationAccess)
        {
            if (poliza == null || invitationAccess == null || !invitationAccess.Found ||
                invitationAccess.PolicyProposalId <= 0)
            {
                throw new InvalidOperationException("La invitación no autoriza una solicitud válida.");
            }

            if (poliza.ProposalId.HasValue && poliza.ProposalId.Value != invitationAccess.PolicyProposalId)
            {
                throw new InvalidOperationException("La solicitud indicada no corresponde a la invitación.");
            }

            poliza.ProposalId = invitationAccess.PolicyProposalId;
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.Retrieve(invitationAccess.PolicyProposalId, invitationAccess.CompanyId);
            if (proposal == null || proposal.ProposalId != invitationAccess.ProposalId ||
                proposal.Status != PolicyProposalStatus.PendientePorComplementos)
            {
                throw new InvalidOperationException("La solicitud no está disponible para ser completada.");
            }

            return proposal;
        }

        /// <summary>
        /// Convierte la instantánea persistida de una propuesta en el contrato del formulario sin aceptar contenido ausente o corrupto.
        /// </summary>
        /// <param name="proposal">Propuesta persistida de la invitación autorizada.</param>
        /// <returns>Datos almacenados que sirven como referencia para las operaciones del asegurado.</returns>
        private static RequestPoliza DeserializeStoredForm(Contracts.PolicyProposal proposal)
        {
            RequestPoliza form = proposal == null || string.IsNullOrWhiteSpace(proposal.ProposalData)
                ? null
                : JsonConvert.DeserializeObject<RequestPoliza>(proposal.ProposalData);

            if (form == null)
            {
                throw new InvalidOperationException("La solicitud almacenada no contiene datos válidos para completar.");
            }

            return form;
        }

        /// <summary>
        /// Recupera una solicitud existente de la compañía o crea su primer borrador.
        /// </summary>
        /// <param name="poliza">Datos de solicitud suministrados por el agente.</param>
        /// <param name="tokenInfo">Contexto autenticado del agente o empleado.</param>
        /// <returns>Solicitud existente o recién creada.</returns>
        private static Contracts.PolicyProposal RetrieveOrCreate(RequestPoliza poliza, Core.Contracts.Security.Token tokenInfo)
        {
            if (poliza.ProposalId.HasValue && poliza.ProposalId.Value > 0)
            {
                Contracts.PolicyProposal existing = DataAccess.PolicyProposal.Retrieve(poliza.ProposalId.Value, tokenInfo.CompanyId);
                if (existing == null)
                {
                    throw new InvalidOperationException("La solicitud indicada no existe en la compañía actual.");
                }

                return existing;
            }

            // Se conserva temporalmente la asignación histórica hasta liberar la secuencia de Oracle en un cambio separado.
            int id = DataAccess.PolicyProposal.RetrieveLastKey() + 1;
            poliza.ProposalId = id;
            string proposalId = PolicyProposalIdentifier.Create(poliza.RAMO, id);
            Contracts.PolicyProposal proposal = new Contracts.PolicyProposal
            {
                Id = id,
                CompanyId = tokenInfo.CompanyId,
                AgentCode = tokenInfo.AgentCode,
                BranchCode = poliza.RAMO > 0 ? (int?)poliza.RAMO : null,
                ProposalId = proposalId,
                InsuredId = poliza.COD_DOCUM_ASEG,
                InsuredName = poliza.NOM_TERCERO_ASEG.CompleteFullName(poliza.APE_TERCERO_ASEG),
                Summary = "Solicitud de póliza pendiente de completar.",
                IssueDate = DateTime.Now,
                ProposalData = JsonConvert.SerializeObject(poliza),
                SigningType = "F",
                PrimaryEmailAddress = poliza.EMAIL_ASEG,
                SigningRequestId = string.Empty,
                SigningRequest2Id = string.Empty,
                PolicyId = string.Empty,
                Status = PolicyProposalStatus.Incompleta,
                UpdateUserCode = tokenInfo.UserId
            };

            DataAccess.PolicyProposal.Create(proposal);
            return proposal;
        }

        /// <summary>
        /// Valida los datos comunes sin los cuales no puede generarse un documento identificable para firma ni emitirse la póliza.
        /// Las reglas particulares de cada ramo permanecen en el formulario y en el procedimiento de emisión heredado.
        /// </summary>
        /// <param name="poliza">Solicitud que se congelará o emitirá.</param>
        private static void ValidateForSignature(RequestPoliza poliza)
        {
            if (poliza == null ||
                poliza.RAMO <= 0 ||
                string.IsNullOrWhiteSpace(poliza.COD_DOCUM_ASEGType) ||
                string.IsNullOrWhiteSpace(poliza.COD_DOCUM_ASEG) ||
                string.IsNullOrWhiteSpace(poliza.NOM_TERCERO_ASEG) ||
                string.IsNullOrWhiteSpace(poliza.APE_TERCERO_ASEG) ||
                string.IsNullOrWhiteSpace(poliza.EMAIL_ASEG) ||
                string.IsNullOrWhiteSpace(poliza.TLF_NUMERO_ASEG) ||
                poliza.NAC_ASEG == DateTime.MinValue)
            {
                throw new InvalidOperationException("Debe completar los datos personales obligatorios antes de enviar la solicitud a firma o emitirla.");
            }

            if (poliza.Beneficiarios != null && poliza.Beneficiarios.Exists(beneficiario =>
                string.IsNullOrWhiteSpace(beneficiario.COD_DOCUM_BENEFType) ||
                string.IsNullOrWhiteSpace(beneficiario.COD_DOCUM_BENEF) ||
                string.IsNullOrWhiteSpace(beneficiario.NOM_TERCERO_BENEF) ||
                string.IsNullOrWhiteSpace(beneficiario.APE1_TERCERO_BENEF) ||
                beneficiario.PCT_PARTICIPACION <= 0 ||
                beneficiario.FEC_NAC_BENEF == DateTime.MinValue))
            {
                throw new InvalidOperationException("Debe completar los datos obligatorios de cada beneficiario antes de continuar.");
            }
        }
    }
}
