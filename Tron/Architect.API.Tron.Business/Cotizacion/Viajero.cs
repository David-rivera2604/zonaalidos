using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
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
            Contracts.Cotizacion.Viajero result = null;
            Contracts.Traza.TrackSession session = Traza.TrackRequest.NewSession(tokenInfo, "Viajero/Quote/Setup", result);

            try
            {
                result = new Contracts.Cotizacion.Viajero()
                {
                    cod_mon = COD_MON,
                    cod_ramo = COD_RAMO,
                    cod_fracc_pago = 101,
                    fec_efec_poliza = DateTime.Today,
                    fec_vcto_poliza = DateTime.Today,
                    TIP_PLAN = "I",
                    TIP_VIAJE = "NA",
                    FEC_VIAJE = DateTime.Today,
                    DES_DESTINO = "",
                    COD_PAIS_ORIGEN = "CRI",
                    cantidad_riesgos = 1,
                    Agente = tokenInfo.UserName,
                    cod_agt = tokenInfo.AgentCode
                };

                bool IsCoope = false;
                int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
                int cod_ramo = COD_RAMO;
                DateTime fec_validez = DateTime.Today;

                result.coberturas = CoverageByDefault(IsCoope, cod_cia, cod_ramo, fec_validez, string.Empty);
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 400;
                session.ResponseText = ex.Message;
            }

            Traza.TrackRequest.CloseSession(session, result);
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

            Contracts.Traza.TrackSession session = Traza.TrackRequest.NewSession(tokenInfo, "Viajero/Quote/Quote", quoteInfo);
            try
            {
                //TODO: Es necesario convertir las validaciones existentes en el JS
                resultInfo.Errors = Validate(quoteInfo, tokenInfo);
                if (resultInfo.Errors.Count == 0)
                {
                    quoteInfo.presupuesto = string.Empty;
                    quoteInfo.resumen = null;

                    Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = ViajeroConvert.ToTron(quoteInfo, COD_RAMO, quoteInfo.cod_agt, tokenInfo.UserName, tokenInfo.CompanyId);

                    result = Backoffice.Cotizacion.Generico.Calcular(result);

                    resultInfo = LookupComplements((Contracts.Cotizacion.Viajero)Util.FromTron_CoberturasResult(quoteInfo, result, 1, true), tokenInfo);

                    resultInfo.coberturas.Remove(resultInfo.coberturas.Find(r => r.codigo == 9998));

                    Utilities.Cache.SetItem(
                        string.Format("viajero.{0}", quoteInfo.presupuesto),
                         Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                    if (resultInfo.presupuesto.IsNotEmpty())
                    {
                        Core.Business.General.ChangeSet.Create(3000, Convert.ToInt64(resultInfo.presupuesto), tokenInfo.CompanyId, "Cotización Seguro de Viaje", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                    }

                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 400;
                session.ResponseText = ex.Message;
            }

            Traza.TrackRequest.CloseSession(session, resultInfo);

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
        public static List<Core.Contracts.General.Error> Validate(Contracts.Cotizacion.Viajero source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "Viajero";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            if (source.cod_mon.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "cod_mon", Message = "Debe indicar la moneda" });
            }
            if (source.cod_fracc_pago.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "cod_fracc_pago", Message = "Debe indicar el fraccionamiento de pago" });
            }
            if (source.fec_efec_poliza.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "fec_efec_poliza", Message = "Debe indicar el inicio de vigencia" });
            }
            if (source.fec_vcto_poliza.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "fec_vcto_poliza", Message = "Debe indicar el fin de vigencia" });
            }
            if (source.TIP_PLAN.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "TIP_PLAN", Message = "Debe indicar el plan" });
            }
            if (source.TIP_VIAJE.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "TIP_VIAJE", Message = "Debe indicar el tipo de viaje" });
            }
            if (source.FEC_VIAJE.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_VIAJE", Message = "Debe indicar la fecha de inicio del viaje" });
            }

            if (source.COD_PAIS_ORIGEN.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "COD_PAIS_ORIGEN", Message = "Debe indicar el país de origen" });
            }
            if (source.DES_DESTINO.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "DES_DESTINO", Message = "Debe indicar el lugar de destino" });
            }
            if (source.COD_MODALIDAD.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "COD_MODALIDAD", Message = "Debe indicar la modalidad" });
            }
            if (source.cantidad_riesgos.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "cantidad_riesgos", Message = "Debe indicar la cantidad de riesgos" });
            }
            if (source.cantidad_riesgos >= 1 && source.FEC_NACIMIENTO.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO", Message = "Debe indicar la fecha de nacimiento - Riesgo 1" });
            }
            if (source.cantidad_riesgos >= 2 && source.FEC_NACIMIENTO2.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO2", Message = "Debe indicar la fecha de nacimiento - Riesgo 2" });
            }
            if (source.cantidad_riesgos >= 3 && source.FEC_NACIMIENTO3.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO3", Message = "Debe indicar la fecha de nacimiento - Riesgo 3" });
            }
            if (source.cantidad_riesgos >= 4 && source.FEC_NACIMIENTO4.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO4", Message = "Debe indicar la fecha de nacimiento - Riesgo 4" });
            }
            if (source.cantidad_riesgos >= 5 && source.FEC_NACIMIENTO5.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO5", Message = "Debe indicar la fecha de nacimiento - Riesgo 5" });
            }
            if (source.cantidad_riesgos >= 6 && source.FEC_NACIMIENTO6.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO6", Message = "Debe indicar la fecha de nacimiento - Riesgo 6" });
            }
            if (source.cantidad_riesgos >= 7 && source.FEC_NACIMIENTO7.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO7", Message = "Debe indicar la fecha de nacimiento - Riesgo 7" });
            }
            if (source.cantidad_riesgos >= 8 && source.FEC_NACIMIENTO8.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO8", Message = "Debe indicar la fecha de nacimiento - Riesgo 8" });
            }
            if (source.cantidad_riesgos >= 9 && source.FEC_NACIMIENTO9.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO9", Message = "Debe indicar la fecha de nacimiento - Riesgo 9" });
            }
            if (source.cantidad_riesgos >= 10 && source.FEC_NACIMIENTO10.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FEC_NACIMIENTO10", Message = "Debe indicar la fecha de nacimiento - Riesgo 10" });
            }

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
