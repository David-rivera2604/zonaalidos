using Architect.API.Core.Business.General;
using Architect.API.Core.Contracts;
using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Tron.Business.Backoffice;
using Architect.API.Tron.Contracts.Presupuesto.API;
using Architect.API.Tron.Contracts.Variaciones;
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

namespace Architect.API.Tron.Business.Variaciones
{
    public static class MapfreMasPlus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poliza"></param>
        /// <param name="mode">"continue" para retomar un presupuesto (json), "resume" para retomar directo de una cotización de tron, "draft" para complementar la solicitud para luego retomar bajo el modo "continue".</param>
        /// <param name="tokenInfo"></param>
        /// <returns></returns>
        public static Contracts.Variaciones.MapfreMasPlus Setup(string poliza, int num_spto, string mca_provisional, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Variaciones.MapfreMasPlus result = null;
            bool tryOnTron = false;
            string key = string.Format("mapfremasplus.{0}", poliza);

            //if (mode == "continue")
            //{
            //    //Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);
            //    Contracts.Poliza.DatoFijo PolizaInstance = Poliza.PolizaVariaciones(1, poliza, true);

            //    if (proposal != null)
            //    {
            //        Utilities.Cache.SetItem(key, proposal.ProposalData, -1);
            //    }
            //    else
            //    {
            //        tryOnTron = true;
            //    }
            //}
            //if (mode == "resume" || tryOnTron)
            //{
            //Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);

            //Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, presupuesto, 0, 0, 0, null, true);
            Contracts.Poliza.DatoFijo PolizaInstance = Poliza.PolizaVariaciones(1, poliza, true);
            Contracts.Variaciones.MapfreMas resultInfo2 = Variaciones.MapfreMasPlusConvertFrom.Quote(Variaciones.MapfreMasPlusConvertFrom.Quote(PolizaInstance), PolizaInstance);

            resultInfo2 = Variaciones.MapfreMasPlusConvertFrom.SetTipoProducto(resultInfo2);

            //Se recupera la información de campos que no son almacenados en tron.
            Core.Contracts.General.CustomData customData = CustomData.RetrieveByEntity(3000, Convert.ToInt64(PolizaInstance.num_presupuesto), tokenInfo.CompanyId);
            if (!string.IsNullOrEmpty(customData?.Data))
            {
                Contracts.Cotizacion.MapfreMas custom = JsonConvert.DeserializeObject<Contracts.Emision.MapfreMas>(customData.Data);

                if (custom != null)
                {
                    resultInfo2.nombredelcontratante = custom.nombredelcontratante;
                    resultInfo2.edad = custom.edad;
                    resultInfo2.mca_sexo = custom.mca_sexo;
                    resultInfo2.mca_sexoDesc = custom.mca_sexoDesc;
                    resultInfo2.AutoSust = custom.AutoSust;
                }
            }

            if (mca_provisional.Equals("S"))
            {
                resultInfo2.Recibos = DataAccess.Variaciones.VariacionIssue.GetRecibos(resultInfo2.cod_cia, poliza, null);
            }

            Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            //}
            if (Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Variaciones.MapfreMasPlus>(Utilities.Cache.GetItem(key).ToString());

                //result.Modo = mode;

                //if (mode.IsEmpty() || mode == "draft" || mode == "resume" || tryOnTron)
                //{
                //    result.terceros = Reglas.research.Apply_Terceros("MapfreMasPlus", result.terceros, result.Fuente_Tomador, tokenInfo);
                //}

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("MapfreMasPlus", null, result.MCA_CERO_KM, tokenInfo);

                //if (mode == "continue")
                //{
                //    List<Core.Contracts.General.AttachmentView> attachments = Core.Business.General.Attachment.RetrieveByEntity(3000, Convert.ToInt64(presupuesto), tokenInfo.CompanyId);

                //    if (attachments?.Count > 0)
                //    {
                //        foreach (Core.Contracts.General.AttachmentView attachment in attachments)
                //        {
                //            result.documentosrequeridos.Add(new Contracts.Comun.DocumentoRequerido()
                //            {
                //                DStored = attachment.FileName,
                //                documentosrequeridosId = attachment.Id,
                //                tipo = "Genérico",
                //                DArchivoEsperado = attachment.FileName,
                //                DDescripcion = attachment.Description,
                //                DNombre = attachment.FileName,
                //                DFecha = attachment.UpdateDate,
                //                DTamano = attachment.FileSize,
                //                Grupo = "F"
                //            });
                //        }

                //    }
                //}
            }

            Utilities.SerializeHandler<Contracts.Variaciones.MapfreMasPlus>.SerializeJSONToFile(result, string.Format(@"c:\temp\mapfremas.proposal.{0}.json", poliza), true, false, false);

            Utilities.Cache.SetItem(string.Format("mapfremasplus.proposal.{0}", poliza),
                                    Newtonsoft.Json.JsonConvert.SerializeObject(result), -1);

            //if (tryOnTron)
            //{
            //    result.Modo = "draft";
            //}
            return result;
        }

        public static VariacionIssueResult Issue(Contracts.Variaciones.MapfreMasPlus quoteInfo)
        {
            return MapfreVariacionesCommon.Issue(quoteInfo);
        }

        public static VariacionIssueResult Cancelation(Contracts.Variaciones.MapfreMasPlus quoteInfo)
        {
            return MapfreVariacionesCommon.Cancelation(quoteInfo.cod_cia, quoteInfo.cod_ramo, quoteInfo.num_poliza, quoteInfo.fec_efec_cancel, quoteInfo.txt_motivo);
        }

        public static VariacionIssueResult ManageAuthorizationCT(int cod_cia, int cod_ramo, string num_poliza, int num_spto, string mca_autoriza)
        {
            return MapfreVariacionesCommon.ManageAuthorizationCT(cod_cia, cod_ramo, num_poliza, num_spto, mca_autoriza);
        }

        //public static void EvicertiaSigned()
        //{
        //    try
        //    {
        //        Utilities.Log.TraceLog("MapfreMasPlus.EvicertiaSigned", DateTime.Now.ToString(), "Evicertia");
        //        DocuSign.Integrations.Contracts.QueryResult eviSignInf = null;
        //        foreach (string companyIdForReview in Utilities.Helpers.Settings.StringValue("Tenant.Tron.Agent.Information").Split(','))
        //        {
        //            int companyId = Convert.ToInt32(companyIdForReview);
        //            int userId = 666;
        //            foreach (Contracts.PolicyProposal item in DataAccess.PolicyProposal.RetrieveByStatus(companyId, 4))
        //            {
        //                eviSignInf = DocuSign.Integrations.DocuSign.Query(item.SigningRequestId, true).GetAwaiter().GetResult();
        //                if (eviSignInf != null)
        //                {
        //                    Utilities.Log.TraceLog("MapfreMasPlus.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " outcome " + eviSignInf.outcome, "Evicertia");
        //                    switch (eviSignInf.outcome)
        //                    {
        //                        case "Signed":
        //                            DataAccess.PolicyProposal.Update_Status(item.Id, 33, item.SigningRequestId, userId);

        //                            foreach (DocuSign.Integrations.Contracts.affidavits affidavit in eviSignInf.affidavits)
        //                            {
        //                                if (affidavit.Signed)
        //                                {
        //                                    Solicitud.Almacena_Documento_Firmado(item.ProposalId, affidavit.bytes, companyId, userId);
        //                                    break;
        //                                }
        //                            }
        //                            break;
        //                        case "None":
        //                            break;
        //                        case "Expired":
        //                            DataAccess.PolicyProposal.Update_Status(item.Id, 31, item.SigningRequestId, userId);
        //                            break;
        //                        case "Rejected":
        //                            DataAccess.PolicyProposal.Update_Status(item.Id, 32, item.SigningRequestId, userId);
        //                            break;
        //                    }
        //                }
        //                else
        //                {
        //                    Utilities.Log.TraceLog("MapfreMasPlus.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " not outcome", "Evicertia");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utilities.Log.ErrorLog("MapfreMasPlus", "EvicertiaSigned", ex);
        //        throw ex;
        //    }
        //}



        private static string EnviarKYC(string tip_firma, string correoenvio, Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            DocuSign.Integrations.Contracts.SubmitResult submit = new DocuSign.Integrations.Contracts.SubmitResult();
            string kycPDF = General_PDF_KYC(tokenInfo.CompanyId, quoteInfo);
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

        private static string General_PDF_KYC(int companyId, Contracts.Emision.MapfreMas quoteInfo)
        {
            string pdf_FileName = "KYC_Persona";
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();

            if (titular.DocumentNumberType == 4)
            {
                pdf_FileName = "KYC_Juridico";
            }
            return Core.Business.General.Report.Generate(companyId, pdf_FileName, quoteInfo.kyc).GetAwaiter().GetResult();
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
