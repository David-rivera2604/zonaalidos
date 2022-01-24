using Architect.API.Tron.Contracts.Cotizacion;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class Multirriesgo
    {

        const int COD_RAMO = 202;

        public static Architect.API.Tron.Contracts.Cotizacion.Multirriesgo Setup(Core.Contracts.Security.Token tokenInfo)
        {
            bool IsCoope = false;
            Architect.API.Tron.Contracts.Cotizacion.Multirriesgo result = new Architect.API.Tron.Contracts.Cotizacion.Multirriesgo()
            {
                cod_ramo = COD_RAMO,
                cod_mon = 1,
                cod_fracc_pago = 1,
                fec_efec_poliza = DateTime.Today,
                fec_vcto_poliza = DateTime.Today.AddYears(1),
                cod_pais = "CRI",
                cod_estado = 1,
                cod_prov = 101,
                cod_localidad = 10101,
                cod_tip_ocup = 20200111,
                cod_tip_edit = 2,
                num_pisos_edif = 1,
                cod_tipo_estruc = 1,
                cod_tipo_techo = 2,
                cod_tipo_pared = 1,
                MCA_EXTIN_INC = 2,
                cod_tip_rgo_idn = 1,
                Agente = tokenInfo.UserName
            };

            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            int cod_ramo = COD_RAMO;
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);
            DateTime fec_validez = DateTime.Today;

            result.coberturas = CoverageByDefault(IsCoope, cod_cia, cod_ramo, fec_validez);

            return result;
        }


        internal static List<Contracts.Comun.Cobertura> CoverageByDefault(bool isCoope, int cod_cia, int cod_ramo, DateTime fec_validez)
        {
            string cod_cobExcludeFilter = "2019";
            string selected = "2001,2002,2024,2025,2026,2027";
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);

            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            foreach (Architect.API.Tron.Contracts.Tables.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, string.Empty))
            {
                coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = selected.Contains(item.COD_COB.ToString()),
                    requerida = item.MCA_OBLIGATORIO == "S",
                    codigo = item.COD_COB,
                    nombre = item.NOM_COB,
                    capital = item.SUMA_ASEG,
                    primatotal = item.IMP_TOTAL,
                    decucible = item.NOM_FRANQUICIA
                });
            }
            return coberturas;
        }

        public static Contracts.Cotizacion.Multirriesgo Quote(Contracts.Cotizacion.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.Multirriesgo resultInfo = quoteInfo;
            //TODO: Es necesario convertir las validaciones existentes en el JS
            resultInfo.Errors = Validate(quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                bool IsCoope = false;
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;
                Architect.API.Tron.Contracts.Presupuesto.DatoFijo quoteTron = MultirriesgoConvertTo.Tron(quoteInfo, IsCoope, COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName);
                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result, @"C:\temp\Multirriesgo.in.xml");

                //Utilities.SerializeHandler<Architect.API.Tron.Contracts.Presupuesto.DatoFijo>.SerializeJSONToFile(quoteTron, string.Format(@"c:\temp\multi.rriesgo.proposal.json"), true, false, false);

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo resultTron = Backoffice.Cotizacion.Generico.Calcular(quoteTron);
                resultInfo = MultirriesgoConvertFrom.Quote(quoteInfo, resultTron);

                Architect.Utilities.Cache.SetItem(
                    string.Format("multirriesgo.{0}", resultInfo.presupuesto),
                        Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Multirriesgo", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }
                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result, @"C:\temp\Multirriesgo.out.xml");
            }
            return resultInfo;
        }

        /// <summary>
        /// Valida la informacion de una póliza para permitir o no su emisión.
        /// </summary>
        /// <param name="source">Datos de la póliza</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <returns></returns>
        private static List<Core.Contracts.General.Error> Validate(Contracts.Cotizacion.Multirriesgo source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "Multirriesgo";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Coberturas:
            if (!Rule_AtLeastOneCoverageSelected(source))
            {
                result.Add(new Core.Contracts.General.Error() { Group = "Table", Key = "coberturasTbl", Message = "Debe seleccionar al menos una cobertura" });
            }

            //num_pisos_edif: 
            if (tokenInfo.Roles.Contain("Agente") && source.num_pisos_edif > 1)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "num_pisos_edif", Message = "Debido a su perfil de usuario, no podrá cotizar edificaciones superiores a 1 pisos" });
            }
            //num_pisos_edif: 
            if (tokenInfo.Roles.Contain("Agente") && source.cod_tip_ocup > 999999 && source.cod_tip_ocup.ToString().Substring(6, 1) == "6")
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "cod_tip_ocup", Message = "Debido a su perfil de usuario, no podrá cotizar riesgos clasificados como altos" });
            }
            //IMP_EDIFICIO:
            if (tokenInfo.Roles.Contain("Agente") && source.cod_mon == 1 && source.IMP_EDIFICIO > 0 && source.IMP_EDIFICIO < 25000000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "IMP_EDIFICIO", Message = "Debido a su perfil de usuario, no puede cotizar edificios menores a 25.000.000,00 colones" });
            }
            //IMP_EDIFICIO:
            if (tokenInfo.Roles.Contain("Agente") && source.cod_mon == 2 && source.IMP_EDIFICIO > 0 && source.IMP_EDIFICIO < 50000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "IMP_EDIFICIO", Message = "Debido a su perfil de usuario, nopuede cotizar edificios menores a $50.000,00 dolares" });
            }

            //*: Sumas aseguradas maxima en colones
            if (result.Count == 0 && tokenInfo.Roles.Contain("Agente") && source.cod_mon == 1 &&
                Util_TotalSumInsured(source) > 375000000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, solo puede cotizar hasta 375.000.000,00 colones" });
            }
            //*: Sumas aseguradas maxima en dolares
            if (result.Count == 0 && tokenInfo.Roles.Contain("Agente") && source.cod_mon == 2 &&
                Util_TotalSumInsured(source) > 750000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, solo puede cotizar hasta $750.000,00 dolares" });
            }
            //*: contenidos en colones
            if (result.Count == 0 && tokenInfo.Roles.Contain("Agente") && (Util_CoverageSelected(source, 2008) || Util_CoverageSelected(source, 2009)) &&
                source.cod_mon == 1 && Util_TotalSumInsuredContenido(source) > 0 && Util_TotalSumInsuredContenido(source) < 7000000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, no puede tarifar contenidos menores a 7.000.000,00 colones" });
            }
            //*: contenidos en dolares
            if (result.Count == 0 && tokenInfo.Roles.Contain("Agente") && (Util_CoverageSelected(source, 2008) || Util_CoverageSelected(source, 2009)) &&
                source.cod_mon == 2 && Util_TotalSumInsuredContenido(source) > 0 && Util_TotalSumInsuredContenido(source) < 14000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, no puede tarifar contenidos menores a $14.000,00 dolares" });
            }

            return result;
        }

        /// <summary>
        /// Total suma asegurada
        /// </summary>
        /// <param name="source">Cotización</param>
        /// <returns>Total suma asegurada</returns>
        private static double Util_TotalSumInsured(Contracts.Cotizacion.Multirriesgo source)
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
        private static double Util_TotalSumInsuredContenido(Contracts.Cotizacion.Multirriesgo source)
        {
            return source.IMP_MOBILIARIO + source.IMP_MERCADERIA +
                    source.IMP_BIE_TEM_DES + source.IMP_BIE_INT + source.IMP_OBJ_ESP_VAL;
        }


        private static bool Util_CoverageSelected(Contracts.Cotizacion.Multirriesgo source, int code)
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

        private static bool Rule_AtLeastOneCoverageSelected(Contracts.Cotizacion.Multirriesgo source)
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
