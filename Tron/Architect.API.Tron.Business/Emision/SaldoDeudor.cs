using Architect.API.Insurance.Contracts.Policy;
using Architect.API.Tron.Contracts.Emision;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Architect.API.Tron.Business.Emision
{
    /// <summary>
    /// Emisión de póliza de saldo deudor en tron.
    /// </summary>
    public static class SaldoDeudor
    {

        /// <summary>
        /// Devuelve información de un presupuesto para la emisión de una póliza de saldo deudor.
        /// </summary>
        public static Contracts.Emision.SaldoDeudor Setup(string presupuesto, string mode, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.SaldoDeudor result = null;
            string key = string.Format("{0}.{1}", Cotizacion.SaldoDeudor.NOM_PROD, presupuesto);
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

            if (mode == "resume")
            {
                //Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);

                Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, presupuesto, 0, 0, 0, null, true);
                Contracts.Cotizacion.SaldoDeudor resultInfo2 = Cotizacion.SaldoDeudorConvert.FromTron_Full(P30Instance);

                Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            }

            if (Utilities.Cache.Exist(key))
            {
                //    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.SaldoDeudor>(Utilities.Cache.GetItem(key).ToString());

                //    result.terceros = Reglas.research.Apply_Terceros(Cotizacion.SaldoDeudor.NOM_PROD, result.terceros, string.Empty, tokenInfo);

                //    result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos(Cotizacion.SaldoDeudor.NOM_PROD, null, 0, tokenInfo);

                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.SaldoDeudor>(Utilities.Cache.GetItem(key).ToString());

                result.Modo = mode;

                if (mode.IsEmpty() || mode == "draft" || mode == "resume" || tryOnTron)
                {
                    result.terceros = Reglas.research.Apply_Terceros(Cotizacion.SaldoDeudor.NOM_PROD, result.terceros, string.Empty, result.num_contrato, tokenInfo);
                }

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos(Cotizacion.SaldoDeudor.NOM_PROD, null, 0, tokenInfo);

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

        /// <summary>
        /// Realiza la validación de datos y emisión de la póliza para un producto de tipo Saldo deudor
        /// </summary>
        public static Contracts.Emision.SaldoDeudor Issue(Contracts.Emision.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.SaldoDeudor resultQuoteInfo = null;

            if (quoteInfo.Modo == "draft")
            {
                //TODO: Se debe incluir la validación de que de haber un Tomador, Asegurado y Conductor Habitual, pero faltan las básicas.
                //quoteInfo.DatosEconomicos = EconomicDataCalculate(quoteInfo);

                string uniqueId = EnviarSolicitud(quoteInfo.tip_firma, quoteInfo.correoenvio, quoteInfo, tokenInfo);
                AlmacenarSolicitud(quoteInfo, quoteInfo.tip_firma == Contracts.TipoDeFirma.Manual ? 33 : 4, tokenInfo, uniqueId);
                GuardaDatosVariables(quoteInfo.presupuesto, quoteInfo.cod_ramo, quoteInfo.tip_firma, quoteInfo.tip_firmaDesc, uniqueId);
                string message = string.Empty;

                if (uniqueId.IsNotEmpty() || quoteInfo.tip_firma == "M")
                {
                    message = string.Format("La solicitud fue enviada de forma exitosa usando el tipo de envío indicado ({0})", quoteInfo.tip_firmaDesc);
                }
                else
                {
                    message = "Ha ocurrido un error tratando de comunicarnos con el sistema de firma, por favor intente nuevamente y si el problema persiste comuníquese con MAPFRE Costa Rica.";
                }

                resultQuoteInfo = new Contracts.Emision.SaldoDeudor()
                {
                    Mensaje = message
                };

            }
            else
            {
                Contracts.Presupuesto.DatoFijo result = SaldoDeudorConvert.ToTron(quoteInfo, Cotizacion.SaldoDeudor.COD_RAMO, quoteInfo.cod_agt, tokenInfo.UserName);

                result.user_txt_motivo_spto = quoteInfo.user_txt_motivo_spto;

                Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

                resultQuoteInfo = SaldoDeudorConvert.FromTron(quoteInfo, result2);

                if (resultQuoteInfo.num_poliza.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Seguro de Viaje", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                    //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                    Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

                }

            }

            return resultQuoteInfo;
        }


        private static string EnviarSolicitud(string tip_firma, string correoenvio, Contracts.Emision.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            DocuSign.Integrations.Contracts.SubmitResult submit = new DocuSign.Integrations.Contracts.SubmitResult();
            string solicitudPDF = Generar_PDF_Solicitud(quoteInfo, tokenInfo);
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
                                "Envío solicitud " + quoteInfo.presupuesto,
                                primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                                correoenvio,
                                solicitudPDF, quoteInfo.tip_firma == Contracts.TipoDeFirma.Tablet ? "Handwriting" : "WebClick").GetAwaiter().GetResult();

            }
            return submit.UniqueId;
        }

        private static string Generar_PDF_Solicitud(Contracts.Emision.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Emision.SaldoDeudorSolicitud data = new SaldoDeudorSolicitud(); //Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.SaldoDeudorSolicitud>(Newtonsoft.Json.JsonConvert.SerializeObject(quoteInfo));

            data.EffectiveDate = quoteInfo.fec_efec_poliza;
            data.EndingDate = quoteInfo.fec_vcto_poliza;
            data.IssueDate = quoteInfo.fec_efec_poliza;

            if (quoteInfo.cod_mon == 1)
                data.CurrencyDesc = "COLONES";
            else
                data.CurrencyDesc = "DÓLARES";

            //
            RiskRolesView riskRolesView = new RiskRolesView();
            riskRolesView.FullName = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.nombre + " " + a.apellido1 + " " + a.apellido2).FirstOrDefault();
            riskRolesView.FullAddress = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.otrasenas).FirstOrDefault();
            riskRolesView.DocumentType = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.DocumentNumberType).FirstOrDefault();
            riskRolesView.DocumentNumber = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.DocumentNumber).FirstOrDefault();
            riskRolesView.BirthDate = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.fechadenacimiento).FirstOrDefault();
            riskRolesView.PrimaryEmailAddress = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.correoelectronico).FirstOrDefault();
            riskRolesView.PhoneNumber = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.numerodetelefono).FirstOrDefault();
            riskRolesView.CivilStatusDesc = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.estadoCivilDesc).FirstOrDefault();
            riskRolesView.ProvinceDesc = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.TProvinciaDesc).FirstOrDefault();
            riskRolesView.CantonDesc = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.TCantonDesc).FirstOrDefault();
            riskRolesView.CantonDesc = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.TDistritoDesc).FirstOrDefault();
            riskRolesView.AddressDetail = (from a in quoteInfo.terceros where a.tipodetercero == 2 select a.otrasenas).FirstOrDefault();
            riskRolesView.Weight = quoteInfo.NUM_PESO;
            riskRolesView.Height = quoteInfo.NUM_ESTATURA_CM;

            data.PrimaryInsured = riskRolesView;
            //
            int index = 1;
            RiskBeneficiaryInfoView riskBeneficiaryInfoView = new RiskBeneficiaryInfoView();

            foreach (Contracts.Comun.tercero item in from b in quoteInfo.terceros where b.tipodetercero == 6 select b)
            {
                
                RiskBeneficiaryView riskBeneficiaryView = new RiskBeneficiaryView();

               switch (index)
                {
                    case 1:
                        riskBeneficiaryView.FullName = item.nombre + " " + item.apellido1 + " " + item.apellido2;
                        riskBeneficiaryView.DocumentNumber = item.DocumentNumber;
                        riskBeneficiaryView.RelationshipDesc = item.parentescoDesc;
                        riskBeneficiaryView.ParticipationRate = item.porcentaje;
                        riskBeneficiaryView.FullAddress = item.otrasenas;
                        riskBeneficiaryView.Phone = item.numerodetelefono;
                        riskBeneficiaryView.Email = item.correoelectronico;
                        riskBeneficiaryInfoView.Beneficiary1 = riskBeneficiaryView;
                        break;
                    case 2:
                        riskBeneficiaryView.FullName = item.nombre + " " + item.apellido1 + " " + item.apellido2;
                        riskBeneficiaryView.DocumentNumber = item.DocumentNumber;
                        riskBeneficiaryView.RelationshipDesc = item.parentescoDesc;
                        riskBeneficiaryView.ParticipationRate = item.porcentaje;
                        riskBeneficiaryView.FullAddress = item.otrasenas;
                        riskBeneficiaryView.Phone = item.numerodetelefono;
                        riskBeneficiaryView.Email = item.correoelectronico;
                        riskBeneficiaryInfoView.Beneficiary2 = riskBeneficiaryView;
                        break;
                    case 3:
                        riskBeneficiaryView.FullName = item.nombre + " " + item.apellido1 + " " + item.apellido2;
                        riskBeneficiaryView.DocumentNumber = item.DocumentNumber;
                        riskBeneficiaryView.RelationshipDesc = item.parentescoDesc;
                        riskBeneficiaryView.ParticipationRate = item.porcentaje;
                        riskBeneficiaryView.FullAddress = item.otrasenas;
                        riskBeneficiaryView.Phone = item.numerodetelefono;
                        riskBeneficiaryView.Email = item.correoelectronico;
                        riskBeneficiaryInfoView.Beneficiary3 = riskBeneficiaryView;
                        break;
                    case 4:
                        riskBeneficiaryView.FullName = item.nombre + " " + item.apellido1 + " " + item.apellido2;
                        riskBeneficiaryView.DocumentNumber = item.DocumentNumber;
                        riskBeneficiaryView.RelationshipDesc = item.parentescoDesc;
                        riskBeneficiaryView.ParticipationRate = item.porcentaje;
                        riskBeneficiaryView.FullAddress = item.otrasenas;
                        riskBeneficiaryView.Phone = item.numerodetelefono;
                        riskBeneficiaryView.Email = item.correoelectronico;
                        riskBeneficiaryInfoView.Beneficiary5 = riskBeneficiaryView;
                        break;
                    case 5:
                        riskBeneficiaryView.FullName = item.nombre + " " + item.apellido1 + " " + item.apellido2;
                        riskBeneficiaryView.DocumentNumber = item.DocumentNumber;
                        riskBeneficiaryView.RelationshipDesc = item.parentescoDesc;
                        riskBeneficiaryView.ParticipationRate = item.porcentaje;
                        riskBeneficiaryView.FullAddress = item.otrasenas;
                        riskBeneficiaryView.Phone = item.numerodetelefono;
                        riskBeneficiaryView.Email = item.correoelectronico;
                        riskBeneficiaryInfoView.Beneficiary5 = riskBeneficiaryView;
                        break;

                }

                index++;
                data.Beneficiaries = riskBeneficiaryInfoView;
            }
            //
            data.InsuredAmount = quoteInfo.IMP_MONTO_ORI;
            data.MonthlyPremium = (from t in quoteInfo.plandepago select t.importetotal).LastOrDefault();
            //
            data.Questionary = MapperQuestionary(quoteInfo.Questionary);
            data.Behavior = "Show.DS";  ///Show.CV
            //
            return Core.Business.General.Report.Generate(tokenInfo.CompanyId, "coopenae_saldo_deudor", data).GetAwaiter().GetResult();
        }

        private static void AlmacenarSolicitud(Contracts.Emision.SaldoDeudor quoteInfo, int status, Core.Contracts.Security.Token tokenInfo, string uniqueId)
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
                Summary = string.Format("FeNacimiento: {0}, Estatura: {1}, Peso: {2}, NumIMC: {3}", quoteInfo.FEC_NACIMIENTO, quoteInfo.NUM_ESTATURA_CM, quoteInfo.NUM_PESO, quoteInfo.NUM_IMC),
                IssueDate = DateTime.Now,
                SigningRequestId = uniqueId,
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

        public static RiskQuestionaryViews MapperQuestionary(List<Questionary> source)
        {
            RiskQuestionaryViews target = new RiskQuestionaryViews();
            foreach (Questionary item in source)
            {

                switch (item.QuestionId)
                {
                    case 1:
                        target.Question1 = new RiskQuestionViews()
                        {
                            Confirmation = Convert.ToInt32(item.Confirmation),
                            Summary = string.Empty //$"Diagnóstico: {item.Diagnosis}, Tratamiento: {item.Treatment}, Médico: {item.Doctor}, Fecha: {item.When:dd/MM/yyyy}."
                        };
                        break;
                    case 2:
                        target.Question2 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Amplíe: {item.Diagnosis}." : string.Empty
                        };
                        break;
                    case 3:
                        target.Question3 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = string.Empty //$"Diagnóstico: {item.Diagnosis}, Tratamiento: {item.Treatment}, Médico: {item.Doctor}, Fecha: {item.When:dd/MM/yyyy}."
                        };
                        break;
                    case 4:
                        target.Question4 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = string.Empty //$"Diagnóstico: {item.Diagnosis}, Tratamiento: {item.Treatment}, Médico: {item.Doctor}, Fecha: {item.When:dd/MM/yyyy}."
                        };
                        break;
                    case 5:
                        target.Question5 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = string.Empty //$"Diagnóstico: {item.Diagnosis}, Tratamiento: {item.Treatment}, Médico: {item.Doctor}, Fecha {item.When:dd/MM/yyyy}."
                        };
                        break;
                    case 6:
                        target.Question6 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Fecha probable del alumbramiento: {item.When:dd/MM/yyyy}." : string.Empty
                        };
                        break;
                    case 7:
                        target.Question7 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Amplíe: {item.Diagnosis}." : string.Empty
                        };
                        break;
                    case 8:
                        target.Question8 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Resultado: {item.Diagnosis}, Motivo: {item.Doctor}, Fecha: {item.When:dd/MM/yyyy}." : string.Empty
                        };
                        break;
                    case 9:
                        target.Question9 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Resultado: {item.Diagnosis}, Lugar de atención: {item.Treatment}, Médico: {item.Doctor}, Fecha {item.When:dd/MM/yyyy}." : string.Empty
                        };
                        break;
                    case 10:
                        target.Question10 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Resultado: {item.Diagnosis}, Lugar de atención: {item.Treatment}, Médico: {item.Doctor}, Fecha {item.When:dd/MM/yyyy}." : string.Empty
                        };
                        break;
                    case 11:
                        target.Question11 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = string.Empty // $"Diagnóstico: {item.Diagnosis}, Tratamiento: {item.Treatment}, Médico: {item.Doctor}, Fecha: {item.When:dd/MM/yyyy}."
                        };
                        break;
                    case 12:
                        target.Question12 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Amplíe: {item.Diagnosis}." : string.Empty
                        };
                        break;
                    case 13:
                        target.Question13 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Amplíe: {item.Diagnosis}." : string.Empty
                        };
                        break;
                    case 14:
                        target.Question14 = new RiskQuestionViews()
                        {
                            Confirmation = item.Confirmation,
                            Summary = item.Confirmation == 1 ? $"Cuantos cigarros al día fuma: {item.Doctor}, Desde cuándo: {item.When:dd/MM/yyyy}." : string.Empty
                        };
                        break;


                    //case 51:
                    //    target.Question51 = new RiskQuestionViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = item.Confirmation == 1 ? $"País o países y las fechas exactas: {item.Diagnosis}." : string.Empty
                    //    };
                    //    break;
                    //case 52:
                    //    target.Question52 = new RiskQuestionViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = string.Empty
                    //    };
                    //    break;
                    //case 53:
                    //    target.Question53 = new RiskQuestionViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = item.Confirmation == 1 ? $"Detalle: {item.Diagnosis}." : string.Empty
                    //    };
                    //    break;
                    //case 54:
                    //    target.Question54 = new RiskQuestionaryViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = string.Empty
                    //    };
                    //    if (item.QuestionId == 54 && item.Diagnosis.IsNotEmpty())
                    //    {
                    //        string value = item.Diagnosis + ",false,false,false,false,false,false";
                    //        if (item.Confirmation == 1)
                    //        {
                    //            target.Question54.Detail = new Contracts.Policy.RiskQuestionDiagnosisDetailView()
                    //            {
                    //                Detail1 = value.Split(',')[0] == "true",
                    //                Detail2 = value.Split(',')[1] == "true",
                    //                Detail3 = value.Split(',')[2] == "true",
                    //                Detail4 = value.Split(',')[3] == "true",
                    //                Detail5 = value.Split(',')[4] == "true",
                    //                Detail6 = value.Split(',')[5] == "true"
                    //            };
                    //        }
                    //        else
                    //        {
                    //            target.Question54.Detail = new Contracts.Policy.RiskQuestionDiagnosisDetailView();
                    //        }
                    //    }
                    //    break;
                    //case 55:
                    //    target.Question55 = new RiskQuestionaryViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = string.Empty
                    //    };
                    //    break;
                    //case 56:
                    //    target.Question56 = new RiskQuestionaryViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = item.Confirmation == 1 ? $"Detalle: {item.Diagnosis}." : string.Empty
                    //    };
                    //    break;
                    //case 57:
                    //    target.Question57 = new RiskQuestionaryViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = item.Confirmation == 1 ? $"Indique la fecha: {item.When:dd/MM/yyyy}." : string.Empty
                    //    };
                    //    break;
                    //case 58:
                    //    target.Question58 = new RiskQuestionaryViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = item.Confirmation == 2 ? $"Detalle el motivo: {item.Diagnosis}." : string.Empty
                    //    };
                    //    break;
                    //case 59:
                    //    target.Question59 = new RiskQuestionaryViews()
                    //    {
                    //        Confirmation = item.Confirmation,
                    //        Summary = item.Confirmation == 1 ? $"Cual vacuna le aplicaron: {item.Treatment}, Indique la fecha: {item.When:dd/MM/yyyy}, Cuántas dosis pose: {item.Doctor}." : string.Empty
                    //    };
                    //    break;
                }
            }
            return target;
        }


    }
}
