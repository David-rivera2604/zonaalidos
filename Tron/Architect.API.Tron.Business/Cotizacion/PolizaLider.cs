using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class PolizaLider
    {

        const int COD_RAMO = 300;

        public static Architect.API.Tron.Contracts.Cotizacion.PolizaLider Setup(Core.Contracts.Security.Token tokenInfo)
        {
            bool IsCoope = false;
            Architect.API.Tron.Contracts.Cotizacion.PolizaLider result = new Architect.API.Tron.Contracts.Cotizacion.PolizaLider()
            {
                cod_ramo = COD_RAMO,
                cod_mon = 1,
                cod_fracc_pago = 1,
                fec_efec_poliza = DateTime.Today,
                fec_vcto_poliza = DateTime.Today.AddYears(1),
                COD_PLAN_AUTO = 3,
                COD_MARCA = 255,
                COD_MODELO = 1, //3-start
                PCT_DCTO_AUTO_PAR = 0,
                COD_TIP_VEHI = 1, //9
                COD_USO_VEHI = 1,
                ANIO_SUB_MODELO = DateTime.Today.Year,
                MCA_VR = "1",
                MCA_DESC_CLIENTE_NUEVO = 1,
                MCA_CERO_KM = 2,
                MCA_AUTO_GPS = 2,
                mca_HogarTotal = 2,
                MCA_AUTO_GPS_CMS = 2,
                Agente = tokenInfo.UserName,
                cod_agt = tokenInfo.AgentCode
            };

            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            int cod_ramo = COD_RAMO;
            DateTime fec_validez = DateTime.Today;
            result.coberturas = CoverageByDefault(IsCoope, cod_cia, cod_ramo, fec_validez);

            return result;
        }

        internal static List<Contracts.Comun.Cobertura> CoverageByDefault(bool isCoope, int cod_cia, int cod_ramo, DateTime fec_validez)
        {
            string cod_cobExcludeFilter = "3016,3017";
            string selected = "";
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);

            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            foreach (Architect.API.Tron.Contracts.Ramo.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, string.Empty))
            {
                coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = selected.Contains(item.COD_COB.ToString()) || item.MCA_OBLIGATORIO == "S",
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

        public static Contracts.Cotizacion.PolizaLider Quote(Contracts.Cotizacion.PolizaLider quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.PolizaLider resultInfo = quoteInfo;
            //TODO: Es necesario convertir las validaciones existentes en el JS
            resultInfo.Errors = Validate(quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {

                bool IsCoope = false;
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;
                Architect.API.Tron.Contracts.Batch.CotizadorPolizaLiderClass result = PolizaLiderConvertTo.Tron(quoteInfo, IsCoope, COD_RAMO, quoteInfo.cod_agt, tokenInfo.UserName, tokenInfo.IdentificationType, tokenInfo.Identification);
                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.CotizadorPolizaLiderClass>(result, @"C:\temp\poliza.lider.in.xml");

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo resultInt = Backoffice.Cotizacion.PolizaLider.Calcular(result);

                resultInfo = PolizaLiderConvertFrom.Quote(quoteInfo, resultInt);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Póliza Lider", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }

                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result, @"C:\temp\poliza.lider.out.xml");
            }
            return resultInfo;
        }

        /// <summary>
        /// Valida la informacion de una póliza para permitir o no su emisión.
        /// </summary>
        /// <param name="source">Datos de la póliza</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <returns></returns>
        private static List<Core.Contracts.General.Error> Validate(Contracts.Cotizacion.PolizaLider source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "PolizaLider";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Coberturas:
            if (!Rule_AtLeastOneCoverageSelected(source))
            {
                result.Add(new Core.Contracts.General.Error() { Group = "Table", Key = "coberturasTbl", Message = "Debe seleccionar al menos una cobertura" });
            }

            return result;
        }

        private static bool Rule_AtLeastOneCoverageSelected(Contracts.Cotizacion.PolizaLider source)
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
