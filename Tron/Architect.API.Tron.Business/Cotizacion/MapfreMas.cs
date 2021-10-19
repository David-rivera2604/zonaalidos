using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Architect.API.Tron.Business.Cotizacion
{
    public static class MapfreMas
    {

        const int COD_RAMO = 302;

        public static Architect.API.Tron.Contracts.Cotizacion.MapfreMas Setup(Core.Contracts.Security.Token tokenInfo)
        {
            Architect.API.Tron.Contracts.Cotizacion.MapfreMas result = new Architect.API.Tron.Contracts.Cotizacion.MapfreMas()
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

            //Architect.API.Tron.Business.research.MapfreMasBuild();
            return result;
        }

        public static Tron.Contracts.Cotizacion.MapfreMasSettings Settings(int cod_ramo, int cod_mon, int edad, string tipo_prod, int cod_marca, int num_contrato, int num_subcontrato, Core.Contracts.Security.Token tokenInfo)
        {
            Tron.Contracts.Cotizacion.MapfreMasSettings result = new Contracts.Cotizacion.MapfreMasSettings();
            List<string> keys = new List<string> {
                "MM_Plan",
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
                        }
                    }
                }

            }

            LookUps(result, values);

            return result;
        }

        public static List<Contracts.Comun.Cobertura> CoverageByDefault(int cod_mon, int cod_marca, int cod_modelo, int anio_sub_modelo, int cod_tip_vehi, int cod_uso_vehi, int mca_sexo, int cod_zona_circul, int edad, int cod_plan_auto, int num_contrato, int num_subcontrato, string num_poliza_grupo, Core.Contracts.Security.Token tokenInfo)
        {
            List<Contracts.Comun.Cobertura> coberturas = new List<Contracts.Comun.Cobertura>();
            string cod_cobExcludeFilter = string.Empty;
            string cod_cobIncludeFilter = string.Empty;
            string selected = string.Empty;
            int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);
            int cod_cia = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
            int tip_valoracion = 1;
            DateTime fec_validez = DateTime.Today;

            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                if (num_contrato > 0)
                {
                    cod_cobIncludeFilter = Architect.API.Tron.DataAccess.PorRamo.Coberturas_por_contrato(COD_RAMO, num_contrato);
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
                        selected = cod_cobIncludeFilter;

                        foreach (Architect.API.Tron.Contracts.Tables.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, COD_RAMO, cod_modalidad, fec_validez, cod_cobExcludeFilter, cod_cobIncludeFilter))
                        {
                            coberturas.Add(new Contracts.Comun.Cobertura()
                            {
                                seleccionado = string.Format(",{0},", cod_cobIncludeFilter).IndexOf(string.Format(",{0},", item.COD_COB)) > -1,
                                requerida = item.MCA_OBLIGATORIO == "S",
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
                switch (cod_uso_vehi)
                {
                    case 2: //Si el vehículo es de uso comercial
                        switch (cod_plan_auto)
                        {
                            case 31: // Básico
                                selected = "3002,3003";
                                cod_cobExcludeFilter = "3002,3003,3016,3018,3014,3015,3008,3017";
                                break;
                            case 32: // Amplio
                                selected = "3002,3003";
                                cod_cobExcludeFilter = "3015,3008,3016,3018,3017";
                                break;

                            case 34: // Oro
                                selected = "3001,3002,3003,3004,3005,3006,3009,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061";
                                break;
                            case 35: //Plata
                                selected = "3001,3004,3005,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061,3002,3003,3007,3014,3015,3008";
                                //cod_cobExcludeFilter = "3002,3003,3007,3014,3015,3008,1060,3016,3018,3017";
                                break;
                            case 36: //Trebol
                                selected = "3001,3004,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061";
                                break;
                            case 37: //Trebol RC
                                selected = "3001,3004,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061";
                                break;

                            default: // 33 Plus
                                selected = "3002,3003";
                                cod_cobExcludeFilter = "3016,3018,3017";
                                break;
                        }
                        break;
                    default: //Si el vehículo no es de uso comercial
                        switch (cod_plan_auto)
                        {
                            case 31: // Básico
                                selected = "";
                                cod_cobExcludeFilter = "3002,3003,3016,3018,3014,3015,3008,3017";
                                break;
                            case 32: // Amplio
                                selected = "";
                                cod_cobExcludeFilter = "3015,3008,3016,3018,3017";
                                break;

                            case 34: // Oro
                                selected = "3001,3002,3003,3004,3005,3006,3009,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061";
                                break;
                            case 35: //Plata
                                selected = "3001,3004,3005,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061,3002,3003,3007,3014,3015,3008";
                                //cod_cobExcludeFilter = "3002,3003,3007,3014,3015,3008,1060,3016,3018,3017";
                                break;
                            case 36: //Trebol
                                selected = "3001,3004,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061";
                                break;
                            case 37: //Trebol RC
                                selected = "3001,3004,3010";
                                cod_cobExcludeFilter = "3016,3018,3017,3094,1061";
                                break;

                            default: // 33 Plus
                                selected = "";
                                cod_cobExcludeFilter = "3016,3018,3017";
                                break;
                        }
                        break;
                }
                List<Architect.API.Tron.Contracts.Tables.ta301003> coverageSelection = Architect.API.Tron.DataAccess.PorRamo.AutomobileCoverageSelection(cod_cia, num_poliza_grupo, num_contrato, num_subcontrato, COD_RAMO, cod_mon, cod_marca, cod_modelo, anio_sub_modelo, cod_tip_vehi, cod_uso_vehi, mca_sexo, cod_zona_circul, edad, cod_plan_auto, tip_valoracion);

                foreach (Architect.API.Tron.Contracts.Tables.a1002150 item in Architect.API.Tron.DataAccess.PorRamo.Coberturas(cod_cia, COD_RAMO, cod_modalidad, fec_validez, cod_cobExcludeFilter, cod_cobIncludeFilter))
                {
                    coberturas.Add(new Contracts.Comun.Cobertura()
                    {
                        seleccionado = coverageSelection.Any(r => r.cod_cob == item.COD_COB && r.mca_obligatoria == "S"),
                        requerida = item.MCA_OBLIGATORIO == "S",
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

        public static Contracts.Cotizacion.MapfreMas Quote(Contracts.Cotizacion.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Cotizacion.MapfreMas resultInfo = quoteInfo;

            //TODO: Es necesario convertir las validaciones existentes en el JS
            resultInfo.Errors = Validate(quoteInfo, tokenInfo);

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
        /// Valida la información de una póliza para permitir o no su emisión.
        /// </summary>
        /// <param name="source">Datos de la póliza</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns></returns>
        private static List<Core.Contracts.General.Error> Validate(Contracts.Cotizacion.MapfreMas source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "MapfreMas";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Coberturas:
            if (!Rule_AtLeastOneCoverageSelected(source))
            {
                result.Add(new Core.Contracts.General.Error() { Group = "Table", Key = "coberturasTbl", Message = "Debe seleccionar al menos una cobertura" });
            }

            //ANIO_SUB_MODELO:
            if (tokenInfo.Roles.Contain("Purdy") && Rule_MinYearOfVehicleManufacture_Purdy(source.ANIO_SUB_MODELO, source.contrato))
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ANIO_SUB_MODELO", Message = string.Format("El año del vehículo debe ser mayor o igual a {0}", Util_MinYearOfVehicleManufactureAllowed_Purdy(source.contrato)) });
            }
            if (tokenInfo.Roles.Contain("Privilegios") && Rule_MinYearOfVehicleManufacture(source.ANIO_SUB_MODELO, 17))
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ANIO_SUB_MODELO", Message = string.Format("El año del vehículo debe ser mayor o igual a {0}", Util_MinYearOfVehicleManufactureAllowed(17)) });
            }
            //Si no aplica algunos de los roles anteriores esta seria la validación por defecto
            if (!tokenInfo.Roles.Contain("Purdy") && !tokenInfo.Roles.Contain("Privilegios") &&
                Rule_MinYearOfVehicleManufacture(source.ANIO_SUB_MODELO, 15))
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ANIO_SUB_MODELO", Message = string.Format("El año del vehículo debe ser mayor o igual a {0}", Util_MinYearOfVehicleManufactureAllowed(15)) });
            }

            //Se debe permitir cotizar la marca Peugeout, pero solamente con 3 años de antigüedad, es decir: del 2018 en adelante.
            //Esto sería para los que cotizan de forma genérica.
            if (source.cod_marca == 60 && Rule_MinYearOfVehicleManufacture(source.ANIO_SUB_MODELO, 3))
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ANIO_SUB_MODELO", Message = string.Format("Para un Peugeot, el año del vehículo debe ser mayor o igual a {0}", Util_MinYearOfVehicleManufactureAllowed(3)) });
            }


            //IMP_VR:
            if (tokenInfo.Roles.Contain("Privilegios") && 
                Rule_MaximumAllowedValueOfVehicle(source.cod_mon, source.IMP_VR, 45000000, 75000))
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "IMP_VR", Message = string.Format("El valor del vehículo debe ser menor o igual a {0}", source.cod_mon == 1 ? "45.000.000 colones" : "75.000 dólares") });
            }
            if ((tokenInfo.Roles.Contain("Davivienda_Prendarios") || tokenInfo.Roles.Contain("Davivienda_Leasing")) && 
                Rule_MaximumAllowedValueOfVehicle(source.cod_mon, source.IMP_VR, 80000000, 125000))
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "IMP_VR", Message = string.Format("El valor del vehículo debe ser menor o igual a {0}", source.cod_mon == 1 ? "80.000.000 colones" : "125.000 dólares") });
            }
            

            //Si no aplica algunos de los roles anteriores esta seria la validación por defecto
            if (!tokenInfo.Roles.Contain("Privilegios") && 
                !tokenInfo.Roles.Contain("Davivienda_Prendarios") && 
                !tokenInfo.Roles.Contain("Davivienda_Leasing") &&
                Rule_MaximumAllowedValueOfVehicle(source.cod_mon, source.IMP_VR, 28650000, 50000))
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "IMP_VR", Message = string.Format("El valor del vehículo debe ser menor o igual a {0}", source.cod_mon == 1 ? "28.650.000 colones" : "50.000 dólares") });
            }
            return result;
        }


        /// <summary>
        /// Valida monto permitido
        /// </summary>
        /// <param name="currency">Código de la moneda</param>
        /// <param name="vehicleValue">Valor del vehículo</param>
        /// <returns>Verdadero si el valor indicado es permitido, falso en el caso contrario</returns>
        private static bool Rule_MaximumAllowedValueOfVehicle(int currency, int vehicleValue, int maximumColones, int maximumDollars)
        {
            bool result = false;
            switch (currency)
            {
                case 1: //Colones
                    result = vehicleValue > maximumColones;
                    break;
                case 2: //Dolares
                    result = vehicleValue > maximumDollars;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Solo se permite cotizar a vehículos máximo con 6 años de antigüedad excepto para el contrato 10002 el cual permite solo 1 año
        /// </summary>
        /// <param name="yearOfVehicleManufacture">Año de fabricación del vehículo</param>
        /// <param name="contract">Número de contrato de póliza grupo</param>
        /// <returns>Verdadero si el año de fabricación es valido, falso en el caso contrario</returns>
        private static bool Rule_MinYearOfVehicleManufacture_Purdy(int yearOfVehicleManufacture, int contract)
        {
            return yearOfVehicleManufacture < Util_MinYearOfVehicleManufactureAllowed_Purdy(contract);
        }

        /// <summary>
        /// Recupera el año mínimo permitido por contrato
        /// </summary>
        /// <param name="contract">Número de contrato de póliza grupo</param>
        /// <returns>Año permitido</returns>
        private static int Util_MinYearOfVehicleManufactureAllowed_Purdy(int contract)
        {
            int minYear = DateTime.Today.Year;

            if (contract == 10002)
            {
                minYear -= 1;
            }
            else
            {
                minYear -= 6;
            }
            return minYear;
        }

        /// <summary>
        /// Solo se permite cotizar a vehículos máximo con 17 años de antigüedad
        /// </summary>
        /// <param name="yearOfVehicleManufacture">Año de fabricación del vehículo</param>
        /// <param name="maxValue">Cantidad máxima de años de antigüedad</param>
        /// <returns>Verdadero si el año de fabricación es valido, falso en el caso contrario</returns>
        private static bool Rule_MinYearOfVehicleManufacture(int yearOfVehicleManufacture, int maxValue)
        {
            return yearOfVehicleManufacture < Util_MinYearOfVehicleManufactureAllowed(maxValue);
        }

        /// <summary>
        /// Recupera el año mínimo permitido por contrato
        /// </summary>
        /// <param name="maxValue">Cantidad máxima de años de antigüedad</param>
        /// <returns>Año permitido</returns>
        private static int Util_MinYearOfVehicleManufactureAllowed(int maxValue)
        {
            return DateTime.Today.Year - maxValue;
        }

        private static bool Rule_AtLeastOneCoverageSelected(Contracts.Cotizacion.MapfreMas source)
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

        private static void LookUps(Contracts.Cotizacion.MapfreMasSettings result, List<Core.Contracts.General.LookupValues> values)
        {
            foreach (Core.Contracts.General.LookupValues itemValues in values)
            {
                switch (itemValues.Key)
                {
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
