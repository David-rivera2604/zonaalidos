using Architect.Utilities.Extensions;
using System;
using System.Configuration;

namespace Architect.API.Tron.Business.Emision
{
    /// <summary>
    /// Cotización de póliza de hogar total en tron.
    /// </summary>
    public static class HogarTotal
    {

        public static Contracts.Emision.HogarTotal Setup(string presupuesto, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Emision.HogarTotal result = null;
            string key = string.Format("hogartotal.{0}", presupuesto);

            if (Architect.Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.HogarTotal>(Architect.Utilities.Cache.GetItem(key).ToString());

                result.terceros = Reglas.research.Apply_Terceros("HogarTotal", result.terceros, string.Empty, tokenInfo);

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("HogarTotal", null, 0, tokenInfo);

            }

            return result;
        }

        public static Contracts.Emision.HogarTotal Issue(Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            //Architect.Common.Helpers.Serialize.SerializeToFile<Contracts.Cotizacion.HogarTotal>(quoteInfo,
            //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.emision.in.xml", true);

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = HogarTotalConvertTo.Tron(quoteInfo);

            //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result,
            //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.emision.in.raw.xml", true);

            Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

            //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.a2000030>(result2,
            //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.out.raw.xml", true);

            Contracts.Emision.HogarTotal resultQuoteInfo = HogarTotalConvertFrom.Quote(quoteInfo, result2);

            if (resultQuoteInfo.num_poliza.IsNotEmpty())
            {
                Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Hogar Total", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);
            }

            return resultQuoteInfo;
        }

    }
}
