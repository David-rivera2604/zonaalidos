using Architect.API.Core.Business.General;
using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Insurance.Contracts.ManualPolicies;
using Architect.API.Insurance.Contracts.Policy;
using Architect.API.Tron.Business.InsuredCompletion;
using Architect.API.Tron.Contracts.InsuredCompletion;
using Architect.API.Tron.DataAccess.Pagos;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Payment.Integrations.Contracts.v2;
using Architect.Utilities.Extensions;
using Microsoft.Win32;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Coordina la emisión y cancelación heredadas de pólizas, y el almacenamiento de una propuesta antes del completado por asegurado.
    /// </summary>
    public class AltasBajasPoliza
    {

        /// <summary>
        /// Ejecuta la operación explícita seleccionada para una solicitud de alta o baja.
        /// Un alta <c>SendLink</c> guarda la propuesta y emite únicamente una invitación restringida de completado; nunca emite una póliza.
        /// </summary>
        /// <param name="poliza">Datos heredados de póliza suministrados por el flujo del agente autenticado.</param>
        /// <param name="alta">Indica si la solicitud es un alta en lugar de una cancelación.</param>
        /// <param name="tokenInfo">Contexto del empleado o agente autenticado que posee la propuesta almacenada.</param>
        /// <param name="invitationAccess">Alcance interno de invitación validado cuando la solicitud proviene del asegurado.</param>
        /// <returns>Resultado de la operación y, para acciones previas a emisión, el identificador de solicitud en <c>NUM_POLIZA</c>.</returns>
        public static Task<Contracts.AltasBajas.Response.Poliza> AltasBajas(
            Contracts.AltasBajas.Request.Poliza poliza,
            bool alta,
            Core.Contracts.Security.Token tokenInfo,
            InvitationSessionAccess invitationAccess = null)
        {
            if (poliza == null)
            {
                throw new ArgumentNullException(nameof(poliza));
            }

            AltasBajasOperation operation = AltasBajasOperationResolver.Resolve(alta, poliza.modo);
            if (invitationAccess != null && invitationAccess.Found)
            {
                return Task.FromResult(ExecuteInsuredOperation(operation, poliza, tokenInfo, invitationAccess));
            }

            return Task.FromResult(ExecuteAgentOperation(operation, poliza, alta, tokenInfo));
        }

        /// <summary>
        /// Persiste la propuesta propiedad del agente y envía a su asegurado una capacidad opaca de completado basada solo en hash.
        /// Exige correo válido y el riesgo mínimo del ramo antes de persistir o enviar; la respuesta omite el enlace y el secreto.
        /// </summary>
        /// <param name="poliza">Datos de propuesta que se almacenarán antes de emitir la invitación.</param>
        /// <param name="tokenInfo">Propietario autenticado de la propuesta e identidad remitente del correo.</param>
        /// <returns>Respuesta de éxito sin secretos para el flujo del agente.</returns>
        private static Contracts.AltasBajas.Response.Poliza SendLink(Contracts.AltasBajas.Request.Poliza poliza, Core.Contracts.Security.Token tokenInfo)
        {
            PolicyProposalInvitationRiskValidator.ValidateForInvitation(poliza);

            Contracts.PolicyProposal proposal = PolicyProposalWorkflow.SendInvitation(poliza, tokenInfo);
            InvitationService invitationService = CreateInvitationService();
            invitationService.CreateOrResend(new CreateInvitationRequest
            {
                CompanyId = tokenInfo.CompanyId,
                PolicyProposalId = proposal.Id,
                ProposalId = proposal.ProposalId,
                RecipientEmail = poliza.EMAIL_ASEG,
                UserId = tokenInfo.UserId,
                OwnerId = tokenInfo.UserId,
                CompletionPath = "/form/EmitirPoliza?proposal=" + proposal.ProposalId,
                CompletionFlow = CompletionFlow.PolicyProposal
            });

            return CreateWorkflowResponse(proposal, "La invitación para completar la solicitud fue enviada.");
        }

        /// <summary>
        /// Ejecuta las operaciones permitidas al agente o empleado autenticado.
        /// </summary>
        /// <param name="operation">Acción solicitada por el formulario.</param>
        /// <param name="poliza">Datos de la solicitud.</param>
        /// <param name="alta">Indica si corresponde una emisión o una baja heredada.</param>
        /// <param name="tokenInfo">Contexto del agente o empleado autenticado.</param>
        /// <returns>Resultado de la operación.</returns>
        private static Contracts.AltasBajas.Response.Poliza ExecuteAgentOperation(
            AltasBajasOperation operation,
            Contracts.AltasBajas.Request.Poliza poliza,
            bool alta,
            Core.Contracts.Security.Token tokenInfo)
        {
            switch (operation)
            {
                case AltasBajasOperation.Draft:
                    return CreateWorkflowResponse(
                        PolicyProposalWorkflow.SaveAgentDraft(poliza, tokenInfo),
                        "El borrador de la solicitud fue guardado.");

                case AltasBajasOperation.SendInvitation:
                    return SendLink(poliza, tokenInfo);

                case AltasBajasOperation.SendSignature:
                    Contracts.PolicyProposal signatureProposal = PolicyProposalWorkflow.BeginAgentSignature(poliza, tokenInfo);
                    PolicyProposalSignatureService.DeliverPending(signatureProposal.Id, tokenInfo.CompanyId, tokenInfo);
                    return CreateWorkflowResponse(signatureProposal, "La solicitud fue enviada a firma electrónica.");

                case AltasBajasOperation.Issue:
                    Contracts.PolicyProposal directProposal = PolicyProposalWorkflow.PrepareDirectIssue(poliza, tokenInfo);
                    if (PolicyProposalSimulationSettings.SignatureSimulationEnabled)
                    {
                        Contracts.AltasBajas.Response.Poliza simulatedIssued = new Contracts.AltasBajas.Response.Poliza
                        {
                            ID_TIP_RESPUESTA = 1,
                            NUM_POLIZA = PolicyProposalSimulationSettings.CreateSimulatedPolicyId(directProposal.Id),
                            OBSERVACION = "La póliza fue emitida mediante la simulación local."
                        };

                        UpdateIssuedProposal(directProposal, tokenInfo, simulatedIssued, "Póliza emitida en simulación", "El agente completó la emisión local sin invocar el servicio real de pólizas.");
                        return simulatedIssued;
                    }

                    Contracts.AltasBajas.Response.Poliza issued;
                    try
                    {
                        issued = EmitirPropuesta(poliza, true);
                    }
                    catch
                    {
                        PolicyProposalAudit.Create(directProposal, tokenInfo, "Error de emisión", "La emisión directa no pudo completarse.");
                        throw;
                    }

                    if (issued == null || (issued.ID_TIP_RESPUESTA != 1 && issued.ID_TIP_RESPUESTA != 2))
                    {
                        PolicyProposalAudit.Create(directProposal, tokenInfo, "Error de emisión", "La emisión directa no fue confirmada por el sistema de emisión.");
                    }
                    UpdateIssuedProposal(directProposal, tokenInfo, issued, "Póliza emitida", "El agente emitió la póliza sin firma electrónica.");
                    return issued;

                case AltasBajasOperation.Cancel:
                    return EmitirPropuesta(poliza, false);

                default:
                    throw new InvalidOperationException("La operación solicitada no está disponible para el agente.");
            }
        }

        /// <summary>
        /// Ejecuta exclusivamente las acciones permitidas al asegurado mediante una invitación validada.
        /// </summary>
        /// <param name="operation">Acción solicitada por el formulario.</param>
        /// <param name="poliza">Datos de la solicitud autorizada.</param>
        /// <param name="tokenInfo">Contexto técnico de la sesión restringida.</param>
        /// <param name="invitationAccess">Alcance inmutable de compañía y solicitud de la invitación.</param>
        /// <returns>Resultado de guardar o confirmar la información.</returns>
        private static Contracts.AltasBajas.Response.Poliza ExecuteInsuredOperation(
            AltasBajasOperation operation,
            Contracts.AltasBajas.Request.Poliza poliza,
            Core.Contracts.Security.Token tokenInfo,
            InvitationSessionAccess invitationAccess)
        {
            switch (operation)
            {
                case AltasBajasOperation.Draft:
                    return CreateWorkflowResponse(
                        PolicyProposalWorkflow.SaveInsuredDraft(poliza, invitationAccess, tokenInfo),
                        "El borrador de la solicitud fue guardado.");

                case AltasBajasOperation.Complete:
                    return CreateWorkflowResponse(
                        PolicyProposalWorkflow.CompleteInsured(poliza, invitationAccess, tokenInfo),
                        "La solicitud fue confirmada y enviada a firma electrónica.");

                default:
                    throw new InvalidOperationException("La invitación solo permite guardar o confirmar la información de la solicitud.");
            }
        }

        /// <summary>
        /// Compone el mecanismo de invitación con la URL pública ya administrada por la aplicación.
        /// Esto evita duplicar la configuración de origen utilizada por el portal de agentes y por el enlace de correo.
        /// </summary>
        /// <returns>Servicio de invitación limitado para la ruta heredada de envío de enlace.</returns>
        private static InvitationService CreateInvitationService()
        {
            string portalBaseUrl = ConfigurationManager.AppSettings["Aliados.URL.Base"];
            if (string.IsNullOrWhiteSpace(portalBaseUrl))
            {
                throw new ConfigurationErrorsException("Debe configurar Aliados.URL.Base antes de enviar invitaciones.");
            }

            return new InvitationService(
                new InvitationStore(),
                new InvitationMailSender(),
                () => DateTime.UtcNow,
                InvitationSecret.Generate,
                portalBaseUrl);
        }

        /// <summary>
        /// Emite o cancela una póliza mediante el procedimiento almacenado heredado después de que el resolvedor de operación selecciona esa ruta.
        /// La invitación del asegurado se completa antes de firma, por lo que la emisión no modifica su ciclo de acceso.
        /// </summary>
        internal static Contracts.AltasBajas.Response.Poliza EmitirPropuesta(
            Contracts.AltasBajas.Request.Poliza poliza,
            bool alta)
        {
            Contracts.AltasBajas.Request.SPCall sp = new Contracts.AltasBajas.Request.SPCall()
            {
                NUM_POLIZA_GRUPO = poliza.NUM_POLIZA_GRUPO,
                NUM_CONTRATO = poliza.NUM_CONTRATO,
                RAMO = poliza.RAMO,
                TIP_DOCUM_ASEG = poliza.COD_DOCUM_ASEGType.IdentificationType(),
                COD_DOCUM_ASEG = poliza.COD_DOCUM_ASEG.DocumentNumber(poliza.COD_DOCUM_ASEGType),
                NOM_TERCERO_ASEG = poliza.NOM_TERCERO_ASEG,
                APE_TERCERO_ASEG = poliza.APE_TERCERO_ASEG,
                MCA_SEXO_ASEG = poliza.MCA_SEXO_ASEG == "1" ? "M" : "F",
                NACIONALIDAD_ASEG = poliza.NACIONALIDAD_ASEG,
                COD_ESTADO = poliza.COD_ESTADO,
                COD_PROVINCIA = poliza.COD_PROVINCIA,
                COD_LOCALIDAD = poliza.COD_LOCALIDAD,
                DOMICILIO = poliza.DOMICILIO,
                NUM_PRESTAMO = poliza.NUM_PRESTAMO,
                IMP_SUMA_ASEG = poliza.IMP_SUMA_ASEG,
                IMP_SUM_ASEG_VC = poliza.IMP_SUM_ASEG_VC,
                IMP_PRIMA_FACT = poliza.IMP_PRIMA_FACT == 0 ? null : poliza.IMP_PRIMA_FACT,
                IMP_PRIMA_INFORMADA = poliza.IMP_PRIMA_INFORMADA,
                ID_CRED_ESTUDIANTE = poliza.ID_CRED_ESTUDIANTE,
                MCA_ASISTENCIA = poliza.MCA_ASISTENCIA,
                IMP_SUMA_MUERTE = poliza.IMP_SUMA_MUERTE,
                FEC_EFEC_SPTO = poliza.EFEC_SPTO.ToString("dd/MM/yyyy"),
                FEC_VCTO_SPTO = poliza.VCTO_SPTO.ToString("dd/MM/yyyy"),
                FEC_NAC_ASEG = poliza.NAC_ASEG.ToString("dd/MM/yyyy"),
                FEC_INI_PRESTAMO = poliza.INI_PRESTAMO.ToString("dd/MM/yyyy"),
                FEC_VCTO_PRESTAMO = poliza.VCTO_PRESTAMO.ToString("dd/MM/yyyy"),
                COD_PLAN_AP = poliza.COD_PLAN_AP,
                TIP_DE_PROCESO = alta ? "N" : "A",
                OCUPACION_ASEG = poliza.OCUPACION_ASEG,
                TLF_NUMERO_ASEG = poliza.TLF_NUMERO_ASEG,
                EMAIL_ASEG = poliza.EMAIL_ASEG,
                BENEFICIARIOS = poliza.Beneficiarios?.Select(b => new Contracts.AltasBajas.Request.SPCallBeneficiario
                {
                    TIP_DOCUM_BENEF = b.COD_DOCUM_BENEFType.IdentificationType(),
                    COD_DOCUM_BENEF = b.COD_DOCUM_BENEF.DocumentNumber(b.COD_DOCUM_BENEFType),
                    NOM_TERCERO_BENEF = b.NOM_TERCERO_BENEF,
                    NOM2_TERCERO_BENEF = b.NOM2_TERCERO_BENEF,
                    APE1_TERCERO_BENEF = b.APE1_TERCERO_BENEF,
                    APE2_TERCERO_BENEF = b.APE2_TERCERO_BENEF,
                    TIP_BENEF = 15,
                    PCT_PARTICIPACION = b.PCT_PARTICIPACION,
                    TIP_RELAC = b.TIP_RELAC,
                    MCA_SEXO_BENEF = b.MCA_SEXO_BENEF,
                    PROVINCIA_BENEF = b.PROVINCIA_BENEF,
                    LOCALIDAD_BENEF = b.LOCALIDAD_BENEF,
                    TLF_NUMERO_BENEF = b.TLF_NUMERO_BENEF,
                    EMAIL_BENEF = b.EMAIL_BENEF,
                    FEC_NAC_BENEF = b.FEC_NAC_BENEF.ToString("ddMMyyyy")
                }).ToList()
            };


            string json = JsonConvert.SerializeObject(sp);
            string resultjson = DataAccess.PorRamo.EM_K_ALTA_BAJA_POLIZA_WEB_MCR(json);

            return JsonConvert.DeserializeObject<Contracts.AltasBajas.Response.Poliza>(resultjson);
        }

        /// <summary>
        /// Construye una respuesta compatible con el contrato heredado para acciones que todavía no emiten una póliza.
        /// </summary>
        /// <param name="proposal">Solicitud persistida sobre la que se realizó la acción.</param>
        /// <param name="message">Descripción legible de la acción completada.</param>
        /// <returns>Respuesta exitosa con el identificador NUMBER(9) de la solicitud.</returns>
        private static Contracts.AltasBajas.Response.Poliza CreateWorkflowResponse(
            Contracts.PolicyProposal proposal,
            string message)
        {
            return new Contracts.AltasBajas.Response.Poliza
            {
                ID_TIP_RESPUESTA = 1,
                NUM_POLIZA = proposal.Id.ToString(),
                OBSERVACION = message,
                ERROR = string.Empty
            };
        }

        /// <summary>
        /// Registra la emisión directa solo si el procedimiento heredado confirmó el alta.
        /// </summary>
        /// <param name="proposal">Solicitud que originó la emisión.</param>
        /// <param name="tokenInfo">Usuario responsable de la emisión.</param>
        /// <param name="issued">Respuesta del procedimiento almacenado de emisión.</param>
        private static void UpdateIssuedProposal(
            Contracts.PolicyProposal proposal,
            Core.Contracts.Security.Token tokenInfo,
            Contracts.AltasBajas.Response.Poliza issued,
            string auditAction,
            string auditDetail)
        {
            if (issued == null || (issued.ID_TIP_RESPUESTA != 1 && issued.ID_TIP_RESPUESTA != 2))
            {
                return;
            }

            if (!DataAccess.PolicyProposal.TryTransition(
                proposal.Id,
                tokenInfo.CompanyId,
                proposal.Status,
                Contracts.PolicyProposalStatus.Alta,
                tokenInfo.UserId,
                null,
                issued.NUM_POLIZA))
            {
                throw new InvalidOperationException("La póliza fue emitida, pero la solicitud cambió antes de registrar su resultado.");
            }

            DataAccess.PolicyProposalInvitation.RevokeActiveForProposal(
                tokenInfo.CompanyId,
                proposal.ProposalId,
                DateTime.UtcNow);

            proposal.Status = Contracts.PolicyProposalStatus.Alta;
            PolicyProposalAudit.Create(proposal, tokenInfo, auditAction, auditDetail);
        }

    }
}
