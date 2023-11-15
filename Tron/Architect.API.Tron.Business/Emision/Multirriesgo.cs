using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.API.Tron.Business.Models;
using Architect.API.Tron.Business.DocumentGenerator;
using System.Data;
using Architect.API.Tron.Business.Backoffice;
using Newtonsoft.Json.Linq;
using Architect.Payment.Integrations.Contracts;
using Architect.API.Core.Business;
using Architect.API.Core.Business.General;
using Architect.API.Core.Contracts;
using Newtonsoft.Json;
using Architect.Compliance.Integrations.Contracts;
using Architect.API.Tron.Contracts.Presupuesto.API;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Architect.API.Tron.Business.Emision
{
    public static class Multirriesgo
    {

        public static Architect.API.Tron.Contracts.Emision.Multirriesgo Setup(string presupuesto, string mode, Core.Contracts.Security.Token tokenInfo)
        {
            Architect.API.Tron.Contracts.Emision.Multirriesgo result = null;
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
                Contracts.Cotizacion.Multirriesgo resultInfo2 = Cotizacion.MultirriesgoConvertFrom.Quote(Cotizacion.MultirriesgoConvertFrom.Quote(P30Instance), P30Instance);

                Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            }

            if (Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Architect.API.Tron.Contracts.Emision.Multirriesgo>(Architect.Utilities.Cache.GetItem(key).ToString());
                result.Modo = mode;

                if (mode.IsEmpty() || mode == "draft" || mode == "resume" || tryOnTron)
                {
                    result.terceros = Reglas.research.Apply_Terceros("Multirriesgos", result.terceros, result.Fuente_Tomador, tokenInfo);
                }
                if (result.documentosrequeridos == null)
                {
                    if (!tokenInfo.Roles.Contain("Formularios_digitales"))
                    {
                        result.documentosrequeridos = new List<Contracts.Comun.DocumentoRequerido>
                            {
                            new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=1, tipo = "Expediente Cliente", DArchivoEsperado="Expediente Cliente.pdf", Grupo="F"  },
                            new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=2, tipo = "Expediente Póliza" , DArchivoEsperado="Expediente Póliza.pdf", Grupo="F" },
                            };
                    }
                }
            }
            return result;
        }

        public static Contracts.Emision.Multirriesgo Issue(Contracts.Emision.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.Multirriesgo resultQuoteInfo = null;

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

                quoteInfo.DatosEconomicos = EconomicDataCalculate(quoteInfo);

                //Compliance(quoteInfo, tokenInfo);

                string uniqueId = EnviarSolicitud(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
                string kycUniqueId = String.Empty;

                AlmacenarSolicitud(quoteInfo, quoteInfo.tip_firma == Contracts.TipoDeFirma.Manual ? 33 : 4, tokenInfo, uniqueId, kycUniqueId);
                GuardaDatosVariables(quoteInfo, quoteInfo.presupuesto, quoteInfo.cod_ramo, quoteInfo.tip_firma, quoteInfo.tip_firmaDesc, uniqueId);
                string message = string.Empty;

                if (uniqueId.IsNotEmpty())
                {
                    message = string.Format("La solicitud fue enviada de forma exitosa usando el tipo de envío indicado ({0})", quoteInfo.tip_firmaDesc);
                    AlmacenarDatosKYC(quoteInfo.kyc);
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

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = MultirriesgoConvertTo.Tron(quoteInfo);

                Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

                resultQuoteInfo = MultirriesgoConvertFrom.Quote(quoteInfo, result2);

                if (resultQuoteInfo.num_poliza.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Multirriesgo", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                    //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                    Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                    try
                    {
                        if (quoteInfo.kyc != null && Utilities.Helpers.Settings.BoolValue("Compliance.Enabled"))
                        {
                            Compliance(quoteInfo, tokenInfo);
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.Log.ErrorLog("Issue.Compliance", "Fail send compliance information", ex);
                    }


                    Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(quoteInfo.presupuesto, tokenInfo.CompanyId);
                    //DataAccess.PolicyProposal.Update_Status(proposal.Id, 10, quoteInfo.presupuesto, tokenInfo.UserId);
                }
            }

            return resultQuoteInfo;
        }

        private static string EnviarSolicitud(string tip_firma, string correoenvio, Contracts.Emision.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            DocuSign.Integrations.Contracts.SubmitResult submit = new DocuSign.Integrations.Contracts.SubmitResult();
            string solicitudPDF = General_PDF_Solicitud(quoteInfo, tokenInfo);
            FileInfo fileinfo = new FileInfo(solicitudPDF);

            quoteInfo.documentosrequeridos.Add(new Contracts.Comun.DocumentoRequerido()
            {
                documentosrequeridosId = 3,
                DStored = fileinfo.Name,
                DArchivoEsperado = "Documento Firmado",
                tipo = "Multirriesgo Solicitud",
                DNombre = fileinfo.Name,
                Grupo = "F",
                DFecha = DateTime.Now,
                DTamano = (int)fileinfo.Length,
                DDescripcion = null
            });

            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();
            if (tip_firma == Contracts.TipoDeFirma.Manual)
            {
                Core.Business.General.Mail.SendByTemplate("Multirriesgo_Solicitud", tokenInfo.CompanyId, tokenInfo.UserId, 0, quoteInfo,
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

        public static string ReEnviarSolicitud(string presupuesto, string correoenvio, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);
            Contracts.Emision.Multirriesgo quoteInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.Multirriesgo>(proposal.ProposalData);

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

        private static string General_PDF_Solicitud(Contracts.Emision.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.MultirriesgoSolicitud data = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.MultirriesgoSolicitud>(Newtonsoft.Json.JsonConvert.SerializeObject(quoteInfo));

            data.kyc = quoteInfo.kyc;
            data.titular = (from t in data.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
            data.asegurado = (from a in data.terceros where a.tipodetercero == 2 select a).FirstOrDefault();
            data.acredor = (from c in data.terceros where c.tipodetercero == 8 select c).FirstOrDefault();

            if (tokenInfo.Roles.Contain("Purdy"))
            {
                data.mainrole = "Purdy";
            }
            GeneratedPDF generated = new GeneratedPDF();

            string newpdfname = generated.GeneratePDF(data, tokenInfo);

            return newpdfname;

            //return Core.Business.General.Report.GeneratePDFFile("multiriesgos_solicitud_individual", data).GetAwaiter().GetResult();
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

        private static Contracts.Emision.EconomicData EconomicDataCalculate(Contracts.Cotizacion.Multirriesgo quoteInfo)
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


        private static string Compliance(Contracts.Emision.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            JObject jsonvalues = null;
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();

            if (quoteInfo.kyc != null)
            {
                jsonvalues = (JObject)quoteInfo.kyc;
            }

            string numidenti = titular.DocumentNumber;
            if (titular.DocumentNumberType == 1)
            {
                numidenti = numidenti.Remove(0, 1);
                numidenti = numidenti.Replace("-", string.Empty);
            }

            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Compliance.Integrations.Contracts.Clientes()
            {


                tipoIdentificacion = titular.DocumentNumberType,
                numeroIdentificacion = numidenti,
                nombreCliente = titular.nombre,
                primerApellido = titular.apellido1,
                segundoApellido = titular.apellido2,
                conocidoComo = String.Empty,
                razonSocial = String.Empty,
                nombreComercial = String.Empty,
                descripcionCuenta = titular.nombre.CompleteFullName(titular.apellido1, titular.apellido2),
                numeroIdentificacionEntidad = titular.DocumentNumber,
                fechaVencimientoIdentificacion = new DateTime(1900, 1, 1),
                lugarExpedicionIdentificacion = "Costa Rica",
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
                fechaSalida = new DateTime(1900, 1, 1),
                fechaIngreso = DateTime.Now,
                fechaRegistro = DateTime.Now,
                sectorPublico = "N",
                fechaInactividad = new DateTime(1900, 1, 1),
                fechaVinculacion = DateTime.Now,
                fechaCargaCliente = DateTime.Now,
                institucionLabora = "0",
                fechaRegistroApnfd = new DateTime(1900, 1, 1),
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

            Clientesfatca FATCA = new Clientesfatca()
            {
                poseeGreenCard = "N",
                poseeEIN = "N",
                contribuyenteUSA = "N",
                domicilioExtranjero = "N",
                paisDomicilio = 188,
                poseeTelefonoExtranjero = "N",
                poseeProductos = "N"
            };

            Clientestransaccione Transacciones = new Clientestransaccione()
            {
                monto = quoteInfo.IMP_BIE_INT + quoteInfo.IMP_BIE_TEM_DES +
                quoteInfo.IMP_DOMOS_TOTAL + quoteInfo.IMP_EDIFICIO + quoteInfo.IMP_EQUIP_ELEC +
                quoteInfo.IMP_EQUIP_ELEC_M + quoteInfo.IMP_GAS_ALQ + quoteInfo.IMP_INT_NEG +
                quoteInfo.IMP_MAQUINARIA + quoteInfo.IMP_MERCADERIA + quoteInfo.IMP_MER_TRA +
                quoteInfo.IMP_MOBILIARIO + quoteInfo.IMP_OBJ_ESP_VAL + quoteInfo.IMP_PER_REN,
                frecuencia = "N"

            };

            Clientesingreso Ingresos = new Clientesingreso()
            {
                sustentoOtraPersonas = "N",
                origenRecursos = 3,
            };

            Clientesotrosatributo OtrosAtributos = new Clientesotrosatributo()
            {
                atributo = 1,
                descripcionAtributo = "0"
            };

            Clientespatrimonio Patrimonio = new Clientespatrimonio()
            {
                descripcionPatrimonio = "Edificio",
                tipoBien = 1,
                moneda = quoteInfo.cod_mon,
                montoValor = 0,
                fechaRegistro = DateTime.Now
            };

            if (quoteInfo.coberturas != null)
            {
                foreach (Contracts.Comun.Cobertura cobertura in quoteInfo.coberturas)
                {
                    if (cobertura.nombre == "EDIFICIO")
                    {
                        Patrimonio.montoValor = (int)cobertura.capital;
                    }
                }
            }



            if (jsonvalues != null)
            {

                mapInfo.actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomica");
                mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N";
                //------FACTA General------\\
                FATCA.poseeGreenCard = jsonvalues.TokenStringValue("greencard") == "1" ? "S" : "N";
                FATCA.numeroTIN = jsonvalues.TokenStringValue("numeroTIN");
                FATCA.poseeEIN = jsonvalues.TokenStringValue("identificacionEIN") == "1" ? "S" : "N";
                FATCA.contribuyenteUSA = jsonvalues.TokenStringValue("contribuyenteUSA") == "1" ? "S" : "N";
                FATCA.domicilioExtranjero = jsonvalues.TokenStringValue("domicilioExtranjero") == "1" ? "S" : "N";
                FATCA.paisDomicilio = jsonvalues.TokenInt32Value("paisDomicilio");
                FATCA.detalleDomicilio = jsonvalues.TokenStringValue("otrassenasFATCA");
                FATCA.poseeTelefonoExtranjero = jsonvalues.TokenStringValue("poseeTelefonoExtranjero") == "1" ? "S" : "N";
                FATCA.telefonoExtranjero = jsonvalues.TokenStringValue("numeroExt");

                //------PEPs General------\\
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

                //------Transaccionalidad General------\\

                switch (jsonvalues.TokenInt32Value("formadepagodelapoliza"))
                {
                    case 1: //Efectivo
                        Transacciones.inversionInicial = "E";
                        break;
                    case 2: //Cheque
                        Transacciones.inversionInicial = "C";
                        break;
                    case 3: //Deposito
                        Transacciones.inversionInicial = "D";
                        break;
                    case 4: //Transferencia
                        Transacciones.inversionInicial = "T";
                        break;
                }

                Transacciones.frecuencia = quoteInfo.cod_fracc_pago == 12 ? "M" : "N";
                Transacciones.montoIngresoMensual = jsonvalues.TokenInt32Value("ingresomensualestimado");

                //-----Ingresos General-----\\
                Ingresos.direccion = jsonvalues.TokenStringValue("domiciliocomercialCod_paisDesc") + " " +
                       jsonvalues.TokenStringValue("domiciliocomercialCod_estadoDesc") + " " +
                       jsonvalues.TokenStringValue("domiciliocomercialCod_provDesc") + " " +
                       jsonvalues.TokenStringValue("domiciliocomercialCod_localidadDesc");
                Ingresos.actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomica");
                Ingresos.monto = jsonvalues.TokenInt32Value("ingresomensualestimado");
                Ingresos.justificacionOrigenRecursos = jsonvalues.TokenStringValue("correspondenciaOrigendelosfondos");
                Ingresos.moneda = quoteInfo.cod_mon;
                //------Otros atributos General------\\
                OtrosAtributos.descripcionAtributo = jsonvalues.TokenStringValue("valorcanalingreso");
            }



            if (titular.DocumentNumberType == 4)
            {
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
                    mapInfo.fechaVencimientoIdentificacion = jsonvalues.TokenDateTimeValue("fechadecaducidadPer");
                    Clientesrepresentante representante = new Clientesrepresentante()
                    {

                        tipoIdentificacionRepresentante = jsonvalues.TokenInt32Value("tipodeidentificacionJur"),
                        numeroIdentificacionRepresentante = jsonvalues.TokenStringValue("numerodeidentificacionJur"),
                        nombre = jsonvalues.TokenStringValue("nombrecompletoJur"),
                        segundoNombre = string.Empty,
                        primerApellido = jsonvalues.TokenStringValue("primerapellidoJur"),
                        segundoApellido = jsonvalues.TokenStringValue("segundoapellidoJur"),
                        conocidoComo = String.Empty,
                        genero = jsonvalues.TokenStringValue("sexoJur") == "1" ? "M" : "F",
                        fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadenacimientoJur"),
                        estadoCivil = jsonvalues.TokenStringValue("estadocivilJur", "X"),
                        paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoJur"),
                        profesion = jsonvalues.TokenInt32Value("profesionJur"),
                        actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomicaRep"),
                        esPep = "N",
                        tipoPep = "N",
                        descripcionPep = "No aplica",
                        articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N",
                        cargo = jsonvalues.TokenStringValue("posiciondentrodelaempresaJur", "No aplica"),
                        fechaVencimiento = jsonvalues.TokenDateTimeValue("fechadecaducidadJur")
                    };

                    switch (representante.estadoCivil)
                    {
                        case "1": //casado
                            representante.estadoCivil = "C";
                            break;
                        case "2": //divorciado
                            representante.estadoCivil = "D";
                            break;
                        case "3": //soltero
                            representante.estadoCivil = "S";
                            break;
                        case "4": //viudo
                            representante.estadoCivil = "V";
                            break;
                        case "5": //otro
                            representante.estadoCivil = "X";
                            break;
                        case "7": //acompañado
                            representante.estadoCivil = "U";
                            break;
                        default:
                            representante.estadoCivil = "X";
                            break;
                    }

                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        representante.esPep = "S";
                        representante.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        representante.esPep = "S";
                        representante.tipoPep = "D";
                    }

                    mapInfo.clientesRepresentantes = new[] { representante };


                    //-----Ingresos Juridico-----\\
                    Ingresos.nombreEmpresa = jsonvalues.TokenStringValue("nombrecomercialJur");
                    Ingresos.telefonoCentral = jsonvalues.TokenStringValue("telefonoJur");

                    KycJuridico deserializedKyc = JsonConvert.DeserializeObject<KycJuridico>(JsonConvert.SerializeObject(jsonvalues));
                    List<Participador_Accionario> participacionAccionaria = deserializedKyc.participacionaccionariaJur;
                    List<Clientessocio> sociosList = new List<Clientessocio>();
                    foreach (Participador_Accionario accionario in participacionAccionaria)
                    {
                        Clientessocio socios = new Clientessocio()
                        {
                            tipoIdentificacionSocio = accionario.participacionaccionariaTipodeidentificacionJur,
                            numeroIdentificacionSocio = accionario.participacionaccionariaNumerodeidentificacionJur,
                            nombre = accionario.participacionaccionariaNombrecompletoJur,
                            primerApellido = string.Empty,
                            segundoApellido = string.Empty,
                            conocidoComo = string.Empty,
                            participacion = accionario.porcentajedeparticipacionJur,
                            genero = accionario.participacionaccionariaSexoJur == 1 ? "M" : "F",
                            fechaNacimiento = accionario.participacionaccionariaFechadenacimientoJur,
                            estadoCivil = accionario.participacionaccionariaEstadocivilJur.ToString(),
                            paisOrigen = accionario.participacionaccionariaPaisdenacimientoJur,
                            profesion = accionario.participacionaccionariaProfesionJur,
                            actividadEconomica = accionario.participacionaccionariaAct_Economica, //ARREGLAR
                            esPep = "N",
                            tipoPep = "N",
                            descripcionPep = "No aplica",
                            articulo15 = accionario.participacionaccionariaArt15Jur == 1 ? "S" : "N",
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
                        if (accionario.participacionaccionariaPepCargoJur == 1)
                        {
                            representante.esPep = "S";
                            representante.tipoPep = "R";
                        }
                        if (accionario.participacionaccionariaPepRelacionJur == 1)
                        {
                            representante.esPep = "S";
                            representante.tipoPep = "D";
                        }

                        sociosList.Add(socios);
                    }

                    mapInfo.clientesSocios = sociosList;
                }

            }
            else
            {
                mapInfo.genero = titular.tercerosMca_sexo == 1 ? "M" : "F";
                mapInfo.estadoCivil = titular.estadoCivil;

                if (jsonvalues != null)
                {

                    mapInfo.profesion = jsonvalues.TokenInt32Value("profesionPer");
                    mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoPer");
                    mapInfo.fechaVencimientoIdentificacion = jsonvalues.TokenDateTimeValue("fechadecaducidadPer");

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



                    //-----Ingresos Persona-----\\
                    Ingresos.nombreEmpresa = jsonvalues.TokenStringValue("nombreempresaPer");
                    Ingresos.cargo = jsonvalues.TokenStringValue("cargoempresaPer");
                    Ingresos.telefonoCentral = jsonvalues.TokenStringValue("telefonoempresaPer");

                }
            }


            mapInfo.clientesFATCA = new List<Clientesfatca>() { FATCA };
            mapInfo.clientesTransacciones = new[] { Transacciones };
            mapInfo.clientesIngresos = new[] { Ingresos };
            mapInfo.clientesPolizas = new List<Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.num_poliza,
                    descripcionPoliza = "Multirriesgo",
                    fechaInicio = quoteInfo.fec_efec_poliza,
                    fechaFinalizacion = quoteInfo.fec_vcto_poliza,
                    moneda  = quoteInfo.cod_mon,
                   // prima = (int)quoteInfo.DatosEconomicos.annualnetpremium,
                    estado="A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = 202,


                }
            };
            mapInfo.clientesOtrosAtributos = new[] { OtrosAtributos };
            mapInfo.clientesPatrimonio = new List<Clientespatrimonio> { Patrimonio };
            if (quoteInfo.DatosEconomicos != null)
            {
                mapInfo.clientesPolizas[0].prima = (int)quoteInfo.DatosEconomicos.annualgrosspremium;
            }



            string result = Architect.Compliance.Integrations.Business.Customers.SendCustomers(mapInfo).Result;
            return result;
        }
    }
}
