using Architect.Utilities.Extensions;
using System;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    /// <summary>
    /// Cotización de póliza de saldo deudor en tron.
    /// </summary>
    public sealed class SaldoDeudor
    {
        public const int COD_RAMO = 401;
        public const string NOM_PROD = "SaldoDeudor";

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo saldo deudor.
        /// </summary>
        public static Contracts.Cotizacion.SaldoDeudor Setup(Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.SaldoDeudor result = (Contracts.Cotizacion.SaldoDeudor)Generico.ValoresIniciales(new Contracts.Cotizacion.SaldoDeudor(), COD_RAMO, NOM_PROD, tokenInfo);
            if(result.coberturas.Where(r => r.codigo==4001) != null){
                result.coberturas.Where(r => r.codigo == 4001).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4002) != null)
            {
                result.coberturas.Where(r => r.codigo == 4002).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4005) != null)
            {
                result.coberturas.Where(r => r.codigo == 4005).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4006) != null)
            {
                result.coberturas.Where(r => r.codigo == 4006).First().edtCapital = true;
            }
            if (result.coberturas.Where(r => r.codigo == 4007) != null)
            {
                result.coberturas.Where(r => r.codigo == 4007).First().edtCapital = true;
            }
            result.MCA_NEGOCIO_MIGRADO = "N";
            return result;
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo saldo deudor.
        /// </summary>
        public static Contracts.Cotizacion.SaldoDeudor Quote(Contracts.Cotizacion.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.SaldoDeudor resultInfo = quoteInfo;

            resultInfo.Errors = Reglas.research.Apply_Reglas(NOM_PROD, quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;

                Contracts.Presupuesto.DatoFijo result = SaldoDeudorConvert.ToTron(quoteInfo, COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName);
                result = Backoffice.Cotizacion.Generico.Calcular(result);

                resultInfo = LookupComplements((Contracts.Cotizacion.SaldoDeudor)Util.FromTron_CoberturasResult(quoteInfo, result, 11), tokenInfo);
                resultInfo.cod_ramo = COD_RAMO;
                Architect.Utilities.Cache.SetItem(string.Format("{0}.{1}", NOM_PROD, quoteInfo.presupuesto), Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Saldo Deudor", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }
            }

            return resultInfo;
        }

        /// <summary>
        /// Prepara las descripciones de campos relacionados a listas de valores.
        /// </summary>
        private static Contracts.Cotizacion.SaldoDeudor LookupComplements(Contracts.Cotizacion.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            //string context = string.Format("cod_ramo={0}:cod_mon={1}:cod_pais={2}:cod_tip_ocup={3}%:cod_estado={4}:cod_prov={5}",
            //    quoteInfo.cod_ramo, quoteInfo.moneda, quoteInfo.pais, quoteInfo.ocupaciondelriesgo, quoteInfo.provincia, quoteInfo.canton);

            //quoteInfo.monedaDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "MonedasPorRamo", quoteInfo.moneda.ToString(), context);


            return quoteInfo;
        }

    }
}
