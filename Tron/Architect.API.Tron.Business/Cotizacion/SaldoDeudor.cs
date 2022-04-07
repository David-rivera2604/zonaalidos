using Architect.Utilities.Extensions;
using System;

namespace Architect.API.Tron.Business.Cotizacion
{
    /// <summary>
    /// Cotización de póliza de saldo deudor en tron.
    /// </summary>
    public sealed class SaldoDeudor
    {
        const int COD_RAMO = 401;
        const string NOM_PROD = "SaldoDeudor";

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo saldo deudor.
        /// </summary>
        public static Contracts.Cotizacion.SaldoDeudor Setup(Core.Contracts.Security.Token tokenInfo)
        {
            return (Contracts.Cotizacion.SaldoDeudor)Generico.ValoresIniciales(new Contracts.Cotizacion.SaldoDeudor(), COD_RAMO, NOM_PROD, tokenInfo);
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

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = SaldoDeudorConvert.ToTron(quoteInfo, COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName);
                result = Backoffice.Cotizacion.Generico.Calcular(result);

                //resultInfo = LookupComplements(HogarTotalConvertFrom.Quote(quoteInfo, result), tokenInfo);
                //Architect.Utilities.Cache.SetItem(string.Format("{0}.{1}", NOM_PROD, quoteInfo.presupuesto),Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Saldo Deudor", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }
            }

            return resultInfo;
        }
    }
}
