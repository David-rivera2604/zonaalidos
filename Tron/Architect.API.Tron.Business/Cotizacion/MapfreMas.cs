using Architect.API.Core.Contracts.Security;
using Architect.Payment.Integrations.Contracts;

using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Architect.API.Tron.Business.Cotizacion
{
    /// <summary>
    /// Cotización de póliza de MapfreMas en tron.
    /// </summary>
    public static class MapfreMas
    {

        /// <summary>
        /// Devuelve la estructura de datos con los valores por defecto para una cotización de tipo Mapfre Más.
        /// </summary>
        public static Contracts.Cotizacion.MapfreMas Setup(string mode, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMas result = new Contracts.Cotizacion.MapfreMas()
            {
                cod_ramo = 302,
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
                ext_garantia = 2,
                MCA_AUTO_GPS_CMS = 2,
                MCA_PRA = 2,
                MCA_VR = 1,
                MCA_DESC_CLIENTE_NUEVO = 1,
                IMP_AUTO_RC = 50000000,
                DED_AUTO_RC = 1,
                IMP_AUTO_CRI = 750000,
                Agente = tokenInfo.UserName,
                cod_agt = tokenInfo.AgentCode
            };
            result.coberturas = CoverageByDefault(result.cod_ramo, result.cod_mon, result.cod_marca, result.cod_modelo, result.cod_sub_modelo, result.ANIO_SUB_MODELO, result.cod_tip_vehi, result.cod_uso_vehi, result.mca_sexo, result.cod_zona_circul, result.edad, result.COD_PLAN_AUTO, 0, 0, string.Empty, tokenInfo);

            return result;
        }

        /// <summary>
        /// Recupera lista de valores para sumas aseguradas de coberturas o valores deducibles según el rol del usuario
        /// </summary>
        public static Contracts.Cotizacion.MapfreMasSettings Settings(int cod_ramo, int cod_mon, int cod_marca, int cod_modelo, int cod_sub_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo, string tipo_prod, int cod_agt, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMasSettings result = new Contracts.Cotizacion.MapfreMasSettings();
            Contracts.Cotizacion.MapfreMas data = new Contracts.Cotizacion.MapfreMas()
            {
                cod_mon = cod_mon,
                cod_marca = cod_marca,
                cod_modelo = cod_modelo,
                cod_sub_modelo = cod_sub_modelo,
                tipo_prod = tipo_prod,
                edad = edad,
                contrato = num_contrato,
                subcontrato = num_subcontrato
            };

            List<string> keys = new List<string> {
                "MM_ClaseVehiculos", "MM_Plan",
                "MM_CAPITAL_RC", "MM_CAPITAL_GM", "MM_CAPITAL_AC", "MM_CAPITAL_GN", "MM_CAPITAL_AM", "MM_CAPITAL_ROTCRI",
                "MM_DEDU_RC", "MM_DEDU_CV", "MM_DEDU_RA", "MM_DEDU_ROBO", "MM_DEDU_EE", "MM_DEDU_ROTCRI", "TRON_G2990006_ByMod:COD_TIP_COM_VEHI" };
            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                keys.AddRange(new List<string> {
                    "TRON_TA301001:3001", "MM_CAPITAL_GM_G", "MM_CAPITAL_AC_G", "MM_CAPITAL_ROTCRI_G",
                    "MM_DEDU_RC_G", "MM_DEDU_CV_G", "MM_DEDU_ROTCRI_G", "MM_DEDU_EE_G", "MM_DEDU_RA_G", "MM_DEDU_ROBO_G", "MM_POLIZA_GRUPO"});
            }

            string url = $"cod_ramo={cod_ramo}:cod_mon={cod_mon}:edad={edad}:plan={tipo_prod}:cod_marca={cod_marca}:num_contrato={num_contrato}:num_subcontrato={num_subcontrato}:num_poliza_grupo={num_poliza_grupo}:cod_modelo={cod_modelo}:anio_sub_modelo={anio_sub_modelo}:cod_tip_vehi={cod_tip_vehi}:cod_uso_vehi={cod_uso_vehi}:mca_sexo={mca_sexo}:cod_zona_circul={cod_zona_circul}:cod_plan_auto={cod_plan_auto}:cod_agt={cod_agt}:cod_modalidad={99999}";
            List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps(string.Join(",", keys), url, tokenInfo);

            // result.fec_vcto_poliza = DateTime.Today.AddYears(1);
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
                result.cod_fracc_pago = Architect.API.Tron.DataAccess.PorRamo.FrecuenciaDePagoPorContrato(1, cod_ramo, num_contrato, cod_agt);
            }

            LookUps(result, values, data, tokenInfo);

            return result;
        }

        /// <summary>
        /// Recupera la configuración de coberturas por defecto.
        /// </summary>
        public static List<Contracts.Comun.Cobertura> CoverageByDefault(int cod_ramo, int cod_mon, int cod_marca, int cod_modelo, int cod_sub_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo, Core.Contracts.Security.Token tokenInfo)
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
                    List<Contracts.Ramo.G2990026> coberturaGrupo = DataAccess.PorRamo.Coberturas_por_contrato2(cod_ramo, num_contrato);
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


                        foreach (Contracts.Ramo.a1002150 item in DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, cod_cobIncludeFilter))
                        {
                            coberturas.Add(new Contracts.Comun.Cobertura()
                            {
                                seleccionado = false,
                                requerida = coberturaGrupo.Any(r => r.COD_COB == item.COD_COB && r.MCA_OBLIGATORIO == "S"),
                                codigo = item.COD_COB,
                                nombre = item.NOM_COB,
                                capital = item.SUMA_ASEG,
                                primatotal = item.IMP_TOTAL,
                                deducible = item.NOM_FRANQUICIA
                            });
                            if (coberturas.Last().requerida)
                            {
                                coberturas.Last().seleccionado = true;
                            }
                        }
                    }

                }
            }

            if (cod_cobIncludeFilter.IsEmpty())
            {
                cod_cobExcludeFilter = Reglas.research.Apply_Coberturas("MapfreMas",
                    new Contracts.Cotizacion.MapfreMas()
                    {
                        cod_ramo = cod_ramo,
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

                if (cod_cobExcludeFilter.IsNotEmpty())
                {
                    Architect.Utilities.Log.TraceLog("Coverage", $"Excluir '{cod_cobExcludeFilter}' las coberturas", "Decision");
                }

                List<Contracts.Ramo.ta301003> coverageSelection = DataAccess.PorRamo.AutomobileCoverageSelection(cod_cia, num_poliza_grupo, num_contrato, num_subcontrato, cod_ramo, cod_mon, cod_marca, cod_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, tip_valoracion);
                bool required;
                cod_cobIncludeFilter = "3001,3002,3003,3004,3005,3006,3007,3008,3009,3010,3011,3012,1060";

                if (IsPlan(cod_plan_auto, new int[] { 34, 35, 36 }))
                {
                    if (IsFromFeb2026(fec_validez) && !tokenInfo.Roles.Contain("PolizaGrupo"))
                    {
                        cod_cobIncludeFilter += ",1063";
                        cod_cobExcludeFilter = cod_cobExcludeFilter.Replace(",1063", string.Empty);
                    }
                    else if (IsPlan(cod_plan_auto, new int[] { 34, 35 }))
                    {
                        cod_cobIncludeFilter += ",3016";
                    }
                }

                foreach (Contracts.Ramo.a1002150 item in DataAccess.PorRamo.Coberturas(cod_cia, cod_ramo, cod_modalidad, fec_validez, cod_cobExcludeFilter, cod_cobIncludeFilter))
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
                        deducible = item.NOM_FRANQUICIA
                    });
                }
            }

            return coberturas;
        }
        public static bool IsFromFeb2026(DateTime date) => date.Year > 2026 || (date.Year == 2026 && date.Month >= 2);
        public static bool IsPlan(int cod_plan_auto, params int[] plans) => plans.Contains(cod_plan_auto);
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
                quoteInfo.NUM_MATRICULA = Regex.Replace(quoteInfo.NUM_MATRICULA, @"[^a-zA-Z0-9]", String.Empty);
                Contracts.Batch.CotizadorMapfreMasClass quoteTron = MapfreMasConvertTo.Tron(quoteInfo, quoteInfo.cod_ramo, quoteInfo.cod_agt, tokenInfo.UserName, tokenInfo.IdentificationType, tokenInfo.Identification, tokenInfo.Roles);
                //Architect.Common.Helpers.Serialize.SerializeToFile<Architect.API.Tron.Contracts.Batch.CotizadorMapfreMasClass>(result, @"C:\temp\mapfremas.in.xml");

                Contracts.Presupuesto.DatoFijo resultTron = Backoffice.Cotizacion.MapfreMas.Calcular(quoteTron);
                resultInfo = MapfreMasConvertFrom.Quote(quoteInfo, resultTron);

                if (resultInfo.Error.IsEmpty() && tokenInfo.Roles.Contain("Purdy") && tokenInfo.Roles.Contain("PolizaGrupo"))
                {
                    DateTime fecha_validar = quoteTron.fec_vcto_poliza.AddMonths(-1);

                    if (quoteTron.fec_efec_poliza >= fecha_validar)
                    {

                        // Guarda dato Variable MCA_RENUEVA_EMI
                        Backoffice.Cotizacion.Generico.Crea_DatosVariable(resultInfo.presupuesto,
                            new Contracts.Presupuesto.DatoVariable()
                            {
                                cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]),
                                num_poliza = resultInfo.presupuesto,
                                num_spto = 0,
                                num_spto_apli = 0,
                                num_riesgo = 1,
                                num_periodo = 1,
                                tip_nivel = 2,
                                cod_campo = "MCA_RENUEVA_EMI",
                                val_campo = "S",
                                txt_campo = "S",
                                cod_ramo = quoteInfo.cod_ramo,
                                num_secu = 105,
                                mca_baja_riesgo = "N",
                                mca_vigente = "S",
                                mca_vigente_apli = "S"
                            });

                        quoteTron.fec_efec_poliza = quoteTron.fec_vcto_poliza;
                        quoteTron.fec_efec_spto = quoteTron.fec_efec_poliza;
                        quoteTron.fec_vcto_poliza = quoteTron.fec_vcto_poliza.AddYears(1);

                        // Cotiza Vigencia completa
                        Contracts.Presupuesto.DatoFijo resultTronFull = Backoffice.Cotizacion.MapfreMas.Calcular(quoteTron);

                        quoteInfo.plandepagoFull = new List<Contracts.Comun.PlanDePago>();
                        foreach (Architect.API.Tron.Contracts.Presupuesto.Recibo item in resultTronFull.Recibos)
                        {
                            quoteInfo.plandepagoFull.Add(new Contracts.Comun.PlanDePago()
                            {
                                cuota = item.num_cuota,
                                fechadesde = item.fec_efec_recibo,
                                fechahasta = item.fec_vcto_recibo,
                                primaneta = item.imp_neta + item.imp_recargo,
                                iVA = item.imp_imptos,
                                recargoporfraccionamiento = item.imp_interes,
                                importetotal = item.imp_recibo
                            });
                        }
                    }
                }

                //Utilities.SerializeHandler<Contracts.Presupuesto.DatoFijo>.SerializeToFile(resultTron, @"C:\temp\resultTron.xml");
                //Utilities.SerializeHandler<Contracts.Cotizacion.MapfreMas>.SerializeToFile(resultInfo, @"C:\temp\resultInfo.xml");

                //Contracts.Presupuesto.DatoFijo P30Instance = DataAccess.LeerPresupuesto.Presupuesto(1, resultTron.Coberturas.First().num_poliza, 0, 0, 0, null, true);
                //Contracts.Cotizacion.MapfreMas resultInfo2 = MapfreMasConvertFrom.Quote(MapfreMasConvertFrom.Quote(P30Instance), P30Instance);
                //Utilities.SerializeHandler<Contracts.Presupuesto.DatoFijo>.SerializeToFile(P30Instance, @"C:\temp\lecturacompleta.xml");
                //Utilities.SerializeHandler<Contracts.Cotizacion.MapfreMas>.SerializeToFile(resultInfo2, @"C:\temp\resultcompleta.xml");
                //resultInfo = resultInfo2;

                if (resultInfo.Error.IsEmpty())
                {
                    Architect.Utilities.Cache.SetItem(string.Format("mapfremas.{0}", resultInfo.presupuesto),
                        Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo), -1);

                    if (resultInfo.presupuesto.IsNotEmpty())
                    {
                        Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultInfo.presupuesto.Substring(4)), tokenInfo.CompanyId, "Cotización MapfreMas", "Presupuesto #" + resultInfo.presupuesto, tokenInfo.UserId, resultInfo);

                        Core.Business.General.CustomData.Create(tokenInfo, 3000, Convert.ToInt64(resultInfo.presupuesto),
                                                                Newtonsoft.Json.JsonConvert.SerializeObject(new
                                                                {
                                                                    nombredelcontratante = resultInfo.nombredelcontratante,
                                                                    edad = resultInfo.edad,
                                                                    mca_sexo = resultInfo.mca_sexo,
                                                                    mca_sexoDesc = resultInfo.mca_sexoDesc,
                                                                    AutoSust = resultInfo.AutoSust
                                                                }), "QUOTE-", resultInfo.presupuesto);
                    }
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
                    case "TRON_TA301001:3001":
                        result.IMP_AUTO_RC = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_CAPITAL_GM_G":
                        result.IMP_AUTO_GMO = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_CAPITAL_AC_G":
                        result.IMP_AUTO_ACO = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_CAPITAL_ROTCRI_G":
                        result.IMP_AUTO_CRI = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_DEDU_RC_G":
                        result.DED_AUTO_RC = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_DEDU_CV_G":
                        result.DED_AUTO_CYV = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_DEDU_ROTCRI_G":
                        result.DED_AUTO_CRI = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_DEDU_EE_G":
                        result.DED_AUTO_EQESP = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_DEDU_RA_G":
                        result.DED_AUTO_RAD = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_DEDU_ROBO_G":
                        result.DED_AUTO_ROB = CleanEmptyValue(itemValues.Lkp);
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
                            result.IMP_AUTO_RC = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_CAPITAL_GM":
                        if (result.IMP_AUTO_GMO.IsEmpty() || result.IMP_AUTO_GMO.Count == 0)
                        {
                            result.IMP_AUTO_GMO = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_CAPITAL_AC":
                        if (result.IMP_AUTO_ACO.IsEmpty() || result.IMP_AUTO_ACO.Count == 0)
                        {
                            result.IMP_AUTO_ACO = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_CAPITAL_GN":
                        result.IMP_AUTO_NEUM = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_CAPITAL_AM":
                        result.IMP_AUTO_MECA = CleanEmptyValue(itemValues.Lkp);
                        break;
                    case "MM_CAPITAL_ROTCRI":
                        if (result.IMP_AUTO_CRI.IsEmpty() || result.IMP_AUTO_CRI.Count == 0)
                        {
                            result.IMP_AUTO_CRI = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_DEDU_RC":
                        if (result.DED_AUTO_RC.IsEmpty() || result.DED_AUTO_RC.Count == 0)
                        {
                            result.DED_AUTO_RC = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_DEDU_CV":
                        if (result.DED_AUTO_CYV.IsEmpty() || result.DED_AUTO_CYV.Count == 0)
                        {
                            result.DED_AUTO_CYV = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_DEDU_RA":
                        if (result.DED_AUTO_RAD.IsEmpty() || result.DED_AUTO_RAD.Count == 0)
                        {
                            result.DED_AUTO_RAD = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_DEDU_ROBO":
                        if (result.DED_AUTO_ROB.IsEmpty() || result.DED_AUTO_ROB.Count == 0)
                        {
                            result.DED_AUTO_ROB = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_DEDU_EE":
                        if (result.DED_AUTO_EQESP.IsEmpty() || result.DED_AUTO_EQESP.Count == 0)
                        {
                            result.DED_AUTO_EQESP = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "MM_DEDU_ROTCRI":
                        if (result.DED_AUTO_CRI.IsEmpty() || result.DED_AUTO_CRI.Count == 0)
                        {
                            result.DED_AUTO_CRI = CleanEmptyValue(itemValues.Lkp);
                        }
                        break;
                    case "TRON_G2990006_ByMod:COD_TIP_COM_VEHI":
                        result.COD_TIP_COM_VEHI = itemValues.Lkp;
                        break;
                }
            }
        }

        private static List<Core.Contracts.General.LookupValue> CleanEmptyValue(List<Core.Contracts.General.LookupValue> values)
        {
            if (values != null && values.Count > 0 && (values.First().Code == "0" || values.First().Code == ""))
            {
                values.Remove(values.First());
            }
            return values;
        }

        public static List<Core.Contracts.General.LookupValues> LksExclude(string keys, string url, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMas data = MapfreMasLookUpData(url);

            List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps(keys, url, tokenInfo);

            return Exclude(values, data, tokenInfo);
        }

        public static List<Core.Contracts.General.LookupValue> LkpChildExclude(string key, int parentId, string url, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMas data = MapfreMasLookUpData(url);

            List<Core.Contracts.General.LookupValue> values = Core.Business.Common.LkpChild(key, parentId, url, tokenInfo);

            return NewMethod(data, tokenInfo, key, values);
        }

        private static List<Core.Contracts.General.LookupValues> Exclude(List<Core.Contracts.General.LookupValues> values, Contracts.Cotizacion.MapfreMas data, Core.Contracts.Security.Token tokenInfo)
        {
            foreach (Core.Contracts.General.LookupValues itemValues in values)
            {
                itemValues.Lkp = NewMethod(data, tokenInfo, itemValues.Key, itemValues.Lkp);
            }
            return values;
        }

        private static List<Core.Contracts.General.LookupValue> NewMethod(Contracts.Cotizacion.MapfreMas data, Token tokenInfo, string key, List<Core.Contracts.General.LookupValue> values)
        {
            string exclude = string.Empty;
            exclude = Reglas.research.Apply_Listas("MapfreMas", data, key, tokenInfo);

            if (exclude.IsNotEmpty())
            {
                Utilities.Log.TraceLog("Lookups", $"Excluir '{exclude}' de la lista '{key}'", "Decision");

                foreach (string item in exclude.Split(','))
                {
                    values.Remove(values.Find(r => r.Code == item));
                }
            }

            return values;
        }

        private static Contracts.Cotizacion.MapfreMas MapfreMasLookUpData(string url)
        {
            Dictionary<string, string> urlValues = url.ToDictionary(':', '=');
            Contracts.Cotizacion.MapfreMas data = new Contracts.Cotizacion.MapfreMas()
            {
                cod_ramo = 0,
                cod_mon = 0,
                cod_marca = 0,
                tipo_prod = "",
                edad = 0
            };
            if (urlValues.ContainsKey("cod_ramo"))
                data.cod_ramo = Convert.ToInt32(urlValues["cod_ramo"]);
            if (urlValues.ContainsKey("cod_mon"))
                data.cod_mon = Convert.ToInt32(urlValues["cod_mon"]);
            if (urlValues.ContainsKey("edad"))
                data.cod_mon = Convert.ToInt32(urlValues["edad"]);
            if (urlValues.ContainsKey("plan"))
                data.tipo_prod = urlValues["plan"];
            if (urlValues.ContainsKey("cod_marca"))
                data.cod_marca = Convert.ToInt32(urlValues["cod_marca"]);
            return data;
        }

    }
}
