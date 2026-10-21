using Architect.API.Tron.Contracts;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using System;
using RequestPoliza = Architect.API.Tron.Contracts.AltasBajas.Request.Poliza;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Entrega una solicitud congelada al proveedor de firma y registra su identificador externo.
    /// </summary>
    internal static class PolicyProposalSignatureService
    {
        /// <summary>
        /// Genera y entrega a firma una solicitud previamente congelada en estado pendiente por firma.
        /// </summary>
        /// <param name="proposalId">Identificador NUMBER(9) de la solicitud.</param>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <param name="tokenInfo">Contexto del agente, empleado o sesión técnica que inició el envío.</param>
        internal static void DeliverPending(int proposalId, int companyId, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.Retrieve(proposalId, companyId);
            if (proposal == null || proposal.Status != PolicyProposalStatus.PendientePorFirma)
            {
                throw new InvalidOperationException("La solicitud no está disponible para entregarse a firma.");
            }

            RequestPoliza poliza = JsonConvert.DeserializeObject<RequestPoliza>(proposal.ProposalData);
            if (poliza == null || string.IsNullOrWhiteSpace(poliza.EMAIL_ASEG))
            {
                throw new InvalidOperationException("La solicitud no contiene el correo requerido para firma.");
            }

            if (PolicyProposalSimulationSettings.SignatureSimulationEnabled)
            {
                RegisterSubmittedProposal(
                    proposal,
                    companyId,
                    tokenInfo,
                    PolicyProposalSimulationSettings.CreateSimulatedSigningRequestId(proposal.Id),
                    "Solicitud simulada enviada a firma electrónica",
                    "La simulación local omitió la generación del PDF y el proveedor de firma.");
                return;
            }

            string pdfPath = PolicyProposalSignatureDocument.Generate(poliza, tokenInfo);
            Architect.API.Tron.Business.Emision.Solicitud.Almacena_PDF(
                proposal.ProposalId,
                pdfPath,
                "Solicitud " + proposal.ProposalId + ".pdf",
                98,
                "Solicitud enviada a firma",
                companyId,
                tokenInfo.UserId);

            DocuSign.Integrations.Contracts.SubmitResult submit = Architect.DocuSign.Integrations.DocuSign.Submit(
                proposal.ProposalId,
                "Solicitud de seguro " + proposal.ProposalId,
                poliza.NOM_TERCERO_ASEG.CompleteFullName(poliza.APE_TERCERO_ASEG),
                poliza.EMAIL_ASEG,
                pdfPath,
                "WebClick").GetAwaiter().GetResult();

            if (submit == null || string.IsNullOrWhiteSpace(submit.UniqueId))
            {
                throw new InvalidOperationException("Evicertia no devolvió un identificador de firma.");
            }

            RegisterSubmittedProposal(
                proposal,
                companyId,
                tokenInfo,
                submit.UniqueId,
                "Solicitud enviada a firma electrónica",
                "La solicitud fue aceptada por el proveedor de firma.");
        }

        /// <summary>
        /// Registra la aceptación de una solicitud por el proveedor real o por la simulación local.
        /// </summary>
        private static void RegisterSubmittedProposal(
            Contracts.PolicyProposal proposal,
            int companyId,
            Core.Contracts.Security.Token tokenInfo,
            string signingRequestId,
            string auditAction,
            string auditDetail)
        {
            if (!DataAccess.PolicyProposal.TryTransition(
                proposal.Id,
                companyId,
                PolicyProposalStatus.PendientePorFirma,
                PolicyProposalStatus.PorAceptar,
                tokenInfo.UserId,
                signingRequestId))
            {
                throw new InvalidOperationException("No fue posible registrar la solicitud enviada a firma.");
            }

            proposal.Status = PolicyProposalStatus.PorAceptar;
            proposal.SigningRequestId = signingRequestId;
            PolicyProposalAudit.Create(proposal, tokenInfo, auditAction, auditDetail);
        }
    }
}
