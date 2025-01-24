using Architect.API.Tron.Business.DocumentGenerator;
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
using Architect.WS.Integrations.wsWarranty4;
using Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia;
using Architect.API.Core.Business.General;
using Architect.API.Tron.Business.Models;
using Architect.API.Insurance.Contracts.Bayer;

namespace Architect.API.Tron.Business.Emision
{
    /// <summary>
    /// Cotización de póliza de hogar total en tron.
    /// </summary>
    public static class HogarTotal
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

            if (tryOnTron)
            {
                result.Modo = "draft";
            }
            return result;
        }

        public static Contracts.Emision.HogarTotal Issue(Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.HogarTotal resultQuoteInfo = null;
            var mca_cicac = "N";
            var txt_cicac = "NO SE AUTORIZA" ;

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
                    quoteInfo.kyc = kycjuridico;
                    if (!kycjuridico.IsEmpty())
                    {
                        mca_cicac = kycjuridico.mca_cicac;
                        txt_cicac = kycjuridico.obs_cicac;
                    }
                }
                else
                {
                    Kycpersona kycpersona = JsonConvert.DeserializeObject<Kycpersona>(JsonConvert.SerializeObject(quoteInfo.kyc));
                    quoteInfo.kyc = kycpersona;
                    if(!kycpersona.IsEmpty()) 
                    {
                        mca_cicac = kycpersona.mca_cicac;
                        txt_cicac = kycpersona.obs_cicac;
                    }
                }

                quoteInfo.DatosEconomicos = EconomicDataCalculate(quoteInfo);

                string uniqueId = EnviarSolicitud(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
                string kycUniqueId = String.Empty;

                AlmacenarSolicitud(quoteInfo, quoteInfo.tip_firma == Contracts.TipoDeFirma.Manual ? 33 : 4, tokenInfo, uniqueId, kycUniqueId);
                GuardaDatosVariables(quoteInfo.presupuesto, quoteInfo.cod_ramo, quoteInfo.tip_firma, quoteInfo.tip_firmaDesc, uniqueId, mca_cicac, txt_cicac);

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

                    Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = HogarTotalConvertTo.Tron(quoteInfo);

                    result.user_txt_motivo_spto = quoteInfo.user_txt_motivo_spto;

                    //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.emision.in.raw.xml", true);

                    Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

                    //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.a2000030>(result2,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.out.raw.xml", true);

                    resultQuoteInfo = HogarTotalConvertFrom.Quote(quoteInfo, result2);

                    if (resultQuoteInfo.num_poliza.IsNotEmpty())
                    {
                        Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión HogarTotal", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                        //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                        Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                            DataAccess.PolicyProposal.Update_Status(resultQuoteInfo.presupuesto, resultQuoteInfo.num_poliza, tokenInfo.CompanyId, 10, tokenInfo.UserId);

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
                        Compliance(quoteInfo, tokenInfo);
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

        public static string ReEnviarSolicitudHT(string presupuesto, string correoenvio, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);
            Contracts.Emision.HogarTotal quoteInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.HogarTotal>(proposal.ProposalData);

            quoteInfo.DatosEconomicos = EconomicDataCalculate(quoteInfo);

            string uniqueId = EnviarSolicitud(proposal.SigningType, correoenvio, quoteInfo, tokenInfo);
            string message = string.Empty;

            if (proposal.SigningType != Contracts.TipoDeFirma.Manual && uniqueId.IsNotEmpty())
            {
                DataAccess.PolicyProposal.Update_Status(proposal.Id, 4, uniqueId, tokenInfo.UserId);
            }
            if (proposal.SigningType == Contracts.TipoDeFirma.Manual)
            {
                message = "El presupuesto fue enviado a la dirección '" + correoenvio + "' de forma exitosa.";
            }
            else
            {
                if (uniqueId.IsNotEmpty())
                {
                    message = string.Format("La solicitud fue enviada de forma exitosa usando el tipo de envío indicado ({0}).", quoteInfo.tip_firmaDesc);
                }
                else
                {
                    message = "Ha ocurrido un error tratando de comunicarnos con el sistema de firma, por favor intente nuevamente y si el problema persiste comuníquese con MAPFRE Costa Rica.";
                }

            }
            return message;
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
            Byte[] pdfbytes = Convert.FromBase64String(fileContent);
            string originalFileName = "Documento firmado.pdf";
            string fileName = string.Format("{0}.pdf", Guid.NewGuid());
            string fullFileName = Path.Combine(ConfigurationManager.AppSettings["Attachments.Path"], fileName);

            File.WriteAllBytes(fullFileName, pdfbytes);

            Core.Contracts.General.Attachments attachment = new Core.Contracts.General.Attachments
            {
                EntityType = 3000,
                EntityId = Convert.ToInt64(presupuesto),
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

        private static string EnviarSolicitud(string tip_firma, string correoenvio, Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            DocuSign.Integrations.Contracts.SubmitResult submit = new DocuSign.Integrations.Contracts.SubmitResult();
            string solicitudPDF = General_PDF_Solicitud(quoteInfo, tokenInfo);
            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();
            if (tip_firma == Contracts.TipoDeFirma.Manual)
            {
                Core.Business.General.Mail.SendByTemplate("HogarTotal_Solicitud", tokenInfo.CompanyId, tokenInfo.UserId, 0, quoteInfo,
                    new Dictionary<string, string>() { { correoenvio, string.Empty } },
                    new string[] { string.Format("{0};Solicitud {1}.pdf", solicitudPDF, quoteInfo.presupuesto) });
                submit.UniqueId = quoteInfo.presupuesto;
            }
            else
            {
                submit = DocuSign.Integrations.DocuSign.Submit(
                                quoteInfo.presupuesto,
                                "Solicitud de seguro, presupuesto " + quoteInfo.presupuesto,
                                primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                                correoenvio,
                                solicitudPDF, quoteInfo.tip_firma == Contracts.TipoDeFirma.Tablet ? "Handwriting" : "WebClick").GetAwaiter().GetResult();
            }
            return submit.UniqueId;
        }




        private static string General_PDF_Solicitud(Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.HogarTotalSolicitud data = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.HogarTotalSolicitud>(Newtonsoft.Json.JsonConvert.SerializeObject(quoteInfo));
            data.kyc = quoteInfo.kyc;

            data.titular = (from t in data.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
            data.asegurado = (from a in data.terceros where a.tipodetercero == 2 select a).FirstOrDefault();
            data.acredor = (from c in data.terceros where c.tipodetercero == 8 select c).FirstOrDefault();

            data.documentosrequeridos = null;
            data.plandepago = null;
            data.plandepagoporfrecuencia = null;
            data.resumen = null;

            if (tokenInfo.Roles.Contain("Purdy"))
            {
                data.mainrole = "Purdy";
            }

            GeneratedPDF generated = new GeneratedPDF();

            string newpdfname = generated.GeneratePDF(data, tokenInfo);

            return newpdfname;
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
                num_secu = 903,
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
                num_secu = 904,
                cod_ramo = cod_ramo,
                num_apli = 0,
                mca_baja_riesgo = "N",
                mca_vigente = "S",
                mca_vigente_apli = "S"
            }, currentConnection);

            currentConnection.Close();
        }

        private static Contracts.Emision.EconomicData EconomicDataCalculate(Contracts.Cotizacion.HogarTotal quoteInfo)
        {
            Contracts.Emision.EconomicData result = new Contracts.Emision.EconomicData();
            int cod_cia = Utilities.Helpers.Settings.IntegerValue("Ma.Tron.cod_cia");
            double importeAnual = 0;

            foreach (Contracts.Comun.Cobertura itemQuote in quoteInfo.coberturas)
            {
                importeAnual += itemQuote.primatotal;
            }
            result.annualgrosspremium = importeAnual;
            result.tax = importeAnual * .13;
            result.annualnetpremium = importeAnual - result.tax;

            if (quoteInfo.cod_fracc_pago != 1)
            {
                List<Contracts.Ramo.A1001403> xxx = DataAccess.PorRamo.MM_FrecuenciaDePago(importeAnual, quoteInfo.polizagrupo, quoteInfo.contrato);

                if (xxx?.Count > 0)
                {
                    Contracts.Ramo.A1001403 yyy = (from r in xxx where r.cod_fracc_pago == quoteInfo.cod_fracc_pago select r).FirstOrDefault();
                    if (yyy != null)
                    {
                        result.monthlygrosspremium = (importeAnual / quoteInfo.cod_fracc_pago) + ((importeAnual / quoteInfo.cod_fracc_pago) * (yyy.pct_fracc_pago / 100));
                    }
                }
            }
            return result;
        }

        private static void Compliance(Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
            JObject jsonvalues = null;
            DateTime fechanaci = new DateTime(1900, 01, 01, 0, 00, 20);

            if (quoteInfo.kyc != null)
            {
                jsonvalues = (JObject)quoteInfo.kyc;
            }

            if (titular.DocumentNumberType != 4)
            {
                fechanaci = titular.fechadenacimiento;
            }

            int tipoIdenditificacion = titular.DocumentNumberType;
            switch (tipoIdenditificacion)
            {
                case 1: //Nacional
                    tipoIdenditificacion = 1;
                    break;
                case 2://Residente
                    tipoIdenditificacion = 3;
                    break;
                case 3://Pasaporte
                    tipoIdenditificacion = 5;
                    break;
                case 4: //Juridico
                    tipoIdenditificacion = 2;
                    break;
            }

            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Compliance.Integrations.Contracts.Clientes()
            {
                tipoIdentificacion = tipoIdenditificacion,
                numeroIdentificacion = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber),
                nombreCliente = titular.nombre,
                primerApellido = titular.apellido1,
                segundoApellido = titular.apellido2,
                conocidoComo = String.Empty,
                razonSocial = String.Empty,
                nombreComercial = String.Empty,
                fechaUltimaActualizacion = DateTime.Now,
                descripcionCuenta = titular.nombre.CompleteFullName(titular.apellido1, titular.apellido2),
                numeroIdentificacionEntidad = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber),
                fechaNacimiento = fechanaci,
                ejecutivo = tokenInfo.AgentCode.ToString(),
                genero = "",
                estadoCivil = "",
                estado = "A",
                estadoXML = "X",
                usuarioRegistro = tokenInfo.AgentCode.ToString(),
                administFondosTercero = "N",
                usuario = tokenInfo.UserId,
                esApnfd = "N",
                tipoApnfd = "0",
                esCpe = "N",
                pagaImpuestos = "N",
                //faltaban
                esPep = "N",
                tipoPep = "N",
                residente = "S",
                articulo15 = "S",
                esEmpleado = "N",
                fechaValor = DateTime.Now,
                tipoCuenta = "1",
                fechaSalida = new DateTime(1900, 1, 1),
                fechaIngreso = DateTime.Now,
                fechaRegistro = DateTime.Now,
                sectorPublico = "N",
                fechaInactividad = new DateTime(1900, 1, 1),
                fechaVinculacion = DateTime.Now,
                fechaCargaCliente = DateTime.Now,
                institucionLabora = "0",
                fechaRegistroApnfd = new DateTime(1900, 1, 1),
                lugarExpedicionIdentificacion = "Costa Rica",
                fechaVencimientoIdentificacion = titular.DocumentNumberType == 4 ? jsonvalues.TokenDateTimeValue("fechadecaducidadJur") : jsonvalues.TokenDateTimeValue("fechadecaducidadPer"),
                fechaProximaActualizacion = new DateTime(1900, 1, 1),
                descripcionInversionInicial = String.Empty
            };


            //KYC
            //administFondosTercero
            //
            //montoIngresoMensual
            //esPep
            //tipoPep
            //articulo15
            //origenFondos
            //paisOrigen = "111111"
            //profesion
            mapInfo.clientesUbicaciones = new List<Compliance.Integrations.Contracts.Clientesubicacione>()
            {
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.numerodetelefono
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.correoelectronico
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = titular.TDistrito,
                    descripcionUbicacion = String.Format("{0}, {1}, {2}, {3}. {4}.", titular.TProvinciaDesc , titular.TCantonDesc,titular.TDistritoDesc,titular.otrasenas, "Costa Rica")
                }
            };

            if (titular.DocumentNumberType == 4)
            {
                var removeLine = titular.DocumentNumber.Replace("-", string.Empty);
                mapInfo.numeroIdentificacion = removeLine;

                mapInfo.razonSocial = titular.nombre;
                mapInfo.nombreComercial = titular.nombre;
                mapInfo.nombreCliente = string.Empty;
                mapInfo.primerApellido = string.Empty;
                mapInfo.segundoApellido = string.Empty;
                mapInfo.genero = "X";
                mapInfo.estadoCivil = "X";

                if (jsonvalues != null)
                {
                    mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdeconstitucionJur");
                    mapInfo.actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomica");

                    mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N";
                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "D";
                    }

                    Clientesfatca FATCA = new Clientesfatca()
                    {
                        poseeGreenCard = jsonvalues.TokenStringValue("greencard") == "1" ? "S" : "N",
                        numeroTIN = jsonvalues.TokenStringValue("numeroTIN"),
                        detalleDomicilio = jsonvalues.TokenStringValue("otrassenasFATCA"),
                        poseeEIN = jsonvalues.TokenStringValue("identificacionEIN") == "1" ? "S" : "N",
                        contribuyenteUSA = jsonvalues.TokenStringValue("contribuyenteUSA") == "1" ? "S" : "N",
                        domicilioExtranjero = jsonvalues.TokenStringValue("domicilioExtranjero") == "1" ? "S" : "N",
                        paisDomicilio = jsonvalues.TokenInt32Value("paisDomicilio"),
                        poseeTelefonoExtranjero = jsonvalues.TokenStringValue("poseeTelefonoExtranjero") == "1" ? "S" : "N",
                        telefonoExtranjero = jsonvalues.TokenStringValue("numeroExt"),
                        poseeProductos = "N"
                    };
                    mapInfo.clientesFATCA = new List<Clientesfatca>() { FATCA };


                    Clientesrepresentante representantesLegales = new Clientesrepresentante()
                    {
                        nombre = titular.nombre,
                        tipoIdentificacionRepresentante = tipoIdenditificacion,
                        numeroIdentificacionRepresentante = Util.IdentificationFormat(titular.DocumentNumberType, mapInfo.numeroIdentificacion),
                        segundoNombre = string.Empty,
                        cargo = jsonvalues.TokenStringValue("posiciondentrodelaempresaJur"),
                        estadoCivil = jsonvalues.TokenStringValue("estadocivilJur", "X"),
                        conocidoComo = jsonvalues.TokenStringValue("nombreJur"),
                        primerApellido = jsonvalues.TokenStringValue("primerapellidoJur"),
                        segundoApellido = jsonvalues.TokenStringValue("segundoapellidoJur"),
                        genero = jsonvalues.TokenStringValue("sexoJur") == "1" ? "M" : "F",
                        fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadenacimientoJur"),
                        paisOrigen = jsonvalues.TokenInt32Value("nacionalidadJur"),
                        profesion = jsonvalues.TokenInt32Value("profesionJur"),
                        actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomicaRep"),
                        fechaVencimiento = mapInfo.fechaVencimientoIdentificacion,
                        esPep = mapInfo.esPep,
                        tipoPep = mapInfo.tipoPep,
                        descripcionPep = "No aplica",
                        articulo15 = mapInfo.articulo15
                    };
                    switch (representantesLegales.estadoCivil)
                    {
                        case "1": //casado
                            representantesLegales.estadoCivil = "C";
                            break;
                        case "2": //divorciado
                            representantesLegales.estadoCivil = "D";
                            break;
                        case "3": //soltero
                            representantesLegales.estadoCivil = "S";
                            break;
                        case "4": //viudo
                            representantesLegales.estadoCivil = "V";
                            break;
                        case "5": //otro
                            representantesLegales.estadoCivil = "X";
                            break;
                        case "7": //acompañado
                            representantesLegales.estadoCivil = "U";
                            break;
                        default:
                            representantesLegales.estadoCivil = "X";
                            break;
                    }

                    mapInfo.clientesRepresentantes = new[] { representantesLegales };

                    Clientestransaccione transaccionalidadCliente = new Clientestransaccione()
                    {
                        monto = quoteInfo.sAEdificio,
                        montoIngresoMensual = jsonvalues.TokenInt32Value("ingresomensualestimado"),
                        inversionInicial = jsonvalues.TokenStringValue("formadepagodelapoliza"),
                        frecuencia = jsonvalues.TokenStringValue("periodicidad")

                    };
                    switch (transaccionalidadCliente.frecuencia)
                    {
                        case "4":
                            transaccionalidadCliente.frecuencia = "M";
                            break;

                        default:
                            transaccionalidadCliente.frecuencia = "N";
                            break;

                    }
                    switch (transaccionalidadCliente.inversionInicial)
                    {
                        case "1":
                            transaccionalidadCliente.inversionInicial = "E";
                            break;
                        case "2":
                            transaccionalidadCliente.inversionInicial = "C";
                            break;

                        case "3":
                            transaccionalidadCliente.inversionInicial = "D";
                            break;

                        case "4":
                            transaccionalidadCliente.inversionInicial = "T";
                            break;

                        default:
                            transaccionalidadCliente.inversionInicial = "T";
                            break;
                    }
                    mapInfo.clientesTransacciones = new[] { transaccionalidadCliente };

                    KycJuridico deserializedKyc = JsonConvert.DeserializeObject<KycJuridico>(JsonConvert.SerializeObject(jsonvalues));
                    List<Participador_Accionario> participacionAccionaria = deserializedKyc.participacionaccionariaJur;
                    List<Clientessocio> sociosList = new List<Clientessocio>();

                    foreach (dynamic recorrerPA in participacionAccionaria)
                    {
                        Clientessocio socios = new Clientessocio()
                        {
                            tipoIdentificacionSocio = recorrerPA.participacionaccionariaTipodeidentificacionJur,
                            numeroIdentificacionSocio = recorrerPA.participacionaccionariaNumerodeidentificacionJur,
                            nombre = recorrerPA.participacionaccionariaNombrecompletoJur,
                            primerApellido = string.Empty,
                            segundoApellido = string.Empty,
                            conocidoComo = string.Empty,
                            participacion = recorrerPA.porcentajedeparticipacionJur,
                            genero = recorrerPA.participacionaccionariaSexoJur == 1 ? "M" : "F",
                            fechaNacimiento = recorrerPA.participacionaccionariaFechadenacimientoJur,
                            estadoCivil = recorrerPA.participacionaccionariaEstadocivilJur.ToString(),
                            paisOrigen = recorrerPA.participacionaccionariaPaisdenacimientoJur,
                            profesion = recorrerPA.participacionaccionariaProfesionJur,
                            actividadEconomica = mapInfo.actividadEconomica, //ARREGLAR
                            esPep = mapInfo.esPep,
                            tipoPep = mapInfo.tipoPep,
                            descripcionPep = "No aplica",
                            articulo15 = mapInfo.articulo15
                        };

                        switch (socios.estadoCivil)
                        {
                            case "1": //casado
                                socios.estadoCivil = "C";
                                break;
                            case "2": //divorciado
                                socios.estadoCivil = "D";
                                break;
                            case "3": //soltero
                                socios.estadoCivil = "S";
                                break;
                            case "4": //viudo
                                socios.estadoCivil = "V";
                                break;
                            case "5": //otro
                                socios.estadoCivil = "X";
                                break;
                            case "7": //acompañado
                                socios.estadoCivil = "U";
                                break;
                            default:
                                socios.estadoCivil = "X";
                                break;
                        }

                        sociosList.Add(socios);

                    }
                    mapInfo.clientesSocios = sociosList;




                    Clientesotrosatributo otrosAtributos = new Clientesotrosatributo()
                    {
                        atributo = jsonvalues.TokenInt32Value("atributocanaldeingreso"),
                        descripcionAtributo = jsonvalues.TokenStringValue("valorcanalingresoDesc")
                    };

                    mapInfo.clientesOtrosAtributos = new[] { otrosAtributos };


                    Clientespatrimonio clientespatrimonio = new Clientespatrimonio()
                    {
                        descripcionPatrimonio = "SEGURO HOGAR TOTAL",
                        tipoBien = 1,
                        moneda = quoteInfo.moneda,
                        montoValor = quoteInfo.sAEdificio,
                        fechaRegistro = mapInfo.fechaRegistro,
                    };
                    mapInfo.clientesPatrimonio = new List<Clientespatrimonio>() { clientespatrimonio };



                }
            }
            else
            {
                //if (titular.DocumentNumberType == 1)
                //{
                //    var removeLine = titular.DocumentNumber.Replace("-", string.Empty);
                //    var numberChanged = removeLine.Remove(0, 1);
                //    mapInfo.numeroIdentificacion = numberChanged;
                //}

                mapInfo.numeroIdentificacion  = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber);

                mapInfo.genero = titular.tercerosMca_sexo == 1 ? "M" : "F";
                mapInfo.estadoCivil = titular.estadoCivil;
                if (jsonvalues != null)
                {

                    mapInfo.profesion = jsonvalues.TokenInt32Value("profesionPer");
                    mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoPer");
                    mapInfo.actividadEconomica = 1;
                    mapInfo.clientesNacionalidades = new[] { new Clientesnacionalidade() { nacionalidad = jsonvalues.TokenInt32Value("nacionalidadPer") } };
                    string telefonocelularPer = jsonvalues.TokenStringValue("telefonocelularPer");
                    if (telefonocelularPer.IsNotEmpty())
                    {
                        mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                        {
                            tipoUbicacion = 2,
                            divisionTerritorial = 99999,
                            descripcionUbicacion = telefonocelularPer
                        });
                    }

                    mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N";
                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "D";
                    }

                    Clientesfatca FATCA = new Clientesfatca()
                    {
                        poseeGreenCard = jsonvalues.TokenStringValue("greencard") == "1" ? "S" : "N",
                        numeroTIN = jsonvalues.TokenStringValue("numeroTIN"),
                        detalleDomicilio = jsonvalues.TokenStringValue("otrassenasFATCA"),
                        poseeEIN = jsonvalues.TokenStringValue("identificacionEIN") == "1" ? "S" : "N",
                        contribuyenteUSA = jsonvalues.TokenStringValue("contribuyenteUSA") == "1" ? "S" : "N",
                        domicilioExtranjero = jsonvalues.TokenStringValue("domicilioExtranjero") == "1" ? "S" : "N",
                        paisDomicilio = jsonvalues.TokenInt32Value("paisDomicilio"),
                        poseeTelefonoExtranjero = jsonvalues.TokenStringValue("poseeTelefonoExtranjero") == "1" ? "S" : "N",
                        telefonoExtranjero = jsonvalues.TokenStringValue("numeroExt"),
                        poseeProductos = "N"
                    };
                    mapInfo.clientesFATCA = new List<Clientesfatca> { FATCA };

                    Clientesrelacione personasRelacionadas = new Clientesrelacione()
                    {
                        nombre = titular.nombre,
                        tipoIdentificacionRelacion = tipoIdenditificacion,
                        numeroIdentificacionRelacion = Util.IdentificationFormat(titular.DocumentNumberType, mapInfo.numeroIdentificacion),
                        fechaVencimientoIdentificacion = mapInfo.fechaVencimientoIdentificacion,
                        segundoNombre = string.Empty,
                        titular = titular.tipodetercero == 1 ? "S" : "N",
                        cargo = jsonvalues.TokenStringValue("cargoempresaPer"),
                        descripcionPep = "No aplica",
                        tipoTitularidad = titular.tipodetercero == 1 ? "O" : "X",
                        estadoCivil = jsonvalues.TokenStringValue("estadocivilPer", "X"),
                        conocidoComo = jsonvalues.TokenStringValue("nombrePer"),
                        primerApellido = jsonvalues.TokenStringValue("primerapellidoPer"),
                        segundoApellido = jsonvalues.TokenStringValue("segundoapellidoPer"),
                        beneficiario = titular.tipodetercero == 1 ? "S" : "N",
                        genero = mapInfo.genero,
                        fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadenacimientoPer"),
                        paisOrigen = mapInfo.paisOrigen,
                        profesion = jsonvalues.TokenInt32Value("profesionPer"),
                        actividadEconomica = mapInfo.actividadEconomica,
                        esPep = mapInfo.esPep,
                        tipoPep = mapInfo.tipoPep,
                        articulo15 = mapInfo.articulo15,
                        fechaInscripcionCargo = new DateTime(1900, 1, 1),
                        fechaFinalizacionCargo = new DateTime(1900, 1, 1),
                    };

                    switch (personasRelacionadas.estadoCivil)
                    {
                        case "1": //casado
                            personasRelacionadas.estadoCivil = "C";
                            break;
                        case "2": //divorciado
                            personasRelacionadas.estadoCivil = "D";
                            break;
                        case "3": //soltero
                            personasRelacionadas.estadoCivil = "S";
                            break;
                        case "4": //viudo
                            personasRelacionadas.estadoCivil = "V";
                            break;
                        case "5": //otro
                            personasRelacionadas.estadoCivil = "X";
                            break;
                        case "7": //acompañado
                            personasRelacionadas.estadoCivil = "U";
                            break;
                        default:
                            personasRelacionadas.estadoCivil = "X";
                            break;
                    }

                    mapInfo.clientesRelaciones = new[] { personasRelacionadas };



                    Clientesrepresentante beneficiarios = new Clientesrepresentante()
                    {
                        tipoIdentificacionRepresentante = tipoIdenditificacion, 
                        numeroIdentificacionRepresentante = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber),
                        nombre = titular.nombre,
                        fechaVencimiento = mapInfo.fechaVencimientoIdentificacion,
                        segundoNombre = string.Empty,
                        primerApellido = jsonvalues.TokenStringValue("primerapellidoPer"),
                        segundoApellido = jsonvalues.TokenStringValue("segundoapellidoPer"),
                        conocidoComo = String.Empty,
                        genero = jsonvalues.TokenStringValue("sexoPer") == "1" ? "M" : "F",
                        fechaNacimiento = titular.fechadenacimiento,
                        estadoCivil = jsonvalues.TokenStringValue("estadocivilPer", "X"),
                        paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoPer"),
                        profesion = jsonvalues.TokenInt32Value("profesionPer"),
                        actividadEconomica = jsonvalues.TokenInt32Value("actividaddelclientenaturalezadelnegocioPer"),
                        esPep = mapInfo.esPep,
                        tipoPep = mapInfo.tipoPep,
                        descripcionPep = "No aplica",
                        articulo15 = mapInfo.articulo15,
                        cargo = jsonvalues.TokenStringValue("posiciondentrodelaempresaPer", "No aplica")
                    };

                    switch (beneficiarios.estadoCivil)
                    {
                        case "1": //casado
                            beneficiarios.estadoCivil = "C";
                            break;
                        case "2": //divorciado
                            beneficiarios.estadoCivil = "D";
                            break;
                        case "3": //soltero
                            beneficiarios.estadoCivil = "S";
                            break;
                        case "4": //viudo
                            beneficiarios.estadoCivil = "V";
                            break;
                        case "5": //otro
                            beneficiarios.estadoCivil = "X";
                            break;
                        case "7": //acompañado
                            beneficiarios.estadoCivil = "U";
                            break;
                        default:
                            beneficiarios.estadoCivil = "X";
                            break;
                    }
                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        beneficiarios.esPep = "S";
                        beneficiarios.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        beneficiarios.esPep = "S";
                        beneficiarios.tipoPep = "D";
                    }
                    mapInfo.clientesRepresentantes = new[] { beneficiarios };



                    Clientestransaccione transaccionalidadCliente = new Clientestransaccione()
                    {
                        monto = quoteInfo.sAEdificio,
                        montoIngresoMensual = jsonvalues.TokenInt32Value("ingresomensualestimado"),
                        inversionInicial = jsonvalues.TokenStringValue("formadepagodelapoliza"),
                        frecuencia = jsonvalues.TokenStringValue("periodicidad")

                    };
                    switch (transaccionalidadCliente.frecuencia)
                    {
                        case "4":
                            transaccionalidadCliente.frecuencia = "M";
                            break;

                        default:
                            transaccionalidadCliente.frecuencia = "N";
                            break;

                    }
                    switch (transaccionalidadCliente.inversionInicial)
                    {
                        case "1":
                            transaccionalidadCliente.inversionInicial = "E";
                            break;
                        case "2":
                            transaccionalidadCliente.inversionInicial = "C";
                            break;

                        case "3":
                            transaccionalidadCliente.inversionInicial = "D";
                            break;

                        case "4":
                            transaccionalidadCliente.inversionInicial = "T";
                            break;

                        default:
                            transaccionalidadCliente.inversionInicial = "T";
                            break;
                    }
                    mapInfo.clientesTransacciones = new[] { transaccionalidadCliente };


                    Clientesingreso transaccionalidadIngresos = new Clientesingreso()
                    {
                        actividadEconomica = mapInfo.actividadEconomica,
                        cargo = jsonvalues.TokenStringValue("cargoempresaPer"),
                        telefonoDirecto = jsonvalues.TokenStringValue("telefonocelularPer"),
                        telefonoCentral = jsonvalues.TokenStringValue("telefonoresidenciaPer"),
                        origenRecursos = jsonvalues.TokenInt32Value("correspondenciaOrigendelosfondosPer"),
                        sustentoOtraPersonas = "S",
                        moneda = quoteInfo.moneda,
                        monto = jsonvalues.TokenInt32Value("ingresomensualestimado"),
                        direccion = jsonvalues.TokenStringValue("domiciliocomercialCod_paisDesc") + "-" + " " + jsonvalues.TokenStringValue("domiciliocomercialCod_estadoDesc") + "-" + " " + jsonvalues.TokenStringValue("domiciliocomercialCod_provDesc") + "-" + " " + jsonvalues.TokenStringValue("domiciliocomercialCod_localidadDesc")
                    };
                    mapInfo.clientesIngresos = new[] { transaccionalidadIngresos };


                    Clientesotrosatributo otrosAtributos = new Clientesotrosatributo()
                    {
                        atributo = jsonvalues.TokenInt32Value("atributocanaldeingreso"),
                        descripcionAtributo = jsonvalues.TokenStringValue("valorcanalingreso").ToString()
                    };

                    mapInfo.clientesOtrosAtributos = new[] { otrosAtributos };


                    Clientespatrimonio clientespatrimonio = new Clientespatrimonio()
                    {
                        descripcionPatrimonio = "SEGURO HOGAR TOTAL",
                        tipoBien = 1,
                        moneda = quoteInfo.moneda,
                        montoValor = quoteInfo.sAEdificio,
                        fechaRegistro = mapInfo.fechaRegistro,
                    };
                    mapInfo.clientesPatrimonio = new List<Clientespatrimonio>() { clientespatrimonio };
                }
            }

            mapInfo.clientesPolizas = new List<Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.num_poliza,
                    descripcionPoliza = "HogarTotal",
                    fechaInicio = quoteInfo.iniciodevigencia,
                    fechaFinalizacion = quoteInfo.findevigencia,
                    moneda  = quoteInfo.moneda,
                   // prima = (int)quoteInfo.DatosEconomicos.annualnetpremium,
                    estado = "A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = 201,
                }
            };
            if (quoteInfo.DatosEconomicos != null)
            {
                mapInfo.clientesPolizas[0].prima = (int)quoteInfo.DatosEconomicos.annualgrosspremium;
            }

            if (titular.DocumentNumberType != 4)
            {
               mapInfo.clientesNacionalidades = null;
               mapInfo.clientesFATCA = null;
               mapInfo.clientesIngresos = null;
               mapInfo.clientesFondosTerceros = null;
               mapInfo.clientesPatrimonio = null;
               mapInfo.clientesFuncionesPEP = null;
               mapInfo.clientesTransacciones = null;
               mapInfo.clientesOtrosAtributos = null;
               mapInfo.clientesSocios = null;
               mapInfo.clientesRelaciones = null;
               mapInfo.clientesNacionalidades = null;
            }

            string result = Architect.Compliance.Integrations.Business.Customers.SendCustomers(mapInfo).Result;
        }


    }
}
