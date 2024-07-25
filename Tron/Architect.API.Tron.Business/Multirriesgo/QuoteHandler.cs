using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Business.Multirriesgo
{
    public static class QuoteHandler
    {

        /// <summary>
        /// Prepara la información inicial la para la preparación de un presupuesto.
        /// </summary>
        public static Contracts.Cotizacion.Multirriesgo QuoteSetup(int cod_ramo, Core.Contracts.Security.Token tokenInfo)
        {
            bool IsCoope = false;
            Contracts.Cotizacion.Multirriesgo result = new Contracts.Cotizacion.Multirriesgo()
            {
                cod_ramo = cod_ramo,
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

            result.coberturas = Helpers.CoverageByDefault(IsCoope, 
                Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1), 
                cod_ramo,
                Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_modalidad"), 
                DateTime.Today);

            return result;
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo multirriesgo.
        /// </summary>
        public static Contracts.Cotizacion.Multirriesgo Quote(Contracts.Cotizacion.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.Multirriesgo resultInfo = quoteInfo;

            resultInfo.Errors = QuoteValidate(quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                bool IsCoope = false;
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;
                Contracts.Presupuesto.DatoFijo quoteTron = ConvertQuoteToPresupuesto.Tron(quoteInfo, IsCoope, quoteInfo.cod_ramo, tokenInfo.AgentCode, tokenInfo.UserName);

                Contracts.Presupuesto.DatoFijo resultTron = Backoffice.Cotizacion.Generico.Calcular(quoteTron);
                resultInfo = ConvertPresupuestoToQuote.Quote(quoteInfo, resultTron);

                Architect.Utilities.Cache.SetItem(
                    string.Format("multirriesgo.{0}", resultInfo.presupuesto),
                        Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, 
                        Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Multirriesgo", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }
            }
            return resultInfo;
        }

        /// <summary>
        /// Valida la información de una póliza para permitir o no su emisión.
        /// </summary>
        private static List<Core.Contracts.General.Error> QuoteValidate(Contracts.Cotizacion.Multirriesgo source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "Multirriesgo";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Coberturas:
            if (!Helpers.Rule_AtLeastOneCoverageSelected(source))
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
                Helpers.Util_TotalSumInsured(source) > 375000000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, solo puede cotizar hasta 375.000.000,00 colones" });
            }
            //*: Sumas aseguradas maxima en dolares
            if (result.Count == 0 && tokenInfo.Roles.Contain("Agente") && source.cod_mon == 2 &&
                Helpers.Util_TotalSumInsured(source) > 750000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, solo puede cotizar hasta $750.000,00 dolares" });
            }
            //*: contenidos en colones
            if (result.Count == 0 && tokenInfo.Roles.Contain("Agente") && (Helpers.Util_CoverageSelected(source, 2008) || Helpers.Util_CoverageSelected(source, 2009)) &&
                source.cod_mon == 1 && Helpers.Util_TotalSumInsuredContenido(source) > 0 && Helpers.Util_TotalSumInsuredContenido(source) < 7000000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, no puede tarifar contenidos menores a 7.000.000,00 colones" });
            }
            //*: contenidos en dolares
            if (result.Count == 0 && tokenInfo.Roles.Contain("Agente") && (Helpers.Util_CoverageSelected(source, 2008) || Helpers.Util_CoverageSelected(source, 2009)) &&
                source.cod_mon == 2 && Helpers.Util_TotalSumInsuredContenido(source) > 0 && Helpers.Util_TotalSumInsuredContenido(source) < 14000)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "Debido a su perfil de usuario, no puede tarifar contenidos menores a $14.000,00 dolares" });
            }

            return result;
        }

    }
}
