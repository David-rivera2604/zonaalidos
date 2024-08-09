using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Multirriesgo
{
    static class Common
    {
        internal static List<Contracts.Comun.Cobertura> CoverageByDefault(bool isCoope, int cod_cia, int cod_ramo, int cod_modalidad, DateTime fec_validez)
        {
            string cod_cobExcludeFilter = "2019";
            string selected = "2001,2002,2024,2025,2026,2027";

            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            foreach (Contracts.Ramo.a1002150 item in DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, string.Empty))
            {
                coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = selected.Contains(item.COD_COB.ToString()),
                    requerida = item.MCA_OBLIGATORIO == "S",
                    codigo = item.COD_COB,
                    nombre = item.NOM_COB,
                    capital = item.SUMA_ASEG,
                    primatotal = item.IMP_TOTAL,
                    deducible = item.NOM_FRANQUICIA
                });
            }
            return coberturas;
        }

        /// <summary>
        /// Recupera la configuración de coberturas por defecto.
        /// </summary>
        internal static List<Contracts.Comun.Cobertura> CoverageByGroupByDefault(bool isCoope, int cod_cia, int cod_ramo, DateTime fec_validez, string cobIncludeFilter, List<Contracts.Ramo.G2990026> coberturaGrupo)
        {
            string cod_cobExcludeFilter = string.Empty;
            string selected = string.Empty;
            int cod_modalidad = Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_modalidad");

            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            if (cobIncludeFilter.IsEmpty())
            {
                if (isCoope)
                {
                    cod_cobExcludeFilter = "2001, 2009, 2007, 2017,2018, 2034, 2010, 2055, 2056, 2057, 2012, 2014";
                }
                else
                {
                    cod_modalidad = 99999;
                    cod_cobExcludeFilter = "2001, 2009";
                    selected = ",2002,2024,2027,";
                }
            }
            else
            {
                cod_modalidad = 99999;
            }
            Contracts.Comun.Cobertura currentCoverage;
            foreach (Architect.API.Tron.Contracts.Ramo.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, cobIncludeFilter))
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
                if (coberturaGrupo.IsNotEmpty())
                {
                    currentCoverage.requerida = coberturaGrupo.Any(r => r.COD_COB == item.COD_COB && r.MCA_OBLIGATORIO == "S");
                }
                coberturas.Add(currentCoverage);
            }
            return coberturas;
        }

        /// <summary>
        /// Total suma asegurada
        /// </summary>
        /// <param name="source">Cotización</param>
        /// <returns>Total suma asegurada</returns>
        internal static double Util_TotalSumInsured(Contracts.Cotizacion.Multirriesgo source)
        {
            return source.IMP_EDIFICIO + source.IMP_MOBILIARIO + source.IMP_MERCADERIA +
                    source.IMP_BIE_TEM_DES + source.IMP_BIE_INT + source.IMP_OBJ_ESP_VAL +
                    source.IMP_DOMOS_TOTAL + source.IMP_GAS_ALQ + source.IMP_PER_REN +
                    source.IMP_MER_TRA + source.IMP_MAQUINARIA + source.IMP_EQUIP_ELEC +
                    source.IMP_EQUIP_ELEC_M + source.IMP_INT_NEG;
        }

        /// <summary>
        /// Total suma asegurada de contenido
        /// </summary>
        /// <param name="source">Cotización</param>
        /// <returns>Total suma asegurada de contenido</returns>
        internal static double Util_TotalSumInsuredContenido(Contracts.Cotizacion.Multirriesgo source)
        {
            return source.IMP_MOBILIARIO + source.IMP_MERCADERIA +
                    source.IMP_BIE_TEM_DES + source.IMP_BIE_INT + source.IMP_OBJ_ESP_VAL;
        }


        internal static bool Util_CoverageSelected(Contracts.Cotizacion.Multirriesgo source, int code)
        {
            bool finded = false;
            foreach (Contracts.Comun.Cobertura item in source.coberturas)
            {
                if (item.codigo == code && item.seleccionado)
                {
                    finded = true;
                    break;
                }
            }
            return finded;
        }

        internal static bool Rule_AtLeastOneCoverageSelected(Contracts.Cotizacion.Multirriesgo source)
        {
            bool finded = false;
            foreach (Contracts.Comun.Cobertura item in source.coberturas)
            {
                if (item.seleccionado)
                {
                    finded = true;
                    break;
                }
            }
            return finded;
        }

    }
}
