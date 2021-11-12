using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace Architect.API.Tron.Business.Cotizacion
{
    /// <summary>
    /// Cotización de póliza de hogar total en tron.
    /// </summary>
    public static class HogarTotal
    {

        const int COD_RAMO = 201;

        public static Contracts.Cotizacion.HogarTotal Setup(Core.Contracts.Security.Token tokenInfo)
        {

            Contracts.Cotizacion.HogarTotal result = new Contracts.Cotizacion.HogarTotal()
            {
                cod_ramo = COD_RAMO,
                moneda = 1,
                fraccionamientodepago = 1,
                iniciodevigencia = DateTime.Today,
                findevigencia = DateTime.Today.AddYears(1),
                pais = "CRI",
                provincia = 2,
                canton = 201,
                distrito = 20101,
                ocupaciondelriesgo = 20110211,
                tipodesuscripcion = 1,
                numerodepisosedificacion = 1,
                tipodeestrucdelaedificacion = 1,
                Agente = tokenInfo.UserName,
                CERCA_RI_MAR_LAG_TA_CI = 2,
                DISTANCIA_MTS = 0,
                INS_ELECT_ENTUB = 2
            };

            bool IsCoope = false;
            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            int cod_ramo = COD_RAMO;
            DateTime fec_validez = DateTime.Today;


            result.coberturas = CoverageByDefault(IsCoope, cod_cia, cod_ramo, fec_validez, string.Empty);

            return result;
        }

        public static Tron.Contracts.Cotizacion.HogarTotalSettings Settings(int cod_ramo, int num_contrato, int num_subcontrato, string num_poliza_grupo, int cod_mon, Core.Contracts.Security.Token tokenInfo)
        {
            Tron.Contracts.Cotizacion.HogarTotalSettings result = new Contracts.Cotizacion.HogarTotalSettings();
            List<string> keys = new List<string> { };
            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                keys.AddRange(new List<string> { "MM_POLIZA_GRUPO", "HT_CAPITAL_RC" });
            }

            string url = $"cod_ramo={cod_ramo}:num_contrato={num_contrato}:num_subcontrato={num_subcontrato}:num_poliza_grupo={num_poliza_grupo}:cod_mon={cod_mon}";
            List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps(string.Join(",", keys), url, tokenInfo);

            result.fec_vcto_poliza = DateTime.Today.AddYears(1);
            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                result.SumasAseguradasRC = values.Find(x => x.Key == "HT_CAPITAL_RC").Lkp;

                Core.Contracts.General.LookupValues contratosMaster = values.Find(x => x.Key == "MM_POLIZA_GRUPO");
                if (contratosMaster != null)
                {
                    Core.Contracts.General.LookupValue contrato = contratosMaster.Lkp.Find(y => y.Code == num_contrato.ToString());
                    if (contrato != null)
                    {
                        string vcto_poliza = (string)contrato["FEC_VCTO_POLIZA"];
                        if (vcto_poliza.IsNotEmpty())
                        {
                            result.fec_vcto_poliza = DateTime.Parse(vcto_poliza, CultureInfo.CreateSpecificCulture("es-CR"));
                        }
                    }
                }

                if (num_contrato > 0)
                {
                    bool IsCoope = false;
                    int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
                    DateTime fec_validez = DateTime.Today;

                    string cod_cobIncludeFilter = Architect.API.Tron.DataAccess.PorRamo.Coberturas_por_contrato(COD_RAMO, num_contrato);
                    result.coberturas = CoverageByDefault(IsCoope, cod_cia, COD_RAMO, fec_validez, cod_cobIncludeFilter);
                }
            }

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
            foreach (Architect.API.Tron.Contracts.Tables.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, cobIncludeFilter))
            {
                coberturas.Add(new Contracts.Comun.Cobertura()
                {
                    seleccionado = selected.Contains(item.COD_COB.ToString()),
                    requerida = item.MCA_OBLIGATORIO == "S",
                    codigo = item.COD_COB,
                    nombre = item.NOM_COB,
                    capital = item.SUMA_ASEG,
                    primatotal = item.IMP_TOTAL,
                    decucible = item.NOM_FRANQUICIA,
                    error = item.TXT_ERROR
                });
            }
            return coberturas;
        }

        public static Contracts.Cotizacion.HogarTotal Quote(Contracts.Cotizacion.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.HogarTotal resultInfo = quoteInfo;
            //TODO: Es necesario convertir las validaciones existentes en el JS
            resultInfo.Errors = Reglas.research.Apply_Reglas("HogarTotal", quoteInfo, tokenInfo);
            if (resultInfo.Errors.Count == 0)
            {
                bool IsCoope = false;
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;

                //Architect.Common.Helpers.Serialize.SerializeToFile<Contracts.Cotizacion.HogarTotal>(quoteInfo,
                //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.in.xml", true);

                Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = HogarTotalConvertTo.Tron(quoteInfo, IsCoope, COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName);

                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result,
                //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.in.raw.xml", true);

                result = Backoffice.Cotizacion.Generico.Calcular(result);

                //int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
                //int cod_ramo = COD_RAMO;
                //DateTime fec_validez = DateTime.Today;

                resultInfo = LookupComplements(HogarTotalConvertFrom.Quote(quoteInfo, result), tokenInfo);

                Architect.Utilities.Cache.SetItem(
                    string.Format("hogartotal.{0}", quoteInfo.presupuesto),
                     Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización Hogar Total", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }

                //Architect.Common.Helpers.Serialize.SerializeToFile<Contracts.Cotizacion.HogarTotal>(resultQuoteInfo,
                //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.out.xml", true);
                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.p2000030>(result,
                //    ConfigurationManager.AppSettings["Path.Logs"] + @"\hogartotal.out.raw.xml", true);

                //Emision.HogarTotal.Issue(resultQuoteInfo, COD_RAMO, tokenInfo);
            }

            return resultInfo;
        }

        public static Contracts.Cotizacion.HogarTotal LookupComplements(Contracts.Cotizacion.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            string context = string.Format("cod_ramo={0}:cod_mon={1}:cod_pais={2}:cod_tip_ocup={3}%:cod_estado={4}:cod_prov={5}",
                quoteInfo.cod_ramo, quoteInfo.moneda, quoteInfo.pais, quoteInfo.ocupaciondelriesgo, quoteInfo.provincia, quoteInfo.canton);

            quoteInfo.monedaDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "MonedasPorRamo", quoteInfo.moneda.ToString(), context);
            quoteInfo.paisDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Paises", quoteInfo.pais.ToString(), context);
            quoteInfo.provinciaDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Provincias", quoteInfo.provincia.ToString(), context);
            quoteInfo.cantonDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Cantones", quoteInfo.canton.ToString(), context);
            quoteInfo.distritoDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Distritos", quoteInfo.distrito.ToString(), context);
            quoteInfo.ocupaciondelriesgoDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "TiposOcupacion", quoteInfo.ocupaciondelriesgo.ToString(), context);
            quoteInfo.tipodesuscripcionDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "TiposSuscripcion", quoteInfo.tipodesuscripcion.ToString(), context);
            quoteInfo.numerodepisosedificacionDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "NumeroPisos", quoteInfo.numerodepisosedificacion.ToString(), context);
            quoteInfo.tipodeestrucdelaedificacionDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "TipoEstructura", quoteInfo.tipodeestrucdelaedificacion.ToString(), context);
            if (quoteInfo.medidasdeseguridad != "")
            {
                string medidasdeseguridadDesc = "";
                quoteInfo.medidasdeseguridadDesc = "";
                foreach (string item in quoteInfo.medidasdeseguridad.Split(','))
                {
                    medidasdeseguridadDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "MedidasSeguridad", quoteInfo.medidasdeseguridad, context);
                    if (medidasdeseguridadDesc.Length > 0)
                    {
                        quoteInfo.medidasdeseguridadDesc += ", ";
                    }
                    quoteInfo.medidasdeseguridadDesc += medidasdeseguridadDesc;
                }
            }

            quoteInfo.descuentoDesc = Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "DescuentoHogarTotal", quoteInfo.descuento.ToString());

            return quoteInfo;
        }

        private static bool Rule_AtLeastOneCoverageSelected(Contracts.Cotizacion.HogarTotal source)
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
