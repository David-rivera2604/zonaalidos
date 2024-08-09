using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Cotizacion
{
    public sealed class Generico
    {
        /// <summary>
        /// Recupera la configuración de coberturas por defecto.
        /// </summary>
        internal static List<Contracts.Comun.Cobertura> Coberturas(int cod_cia, int cod_ramo, DateTime fec_validez, string nom_prod, object data, Core.Contracts.Security.Token tokenInfo)
        {

            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);

            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            Contracts.Comun.Cobertura currentCoverage;

            string cod_cobExcludeFilter = Reglas.research.Apply_Coberturas(nom_prod, data, tokenInfo);

            if (cod_cobExcludeFilter.IsNotEmpty())
            {
                Architect.Utilities.Log.TraceLog("Coverage", $"Excluir '{cod_cobExcludeFilter}' las coberturas", "Decision");
            }

            string selected = string.Empty;
            foreach (Contracts.Ramo.a1002150 item in DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, string.Empty))
            {
                currentCoverage = new Contracts.Comun.Cobertura()
                {
                    seleccionado = selected.Contains(item.COD_COB.ToString()),
                    requerida = item.MCA_OBLIGATORIO == "S",
                    codigo = item.COD_COB,
                    nombre = item.NOM_COB,
                    capital = item.SUMA_ASEG,
                    primatotal = item.IMP_TOTAL,
                    deducible = item.NOM_FRANQUICIA,
                    error = item.TXT_ERROR
                };
                if (currentCoverage.requerida)
                {
                    currentCoverage.seleccionado = true;
                }
                coberturas.Add(currentCoverage);
            }
            return coberturas;
        }

        /// <summary>
        /// Devuelve un versión inicial genérica del objeto base usado para cotizar.
        /// </summary>
        public static Contracts.Cotizacion.GenericQuote ValoresIniciales(Contracts.Cotizacion.GenericQuote quote, int cod_ramo, string nom_prod, Core.Contracts.Security.Token tokenInfo)
        {
            DateTime fec_validez = DateTime.Today;

            quote.cod_ramo = cod_ramo;
            quote.cod_mon = 1;
            quote.cod_fracc_pago = 1;
            quote.fec_efec_poliza = fec_validez;
            quote.fec_vcto_poliza = fec_validez.AddYears(1);
            quote.Agente = tokenInfo.UserName;
            quote.cod_agt = tokenInfo.AgentCode;
            quote.coberturas = Generico.Coberturas(Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia"), cod_ramo, fec_validez, nom_prod, quote, tokenInfo);


            return quote;
        }

    }
}
