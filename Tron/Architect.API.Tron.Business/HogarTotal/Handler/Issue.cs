using Architect.Compliance.Integrations.Contracts;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using Architect.API.Core.Contracts;
using Architect.API.Core.Business.General;

namespace Architect.API.Tron.Business.HogarTotal.Handler
{
    /// <summary>
    /// Cotización de póliza de hogar total en tron.
    /// </summary>
    public static class Issue
    {
        /// <param name="presupuesto"></param>
        /// <param name="mode">"continue" para retomar un presupuesto (json), "resume" para retomar directo de una cotización de tron, "draft" para complementar la solicitud para luego retomar bajo el modo "continue".</param>
        /// <param name="tokenInfo"></param>

        public static Contracts.Emision.HogarTotal Setup(string presupuesto, string mode, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.HogarTotal result = null;
            string key = string.Format("hogartotal.{0}", presupuesto);
            bool tryOnTron = false;


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
                Contracts.Cotizacion.HogarTotal resultInfo2 = Cotizacion.HogarTotalConvertFrom.Quote(Cotizacion.HogarTotalConvertFrom.Quote(P30Instance), P30Instance);

                Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            }
            if (Utilities.Cache.Exist(key))
            {
                //Se cae aqui
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.HogarTotal>(Utilities.Cache.GetItem(key).ToString());
                result.Modo = mode;

                if (mode.IsEmpty() || mode == "draft" || mode == "resume" || tryOnTron)
                {
                    result.terceros = Reglas.research.Apply_Terceros("HogarTotal", result.terceros, result.Fuente_Tomador, tokenInfo);
                }

                    result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("HogarTotal", null, 0, tokenInfo);
                
                if (mode == "continue")
                {
                    List<Core.Contracts.General.AttachmentView> attachments = Core.Business.General.Attachment.RetrieveByEntity(3000, System.Convert.ToInt64(presupuesto), tokenInfo.CompanyId);

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

            if (tryOnTron)
            {
                if (tokenInfo.Roles.Contain("Formularios_digitales"))
                {
                    result.Modo = "draft";
                }
                else
                {
                    result.Modo = mode;
                }
            }
            return result;
        }

        public static Contracts.Emision.HogarTotal Apply(Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.HogarTotal resultQuoteInfo = null;

            // En caso de que el objeto kyc este vacio (información provista por la UI de aliados),
            // pero el objeto ConoceTuCliente no lo sea (información provista por el api),
            // se asigna el valor de ConoceTuCliente a kyc
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

                //TODO: Se debe incluir la validación de que de haber un Tomador, Asegurado y Conductor Habitual, pero faltan las básicas.
                quoteInfo.DatosEconomicos = Request.EconomicDataCalculate(quoteInfo);

                //Compliance(quoteInfo, tokenInfo);
                string uniqueId = Request.EnviarSolicitud(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
                string kycUniqueId = String.Empty;
                //if (quoteInfo.kyc != null)
                //{
                //    kycUniqueId = EnviarKYC(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
                //}
                AlmacenarSolicitud(quoteInfo, quoteInfo.tip_firma == Contracts.TipoDeFirma.Manual ? 33 : 4, tokenInfo, uniqueId, kycUniqueId);
                GuardaDatosVariables(quoteInfo.presupuesto, quoteInfo.cod_ramo, quoteInfo.tip_firma, quoteInfo.tip_firmaDesc, uniqueId);

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

                resultQuoteInfo = new Contracts.Emision.HogarTotal()
                {
                    Mensaje = message
                };
            }
            else
            {
                try
                {
                    //Architect.Common.Helpers.Serialize.SerializeToFile<Contracts.Cotizacion.HogarTotal>(quoteInfo,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.emision.in.xml", true);

                    Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = Convert.IssueToPresupuesto.Tron(quoteInfo);

                    //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.emision.in.raw.xml", true);

                    Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

                    //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.a2000030>(result2,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.out.raw.xml", true);

                    resultQuoteInfo = Convert.PolizaToIssue.Quote(quoteInfo, result2);

                    if (resultQuoteInfo.num_poliza.IsNotEmpty())
                    {
                        Core.Business.General.ChangeSet.Create(3000, System.Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión HogarTotal", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                        //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                        Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, System.Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, System.Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                        if (tokenInfo.Roles.Contain("Formularios_digitales"))
                        {
                            DataAccess.PolicyProposal.Update_Status(resultQuoteInfo.presupuesto, resultQuoteInfo.num_poliza, tokenInfo.CompanyId, 10, tokenInfo.UserId);
                        }

                        resultQuoteInfo.Mensaje = null;
                        resultQuoteInfo.Error = null;
                    }
                }
                catch (Exception ex)
                {
                    resultQuoteInfo = new Contracts.Emision.HogarTotal()
                    {
                        Mensaje = ex.Message,
                        Error = ex.Message,
                    };

                }
                try
                {
                    if (resultQuoteInfo.num_poliza.IsNotEmpty() && quoteInfo.kyc != null && Utilities.Helpers.Settings.BoolValue("Compliance.Enabled"))
                    {
                        Compliance.Apply(quoteInfo, tokenInfo);
                    }

                }
                catch (Exception ex)
                {
                    Utilities.Log.ErrorLog("Issue.Compliance", "Fail send compliance information", ex);
                }

                DataAccess.PolicyProposal.Update_Status(resultQuoteInfo.presupuesto, resultQuoteInfo.num_poliza, tokenInfo.CompanyId, 10, tokenInfo.UserId);
            }
            return resultQuoteInfo;

        }


        public static void EvicertiaSigned()
        {
            try
            {
                Utilities.Log.TraceLog("HogarTotal.EvicertiaSigned", DateTime.Now.ToString(), "Evicertia");
                DocuSign.Integrations.Contracts.QueryResult eviSignInf = null;
                int companyId = 2;
                int userId = 666;
                foreach (Contracts.PolicyProposal item in DataAccess.PolicyProposal.RetrieveByStatus(companyId, 4))
                {
                    eviSignInf = DocuSign.Integrations.DocuSign.Query(item.SigningRequestId, true).GetAwaiter().GetResult();
                    if (eviSignInf != null)
                    {
                        Utilities.Log.TraceLog("HogarTotal.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " outcome " + eviSignInf.outcome, "Evicertia");
                        switch (eviSignInf.outcome)
                        {
                            case "Signed":
                                DataAccess.PolicyProposal.Update_Status(item.Id, 33, item.SigningRequestId, userId);

                                foreach (DocuSign.Integrations.Contracts.affidavits affidavit in eviSignInf.affidavits)
                                {
                                    if (affidavit.description.Equals("documento firmado", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        Almacena_Documento_Firmado(item.ProposalId, affidavit.bytes, companyId, userId);
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
                        Utilities.Log.TraceLog("HogarTotal.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " not outcome", "Evicertia");
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("HogarTotal", "EvicertiaSigned", ex);
                throw ex;
            }
        }

        private static void Almacena_Documento_Firmado(string presupuesto, string fileContent, int companyId, int userId)
        {
            Byte[] pdfbytes = System.Convert.FromBase64String(fileContent);
            string originalFileName = "Documento firmado.pdf";
            string fileName = string.Format("{0}.pdf", Guid.NewGuid());
            string fullFileName = Path.Combine(ConfigurationManager.AppSettings["Attachments.Path"], fileName);

            File.WriteAllBytes(fullFileName, pdfbytes);

            Core.Contracts.General.Attachments attachment = new Core.Contracts.General.Attachments
            {
                EntityType = 3000,
                EntityId = System.Convert.ToInt64(presupuesto),
                CompanyId = companyId,
                UpdateUserCode = userId,
                DocumentType = 99,
                Description = "Documento firmado",
                FileName = originalFileName,
                FileSize = pdfbytes.Length,
                FileContent = fullFileName
            };
            Core.Business.General.Attachment.SyncUp(attachment);
        }


        private static void AlmacenarSolicitud(Contracts.Emision.HogarTotal quoteInfo, int status, Core.Contracts.Security.Token tokenInfo, string uniqueId, string signingRequest2Id = "")
        {
            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();
            Contracts.Comun.propiedad propiedad = (from t in quoteInfo.propiedad where t.propiedadId >= 0 select t).First();

            DataAccess.PolicyProposal.Create(new Contracts.PolicyProposal()
            {
                Id = DataAccess.PolicyProposal.RetrieveLastKey() + 1,
                CompanyId = tokenInfo.CompanyId,
                AgentCode = tokenInfo.AgentCode,
                ProposalId = quoteInfo.presupuesto,
                InsuredId = primaryInsured.DocumentNumber,
                InsuredName = primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                Summary = string.Format("Año de construcción: {0}, Metros construidos: {1}, Número de folio: {2}", propiedad.anodeconstruccion, propiedad.numerometrosconstruidos, propiedad.numerodefolio),
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

        private static void GuardaDatosVariables(string presupuesto, int cod_ramo, string tipoenvio, string tipoenvioDesc, string uniqueId)
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

            currentConnection.Close();
        }


    }
}
