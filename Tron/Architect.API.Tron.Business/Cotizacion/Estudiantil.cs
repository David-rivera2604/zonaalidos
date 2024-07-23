using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class Estudiantil
    {
        const int COD_RAMO = 194;

        public static Contracts.Cotizacion.Estudiantil Setup(Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Cotizacion.Estudiantil result = new Contracts.Cotizacion.Estudiantil()
            {
                cod_mon = 1,
                cod_fracc_pago = 1,
                fec_efec_poliza = DateTime.Today,
                fec_vcto_poliza = DateTime.Today.AddYears(1),
                TXT_CRED_ESTUD = "",
                COD_PLAN_AP = 1001,
                cod_agt = tokenInfo.AgentCode
            };

            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            int cod_ramo = COD_RAMO;
            DateTime fec_validez = DateTime.Today;
            result.coberturas = CoverageByDefault(cod_cia, cod_ramo, fec_validez);
            result.cod_ramo = cod_ramo;

            return result;
        }

        internal static List<Contracts.Comun.Cobertura> CoverageByDefault( int cod_cia, int cod_ramo, DateTime fec_validez)
        {
            string cod_cobExcludeFilter = string.Empty;
            string selected = string.Empty;
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);

            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            cod_modalidad = 19401;
            cod_cobExcludeFilter = "";
            selected = "1001,1012,1080";

            foreach (Architect.API.Tron.Contracts.Ramo.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, selected))
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

        public static Contracts.Cotizacion.Estudiantil Quote(Contracts.Cotizacion.Estudiantil quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.Estudiantil resultInfo = quoteInfo;
            //TODO: Es necesario convertir las validaciones existentes en el JS
            resultInfo.Errors = Validate(quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = EstudiantilConvert.ToTron(quoteInfo, COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName);

                result = Backoffice.Cotizacion.Generico.Calcular(result);

                resultInfo = LookupComplements((Contracts.Cotizacion.Estudiantil)Util.FromTron_CoberturasResult(quoteInfo, result, 1, true), tokenInfo);

                resultInfo.coberturas.Remove(resultInfo.coberturas.Find(r => r.codigo == 9998));

                Utilities.Cache.SetItem(
                    string.Format("viajero.{0}", quoteInfo.presupuesto),
                     Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Seguro de Viaje", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }

            }

            return resultInfo;
        }

        public static Contracts.Cotizacion.Estudiantil LookupComplements(Contracts.Cotizacion.Estudiantil quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
   
            return quoteInfo;
        }

        /// <summary>
        /// Valida la información de una póliza para permitir o no su emisión.
        /// </summary>
        /// <param name="source">Datos de la póliza</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns></returns>
        private static List<Core.Contracts.General.Error> Validate(Contracts.Cotizacion.Estudiantil source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "Estudiantil";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Coberturas:
            if (!Rule_AtLeastOneCoverageSelected(source))
            {
                result.Add(new Core.Contracts.General.Error() { Group = "Table", Key = "coberturasTbl", Message = "Debe seleccionar al menos una cobertura" });
            }

            return result;
        }

        private static bool Rule_AtLeastOneCoverageSelected(Contracts.Cotizacion.Estudiantil source)
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
