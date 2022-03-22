using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Cotizacion
{
    /// <summary>
    /// Cotización de póliza de MapfreMas en tron.
    /// </summary>
    public static class MapfreMas
    {

        const int COD_RAMO = 302;

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Mapfre Más.
        /// </summary>
        public static Contracts.Cotizacion.MapfreMas Setup(Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMas result = new Contracts.Cotizacion.MapfreMas()
            {
                cod_ramo = COD_RAMO,
                cod_mon = 1,
                cod_fracc_pago = 1,
                fec_efec_poliza = DateTime.Today,
                fec_vcto_poliza = DateTime.Today.AddYears(1),
                edad = 18,
                mca_sexo = 1,
                tipo_prod = "basico",
                COD_PLAN_AUTO = 31,
                cod_zona_circul = 1,
                cod_marca = 255,
                cod_modelo = 1,
                ANIO_SUB_MODELO = DateTime.Today.Year,
                cod_tip_vehi = 3,
                cod_uso_vehi = 1,
                MCA_CERO_KM = 2,
                MCA_AUTO_GPS = 2,
                MCA_MONITOREO_GPS = 2,
                MCA_AUTO_GPS_CMS = 2,
                MCA_PRA = 2,
                MCA_VR = 1,
                MCA_DESC_CLIENTE_NUEVO = 1,
                IMP_AUTO_RC = 50000000,
                DED_AUTO_RC = 1,
                IMP_AUTO_CRI = 750000,
                Agente = tokenInfo.UserName
            };
            result.coberturas = CoverageByDefault(result.cod_mon, result.cod_marca, result.cod_modelo, result.ANIO_SUB_MODELO, result.cod_tip_vehi, result.cod_uso_vehi, result.mca_sexo, result.cod_zona_circul, result.edad, result.COD_PLAN_AUTO, 0, 0, string.Empty, tokenInfo);

            return result;
        }

        /// <summary>
        /// Recupera lista de valores para sumas aseguradas de coberturas o valores deducibles según el rol del usuario
        /// </summary>
        public static Contracts.Cotizacion.MapfreMasSettings Settings(int cod_ramo, int cod_mon, int edad, string tipo_prod, int cod_marca, int num_contrato, int num_subcontrato, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMasSettings result = new Contracts.Cotizacion.MapfreMasSettings();
            Contracts.Cotizacion.MapfreMas data = new Contracts.Cotizacion.MapfreMas()
            {
                cod_mon = cod_mon,
                cod_marca = cod_marca,
                tipo_prod = tipo_prod,
                edad = edad,
                contrato = num_contrato,
                subcontrato = num_subcontrato
            };

            List<string> keys = new List<string> {
                "MM_ClaseVehiculos", "MM_Plan",
                "MM_CAPITAL_RC", "MM_CAPITAL_GM", "MM_CAPITAL_AC", "MM_CAPITAL_GN", "MM_CAPITAL_AM", "MM_CAPITAL_ROTCRI",
                "MM_DEDU_RC", "MM_DEDU_CV", "MM_DEDU_RA", "MM_DEDU_ROBO", "MM_DEDU_EE", "MM_DEDU_ROTCRI" };
            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                keys.AddRange(new List<string> {
                    "MM_CAPITAL_RC_G", "MM_CAPITAL_GM_G", "MM_CAPITAL_AC_G", "MM_CAPITAL_ROTCRI_G",
                    "MM_DEDU_RC_G", "MM_DEDU_CV_G", "MM_DEDU_ROTCRI_G", "MM_DEDU_EE_G", "MM_DEDU_RA_G", "MM_DEDU_ROBO_G", "MM_POLIZA_GRUPO"});
            }

            string url = $"cod_ramo={cod_ramo}:cod_mon={cod_mon}:edad={edad}:plan={tipo_prod}:cod_marca={cod_marca}:num_contrato={num_contrato}:num_subcontrato={num_subcontrato}";
            List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps(string.Join(",", keys), url, tokenInfo);

            result.fec_vcto_poliza = DateTime.Today.AddYears(1);
            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                LookUpsForPolizaGrupo(result, values);

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
                            result.fec_vcto_poliza_grupo = result.fec_vcto_poliza;
                        }
                    }
                }

            }

            LookUps(result, values, data, tokenInfo);

            return result;
        }

        /// <summary>
        /// Recupera la configuración de coberturas por defecto.
        /// </summary>
        public static List<Contracts.Comun.Cobertura> CoverageByDefault(int cod_mon, int cod_marca, int cod_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo, Core.Contracts.Security.Token tokenInfo)
        {
            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            string cod_cobExcludeFilter = string.Empty;
            string cod_cobIncludeFilter = string.Empty;
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);
            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            int tip_valoracion = 1;
            DateTime fec_validez = DateTime.Today;

            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                if (num_contrato > 0)
                {
                    List<Contracts.Ramo.G2990026> coberturaGrupo = DataAccess.PorRamo.Coberturas_por_contrato2(COD_RAMO, num_contrato);
                    cod_cobIncludeFilter = Util.Convert_CoverageListToString(coberturaGrupo);
                    
                    if (cod_cobIncludeFilter.IsNotEmpty())
                    {
                        switch (cod_tip_vehi)
                        {
                            case 5:
                                cod_cobIncludeFilter = cod_cobIncludeFilter.Replace(",3009", string.Empty);
                                cod_cobIncludeFilter = cod_cobIncludeFilter.Replace(",3017", string.Empty);
                                break;
                            case 17:
                            case 18:
                                cod_cobIncludeFilter = cod_cobIncludeFilter.Replace(",3017", string.Empty);
                                break;
                        }


                        foreach (Contracts.Tables.a1002150 item in DataAccess.PorRamo.Coberturas(cod_cia, COD_RAMO, cod_modalidad, fec_validez, cod_cobExcludeFilter, cod_cobIncludeFilter))
                        {
                            coberturas.Add(new Contracts.Comun.Cobertura()
                            {
                                seleccionado = string.Format(",{0},", cod_cobIncludeFilter).IndexOf(string.Format(",{0},", item.COD_COB)) > -1,
                                requerida = coberturaGrupo.Any(r => r.COD_COB == item.COD_COB && r.MCA_OBLIGATORIO == "S"),
                                codigo = item.COD_COB,
                                nombre = item.NOM_COB,
                                capital = item.SUMA_ASEG,
                                primatotal = item.IMP_TOTAL,
                                decucible = item.NOM_FRANQUICIA
                            });
                        }
                    }

                }
            }

            if (cod_cobIncludeFilter.IsEmpty())
            {
                cod_cobExcludeFilter = Reglas.research.Apply_Coberturas("MapfreMas",
                    new Contracts.Cotizacion.MapfreMas()
                    {
                        cod_mon = cod_mon,
                        cod_marca = cod_marca,
                        cod_modelo = cod_modelo,
                        ANIO_SUB_MODELO = anio_sub_modelo,
                        cod_tip_vehi = cod_tip_vehi,
                        cod_uso_vehi = cod_uso_vehi,
                        mca_sexo = mca_sexo,
                        cod_zona_circul = cod_zona_circul,
                        edad = edad,
                        COD_PLAN_AUTO = cod_plan_auto,
                        contrato = num_contrato,
                        subcontrato = num_subcontrato,
                        polizagrupo = num_poliza_grupo
                    }, tokenInfo);

                if (cod_cobExcludeFilter.IsNotEmpty()) { 
                    Architect.Utilities.Log.TraceLog("Coverage", $"Excluir '{cod_cobExcludeFilter}' las coberturas", "Decision");
                }

                List<Contracts.Tables.ta301003> coverageSelection = DataAccess.PorRamo.AutomobileCoverageSelection(cod_cia, num_poliza_grupo, num_contrato, num_subcontrato, COD_RAMO, cod_mon, cod_marca, cod_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, tip_valoracion);
                bool required;
                foreach (Contracts.Tables.a1002150 item in DataAccess.PorRamo.Coberturas(cod_cia, COD_RAMO, cod_modalidad, fec_validez, cod_cobExcludeFilter, cod_cobIncludeFilter))
                {
                    required = coverageSelection.Any(r => r.cod_cob == item.COD_COB && r.mca_obligatoria == "S");
                    coberturas.Add(new Contracts.Comun.Cobertura()
                    {
                        seleccionado = required,
                        requerida = required,
                        codigo = item.COD_COB,
                        nombre = item.NOM_COB,
                        capital = item.SUMA_ASEG,
                        primatotal = item.IMP_TOTAL,
                        decucible = item.NOM_FRANQUICIA
                    });
                }
            }

            return coberturas;
        }

        /// <summary>
        /// Realiza la validación de datos y cálculo necesarios para obtener una cotización o presupuesto de un producto de tipo Mapfre Más
        /// </summary>
        public static Contracts.Cotizacion.MapfreMas Quote(Contracts.Cotizacion.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMas resultInfo = quoteInfo;

            //Valida la información de una póliza para permitir o no su emisión.
            resultInfo.Errors = Reglas.research.Apply_Reglas("MapfreMas", quoteInfo, tokenInfo);
            //TODO: Es necesario convertir las validaciones existentes en el JS

            if (resultInfo.Errors.Count == 0)
            {
                quoteInfo.presupuesto = string.Empty;
                quoteInfo.resumen = null;
                Contracts.Batch.CotizadorMapfreMasClass quoteTron = MapfreMasConvertTo.Tron(quoteInfo, COD_RAMO, tokenInfo.AgentCode, tokenInfo.UserName, tokenInfo.IdentificationType, tokenInfo.Identification);
                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.CotizadorMapfreMasClass>(result, @"C:\temp\mapfremas.in.xml");

                Contracts.Presupuesto.DatoFijo resultTron = Backoffice.Cotizacion.MapfreMas.Calcular(quoteTron);
                resultInfo = MapfreMasConvertFrom.Quote(quoteInfo, resultTron);

                //Utilities.SerializeHandler<Contracts.Presupuesto.DatoFijo>.SerializeToFile(resultTron, @"C:\temp\resultTron.xml");
                //Utilities.SerializeHandler<Contracts.Cotizacion.MapfreMas>.SerializeToFile(resultInfo, @"C:\temp\resultInfo.xml");

                //Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, resultTron.Coberturas.First().num_poliza, 0, 0, 0, null, true);
                //Contracts.Cotizacion.MapfreMas resultInfo2 = MapfreMasConvertFrom.Quote(MapfreMasConvertFrom.Quote(P30Instance), P30Instance);
                //Utilities.SerializeHandler<Contracts.Presupuesto.DatoFijo>.SerializeToFile(P30Instance, @"C:\temp\lecturacompleta.xml");
                //Utilities.SerializeHandler<Contracts.Cotizacion.MapfreMas>.SerializeToFile(resultInfo2, @"C:\temp\resultcompleta.xml");
                //resultInfo = resultInfo2;

                Architect.Utilities.Cache.SetItem(
                    string.Format("mapfremas.{0}", resultInfo.presupuesto),
                        Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                if (resultInfo.presupuesto.IsNotEmpty())
                {
                    Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización MapfreMas", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);
                }
            }
            return resultInfo;
        }

        /// <summary>
        /// Prepara las lista de valores por póliza de grupo necesarias para la cotización.
        /// </summary>
        private static void LookUpsForPolizaGrupo(Contracts.Cotizacion.MapfreMasSettings result, List<Core.Contracts.General.LookupValues> values)
        {
            foreach (Core.Contracts.General.LookupValues itemValues in values)
            {
                switch (itemValues.Key)
                {
                    case "MM_CAPITAL_RC_G":
                        result.IMP_AUTO_RC = itemValues.Lkp;
                        break;
                    case "MM_CAPITAL_GM_G":
                        result.IMP_AUTO_GMO = itemValues.Lkp;
                        break;
                    case "MM_CAPITAL_AC_G":
                        result.IMP_AUTO_ACO = itemValues.Lkp;
                        break;
                    case "MM_CAPITAL_ROTCRI_G":
                        result.IMP_AUTO_CRI = itemValues.Lkp;
                        break;
                    case "MM_DEDU_RC_G":
                        result.DED_AUTO_RC = itemValues.Lkp;
                        break;
                    case "MM_DEDU_CV_G":
                        result.DED_AUTO_CYV = itemValues.Lkp;
                        break;
                    case "MM_DEDU_ROTCRI_G":
                        result.DED_AUTO_CRI = itemValues.Lkp;
                        break;
                    case "MM_DEDU_EE_G":
                        result.DED_AUTO_EQESP = itemValues.Lkp;
                        break;
                    case "MM_DEDU_RA_G":
                        result.DED_AUTO_RAD = itemValues.Lkp;
                        break;
                    case "MM_DEDU_ROBO_G":
                        result.DED_AUTO_ROB = itemValues.Lkp;
                        break;
                }
            }
        }

        /// <summary>
        /// Prepara las lista de valores necesarias para la cotización.
        /// </summary>
        private static void LookUps(Contracts.Cotizacion.MapfreMasSettings result, List<Core.Contracts.General.LookupValues> values, Contracts.Cotizacion.MapfreMas data, Core.Contracts.Security.Token tokenInfo)
        {
            string exclude = string.Empty;
            foreach (Core.Contracts.General.LookupValues itemValues in values)
            {
                exclude = string.Empty;
                exclude = Reglas.research.Apply_Listas("MapfreMas", data, itemValues.Key, tokenInfo);

                if (exclude.IsNotEmpty())
                {
                    Architect.Utilities.Log.TraceLog("Lookups", $"Excluir '{exclude}' de la lista '{itemValues.Key}'", "Decision");

                    foreach (string item in exclude.Split(','))
                    {
                        itemValues.Lkp.Remove(itemValues.Lkp.Find(r => r.Code == item));
                    }
                }

                switch (itemValues.Key)
                {
                    case "MM_ClaseVehiculos":
                        result.cod_tip_vehi = itemValues.Lkp;
                        break;
                    case "MM_Plan":
                        result.PLAN_AUTO = itemValues.Lkp;
                        break;
                    case "MM_CAPITAL_RC":
                        if (result.IMP_AUTO_RC.IsEmpty() || result.IMP_AUTO_RC.Count == 0)
                        {
                            result.IMP_AUTO_RC = itemValues.Lkp;
                        }
                        break;
                    case "MM_CAPITAL_GM":
                        if (result.IMP_AUTO_GMO.IsEmpty() || result.IMP_AUTO_GMO.Count == 0)
                        {
                            result.IMP_AUTO_GMO = itemValues.Lkp;
                        }
                        break;
                    case "MM_CAPITAL_AC":
                        if (result.IMP_AUTO_ACO.IsEmpty() || result.IMP_AUTO_ACO.Count == 0)
                        {
                            result.IMP_AUTO_ACO = itemValues.Lkp;
                        }
                        break;
                    case "MM_CAPITAL_GN":
                        result.IMP_AUTO_NEUM = itemValues.Lkp;
                        break;
                    case "MM_CAPITAL_AM":
                        result.IMP_AUTO_MECA = itemValues.Lkp;
                        break;
                    case "MM_CAPITAL_ROTCRI":
                        if (result.IMP_AUTO_CRI.IsEmpty() || result.IMP_AUTO_CRI.Count == 0)
                        {
                            result.IMP_AUTO_CRI = itemValues.Lkp;
                        }
                        break;
                    case "MM_DEDU_RC":
                        if (result.DED_AUTO_RC.IsEmpty() || result.DED_AUTO_RC.Count == 0)
                        {
                            result.DED_AUTO_RC = itemValues.Lkp;
                        }
                        break;
                    case "MM_DEDU_CV":
                        if (result.DED_AUTO_CYV.IsEmpty() || result.DED_AUTO_CYV.Count == 0)
                        {
                            result.DED_AUTO_CYV = itemValues.Lkp;
                        }
                        break;
                    case "MM_DEDU_RA":
                        if (result.DED_AUTO_RAD.IsEmpty() || result.DED_AUTO_RAD.Count == 0)
                        {
                            result.DED_AUTO_RAD = itemValues.Lkp;
                        }
                        break;
                    case "MM_DEDU_ROBO":
                        if (result.DED_AUTO_ROB.IsEmpty() || result.DED_AUTO_ROB.Count == 0)
                        {
                            result.DED_AUTO_ROB = itemValues.Lkp;
                        }
                        break;
                    case "MM_DEDU_EE":
                        if (result.DED_AUTO_EQESP.IsEmpty() || result.DED_AUTO_EQESP.Count == 0)
                        {
                            result.DED_AUTO_EQESP = itemValues.Lkp;
                        }
                        break;
                    case "MM_DEDU_ROTCRI":
                        if (result.DED_AUTO_CRI.IsEmpty() || result.DED_AUTO_CRI.Count == 0)
                        {
                            result.DED_AUTO_CRI = itemValues.Lkp;
                        }
                        break;
                }
            }
        }

    }
}
