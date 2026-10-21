using Architect.API.Tron.Contracts;
using Architect.Utilities;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using RequestPoliza = Architect.API.Tron.Contracts.AltasBajas.Request.Poliza;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Revisa solicitudes pendientes de firma, conserva el documento firmado y emite automáticamente las solicitudes confirmadas.
    /// Reutiliza la misma configuración de compañías y frecuencia del monitor de Evicertia existente.
    /// </summary>
    public static class PolicyProposalSignatureMonitor
    {
        /// <summary>Usuario técnico trazable responsable de las transiciones automáticas del monitor.</summary>
        private const int TechnicalUserId = 666;

        /// <summary>
        /// Ejecuta una revisión completa para las compañías configuradas para el portal de agentes de Tron.
        /// Cada solicitud se procesa de forma aislada para que una falla externa no detenga las demás.
        /// </summary>
        public static void Run()
        {
            foreach (int companyId in RetrieveCompanyIds())
            {
                ProcessPendingDeliveries(companyId);
                ProcessSignatureReplies(companyId);
                ProcessPendingIssuance(companyId);
            }
        }

        /// <summary>
        /// Reintenta las solicitudes congeladas que aún no pudieron ser aceptadas por el proveedor de firma.
        /// </summary>
        /// <param name="companyId">Compañía propietaria de las solicitudes.</param>
        private static void ProcessPendingDeliveries(int companyId)
        {
            foreach (Contracts.PolicyProposal proposal in DataAccess.PolicyProposal.RetrieveByStatus(companyId, PolicyProposalStatus.PendientePorFirma))
            {
                try
                {
                    PolicyProposalSignatureService.DeliverPending(proposal.Id, companyId, CreateTechnicalToken(companyId));
                }
                catch (Exception exception)
                {
                    Log.ErrorLog("PolicyProposalSignatureMonitor", "No fue posible entregar la solicitud " + proposal.Id + " a firma.", exception);
                }
            }
        }

        /// <summary>
        /// Consulta Evicertia para cada solicitud aceptada y aplica únicamente la transición que corresponda a su respuesta.
        /// </summary>
        /// <param name="companyId">Compañía propietaria de las solicitudes.</param>
        private static void ProcessSignatureReplies(int companyId)
        {
            foreach (Contracts.PolicyProposal proposal in DataAccess.PolicyProposal.RetrieveByStatus(companyId, PolicyProposalStatus.PorAceptar))
            {
                try
                {
                    if (PolicyProposalSimulationSettings.IsSimulatedSignature(proposal.SigningRequestId))
                    {
                        ProcessSimulatedSignature(proposal, companyId);
                        continue;
                    }

                    DocuSign.Integrations.Contracts.QueryResult signature = Architect.DocuSign.Integrations.DocuSign
                        .Query(proposal.SigningRequestId, true)
                        .GetAwaiter()
                        .GetResult();

                    if (signature == null)
                    {
                        continue;
                    }

                    switch (signature.outcome)
                    {
                        case "Signed":
                            StoreSignedDocument(proposal, signature, companyId);
                            if (DataAccess.PolicyProposal.TryTransition(
                                proposal.Id,
                                companyId,
                                PolicyProposalStatus.PorAceptar,
                                PolicyProposalStatus.ParaEmitir,
                                TechnicalUserId,
                                proposal.SigningRequestId))
                            {
                                PolicyProposalAudit.Create(proposal, CreateTechnicalToken(companyId), "Firma completada", "El monitor confirmó la firma electrónica.");
                            }
                            break;

                        case "Expired":
                            if (DataAccess.PolicyProposal.TryTransition(
                                proposal.Id,
                                companyId,
                                PolicyProposalStatus.PorAceptar,
                                PolicyProposalStatus.DeclinadaPorExpiracion,
                                TechnicalUserId,
                                proposal.SigningRequestId))
                            {
                                PolicyProposalAudit.Create(proposal, CreateTechnicalToken(companyId), "Firma vencida", "El monitor informó el vencimiento de la firma electrónica.");
                            }
                            break;

                        case "Rejected":
                            if (DataAccess.PolicyProposal.TryTransition(
                                proposal.Id,
                                companyId,
                                PolicyProposalStatus.PorAceptar,
                                PolicyProposalStatus.Rechazada,
                                TechnicalUserId,
                                proposal.SigningRequestId))
                            {
                                PolicyProposalAudit.Create(proposal, CreateTechnicalToken(companyId), "Firma rechazada", "El monitor informó el rechazo de la firma electrónica.");
                            }
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Log.ErrorLog("PolicyProposalSignatureMonitor", "No fue posible revisar la firma de la solicitud " + proposal.Id + ".", exception);
                }
            }
        }

        /// <summary>
        /// Reclama y emite las solicitudes firmadas que pertenecen al contrato de altas y bajas.
        /// Las demás propuestas conservan su ciclo heredado aunque compartan la tabla PolicyProposal.
        /// </summary>
        /// <param name="companyId">Compañía propietaria de las solicitudes.</param>
        private static void ProcessPendingIssuance(int companyId)
        {
            foreach (Contracts.PolicyProposal candidate in DataAccess.PolicyProposal.RetrieveByStatus(companyId, PolicyProposalStatus.ParaEmitir))
            {
                try
                {
                    Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.Retrieve(candidate.Id, companyId);
                    if (!IsAltasBajasProposal(proposal))
                    {
                        continue;
                    }

                    bool simulatedSignature = PolicyProposalSimulationSettings.IsSimulatedSignature(proposal.SigningRequestId);
                    if (simulatedSignature && !PolicyProposalSimulationSettings.SignatureSimulationEnabled)
                    {
                        PolicyProposalAudit.Create(proposal, CreateTechnicalToken(companyId), "Emisión simulada pendiente", "La firma simulada no puede activar la emisión real; habilite la simulación de firma para continuar localmente.");
                        continue;
                    }

                    if (!DataAccess.PolicyProposal.TryTransition(
                            proposal.Id,
                            companyId,
                            PolicyProposalStatus.ParaEmitir,
                            PolicyProposalStatus.EnRevisionPorMapfre,
                            TechnicalUserId))
                    {
                        continue;
                    }

                    if (simulatedSignature)
                    {
                        CompleteSimulatedIssue(proposal, companyId);
                        continue;
                    }

                    RequestPoliza poliza = JsonConvert.DeserializeObject<RequestPoliza>(proposal.ProposalData);
                    Contracts.AltasBajas.Response.Poliza issued = AltasBajasPoliza.EmitirPropuesta(poliza, true);
                    if (issued != null && (issued.ID_TIP_RESPUESTA == 1 || issued.ID_TIP_RESPUESTA == 2))
                    {
                        if (DataAccess.PolicyProposal.TryTransition(
                            proposal.Id,
                            companyId,
                            PolicyProposalStatus.EnRevisionPorMapfre,
                            PolicyProposalStatus.Alta,
                            TechnicalUserId,
                            null,
                            issued.NUM_POLIZA))
                        {
                            PolicyProposalAudit.Create(proposal, CreateTechnicalToken(companyId), "Póliza emitida", "El monitor emitió la póliza después de validar la firma.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.ErrorLog("PolicyProposalSignatureMonitor", "No fue posible emitir la solicitud firmada " + candidate.Id + ".", exception);
                    PolicyProposalAudit.Create(candidate, CreateTechnicalToken(companyId), "Error de emisión", "El monitor no pudo completar la emisión automática.");
                }
            }
        }

        /// <summary>
        /// Confirma localmente una firma simulada sin consultar el proveedor ni almacenar un documento inexistente.
        /// </summary>
        private static void ProcessSimulatedSignature(Contracts.PolicyProposal proposal, int companyId)
        {
            if (!PolicyProposalSimulationSettings.SignatureSimulationEnabled)
            {
                return;
            }

            if (DataAccess.PolicyProposal.TryTransition(
                proposal.Id,
                companyId,
                PolicyProposalStatus.PorAceptar,
                PolicyProposalStatus.ParaEmitir,
                TechnicalUserId,
                proposal.SigningRequestId))
            {
                PolicyProposalAudit.Create(proposal, CreateTechnicalToken(companyId), "Firma simulada completada", "El monitor local confirmó la firma simulada sin consultar al proveedor externo.");
            }
        }

        /// <summary>
        /// Completa una emisión local de una propuesta ya identificada como firma simulada.
        /// </summary>
        private static void CompleteSimulatedIssue(Contracts.PolicyProposal proposal, int companyId)
        {
            string simulatedPolicyId = PolicyProposalSimulationSettings.CreateSimulatedPolicyId(proposal.Id);
            if (DataAccess.PolicyProposal.TryTransition(
                proposal.Id,
                companyId,
                PolicyProposalStatus.EnRevisionPorMapfre,
                PolicyProposalStatus.Alta,
                TechnicalUserId,
                null,
                simulatedPolicyId))
            {
                PolicyProposalAudit.Create(proposal, CreateTechnicalToken(companyId), "Póliza emitida en simulación", "El monitor local completó la emisión sin invocar el servicio real de pólizas.");
            }
        }

        /// <summary>
        /// Almacena el primer documento firmado informado por Evicertia antes de habilitar la emisión automática.
        /// </summary>
        /// <param name="proposal">Solicitud cuya firma fue confirmada.</param>
        /// <param name="signature">Respuesta de Evicertia con los documentos de firma.</param>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        private static void StoreSignedDocument(
            Contracts.PolicyProposal proposal,
            DocuSign.Integrations.Contracts.QueryResult signature,
            int companyId)
        {
            DocuSign.Integrations.Contracts.affidavits affidavit = signature.affidavits == null
                ? null
                : signature.affidavits.FirstOrDefault(item => item.Signed);
            if (affidavit == null || string.IsNullOrWhiteSpace(affidavit.bytes))
            {
                throw new InvalidOperationException("Evicertia confirmó la firma sin incluir un documento firmado.");
            }

            Architect.API.Tron.Business.Emision.Solicitud.Almacena_Documento_Firmado(
                proposal.ProposalId,
                affidavit.bytes,
                companyId,
                TechnicalUserId);
        }

        /// <summary>
        /// Determina si la instantánea pertenece al contrato de altas y bajas creado por este mecanismo.
        /// </summary>
        /// <param name="proposal">Solicitud almacenada.</param>
        /// <returns><c>true</c> cuando contiene el identificador interno de solicitud del contrato de altas.</returns>
        private static bool IsAltasBajasProposal(Contracts.PolicyProposal proposal)
        {
            return proposal != null && !string.IsNullOrWhiteSpace(proposal.ProposalData) &&
                proposal.ProposalData.Contains("\"ProposalId\"");
        }

        /// <summary>
        /// Obtiene las compañías ya configuradas para el monitor de solicitudes de Tron.
        /// </summary>
        /// <returns>Identificadores de compañías válidos y sin repeticiones.</returns>
        private static IEnumerable<int> RetrieveCompanyIds()
        {
            string configuredCompanies = Architect.Utilities.Helpers.Settings.StringValue("PolicyProposal.Request.Tenant.Review");
            return (configuredCompanies ?? string.Empty)
                .Split(',')
                .Select(value =>
                {
                    int.TryParse(value, out int companyId);
                    return companyId;
                })
                .Where(companyId => companyId > 0)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Construye el contexto mínimo utilizado por el reintento de entrega a firma.
        /// </summary>
        /// <param name="companyId">Compañía propietaria de la solicitud.</param>
        /// <returns>Contexto técnico trazable para la entrega automática.</returns>
        private static Core.Contracts.Security.Token CreateTechnicalToken(int companyId)
        {
            return new Core.Contracts.Security.Token
            {
                CompanyId = companyId,
                UserId = TechnicalUserId,
                Roles = string.Empty
            };
        }
    }
}
