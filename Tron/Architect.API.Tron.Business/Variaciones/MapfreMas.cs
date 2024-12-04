using Architect.API.Tron.Business.Backoffice;
using Architect.API.Tron.Contracts.Variaciones;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Architect.API.Tron.Business.Variaciones
{
    public static class MapfreMas
    {
        /// <summary>
        /// Preparara información necesaria para inicial la emision de una variación.
        /// </summary>
        /// <param name="presupuesto">Número de presupuesto</param>
        /// <param name="tokenInfo">Información de contexto del usuario conectando.</param>
        public static Contracts.Variaciones.MapfreMas Setup(string num_poliza, int num_spto, string mca_provisional, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Variaciones.MapfreMas result = null;
            string key = string.Format("mapfremas.{0}", num_poliza);

            Contracts.Poliza.DatoFijo A30Instance = Poliza.PolizaVariaciones(1, num_poliza, true);

            Contracts.Variaciones.MapfreMas resultInfo2 = Variaciones.MapfreMasConvertFrom.Quote(Variaciones.MapfreMasConvertFrom.Quote(A30Instance), A30Instance);

            resultInfo2 = Variaciones.MapfreMasConvertFrom.SetTipoProducto(resultInfo2);

            if (mca_provisional.Equals("S"))
            {
                resultInfo2.Recibos = DataAccess.Variaciones.VariacionIssue.GetRecibos(resultInfo2.cod_cia, num_poliza, num_spto);
            }

            Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(resultInfo2), -1);

            if (Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Variaciones.MapfreMas>(Utilities.Cache.GetItem(key).ToString());

                //result.Modo = mode;

                if (!tokenInfo.Roles.Contain("Purdy") )
                {
                    result.terceros = Reglas.research.Apply_Terceros("MapfreMas", result.terceros, result.Fuente_Tomador, tokenInfo);
                }

                result.documentosrequeridos = Reglas.research.Apply_DocumentosRequeridos("MapfreMas", null, result.MCA_CERO_KM, tokenInfo);
            }

            return result;
        }

        public static VariacionIssueResult Issue(Contracts.Variaciones.MapfreMas quoteInfo)
        {
            VariacionIssueResult result = null;

            try
            {
                quoteInfo.NUM_MATRICULA = Regex.Replace(quoteInfo.NUM_MATRICULA, @"[^a-zA-Z0-9]", String.Empty);

                DateTime Fec_Tratamiento = DateTime.Today;
                string Tip_mvto_batch = "4";

                Architect.API.Tron.Contracts.Poliza.DatoFijo a2000030Instance = Architect.API.Tron.DataAccess.LeerPoliza.Lee_A2000030(quoteInfo.cod_cia, quoteInfo.num_poliza, 0, 0, 0);

                if(a2000030Instance.cod_fracc_pago != quoteInfo.cod_fracc_pago)
                {
                    Architect.API.Tron.Contracts.Variaciones.s2000030 s2000030Instance = new Contracts.Variaciones.s2000030()
                    {
                        Fec_Tratamiento = Fec_Tratamiento,
                        Tip_Mvto_Batch = Tip_mvto_batch,
                        Cod_Cia = quoteInfo.cod_cia,
                        Cod_Ramo = quoteInfo.cod_ramo,
                        Num_Poliza = quoteInfo.num_poliza,
                        Cod_Fracc_Pago = quoteInfo.cod_fracc_pago
                    };

                    Architect.API.Tron.DataAccess.Variaciones.S2000030.Create(s2000030Instance);
                }

                List<Architect.API.Tron.Contracts.Poliza.DatoVariable> DatosVariables = Architect.API.Tron.DataAccess.LeerPoliza.Lee_A2000020(1, quoteInfo.num_poliza, 0, 0, 0);

                List<Architect.API.Tron.Contracts.Variaciones.s2000020> a2000020InstanceList = new List<Contracts.Variaciones.s2000020>();

                foreach (Contracts.Poliza.DatoVariable item in DatosVariables)
                {
                    switch (item.cod_campo)
                    {
                        case "COD_COLOR":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.COD_COLOR.ToString(), Tip_mvto_batch);
                            break;
                        case "NUM_MATRICULA":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.NUM_MATRICULA, Tip_mvto_batch);
                            break;
                        case "IMP_AUTO_RC":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_AUTO_RC.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_AUTO_GMO":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_AUTO_GMO.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_AUTO_ACO":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_AUTO_ACO.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_AUTO_CYV":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_AUTO_CYV.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_VR":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_VR.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_PRA":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_VR.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_AUTO_CRI":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_AUTO_CRI.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_AUTO_RAD":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_AUTO_RAD.ToString(), Tip_mvto_batch);
                            break;
                        case "IMP_AUTO_ROB":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.IMP_AUTO_ROB.ToString(), Tip_mvto_batch);
                            break;
                        case "DED_AUTO_RC":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.DED_AUTO_RC.ToString(), Tip_mvto_batch);
                            break;
                        case "DED_AUTO_ROB":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.DED_AUTO_ROB.ToString(), Tip_mvto_batch);
                            break;
                        case "DED_AUTO_CYV":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.DED_AUTO_CYV.ToString(), Tip_mvto_batch);
                            break;
                        case "DED_AUTO_RAD":
                            RegisterS2000020(item, Fec_Tratamiento, quoteInfo.DED_AUTO_RAD.ToString(), Tip_mvto_batch);
                            break;
                    }
                }

                result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "N", quoteInfo.MCA_FEC_EFEC_SYS);

                if (!string.IsNullOrEmpty(result.ProcessResult.txt_error))
                {
                    result.McaError = "S";
                    Utilities.Log.ErrorLog("Variacion: " + result.ProcessResult.num_poliza, result.ProcessResult.txt_error, "Variacion.Issue.MapfreMas");
                }
                else
                {
                    result.McaError = "N";
                }
            }
            catch (Exception ex)
            {
                result.McaError = "S";
                result.ProcessResult.txt_error = ex.Message;
                Utilities.Log.ErrorLog("Cancelacion: " + result.ProcessResult.num_poliza, ex.Message, "Variacion.Cancelation.MapfreMas");
            }
            return result;
        }

        private static void RegisterS2000020(Architect.API.Tron.Contracts.Poliza.DatoVariable datoVariable, DateTime fec_tratamiento, string val_campo_nuevo, string tip_mvto_batch)
        {
            Contracts.Variaciones.s2000020 dv;

            if (datoVariable.val_campo.Trim() != val_campo_nuevo.Trim())
            {
                dv = new Contracts.Variaciones.s2000020
                {
                    Fec_Tratamiento = fec_tratamiento,
                    Tip_Mvto_Batch = tip_mvto_batch,
                    Cod_Cia = datoVariable.cod_cia,
                    Cod_Ramo = datoVariable.cod_ramo,
                    Num_Poliza = datoVariable.num_poliza,
                    Num_Riesgo = datoVariable.num_riesgo,
                    Cod_Campo = datoVariable.cod_campo,
                    Val_Campo_Actual = datoVariable.val_campo,
                    Val_Campo_Nuevo = val_campo_nuevo
                };

                Architect.API.Tron.DataAccess.Variaciones.S2000020.Create(dv);
            }
        }

        public static VariacionIssueResult Cancelation(Contracts.Variaciones.MapfreMas quoteInfo)
        {
            DateTime Fec_Tratamiento = DateTime.Today;
            string Tip_mvto_batch = "4";
            VariacionIssueResult result = null;

            try
            {
                result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "S", quoteInfo.MCA_FEC_EFEC_SYS);

                if (!string.IsNullOrEmpty(result.ProcessResult?.txt_error))
                {
                    result.McaError = "S";
                    Utilities.Log.ErrorLog("Cancelacion: " + result.ProcessResult.num_poliza, result.ProcessResult.txt_error, "Variacion.Cancelation.MapfreMas");
                }
                else
                {
                    result.McaError = "N";
                }
            }
            catch (Exception ex)
            {
                result.McaError = "S";
                result.ProcessResult.txt_error = ex.Message;
                Utilities.Log.ErrorLog("Cancelacion: " + result.ProcessResult.num_poliza, ex.Message, "Variacion.Cancelation.MapfreMas");
            }

            return result;
        }

        public static VariacionIssueResult ManageAuthorizationCT(int cod_cia, int cod_ramo, string num_poliza, string mca_autoriza)
        {
            VariacionIssueResult result = new VariacionIssueResult();
            bool resultCT = false;
            string observacion;

            try
            {
                observacion = (mca_autoriza.Equals("S")) ? "Autorizacion CT - ZA" : "Rechazo CT - ZA";
                resultCT = DataAccess.Variaciones.VariacionIssue.ManageAuthorizationCT(cod_ramo, num_poliza, observacion, mca_autoriza);

                if (!resultCT)
                {
                    result.McaError = "S";
                    result.ProcessResult.txt_error = "Error al autorizar el CT";
                    Utilities.Log.ErrorLog("Autorizacion-Rechazo CT: " + num_poliza, result.ProcessResult.txt_error, "Variacion.Autorizacion-Rechazo.MapfreMas");
                }
                else
                {
                    result.McaError = "N";
                    result.ProcessResult.txt_error = "Se autorizó correctamente el CT";
                }
            }
            catch (Exception ex)
            {
                result.McaError = "S";
                result.ProcessResult.txt_error = "Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte";
                Utilities.Log.ErrorLog("Autorizacion-Rechazo CT: " + num_poliza, ex.Message, "Variacion.Autorizacion-Rechazo.MapfreMas");
            }

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
                "MM_DEDU_RC", "MM_DEDU_CV", "MM_DEDU_RA", "MM_DEDU_ROBO", "MM_DEDU_EE", "MM_DEDU_ROTCRI" };
            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                keys.AddRange(new List<string> {
                    "TRON_TA301001:3001", "MM_CAPITAL_GM_G", "MM_CAPITAL_AC_G", "MM_CAPITAL_ROTCRI_G",
                    "MM_DEDU_RC_G", "MM_DEDU_CV_G", "MM_DEDU_ROTCRI_G", "MM_DEDU_EE_G", "MM_DEDU_RA_G", "MM_DEDU_ROBO_G", "MM_POLIZA_GRUPO"});
            }

            string url = $"cod_ramo={cod_ramo}:cod_mon={cod_mon}:edad={edad}:plan={tipo_prod}:cod_marca={cod_marca}:num_contrato={num_contrato}:num_subcontrato={num_subcontrato}:num_poliza_grupo={num_poliza_grupo}:cod_modelo={cod_modelo}:anio_sub_modelo={anio_sub_modelo}:cod_tip_vehi={cod_tip_vehi}:cod_uso_vehi={cod_uso_vehi}:mca_sexo={mca_sexo}:cod_zona_circul={cod_zona_circul}:cod_plan_auto={cod_plan_auto}:cod_agt={cod_agt}";
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

    }
}
