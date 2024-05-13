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

namespace Architect.API.Tron.Business.Emision
{
    public static class Solicitud
    {

        public static string ReEnviarSolicitud(string presupuesto, string correoenvio, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);
            Contracts.Emision.MapfreMas quoteInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.MapfreMas>(proposal.ProposalData);

            quoteInfo.DatosEconomicos = EconomicDataCalculate(quoteInfo);

            Dictionary<string, string> request = EnviarSolicitud(proposal.SigningType, correoenvio, quoteInfo, tokenInfo);
            string message = string.Empty;

            if (proposal.SigningType != Contracts.TipoDeFirma.Manual && request["UniqueId"].IsNotEmpty())
            {
                DataAccess.PolicyProposal.Update_Status(proposal.Id, 4, request["UniqueId"], tokenInfo.UserId);
            }
            if (proposal.SigningType == Contracts.TipoDeFirma.Manual)
            {
                message = "El presupuesto fue enviado a la dirección '" + correoenvio + "' de forma exitosa.";
            }
            else
            {
                if (request["UniqueId"].IsNotEmpty())
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

        internal static Dictionary<string, string> EnviarSolicitud(string tip_firma, string correoenvio, Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            string filename;
            Dictionary<string, string> result = new Dictionary<string, string>
            {
                { "UniqueId", string.Empty },
                { "PDF", string.Empty },
                { "Quote", string.Empty }
            };
            DocuSign.Integrations.Contracts.SubmitResult submit = new DocuSign.Integrations.Contracts.SubmitResult();
            result["PDF"] = General_PDF_Solicitud(quoteInfo, tokenInfo);

            filename = string.Format("Solicitud {0}.pdf", quoteInfo.presupuesto);
            Solicitud.Almacena_PDF(quoteInfo.presupuesto, result["PDF"], filename, 98, filename, tokenInfo.CompanyId, tokenInfo.UserId);

            result["Quote"] = General_PDF_Cotización(quoteInfo, tokenInfo);

            filename = string.Format("Cotización {0}.pdf", quoteInfo.presupuesto);
            Solicitud.Almacena_PDF(quoteInfo.presupuesto, result["Quote"], filename, 98, filename, tokenInfo.CompanyId, tokenInfo.UserId);

            Contracts.Comun.tercero primaryInsured = (from t in quoteInfo.terceros where t.tipodetercero == 2 select t).First();
            if (tip_firma == Contracts.TipoDeFirma.Manual)
            {


                Core.Business.General.Mail.SendByTemplate("MapfreMas_Solicitud", tokenInfo.CompanyId, tokenInfo.UserId, 0, quoteInfo,
                    new Dictionary<string, string>() { { correoenvio, string.Empty } },
                    new string[] { string.Format("{0};Solicitud {1}.pdf", result["PDF"], quoteInfo.presupuesto),
                                   string.Format("{0};Cotización {1}.pdf", result["Quote"], quoteInfo.presupuesto)});
                submit.UniqueId = quoteInfo.presupuesto;
            }
            else
            {
                submit = DocuSign.Integrations.DocuSign.Submit(
                                quoteInfo.presupuesto,
                                "Solicitud de seguro, presupuesto " + quoteInfo.presupuesto,
                                primaryInsured.nombre.CompleteFullName(primaryInsured.apellido1, primaryInsured.apellido2),
                                correoenvio,
                                result["PDF"], quoteInfo.tip_firma == Contracts.TipoDeFirma.Tablet ? "Handwriting" : "WebClick").GetAwaiter().GetResult();
            }
            result["UniqueId"] = submit.UniqueId;
            return result;
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

            if (tokenInfo.Roles.Contain("PolizaGrupo") && !((quoteInfo.polizagrupo == "3022310199235") || (quoteInfo.polizagrupo == null) || quoteInfo.polizagrupo == "")) //Bariloche
            {
                return Core.Business.General.Report.GeneratePDFFile("mapfremas_solicitud", data).GetAwaiter().GetResult();
            }
            else
            {
                return Core.Business.General.Report.GeneratePDFFile("mapfremas_solicitud_individual", data).GetAwaiter().GetResult();
            }


        }

        private static string General_PDF_Cotización(Contracts.Cotizacion.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            return Core.Business.General.Report.GeneratePDFFile("mapfremas", quoteInfo).GetAwaiter().GetResult();
        }

        internal static void Almacena_Documento_Firmado(string presupuesto, string fileContent, int companyId, int userId)
        {
            Byte[] pdfbytes = Convert.FromBase64String(fileContent);
            string originalFileName = "Documento firmado.pdf";
            string fileName = string.Format("{0}.pdf", Guid.NewGuid());
            string fullFileName = Path.Combine(ConfigurationManager.AppSettings["Attachments.Path"], fileName);

            File.WriteAllBytes(fullFileName, pdfbytes);

            Solicitud.Almacena_PDF(presupuesto, fullFileName, originalFileName, 99, "Documento firmado", companyId, userId);
        }

        internal static void Almacena_PDF(string presupuesto, string fullFileName, string originalFileName, int documentType, string description, int companyId, int userId)
        {

            Core.Contracts.General.Attachments attachment = new Core.Contracts.General.Attachments
            {
                EntityType = 3000,
                EntityId = Convert.ToInt64(presupuesto),
                CompanyId = companyId,
                UpdateUserCode = userId,
                DocumentType = documentType,
                Description = description,
                FileName = originalFileName,
                FileContent = fullFileName
            };
            Core.Business.General.Attachment.SyncUp(attachment);
        }

        internal static Contracts.Emision.EconomicData EconomicDataCalculate(Contracts.Cotizacion.MapfreMas quoteInfo)
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

    }
}
