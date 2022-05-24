using Architect.Utilities.Extensions;
using System;
using System.Configuration;

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

            if (mode == "resume")
            {
                //Contracts.PolicyProposal proposal = DataAccess.PolicyProposal.RetrieveByProposalId(presupuesto, tokenInfo.CompanyId);

                Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, presupuesto, 0, 0, 0, null, true);
                Contracts.Cotizacion.SaldoDeudor resultInfo2 = Cotizacion.SaldoDeudorConvert.FromTron_Full(P30Instance);

                Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);
            }

            if (Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Emision.SaldoDeudor>(Utilities.Cache.GetItem(key).ToString());

                result.terceros = Reglas.research.Apply_Terceros(Cotizacion.SaldoDeudor.NOM_PROD, result.terceros, string.Empty, tokenInfo);

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos(Cotizacion.SaldoDeudor.NOM_PROD, null, 0, tokenInfo);
            }

            return result;
        }

        /// <summary>
        /// Realiza la validación de datos y emisión de la póliza para un producto de tipo Saldo deudor
        /// </summary>
        public static Contracts.Emision.SaldoDeudor Issue(Contracts.Emision.SaldoDeudor quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Presupuesto.DatoFijo result = SaldoDeudorConvert.ToTron(quoteInfo, Cotizacion.SaldoDeudor.COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName);

            Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

            Contracts.Emision.SaldoDeudor resultQuoteInfo = SaldoDeudorConvert.FromTron(quoteInfo, result2);

            if (resultQuoteInfo.num_poliza.IsNotEmpty())
            {
                Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Seguro de Viaje", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);

            }
            return resultQuoteInfo;
        }

    }
}
