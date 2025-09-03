using Architect.API.Tron.Contracts.Poliza;
using Architect.API.Tron.Contracts.Variaciones;
using Architect.API.Tron.DataAccess.Variaciones;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Variaciones
{
    public static class VariacionesServiceCommon
    {
        /// <summary>
        /// Procesa una variación genérica
        /// </summary>
        /// <typeparam name="T">Tipo que implementa IVariacionData</typeparam>
        /// <param name="quoteInfo">Información de la variación</param>
        /// <returns>Resultado del procesamiento</returns>
        public static VariacionIssueResult Issue<T>(T quoteInfo)
            where T : IVariacionData
        {
            VariacionIssueResult result = null;

            try
            {
                // Limpiar matrícula si es un proveedor de datos variables
                if (quoteInfo is IVariableDataProvider variableProvider)
                {
                    var variableData = variableProvider.GetVariableData();
                    if (variableData.ContainsKey("NUM_MATRICULA") && !string.IsNullOrEmpty(variableData["NUM_MATRICULA"].val_campo))
                    {
                        var cleanedData = variableProvider.GetVariableData();
                        cleanedData["NUM_MATRICULA"].val_campo = Regex.Replace(cleanedData["NUM_MATRICULA"].val_campo, @"[^a-zA-Z0-9]", String.Empty);
                    }
                }

                DateTime Fec_Tratamiento = DateTime.Today;
                string Tip_mvto_batch = "4";

                VariacionIssue.DeleteTablesS(Fec_Tratamiento, Tip_mvto_batch, quoteInfo.cod_cia, quoteInfo.num_poliza);

                Architect.API.Tron.Contracts.Poliza.DatoFijo a2000030Instance =
                    Architect.API.Tron.DataAccess.LeerPoliza.Lee_A2000030(quoteInfo.cod_cia, quoteInfo.num_poliza, null, 0, 0);

                if (a2000030Instance.cod_fracc_pago != quoteInfo.cod_fracc_pago)
                {
                    result = ProcessFraccionamientoChange(quoteInfo, Fec_Tratamiento, Tip_mvto_batch);
                }
                else
                {
                    result = ProcessVariaciones(quoteInfo, Fec_Tratamiento, Tip_mvto_batch);
                }

                return ProcessResult(result, quoteInfo);
            }
            catch (Exception ex)
            {
                return HandleException(ex, quoteInfo.num_poliza, "Variacion.Issue");
            }
        }

        /// <summary>
        /// Procesa una cancelación
        /// </summary>
        /// <param name="cod_cia">Información de la cancelación</param>
        /// <param name="cod_ramo">Información de la cancelación</param>
        /// <param name="num_poliza">Información de la cancelación</param>
        /// <param name="fec_efec_cancel">Información de la cancelación</param>
        /// <param name="txt_motivo">Información de la cancelación</param>
        /// <returns>Resultado del procesamiento</returns>
        public static VariacionIssueResult Cancelation(int cod_cia, int cod_ramo, string num_poliza,
            DateTime fec_efec_cancel, string txt_motivo)
        {
            DateTime Fec_Tratamiento = DateTime.Today;
            string Tip_mvto_batch = "4";
            VariacionIssueResult result = null;

            try
            {
                result = DataAccess.Variaciones.VariacionIssue.Issue(
                    cod_cia, num_poliza, Fec_Tratamiento, Tip_mvto_batch, "S", "N", fec_efec_cancel, txt_motivo);

                int countError = ProcessErrorCount(result, num_poliza, "Cancelacion");

                if (countError > 0)
                {
                    result.McaError = "S";
                }
                else
                {
                    result = GetCoverageAndReceipts(result, cod_cia, cod_ramo, num_poliza);
                    result.McaError = "N";
                }
            }
            catch (Exception ex)
            {
                result = new VariacionIssueResult
                {
                    McaError = "S",
                    ProcessResult = new List<VariacionIssueProcessResult>
                    {
                        new VariacionIssueProcessResult
                        {
                            num_poliza = num_poliza,
                            txt_error = ex.Message
                        }
                    }
                };
                Utilities.Log.ErrorLog("Cancelacion: " + num_poliza, ex.Message, "Variacion.Cancelation.Generic");
            }

            return result;
        }

        /// <summary>
        /// Maneja la autorización/rechazo de CT de forma genérica
        /// </summary>
        /// <param name="cod_cia">Información de autorización</param>
        /// <param name="cod_ramo">Información de autorización</param>
        /// <param name="num_poliza">Información de autorización</param>
        /// <param name="num_spto">Información de autorización</param>
        /// <param name="mca_autoriza">Información de autorización</param>
        /// <returns>Resultado del procesamiento</returns>
        public static VariacionIssueResult ManageAuthorizationCT(int cod_cia, int cod_ramo, string num_poliza,
            int num_spto, string mca_autoriza)
        {
            VariacionIssueResult result = new VariacionIssueResult();
            (int, string) resultCT = (0, string.Empty);
            string observacion;

            try
            {
                observacion = (mca_autoriza.Equals("S")) ? "Autorizacion CT - ZA" : "Rechazo CT - ZA";
                resultCT = DataAccess.Variaciones.VariacionIssue.ManageAuthorizationCT(
                    cod_ramo, num_poliza, observacion, mca_autoriza, 4004);

                if (resultCT.Item1.Equals(1))
                {
                    result.McaError = "S";
                    result.ProcessResult.Add(new VariacionIssueProcessResult
                    {
                        num_poliza = num_poliza,
                        txt_error = resultCT.Item2
                    });
                    Utilities.Log.ErrorLog("Autorizacion-Rechazo CT: " + num_poliza, resultCT.Item2,
                        "Variacion.Autorizacion-Rechazo.Generic");
                }
                else
                {
                    result = GetCoverageAndReceipts(result, cod_cia, cod_ramo, num_poliza);
                    result.Recibos = DataAccess.Variaciones.VariacionIssue.GetRecibos(cod_cia, num_poliza, null);

                    result.McaError = "N";
                    result.ProcessResult.Add(new VariacionIssueProcessResult
                    {
                        num_poliza = num_poliza,
                        txt_error = (!string.IsNullOrEmpty(resultCT.Item2))
                            ? resultCT.Item2
                            : "Se autorizó correctamente el CT"
                    });
                }
            }
            catch (Exception ex)
            {
                result.McaError = "S";
                result.ProcessResult.Add(new VariacionIssueProcessResult
                {
                    num_poliza = num_poliza,
                    txt_error = "Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte"
                });
                Utilities.Log.ErrorLog("Autorizacion-Rechazo CT: " + num_poliza, ex.Message,
                    "Variacion.Autorizacion-Rechazo.Generic");
            }

            return result;
        }

        #region Métodos Privados de Procesamiento

        private static VariacionIssueResult ProcessFraccionamientoChange<T>(T quoteInfo,
            DateTime fecTratamiento, string tipMvtoBatch) where T : IVariacionData
        {
            var s2000030Instance = new Contracts.Variaciones.s2000030()
            {
                Fec_Tratamiento = fecTratamiento,
                Tip_Mvto_Batch = tipMvtoBatch,
                Cod_Cia = quoteInfo.cod_cia,
                Cod_Ramo = quoteInfo.cod_ramo,
                Num_Poliza = quoteInfo.num_poliza,
                Cod_Fracc_Pago = quoteInfo.cod_fracc_pago
            };

            Architect.API.Tron.DataAccess.Variaciones.S2000030.Create(s2000030Instance);

            return DataAccess.Variaciones.VariacionIssue.Issue(
                quoteInfo.cod_cia, quoteInfo.num_poliza, fecTratamiento,
                tipMvtoBatch, "N", "S", quoteInfo.fec_efec);
        }

        private static VariacionIssueResult ProcessVariaciones<T>(T quoteInfo,
            DateTime fecTratamiento, string tipMvtoBatch) where T : IVariacionData
        {
            // Procesar datos variables si el objeto los soporta
            if (quoteInfo is IVariableDataProvider variableDataProvider)
            {
                ProcessVariableData(variableDataProvider, quoteInfo, fecTratamiento, tipMvtoBatch);
            }

            // Procesar coberturas (común para todos)
            ProcessCoverages(quoteInfo, fecTratamiento, tipMvtoBatch);

            return DataAccess.Variaciones.VariacionIssue.Issue(
                quoteInfo.cod_cia, quoteInfo.num_poliza, fecTratamiento,
                tipMvtoBatch, "N", "N", quoteInfo.fec_efec);
        }

        private static void ProcessVariableData<T>(IVariableDataProvider variableDataProvider,
            T quoteInfo, DateTime fecTratamiento, string tipMvtoBatch) where T : IVariacionData
        {
            List<Architect.API.Tron.Contracts.Poliza.DatoVariable> datosVariables =
                Architect.API.Tron.DataAccess.LeerPoliza.Lee_A2000020(1, quoteInfo.num_poliza, null, 0, 0);

            var variableData = variableDataProvider.GetVariableData();

            foreach (var item in variableData)
            {
                if (!string.IsNullOrEmpty(item.Value.val_campo))
                {
                    RegisterS2000020(datosVariables, fecTratamiento, item.Key, item.Value.val_campo, tipMvtoBatch);

                    if (item.Value.tiene_ocurrencia)
                    {
                        int num_riesgo = quoteInfo.Riesgos.FirstOrDefault().num_riesgo;
                        foreach ( OcurrenciaVariacion ocurr in item.Value.ocurrencias)
                        {
                            RegisterS2000025(quoteInfo, fecTratamiento, tipMvtoBatch, num_riesgo, ocurr.cod_campo, ocurr.val_campo, ocurr.index);
                        }
                    }
                }
            }
        }

        private static void ProcessCoverages<T>(T quoteInfo, DateTime fecTratamiento, string tipMvtoBatch)
            where T : IVariacionData
        {
            if (quoteInfo.NewCoverages?.Count > 0)
            {
                List<Architect.API.Tron.Contracts.Poliza.Cobertura> coberturas =
                    DataAccess.LeerPoliza.PP_Lee_A2000040_ZA(quoteInfo.cod_cia, quoteInfo.num_poliza, null);

                foreach (var item in quoteInfo.NewCoverages)
                {
                    ProcessSingleCoverage(item, coberturas, quoteInfo, fecTratamiento, tipMvtoBatch);
                }
            }
        }

        private static void ProcessSingleCoverage<T>(CoberturaVariacion item,
            List<Architect.API.Tron.Contracts.Poliza.Cobertura> coberturas,
            T quoteInfo, DateTime fecTratamiento, string tipMvtoBatch) where T : IVariacionData
        {
            bool existe = coberturas.Any(c => c.cod_cob == item.codigo);

            if (existe && item.mcaSeleccion == "*")
            {
                if (item.codigo != 1060 && item.codigo != 3010 && item.codigo != 3016) return;
            }
            if (!existe && item.mcaSeleccion == "X")
            {
                return;
            }

            // Procesamiento específico para código 3007 (Equipo especial)
            if (item.codigo == 3007 && quoteInfo is IVariableDataProvider variableProvider)
            {
                ProcessEquipoEspecial(variableProvider, quoteInfo, item, fecTratamiento, tipMvtoBatch);
            }

            CreateS2000040Record(item, quoteInfo, fecTratamiento, tipMvtoBatch);
        }

        private static void ProcessEquipoEspecial<T>(IVariableDataProvider variableProvider, T quoteInfo,
            CoberturaVariacion item, DateTime fecTratamiento, string tipMvtoBatch) where T : IVariacionData
        {
            var variableData = variableProvider.GetVariableData();
            if (variableData.TryGetValue("IMP_AUTO_EQESP", out ValDatoVariable impAutoEqesp))
            {
                if (double.TryParse(impAutoEqesp.val_campo, out double impValue))
                {
                    S2100610.Create(new s2100610
                    {
                        Fec_Tratamiento = fecTratamiento,
                        Tip_Mvto_Batch = tipMvtoBatch,
                        Cod_Cia = quoteInfo.cod_cia,
                        Num_Poliza = quoteInfo.num_poliza,
                        Num_Riesgo = item.riesgo,
                        Cod_Accesorio = 9999,
                        Mca_Seleccion = item.mcaSeleccion,
                        Txt_Accesorio = "GEN",
                        Imp_Accesorio = impValue,
                    });
                }
            }
        }

        private static void CreateS2000040Record<T>(CoberturaVariacion item, T quoteInfo,
            DateTime fecTratamiento, string tipMvtoBatch) where T : IVariacionData
        {
            var s2000040Instance = new s2000040
            {
                Fec_Tratamiento = fecTratamiento,
                Tip_Mvto_Batch = tipMvtoBatch,
                Cod_Cia = quoteInfo.cod_cia,
                Num_Poliza = quoteInfo.num_poliza,
                Num_Riesgo = item.riesgo,
                Cod_Cob = item.codigo,
                Mca_Seleccion = item.mcaSeleccion,
                Cod_Limite = null,
                Suma_Aseg = item.capital,
                Cod_Franquicia = null,
                Tasa_Cob = null
            };

            Architect.API.Tron.DataAccess.Variaciones.S2000040.Create(s2000040Instance);
        }

        private static VariacionIssueResult ProcessResult<T>(VariacionIssueResult result, T quoteInfo)
            where T : IVariacionData
        {
            int countError = ProcessErrorCount(result, quoteInfo.num_poliza, "Variacion");

            if (countError > 0)
            {
                result.McaError = "S";
            }
            else
            {
                result = GetCoverageAndReceipts(result, quoteInfo.cod_cia, quoteInfo.cod_ramo, quoteInfo.num_poliza);
                result.McaError = "N";
            }

            return result;
        }

        private static int ProcessErrorCount(VariacionIssueResult result, string numPoliza, string operation)
        {
            int countError = 0;
            if (result.ProcessResult?.Count > 0)
            {
                foreach (var item in result.ProcessResult)
                {
                    if (!string.IsNullOrEmpty(item.txt_error))
                    {
                        countError++;
                        Utilities.Log.ErrorLog($"{operation}: {numPoliza}", item.txt_error,
                            $"Variacion.{operation}.Generic");
                    }
                }
            }
            return countError;
        }

        private static VariacionIssueResult HandleException(Exception ex, string numPoliza, string operation)
        {
            var result = new VariacionIssueResult
            {
                McaError = "S",
                ProcessResult = new List<VariacionIssueProcessResult>
                {
                    new VariacionIssueProcessResult
                    {
                        num_poliza = numPoliza,
                        txt_error = ex.Message
                    }
                }
            };

            Utilities.Log.ErrorLog($"{operation}: {numPoliza}", ex.Message, $"Variacion.{operation}.Generic");
            return result;
        }

        private static VariacionIssueResult HandleAuthorizationException(Exception ex, string numPoliza)
        {
            var result = new VariacionIssueResult
            {
                McaError = "S",
                ProcessResult = new List<VariacionIssueProcessResult>
                {
                    new VariacionIssueProcessResult
                    {
                        num_poliza = numPoliza,
                        txt_error = "Por favor intente nuevamente y en caso de persistir el problema contacte el personal de soporte"
                    }
                }
            };

            Utilities.Log.ErrorLog("Autorizacion-Rechazo CT: " + numPoliza, ex.Message,
                "Variacion.Autorizacion-Rechazo.Generic");
            return result;
        }

        #endregion

        #region Métodos Auxiliares


        private static void RegisterS2000025<T>(T quoteInfo, DateTime fec_tratamiento, string tip_mvto_batch, int num_riesgo, string cod_campo, string val_campo, int num_ocurrencia) where T : IVariacionData
        {
            Ocurrencia Ocurrencia = quoteInfo.Ocurrencias.Where(x => x.cod_campo == cod_campo && x.val_campo == val_campo).FirstOrDefault();

            if(Ocurrencia == null)
            {
                s2000025 result = new s2000025()
                {
                    Fec_Tratamiento = fec_tratamiento,
                    Tip_Mvto_Batch = tip_mvto_batch,
                    Cod_Cia = quoteInfo.cod_cia,
                    Num_Poliza = quoteInfo.num_poliza,
                    Num_Riesgo = num_riesgo,
                    Cod_Lista = 0,
                    Num_Ocurrencia = num_ocurrencia,
                    Cod_Campo = cod_campo,
                    Val_Campo = val_campo
                };

                switch (cod_campo)
                {
                    case "COD_TIP_BR":
                        result.Cod_Lista = 206;
                        break;
                    case "COD_TIP_MED_INC":
                        result.Cod_Lista = 200;
                        break;
                    case "COD_TIP_MED_BR":
                        result.Cod_Lista = 201;
                        break;
                    case "COD_TIP_MED_ROB":
                        result.Cod_Lista = 202;
                        break;
                    case "COD_TIP_MED_RDM":
                        result.Cod_Lista = 203;
                        break;

                };

                Architect.API.Tron.DataAccess.Variaciones.S2000025.Create(result);
            }

        }

        private static void RegisterS2000020(List<Contracts.Poliza.DatoVariable> datosVariables,
            DateTime fec_tratamiento, string cod_campo, string val_campo_nuevo, string tip_mvto_batch)
        {
            Contracts.Poliza.DatoVariable item = datosVariables.Find(d => d.cod_campo == cod_campo);
            Contracts.Variaciones.s2000020 dv;

            if (item != null)
            {
                if (item.val_campo.Trim() != val_campo_nuevo.Trim())
                {
                    dv = new Contracts.Variaciones.s2000020
                    {
                        Fec_Tratamiento = fec_tratamiento,
                        Tip_Mvto_Batch = tip_mvto_batch,
                        Cod_Cia = item.cod_cia,
                        Cod_Ramo = item.cod_ramo,
                        Num_Poliza = item.num_poliza,
                        Num_Riesgo = item.num_riesgo,
                        Cod_Campo = item.cod_campo,
                        Val_Campo_Actual = item.val_campo,
                        Val_Campo_Nuevo = val_campo_nuevo
                    };

                    Architect.API.Tron.DataAccess.Variaciones.S2000020.Create(dv);
                }
            }
            else
            {
                item = datosVariables.FirstOrDefault();

                if (item != null)
                {
                    dv = new Contracts.Variaciones.s2000020
                    {
                        Fec_Tratamiento = fec_tratamiento,
                        Tip_Mvto_Batch = tip_mvto_batch,
                        Cod_Cia = item.cod_cia,
                        Cod_Ramo = item.cod_ramo,
                        Num_Poliza = item.num_poliza,
                        Num_Riesgo = item.num_riesgo,
                        Cod_Campo = cod_campo,
                        Val_Campo_Actual = string.Empty,
                        Val_Campo_Nuevo = val_campo_nuevo
                    };

                    Architect.API.Tron.DataAccess.Variaciones.S2000020.Create(dv);
                }
            }
        }

        private static VariacionIssueResult GetCoverageAndReceipts(VariacionIssueResult result,
            int cod_cia, int cod_ramo, string num_poliza)
        {
            List<Architect.API.Tron.Contracts.Poliza.Cobertura> coberturas =
                DataAccess.LeerPoliza.PP_Lee_A2000040_ZA(cod_cia, num_poliza, null);
            List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado> recibos =
                Architect.API.Tron.DataAccess.LeerPoliza.PP_Lee_A2990700_Result_ZA(cod_cia, num_poliza, null, 0, 0, null);

            var AvailableCoverages = MapfreMasConvertFrom.getAvailableCoverages(cod_cia, cod_ramo, 0);

            foreach (var item in coberturas)
            {
                var obj = AvailableCoverages.FirstOrDefault(c => c.codigo == item.cod_cob);

                result.coberturas.Add(new Contracts.Comun.Cobertura
                {
                    seleccionado = obj?.seleccionado ?? false,
                    requerida = obj?.mcaObligatorio == "S",
                    codigo = item.cod_cob,
                    nombre = item.nom_cob,
                    capital = item.suma_aseg,
                    primatotal = item.imp_total,
                    deducible = item.deducible,
                    riesgo = item.num_riesgo
                });
            }

            foreach (var item in recibos)
            {
                result.plandepago.Add(new Contracts.Comun.PlanDePago
                {
                    recibo = item.NUM_RECIBO,
                    cuota = item.NUM_CUOTA,
                    numspto = item.NUM_SPTO,
                    tipsituacion = item.TIP_SITUACION,
                    fechadesde = item.FEC_EFEC_RECIBO,
                    fechahasta = item.FEC_VCTO_RECIBO,
                    primaneta = item.IMP_NETA,
                    iVA = item.IMP_IMPTOS,
                    recargoporfraccionamiento = item.IMP_INTERES,
                    importetotal = item.IMP_RECIBO
                });
            }

            result.plandepagoresumen = Architect.API.Tron.DataAccess.Variaciones.VariacionIssue.GetPlanPagosResumen(
                cod_cia, num_poliza, null, null, null);

            return result;
        }

        #endregion

    }
}
