using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Architect.API.Tron.Business.DocumentGenerator;

namespace Architect.API.Tron.Business.HogarTotal.Handler
{
    public static class Request
    {
        public static string ReEnviarSolicitud(string presupuesto, string correoenvio, Core.Contracts.Security.Token tokenInfo)
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

        internal static Contracts.Emision.EconomicData EconomicDataCalculate(Contracts.Cotizacion.HogarTotal quoteInfo)
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

        internal static string EnviarSolicitud(string tip_firma, string correoenvio, Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
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

        internal static string General_PDF_Solicitud(Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
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

    }
}
