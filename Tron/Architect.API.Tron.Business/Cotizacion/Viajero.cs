using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class Viajero
    {
        const int COD_RAMO = 441;
        const int COD_MON = 2;

        public static Contracts.Cotizacion.Viajero Setup(Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Cotizacion.Viajero result = new Contracts.Cotizacion.Viajero()
            {
                cod_mon = COD_MON,
                cod_fracc_pago = 101,
                fec_efec_poliza = DateTime.Today,
                fec_vcto_poliza = DateTime.Today,
                TIP_PLAN = "I",
                TIP_VIAJE = "NA",
                FEC_VIAJE = DateTime.Today,
                DES_DESTINO = "",
                
            };

            bool IsCoope = false;
            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            int cod_ramo = COD_RAMO;
            DateTime fec_validez = DateTime.Today;


            result.coberturas = CoverageByDefault(IsCoope, cod_cia, cod_ramo, fec_validez, string.Empty);

            return result;
        }

        internal static List<Contracts.Comun.Cobertura> CoverageByDefault(bool isCoope, int cod_cia, int cod_ramo, DateTime fec_validez, string cobIncludeFilter)
        {
            string cod_cobExcludeFilter = string.Empty;
            string selected = string.Empty;
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);

            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            if (cobIncludeFilter.IsEmpty())
            {
                
                    cod_modalidad = 99999;
                    cod_cobExcludeFilter = "4449,4450,4451,4452,4453,4454,4455," +
                                "4456,4458,4459,4461,4462,4463,4464,4465,4466,4467,4468,4469,4470,4474," +
                                "4471,4472,4473,4475,4476,4477,44784421,4423,4424,4425,4426," +
                                "4427,4428,4429,4430,4431,4432,4434,4435," +
                                "4436,4437,4438,4439,4440,4441,4442," +
                                "4443,4445,4446,4447,4448,9998,4421,4478";

                    selected = "4457,4460";
                
            }
            else
            {
                cod_modalidad = 99999;
            }
            foreach (Architect.API.Tron.Contracts.Ramo.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, cobIncludeFilter))
            {
                coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = selected.Contains(item.COD_COB.ToString()),
                    codigo = item.COD_COB,
                    nombre = item.NOM_COB,
                    capital = item.SUMA_ASEG,
                    primatotal = item.IMP_TOTAL
                    
                });
            }
            return coberturas;
        }

        public static Contracts.Cotizacion.Viajero Quote(Contracts.Cotizacion.Viajero quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.Viajero resultInfo = quoteInfo;
            //TODO: Es necesario convertir las validaciones existentes en el JS
            resultInfo.Errors = Validate(quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = ViajeroConvertTo.Tron(quoteInfo, COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName);

                result = Backoffice.Cotizacion.Generico.Calcular(result);

                resultInfo = LookupComplements(ViajeroConvertFrom.Quote(quoteInfo, result), tokenInfo);

                Architect.Utilities.Cache.SetItem(
                    string.Format("viajero.{0}", quoteInfo.presupuesto),
                     Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Seguro de Viaje", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }

            }

            return resultInfo;
        }

        public static Contracts.Cotizacion.Viajero LookupComplements(Contracts.Cotizacion.Viajero quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            //string context = string.Format("cod_ramo={0}:cod_mon={1}:TIP_PLAN={2}:TIP_VIAJE={3}%:COD_MODALIDAD={4}:FEC_VIAJE={5}", 
            //quoteInfo.cod_ramo, quoteInfo.cod_mon, quoteInfo.TIP_PLAN, quoteInfo.TIP_VIAJE, quoteInfo.COD_MODALIDAD, quoteInfo.FEC_VIAJE);
            //quoteInfo.cod_mon_desc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "cod_mon", quoteInfo.cod_mon.ToString(), context);
            //quoteInfo.TIP_PLAN_DESC = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "TIP_PLAN", quoteInfo.TIP_PLAN.ToString(), context);
            //quoteInfo.TIP_VIAJE_DESC = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "TIP_VIAJE", quoteInfo.TIP_VIAJE.ToString(), context);
            //quoteInfo.COD_MODALIDAD_DES = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "COD_MODALIDAD", quoteInfo.COD_MODALIDAD.ToString(), context);

            return quoteInfo;
        }

        /// <summary>
        /// Valida la información de una póliza para permitir o no su emisión.
        /// </summary>
        /// <param name="source">Datos de la póliza</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns></returns>
        private static List<Core.Contracts.General.Error> Validate(Contracts.Cotizacion.Viajero source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "Viajero";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Coberturas:
            if (!Rule_AtLeastOneCoverageSelected(source))
            {
                result.Add(new Core.Contracts.General.Error() { Group = "Table", Key = "coberturasTbl", Message = "Debe seleccionar al menos una cobertura" });
            }

            return result;
        }

               private static bool Rule_AtLeastOneCoverageSelected(Contracts.Cotizacion.Viajero source)
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
