using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace Architect.API.Tron.Business.Emision
{
    public static class MapfreMas
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
            string key = string.Format("mapfremas.{0}", presupuesto);

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
                    result.terceros = Reglas.research.Apply_Terceros("MapfreMas", result.terceros, result.Fuente_Tomador, tokenInfo);
                }

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("MapfreMas", null, result.MCA_CERO_KM, tokenInfo);

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

            //Utilities.Cache.SetItem(string.Format("mapfremas.proposal.{0}", presupuesto),
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
            if (quoteInfo.Modo == "draft" || quoteInfo.Modo == "resume")
            {



                //TODO: Se debe incluir la validación de que de haber un Tomador, Asegurado y Conductor Habitual, pero faltan las básicas.
                quoteInfo.DatosEconomicos = EconomicDataCalculate(quoteInfo);

                string uniqueId = EnviarSolicitud(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
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
                    //Architect.Common.Helpers.Serialize.SerializeToFile<Contracts.Cotizacion.MapfreMas>(quoteInfo,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\MapfreMas.emision.in.xml", true);

                    Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = MapfreMasConvertTo.Tron(quoteInfo);

                    //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\MapfreMas.emision.in.raw.xml", true);

                    Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.MapfreMas.Emitir(result, false, tokenInfo);

                    //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.a2000030>(result2,
                    //    ConfigurationManager.AppSettings["Path.Logs"] + @"\MapfreMas.out.raw.xml", true);

                    resultQuoteInfo = MapfreMasConvertFrom.Quote(quoteInfo, result2);

                    if (resultQuoteInfo.num_poliza.IsNotEmpty())
                    {
                        Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión MapfreMas", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                        //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                        Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                        if (tokenInfo.Roles.Contain("Purdy") || tokenInfo.Roles.Contain("Davivienda_Prendarios") || tokenInfo.Roles.Contain("Davivienda_Leasing"))
                        {
                            DataAccess.PolicyProposal.Update_Status(resultQuoteInfo.presupuesto, resultQuoteInfo.num_poliza, tokenInfo.CompanyId, 10, tokenInfo.UserId);
                        }

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
                    if (resultQuoteInfo.num_poliza.IsNotEmpty())
                    {
                        Compliance(quoteInfo, tokenInfo);
                    }

                }
                catch (Exception ex)
                {
                    Utilities.Log.ErrorLog("Issue.Compliance", "Fail send compliance information", ex);
                }

            }
            return resultQuoteInfo;
        }

        public static string ReEnviarSolicitud(string presupuesto, string correoenvio, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);
            Contracts.Emision.MapfreMas quoteInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.MapfreMas>(proposal.ProposalData);

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
                Utilities.Log.TraceLog("MapfreMas.EvicertiaSigned", DateTime.Now.ToString(), "Evicertia");
                DocuSign.Integrations.Contracts.QueryResult eviSignInf = null;
                int companyId = 2;
                int userId = 666;
                foreach (Contracts.PolicyProposal item in DataAccess.PolicyProposal.RetrieveByStatus(companyId, 4))
                {
                    eviSignInf = DocuSign.Integrations.DocuSign.Query(item.SigningRequestId, true).GetAwaiter().GetResult();
                    if (eviSignInf != null)
                    {
                        Utilities.Log.TraceLog("MapfreMas.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " outcome " + eviSignInf.outcome, "Evicertia");
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
                        Utilities.Log.TraceLog("MapfreMas.EvicertiaSigned", item.Id + ' ' + item.SigningRequestId + " not outcome", "Evicertia");
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("MapfreMas", "EvicertiaSigned", ex);
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

        private static string EnviarSolicitud(string tip_firma, string correoenvio, Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            DocuSign.Integrations.Contracts.SubmitResult submit = new DocuSign.Integrations.Contracts.SubmitResult();
            string solicitudPDF = General_PDF_Solicitud(quoteInfo, tokenInfo);
            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();
            if (tip_firma == Contracts.TipoDeFirma.Manual)
            {
                Core.Business.General.Mail.SendByTemplate("MapfreMas_Solicitud", tokenInfo.CompanyId, tokenInfo.UserId, 0, quoteInfo,
                    new Dictionary<string, string>() { { correoenvio, string.Empty } },
                    new string[] { string.Format("{0};Solicitud {1}.pdf", solicitudPDF, quoteInfo.presupuesto) });
            }
            else
            {
                submit = DocuSign.Integrations.DocuSign.Submit(
                                quoteInfo.presupuesto,
                                "Solicitud " + quoteInfo.presupuesto,
                                primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                                correoenvio,
                                solicitudPDF, quoteInfo.tip_firma == Contracts.TipoDeFirma.Tablet ? "Handwriting" : "WebClick").GetAwaiter().GetResult();
            }
            return submit.UniqueId;
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

        private static string General_PDF_Solicitud(Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.MapfreMasSolicitud data = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.MapfreMasSolicitud>(Newtonsoft.Json.JsonConvert.SerializeObject(quoteInfo));

            data.kyc = quoteInfo.kyc;
            data.titular = (from t in data.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
            data.asegurado = (from a in data.terceros where a.tipodetercero == 2 select a).FirstOrDefault();
            data.conductor = (from c in data.terceros where c.tipodetercero == 3 select c).FirstOrDefault();
            data.acredor = (from c in data.terceros where c.tipodetercero == 8 select c).FirstOrDefault();

            int index = 1;
            foreach (Contracts.Comun.tercero item in from b in data.terceros where b.tipodetercero == 6 select b)
            {
                if (index == 1)
                {
                    data.beneficiario1 = item;
                }
                else
                {
                    data.beneficiario2 = item;
                }
                index++;
            }
            data.terceros = null;
            data.documentosrequeridos = null;
            data.coberturas = null;
            data.plandepago = null;
            data.plandepagoporfrecuencia = null;
            data.resumen = null;
            if (tokenInfo.Roles.Contain("Purdy"))
            {
                data.mainrole = "Purdy";
            }

            return Core.Business.General.Report.GeneratePDFFile("mapfremas_solicitud", data).GetAwaiter().GetResult();
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

        private static Contracts.Emision.EconomicData EconomicDataCalculate(Contracts.Cotizacion.MapfreMas quoteInfo)
        {
            Contracts.Emision.EconomicData result = new Contracts.Emision.EconomicData();
            int cod_cia = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia");
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

        private static void Compliance(Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Compliance.Integrations.Contracts.Clientes()
            {
                tipoIdentificacion = titular.DocumentNumberType,
                numeroIdentificacion = titular.DocumentNumber,
                nombreCliente = titular.nombre,
                primerApellido = titular.apellido1,
                segundoApellido = titular.apellido2,
                fechaUltimaActualizacion = DateTime.Now,
                fechaNacimiento = titular.fechadenacimiento,
                ejecutivo = tokenInfo.AgentCode.ToString(),
                estado = "A",
                estadoXML = "X",
                usuarioRegistro = tokenInfo.UserId.ToString(),
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
                articulo15 = "N",
                esEmpleado = "N",
                fechaValor = DateTime.Now,
                tipoCuenta = "1",
                descripcionCuenta = "X",
                fechaSalida = new DateTime(1900, 1, 1),
                fechaIngreso = DateTime.Now,
                fechaRegistro = DateTime.Now,
                sectorPublico = "N",
                fechaInactividad = new DateTime(1900, 1, 1),
                fechaVinculacion = DateTime.Now,
                fechaCargaCliente = DateTime.Now,
                institucionLabora = "0",
                fechaRegistroApnfd = new DateTime(1900, 1, 1),
                numeroIdentificacionEntidad = "X",
                lugarExpedicionIdentificacion = "Costa Rica",
                fechaVencimientoIdentificacion = new DateTime(1900, 1, 1)
            };


            //KYC
            //administFondosTercero
            //actividadEconomica
            //montoIngresoMensual
            //esPep
            //tipoPep
            //articulo15
            //origenFondos
            //paisOrigen = "111111"
            //profesion

            if (titular.DocumentNumberType == 4)
            {
                mapInfo.razonSocial = titular.nombre;
                mapInfo.nombreComercial = titular.nombre;
                mapInfo.nombreCliente = string.Empty;
                mapInfo.primerApellido = string.Empty;
                mapInfo.segundoApellido = string.Empty;
                mapInfo.genero = "X";
                mapInfo.estadoCivil = "X";


            }
            else
            {
                mapInfo.genero = titular.tercerosMca_sexo == 1 ? "M" : "F";
                mapInfo.estadoCivil = titular.estadoCivil;
            }

            mapInfo.clientesPolizas = new List<Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.presupuesto,
                    descripcionPoliza = "MapfreMas",
                    fechaInicio = quoteInfo.fec_efec_poliza,
                    fechaFinalizacion = quoteInfo.fec_vcto_poliza,
                    moneda  = quoteInfo.cod_mon,
                   // prima = (int)quoteInfo.DatosEconomicos.annualnetpremium,
                    estado="A",
                    //faltaban
                    tipoPrima = "A" ,
                    tipoPoliza= "C"

                }
            };
            mapInfo.clientesUbicaciones = new List<Compliance.Integrations.Contracts.Clientesubicacione>()
            {
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 1,
                    descripcionUbicacion = "Costa Rica"
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 2,
                    divisionTerritorial = titular.TProvincia,
                    descripcionUbicacion = titular.TProvinciaDesc
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = titular.TCanton,
                    descripcionUbicacion = titular.TCantonDesc
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = titular.TDistrito,
                    descripcionUbicacion = titular.TDistritoDesc
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 5,
                    divisionTerritorial = 0,
                    descripcionUbicacion = titular.otrasenas
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 6,
                    divisionTerritorial = 0,
                    descripcionUbicacion = titular.correoelectronico
                },
                new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 7,
                    divisionTerritorial = 0,
                    descripcionUbicacion = titular.numerodetelefono
                }

            };


            int result = Architect.Compliance.Integrations.Business.Customers.SendCustomers(mapInfo).Result;
        }
    }
}
