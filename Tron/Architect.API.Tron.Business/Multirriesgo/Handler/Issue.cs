using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Architect.API.Core.Business.General;
using Architect.API.Core.Contracts;
using Newtonsoft.Json;

namespace Architect.API.Tron.Business.Multirriesgo.Handler
{
    public static class Issue
    {
        /// <summary>
        /// Prepara la información inicial la para la preparación de una póliza.
        /// </summary>
        public static Contracts.Emision.Multirriesgo Setup(string presupuesto, string mode, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.Multirriesgo result = null;
            bool tryOnTron = false;
            string key = string.Format("multirriesgo.{0}", presupuesto);

            if (mode == "continue")
            {
                Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);
                if (proposal != null)
                {
                    Utilities.Cache.SetItem(key, proposal.ProposalData, -1);
                }
                else
                {
                    tryOnTron = true;
                }
            }
            if (mode == "resume" || tryOnTron)
            {
                //Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);

                Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, presupuesto, 0, 0, 0, null, true);
                Contracts.Cotizacion.Multirriesgo resultInfo2 = Convert.PresupuestoToQuote.Quote(Convert.PresupuestoToQuote.Quote(P30Instance), P30Instance);

                Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            }

            if (Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.Multirriesgo>(Architect.Utilities.Cache.GetItem(key).ToString());
                result.Modo = mode;

                if (mode.IsEmpty() || mode == "draft" || mode == "resume" || tryOnTron)
                {
                    result.terceros = Reglas.research.Apply_Terceros("Multirriesgos", result.terceros, result.Fuente_Tomador, tokenInfo);
                }

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("Multirriesgos", null, 0, tokenInfo);

            }
            return result;
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la póliza para un producto de tipo multirriesgo.
        /// </summary>
        public static Contracts.Emision.Multirriesgo Apply(Contracts.Emision.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.Multirriesgo resultQuoteInfo = null;
            
            if (quoteInfo.kyc == null && quoteInfo.ConoceTuCliente != null)
            {
                quoteInfo.kyc = quoteInfo.ConoceTuCliente;
            }

            if (quoteInfo.Modo == "draft" || quoteInfo.Modo == "resume")
            {
                Contracts.Comun.tercero tomador = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
                if (tomador.DocumentNumberType == 4)
                {
                    KycJuridico kycjuridico = JsonConvert.DeserializeObject<KycJuridico>(JsonConvert.SerializeObject(quoteInfo.kyc));
                    quoteInfo.kyc = kycjuridico;
                }
                else
                {
                    Kycpersona kycpersona = JsonConvert.DeserializeObject<Kycpersona>(JsonConvert.SerializeObject(quoteInfo.kyc));
                    quoteInfo.kyc = kycpersona;
                }

                quoteInfo.DatosEconomicos = Request.EconomicDataCalculate(quoteInfo);

                string uniqueId = Request.EnviarSolicitud(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
                string kycUniqueId = String.Empty;

                AlmacenarSolicitud(quoteInfo, quoteInfo.tip_firma == Contracts.TipoDeFirma.Manual ? 33 : 4, tokenInfo, uniqueId, kycUniqueId);
                GuardaDatosVariables(quoteInfo, quoteInfo.presupuesto, quoteInfo.cod_ramo, quoteInfo.tip_firma, quoteInfo.tip_firmaDesc, uniqueId);
                string message = string.Empty;

                if (uniqueId.IsNotEmpty())
                {
                    message = string.Format("La solicitud fue enviada de forma exitosa usando el tipo de envío indicado ({0})", quoteInfo.tip_firmaDesc);
                    if (quoteInfo.kyc.IsNotEmpty())
                    {
                        AlmacenarDatosKYC(quoteInfo.kyc);
                    }
                }
                else
                {
                    message = "Ha ocurrido un error tratando de comunicarnos con el sistema de firma, por favor intente nuevamente y si el problema persiste comuníquese con MAPFRE Costa Rica.";
                }

                resultQuoteInfo = new Contracts.Emision.Multirriesgo()
                {
                    Mensaje = message
                };
            }
            else
            {

                Contracts.Presupuesto.DatoFijo result = Convert.IssueToPresupuesto.Tron(quoteInfo);

                Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

                resultQuoteInfo = Convert.PolizaToIssue.Quote(quoteInfo, result2);

                if (resultQuoteInfo.num_poliza.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, System.Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Multirriesgo", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                    //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                    Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, System.Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, System.Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                    try
                    {
                        if (resultQuoteInfo.num_poliza.IsNotEmpty() && quoteInfo.kyc != null && Utilities.Helpers.Settings.BoolValue("Compliance.Enabled"))
                        {
                            Handler.Compliance.Apply(quoteInfo, tokenInfo);
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.Log.ErrorLog("Issue.Compliance", "Fail send compliance information", ex);
                    }


                    if (tokenInfo.Roles.Contain("Formularios_digitales"))
                    {
                        Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(quoteInfo.presupuesto, tokenInfo.CompanyId);
                        DataAccess.PolicyProposal.Update_Status(proposal.Id, 10, quoteInfo.presupuesto, tokenInfo.UserId);
                    }
                }
            }

            return resultQuoteInfo;
        }

        private static void AlmacenarSolicitud(Contracts.Emision.Multirriesgo quoteInfo, int status, Core.Contracts.Security.Token tokenInfo, string uniqueId, string signingRequest2Id = "")
        {
            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(quoteInfo.presupuesto, tokenInfo.CompanyId);
            if (proposal == null)
            {
                DataAccess.PolicyProposal.Create(new Contracts.PolicyProposal()
                {
                    Id = DataAccess.PolicyProposal.RetrieveLastKey() + 1,
                    CompanyId = tokenInfo.CompanyId,
                    AgentCode = tokenInfo.AgentCode,
                    ProposalId = quoteInfo.presupuesto,
                    InsuredId = primaryInsured.DocumentNumber,
                    InsuredName = primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                    Summary = string.Format("Año de construccion: {0}", quoteInfo.anodeconstruccion),
                    IssueDate = DateTime.Now,
                    SigningRequestId = uniqueId,
                    SigningRequest2Id = signingRequest2Id,
                    SignedRequest2 = false,
                    SigningType = quoteInfo.tip_firma,
                    PrimaryEmailAddress = quoteInfo.correoenvio,
                    Status = status,
                    ProposalData = Newtonsoft.Json.JsonConvert.SerializeObject(quoteInfo),
                    UpdateUserCode = tokenInfo.UserId
                });
            }
            else
            {
                DataAccess.PolicyProposal.Update(new Contracts.PolicyProposal()
                {
                    Id = proposal.Id,
                    CompanyId = tokenInfo.CompanyId,
                    AgentCode = tokenInfo.AgentCode,
                    ProposalId = quoteInfo.presupuesto,
                    InsuredId = primaryInsured.DocumentNumber,
                    InsuredName = primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                    Summary = string.Format("Año de construccion: {0}", quoteInfo.anodeconstruccion),
                    IssueDate = DateTime.Now,
                    SigningRequestId = uniqueId,
                    SigningRequest2Id = signingRequest2Id,
                    SignedRequest2 = false,
                    SigningType = quoteInfo.tip_firma,
                    PrimaryEmailAddress = quoteInfo.correoenvio,
                    Status = status,
                    ProposalData = Newtonsoft.Json.JsonConvert.SerializeObject(quoteInfo),
                    UpdateUserCode = tokenInfo.UserId
                });
            }

        }

        private static void AlmacenarDatosKYC(dynamic kyc)
        {

            if (kyc is Kycpersona)
            {
                int result = KycBussines.Insert_or_UpdateKYCpersona(kyc);
            }
            else if (kyc is KycJuridico)
            {
                int result = KycBussines.Insert_or_UpdateKYCjuridico(kyc);
            }

        }

        private static void GuardaDatosVariables(Contracts.Emision.Multirriesgo quoteInfo, string presupuesto, int cod_ramo, string tipoenvio, string tipoenvioDesc, string uniqueId)
        {

            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Tron");

            if (uniqueId.IsNotEmpty())
            {
                if (DataAccess.Batch.P2000020.Exist(presupuesto, "COD_CERT_FIRMA_CLIENTE", currentConnection))
                {
                    DataAccess.Batch.P2000020.Update(presupuesto, "COD_CERT_FIRMA_CLIENTE", uniqueId, currentConnection);
                }
                else
                {
                    DataAccess.CrearPresupuesto.PP_Insert_P2000020(new Contracts.Presupuesto.DatoVariable()
                    {
                        cod_cia = 1,
                        num_poliza = presupuesto,
                        num_spto = 0,
                        num_spto_apli = 0,
                        num_riesgo = 1,
                        num_periodo = 1,
                        tip_nivel = 2,
                        cod_campo = "COD_CERT_FIRMA_CLIENTE",
                        val_campo = uniqueId,
                        txt_campo = uniqueId,
                        num_secu = 100,
                        cod_ramo = cod_ramo,
                        num_apli = 0,
                        mca_baja_riesgo = "N",
                        mca_vigente = "S",
                        mca_vigente_apli = "S"
                    }, currentConnection);
                }

            }

            if (DataAccess.Batch.P2000020.Exist(presupuesto, "MCA_TIP_FIRMA", currentConnection))
            {
                DataAccess.Batch.P2000020.Update(presupuesto, "MCA_TIP_FIRMA", tipoenvio, currentConnection);
            }
            else
            {
                DataAccess.CrearPresupuesto.PP_Insert_P2000020(new Contracts.Presupuesto.DatoVariable()
                {
                    cod_cia = 1,
                    num_poliza = presupuesto,
                    num_spto = 0,
                    num_spto_apli = 0,
                    num_riesgo = 1,
                    num_periodo = 1,
                    tip_nivel = 2,
                    cod_campo = "MCA_TIP_FIRMA",
                    val_campo = tipoenvio,
                    txt_campo = tipoenvioDesc,
                    num_secu = 103,
                    cod_ramo = cod_ramo,
                    num_apli = 0,
                    mca_baja_riesgo = "N",
                    mca_vigente = "S",
                    mca_vigente_apli = "S"
                }, currentConnection);
            }


            currentConnection.Close();
        }

    }
}
