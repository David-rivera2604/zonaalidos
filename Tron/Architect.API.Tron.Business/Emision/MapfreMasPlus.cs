using Architect.API.Core.Contracts;
using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Tron.Contracts.Presupuesto.API;
using Architect.Compliance.Integrations.Contracts;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Architect.API.Tron.Business.Emision
{
    public static class MapfreMasPlus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presupuesto"></param>
        /// <param name="mode">"continue" para retomar un presupuesto (json), "resume" para retomar directo de una cotización de tron, "draft" para complementar la solicitud para luego retomar bajo el modo "continue".</param>
        /// <param name="tokenInfo"></param>
        /// <returns></returns>
        public static Contracts.Emision.MapfreMas Setup(string presupuesto, string mode, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.MapfreMas result = null;
            bool tryOnTron = false;
            string key = string.Format("mapfremasplus.{0}", presupuesto);

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
                Contracts.Cotizacion.MapfreMas resultInfo2 = Cotizacion.MapfreMasConvertFrom.Quote(Cotizacion.MapfreMasConvertFrom.Quote(P30Instance), P30Instance);

                Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            }
            if (Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.MapfreMas>(Utilities.Cache.GetItem(key).ToString());

                result.Modo = mode;

                if (mode.IsEmpty() || mode == "draft" || mode == "resume" || tryOnTron)
                {
                    result.terceros = Reglas.research.Apply_Terceros("MapfreMasPlus", result.terceros, result.Fuente_Tomador, tokenInfo);
                }

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("MapfreMasPlus", null, result.MCA_CERO_KM, tokenInfo);

                if (mode == "continue")
                {
                    List<Core.Contracts.General.AttachmentView> attachments = Core.Business.General.Attachment.RetrieveByEntity(3000, Convert.ToInt64(presupuesto), tokenInfo.CompanyId);

                    if (attachments?.Count > 0)
                    {
                        foreach (Core.Contracts.General.AttachmentView attachment in attachments)
                        {
                            result.documentosrequeridos.Add(new Contracts.Comun.DocumentoRequerido()
                            {
                                DStored = attachment.FileName,
                                documentosrequeridosId = attachment.Id,
                                tipo = "Genérico",
                                DArchivoEsperado = attachment.FileName,
                                DDescripcion = attachment.Description,
                                DNombre = attachment.FileName,
                                DFecha = attachment.UpdateDate,
                                DTamano = attachment.FileSize,
                                Grupo = "F"
                            });
                        }

                    }
                }
            }

            //Utilities.SerializeHandler<Contracts.Emision.MapfreMas>.SerializeJSONToFile(result, string.Format(@"c:\temp\mapfremas.proposal.{0}.json", presupuesto), true, false, false);

            //Utilities.Cache.SetItem(string.Format("mapfremasplus.proposal.{0}", presupuesto),
            //                        Newtonsoft.Json.JsonConvert.SerializeObject(result), -1);

            if (tryOnTron)
            {
                result.Modo = "draft";
            }
            return result;
        }

        public static Contracts.Emision.MapfreMas Issue(Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.MapfreMas resultQuoteInfo = null;
            quoteInfo.NUM_MATRICULA = Regex.Replace(quoteInfo.NUM_MATRICULA, @"[^a-zA-Z0-9]", string.Empty);
            var mca_cicac = "N";
            var txt_cicac = "NO SE AUTORIZA";

            // En caso de que el objeto kyc este vacio (información provista por la UI de aliados),
            // pero el objeto ConoceTuCliente no lo sea (información provista por el api),
            // se asigna el valor de ConoceTuCliente a kyc
            if (quoteInfo.kyc == null && quoteInfo.ConoceTuCliente != null)
            {
                if (quoteInfo.ConoceTuCliente.Persona != null)
                {
                    quoteInfo.kyc = JObject.Parse(JsonConvert.SerializeObject(quoteInfo.ConoceTuCliente.Persona));
                }
                if (quoteInfo.ConoceTuCliente.Juridico != null)
                {
                    quoteInfo.kyc = JObject.Parse(JsonConvert.SerializeObject(quoteInfo.ConoceTuCliente.Juridico));
                }
                quoteInfo.ConoceTuCliente = null;
            }

            if (quoteInfo.Modo == "draft" || quoteInfo.Modo == "resume")
            {
                Contracts.Comun.tercero tomador = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
                if (tomador.DocumentNumberType == 4)
                {
                    KycJuridico kycjuridico = JsonConvert.DeserializeObject<KycJuridico>(JsonConvert.SerializeObject(quoteInfo.kyc));
                    if (!kycjuridico.IsEmpty())
                    {
                        mca_cicac = kycjuridico.mca_cicac;
                        txt_cicac = kycjuridico.obs_cicac;
                    }                  
                }
                else
                {
                    Kycpersona kycpersona = JsonConvert.DeserializeObject<Kycpersona>(JsonConvert.SerializeObject(quoteInfo.kyc));
                    if (!kycpersona.IsEmpty())
                    {
                        mca_cicac = kycpersona.mca_cicac;
                        txt_cicac = kycpersona.obs_cicac;
                    }
                }
                quoteInfo.DatosEconomicos = Solicitud.EconomicDataCalculate(quoteInfo);

                Dictionary<string, string> request = Solicitud.EnviarSolicitud(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
                string kycUniqueId = String.Empty;

                AlmacenarSolicitud(quoteInfo, quoteInfo.tip_firma == Contracts.TipoDeFirma.Manual ? 33 : 4, tokenInfo, request["UniqueId"], kycUniqueId);
                GuardaDatosVariables(quoteInfo.presupuesto, quoteInfo.cod_ramo, quoteInfo.tip_firma, quoteInfo.tip_firmaDesc, request["UniqueId"], mca_cicac, txt_cicac);

                string message = string.Empty;
                if (request["UniqueId"].IsNotEmpty())
                {
                    message = string.Format("La solicitud fue enviada de forma exitosa usando el tipo de envío indicado ({0})", quoteInfo.tip_firmaDesc);
                }
                else
                {
                    message = "Ha ocurrido un error tratando de comunicarnos con el sistema de firma, por favor intente nuevamente y si el problema persiste comuníquese con MAPFRE Costa Rica.";
                }

                resultQuoteInfo = new Contracts.Emision.MapfreMas()
                {
                    Mensaje = message
                };
            }
            else
            {
                try
                {

                    Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = MapfreMasConvertTo.Tron(quoteInfo);
                    Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.MapfreMas.Emitir(result, false, tokenInfo);

                    resultQuoteInfo = MapfreMasConvertFrom.Quote(quoteInfo, result2);

                    if (resultQuoteInfo.num_poliza.IsNotEmpty())
                    {
                        Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión MapfreMas", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                        //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                        Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                        //if (tokenInfo.Roles.Contain("Purdy") || tokenInfo.Roles.Contain("Davivienda_Prendarios") || tokenInfo.Roles.Contain("Davivienda_Leasing"))
                        //{
                            DataAccess.PolicyProposal.Update_Status(resultQuoteInfo.presupuesto, resultQuoteInfo.num_poliza, tokenInfo.CompanyId, 10, tokenInfo.UserId);
                        //}

                        resultQuoteInfo.Mensaje = null;
                        resultQuoteInfo.Error = null;

                    }
                }
                catch (Exception ex)
                {
                    resultQuoteInfo = new Contracts.Emision.MapfreMas()
                    {
                        Mensaje = ex.Message,
                        Error = ex.Message,
                    };

                }
                try
                {
                    if (resultQuoteInfo.num_poliza.IsNotEmpty() && quoteInfo.kyc != null && Utilities.Helpers.Settings.BoolValue("Compliance.Enabled"))
                    {
                        ComplianceSetup.Send(quoteInfo, tokenInfo);
                    }

                }
                catch (Exception ex)
                {
                    Utilities.Log.ErrorLog("Issue.Compliance", "Fail send compliance information", ex);
                }

            }
            return resultQuoteInfo;
        }

        public static void EvicertiaSigned()
        {
            try
            {
                Utilities.Log.TraceLog("MapfreMasPlus.EvicertiaSigned", DateTime.Now.ToString(), "Evicertia");
                DocuSign.Integrations.Contracts.QueryResult eviSignInf = null;
                foreach (string companyIdForReview in Utilities.Helpers.Settings.StringValue("Tenant.Tron.Agent.Information").Split(','))
                {
                    int companyId = Convert.ToInt32(companyIdForReview);
                    int userId = 666;
                    foreach (Contracts.PolicyProposal item in DataAccess.PolicyProposal.RetrieveByStatus(companyId, 4))
                    {
                        eviSignInf = DocuSign.Integrations.DocuSign.Query(item.SigningRequestId, true).GetAwaiter().GetResult();
                        if (eviSignInf != null)
                        {
                            Utilities.Log.TraceLog("MapfreMasPlus.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " outcome " + eviSignInf.outcome, "Evicertia");
                            switch (eviSignInf.outcome)
                            {
                                case "Signed":
                                    DataAccess.PolicyProposal.Update_Status(item.Id, 33, item.SigningRequestId, userId);

                                    foreach (DocuSign.Integrations.Contracts.affidavits affidavit in eviSignInf.affidavits)
                                    {
                                        if (affidavit.Signed)
                                        {
                                            Solicitud.Almacena_Documento_Firmado(item.ProposalId, affidavit.bytes, companyId, userId);
                                            break;
                                        }
                                    }
                                    break;
                                case "None":
                                    break;
                                case "Expired":
                                    DataAccess.PolicyProposal.Update_Status(item.Id, 31, item.SigningRequestId, userId);
                                    break;
                                case "Rejected":
                                    DataAccess.PolicyProposal.Update_Status(item.Id, 32, item.SigningRequestId, userId);
                                    break;
                            }
                        }
                        else
                        {
                            Utilities.Log.TraceLog("MapfreMasPlus.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " not outcome", "Evicertia");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("MapfreMasPlus", "EvicertiaSigned", ex);
                throw ex;
            }
        }



        private static string EnviarKYC(string tip_firma, string correoenvio, Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            DocuSign.Integrations.Contracts.SubmitResult submit = new DocuSign.Integrations.Contracts.SubmitResult();
            string kycPDF = General_PDF_KYC(quoteInfo);
            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();

            if (tip_firma == Contracts.TipoDeFirma.Manual)
            {
                Core.Business.General.Mail.SendByTemplate("MapfreMas_Solicitud", tokenInfo.CompanyId, tokenInfo.UserId, 0, quoteInfo,
                    new Dictionary<string, string>() { { correoenvio, string.Empty } },
                    new string[] { string.Format("{0};Solicitud {1}.pdf", kycPDF, quoteInfo.presupuesto) });
            }
            else
            {
                submit = DocuSign.Integrations.DocuSign.Submit(
                            quoteInfo.presupuesto,
                            "Conozca a su cliente " + quoteInfo.presupuesto,
                            primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                            correoenvio,
                            kycPDF, quoteInfo.tip_firma == Contracts.TipoDeFirma.Tablet ? "Handwriting" : "WebClick").GetAwaiter().GetResult();

            }
            return submit.UniqueId;
        }

        private static string General_PDF_KYC(Contracts.Emision.MapfreMas quoteInfo)
        {
            string pdf_FileName = "KYC_Persona";
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();

            if (titular.DocumentNumberType == 4)
            {
                pdf_FileName = "KYC_Juridico";
            }
            return Core.Business.General.Report.GeneratePDFFile(pdf_FileName, quoteInfo.kyc).GetAwaiter().GetResult();
        }

        private static void AlmacenarSolicitud(Contracts.Emision.MapfreMas quoteInfo, int status, Core.Contracts.Security.Token tokenInfo, string uniqueId, string signingRequest2Id = "")
        {
            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();
            DataAccess.PolicyProposal.Create(new Contracts.PolicyProposal()
            {
                Id = DataAccess.PolicyProposal.RetrieveLastKey() + 1,
                CompanyId = tokenInfo.CompanyId,
                AgentCode = tokenInfo.AgentCode,
                ProposalId = quoteInfo.presupuesto,
                InsuredId = primaryInsured.DocumentNumber,
                InsuredName = primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                Summary = string.Format("Placa: {0}, Chasis: {1}, Motor: {2}, Color: {3}", quoteInfo.NUM_MATRICULA, quoteInfo.COD_CHASSIS, quoteInfo.NUM_MOTOR, quoteInfo.COD_COLORDesc),
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

        private static void GuardaDatosVariables(string presupuesto, int cod_ramo, string tipoenvio, string tipoenvioDesc, string uniqueId, string mca_cicac, string txt_cicac)
        {
            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Tron");

            if (uniqueId.IsNotEmpty())
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
            DataAccess.CrearPresupuesto.PP_Insert_P2000020(new Contracts.Presupuesto.DatoVariable()
            {
                cod_cia = 1,
                num_poliza = presupuesto,
                num_spto = 0,
                num_spto_apli = 0,
                num_riesgo = 0,
                num_periodo = 1,
                tip_nivel = 1,
                cod_campo = "MCA_CICAC",
                val_campo = mca_cicac,
                val_cor_campo = mca_cicac,
                txt_campo = mca_cicac,
                num_secu = 909,
                cod_ramo = cod_ramo,
                num_apli = 0,
                mca_baja_riesgo = "N",
                mca_vigente = "S",
                mca_vigente_apli = "S"
            }, currentConnection);

            DataAccess.CrearPresupuesto.PP_Insert_P2000020(new Contracts.Presupuesto.DatoVariable()
            {
                cod_cia = 1,
                num_poliza = presupuesto,
                num_spto = 0,
                num_spto_apli = 0,
                num_riesgo = 0,
                num_periodo = 1,
                tip_nivel = 1,
                cod_campo = "TXT_CICAC",
                val_campo = txt_cicac,
                val_cor_campo = txt_cicac,
                txt_campo = txt_cicac,
                num_secu = 910,
                cod_ramo = cod_ramo,
                num_apli = 0,
                mca_baja_riesgo = "N",
                mca_vigente = "S",
                mca_vigente_apli = "S"
            }, currentConnection);
            currentConnection.Close();
        }

    }
}
