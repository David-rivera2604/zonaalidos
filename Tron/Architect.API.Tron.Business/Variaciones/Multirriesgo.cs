using Architect.API.Tron.Business.Backoffice;
using Architect.API.Tron.Contracts.Variaciones;
using Architect.API.Tron.DataAccess.Variaciones;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Architect.API.Tron.Business.Variaciones
{
    public static class Multirriesgo
    {
        /// <summary>
        /// Preparara información necesaria para inicial la emision de una variación.
        /// </summary>
        /// <param name="presupuesto">Número de presupuesto</param>
        /// <param name="tokenInfo">Información de contexto del usuario conectando.</param>
        public static Contracts.Variaciones.Multirriesgo Setup(string num_poliza, int num_spto, string mca_provisional, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Variaciones.Multirriesgo result = null;
            string key = string.Format("mapfremas.{0}", num_poliza);

            Contracts.Poliza.DatoFijo A30Instance = Poliza.PolizaVariaciones(1, num_poliza, true);

            Contracts.Variaciones.Multirriesgo resultInfo2 = Variaciones.MultirriesgoConvertFrom.Quote(Variaciones.MultirriesgoConvertFrom.Quote(A30Instance), A30Instance);

            // resultInfo2 = Variaciones.HogarTotalConvertFrom.SetTipoProducto(resultInfo2);

            if (mca_provisional.Equals("S"))
            {
                resultInfo2.Recibos = DataAccess.Variaciones.VariacionIssue.GetRecibos(resultInfo2.cod_cia, num_poliza, null);
            }

            Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);

            if (Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Variaciones.Multirriesgo>(Utilities.Cache.GetItem(key).ToString());

                //result.Modo = mode;

                //if (!tokenInfo.Roles.Contain("Purdy"))
                //{
                //    result.terceros = Reglas.research.Apply_Terceros("MapfreMas", result.terceros, result.Fuente_Tomador, tokenInfo);
                //}

                //result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("MapfreMas", null, result.MCA_CERO_KM, tokenInfo);
            }

            return result;
        }

        public static VariacionIssueResult Issue(Contracts.Variaciones.Multirriesgo quoteInfo)
        {
            return VariacionesServiceCommon.Issue(quoteInfo);
        }

        public static VariacionIssueResult Cancelation(Contracts.Variaciones.Multirriesgo quoteInfo)
        {
            return VariacionesServiceCommon.Cancelation(quoteInfo.cod_cia, quoteInfo.cod_ramo, quoteInfo.num_poliza, quoteInfo.fec_efec_cancel, quoteInfo.txt_motivo);
        }

        public static VariacionIssueResult ManageAuthorizationCT(int cod_cia, int cod_ramo, string num_poliza, int num_spto, string mca_autoriza)
        {
            return VariacionesServiceCommon.ManageAuthorizationCT(cod_cia, cod_ramo, num_poliza, num_spto, mca_autoriza);
        }


    }
}
