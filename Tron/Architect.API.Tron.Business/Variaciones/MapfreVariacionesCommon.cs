using Architect.API.Tron.Contracts.Variaciones;
using Architect.API.Tron.DataAccess.Variaciones;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Variaciones
{
    public static class MapfreVariacionesCommon
    {
        public static VariacionIssueResult Issue(Contracts.Variaciones.MapfreMasPlus quoteInfo)
        {
            VariacionIssueResult result = null;
            bool existeDeducibleEqipoEsp = false;
            bool existeImpoEqipoEsp = false;

            try
            {
                quoteInfo.NUM_MATRICULA = Regex.Replace(quoteInfo.NUM_MATRICULA, @"[^a-zA-Z0-9]", String.Empty);

                DateTime Fec_Tratamiento = DateTime.Today;
                string Tip_mvto_batch = "4";

                VariacionIssue.DeleteTablesS(Fec_Tratamiento, Tip_mvto_batch, quoteInfo.cod_cia, quoteInfo.num_poliza);

                Architect.API.Tron.Contracts.Poliza.DatoFijo a2000030Instance = Architect.API.Tron.DataAccess.LeerPoliza.Lee_A2000030(quoteInfo.cod_cia, quoteInfo.num_poliza, null, 0, 0);

                if (a2000030Instance.cod_fracc_pago != quoteInfo.cod_fracc_pago)
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

                    //result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "N", "S", quoteInfo.MCA_FEC_EFEC_SYS);
                    //result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "N", "S", "N");
                    result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "N", "S", quoteInfo.fec_efec);
                }
                else
                {
                    List<Architect.API.Tron.Contracts.Poliza.DatoVariable> DatosVariables = Architect.API.Tron.DataAccess.LeerPoliza.Lee_A2000020(1, quoteInfo.num_poliza, null, 0, 0);

                    List<Architect.API.Tron.Contracts.Variaciones.s2000020> a2000020InstanceList = new List<Contracts.Variaciones.s2000020>();

                    //RegisterS2000020(DatosVariables, Fec_Tratamiento, "COD_COLOR", quoteInfo.COD_COLOR.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "NUM_MATRICULA", quoteInfo.NUM_MATRICULA, Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_RC", quoteInfo.IMP_AUTO_RC.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_GMO", quoteInfo.IMP_AUTO_GMO.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_ACO", quoteInfo.IMP_AUTO_ACO.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_CYV", quoteInfo.IMP_AUTO_CYV.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_VR", quoteInfo.IMP_VR.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_PRA", quoteInfo.IMP_VR.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_CRI", quoteInfo.IMP_AUTO_CRI.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "DED_AUTO_CRI", quoteInfo.DED_AUTO_CRI.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_RAD", quoteInfo.IMP_AUTO_RAD.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_ROB", quoteInfo.IMP_AUTO_ROB.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "DED_AUTO_RC", quoteInfo.DED_AUTO_RC.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "DED_AUTO_ROB", quoteInfo.DED_AUTO_ROB.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "DED_AUTO_CYV", quoteInfo.DED_AUTO_CYV.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "DED_AUTO_RAD", quoteInfo.DED_AUTO_RAD.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "IMP_AUTO_EQESP", quoteInfo.IMP_AUTO_EQESP.ToString(), Tip_mvto_batch);
                    RegisterS2000020(DatosVariables, Fec_Tratamiento, "DED_AUTO_EQESP", quoteInfo.DED_AUTO_EQESP.ToString(), Tip_mvto_batch);

                    if (quoteInfo.NewCoverages?.Count > 0)
                    {
                        List<Architect.API.Tron.Contracts.Poliza.Cobertura> coberturas = DataAccess.LeerPoliza.PP_Lee_A2000040_ZA(quoteInfo.cod_cia, quoteInfo.num_poliza, null);

                        Architect.API.Tron.Contracts.Variaciones.s2000040 s2000040Instance = new Contracts.Variaciones.s2000040();

                        foreach (var item in quoteInfo.NewCoverages)
                        {
                            bool existe = coberturas.Any(c => c.cod_cob == item.codigo);

                            if (existe && item.mcaSeleccion == "*")
                            {
                                if (item.codigo != 1060 && item.codigo != 3010 && item.codigo != 3016) continue;
                            }
                            if (!existe && item.mcaSeleccion == "X")
                            {
                                continue;
                            }

                            if (item.codigo == 3007)
                            {
                                S2100610.Create(new s2100610
                                {
                                    Fec_Tratamiento = Fec_Tratamiento,
                                    Tip_Mvto_Batch = Tip_mvto_batch,
                                    Cod_Cia = quoteInfo.cod_cia,
                                    Num_Poliza = quoteInfo.num_poliza,
                                    Num_Riesgo = item.riesgo,
                                    Cod_Accesorio = 9999,
                                    Mca_Seleccion = item.mcaSeleccion,
                                    Txt_Accesorio = "GEN",
                                    Imp_Accesorio = quoteInfo.IMP_AUTO_EQESP,
                                });
                            }

                            s2000040Instance = new s2000040
                            {
                                Fec_Tratamiento = Fec_Tratamiento,
                                Tip_Mvto_Batch = Tip_mvto_batch,
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

                    }

                    //result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "N", "N", quoteInfo.MCA_FEC_EFEC_SYS);
                    //result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "N", "N", "N");
                    result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "N", "N", quoteInfo.fec_efec);
                }

                int countError = 0;
                if (result.ProcessResult?.Count > 0)
                {
                    foreach (var item in result.ProcessResult)
                    {
                        if (!string.IsNullOrEmpty(item.txt_error))
                        {
                            countError = countError + 1;
                            Utilities.Log.ErrorLog("Variacion: " + quoteInfo.num_poliza, item.txt_error, "Variacion.Issue.MapfreMas");
                        }
                    }
                }

                if (countError > 0)
                {
                    result.McaError = "S";
                }
                else
                {
                    result = GetCoverageAndReceipts(result, quoteInfo.cod_cia, quoteInfo.cod_ramo, quoteInfo.num_poliza);
                    result.McaError = "N";
                }
            }
            catch (Exception ex)
            {
                result.McaError = "S";
                result.ProcessResult.Add(new VariacionIssueProcessResult
                {
                    num_poliza = quoteInfo.num_poliza,
                    txt_error = ex.Message
                });
                Utilities.Log.ErrorLog("Cancelacion: " + quoteInfo.num_poliza, ex.Message, "Variacion.Cancelation.MapfreMas");
            }
            return result;
        }

        private static void RegisterS2000020(List<Contracts.Poliza.DatoVariable> datosVariables, DateTime fec_tratamiento, string cod_campo, string val_campo_nuevo, string tip_mvto_batch)
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
                item = datosVariables.First();

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

        //public static VariacionIssueResult Cancelation(Contracts.Variaciones.MapfreMas quoteInfo)
        public static VariacionIssueResult Cancelation(int cod_cia, int cod_ramo, string num_poliza, DateTime fec_efec_cancel, string txt_motivo)
        {
            DateTime Fec_Tratamiento = DateTime.Today;
            string Tip_mvto_batch = "4";
            VariacionIssueResult result = null;

            try
            {
                //result = DataAccess.Variaciones.VariacionIssue.Issue(quoteInfo.cod_cia, quoteInfo.num_poliza, Fec_Tratamiento, Tip_mvto_batch, "S", "N", quoteInfo.MCA_FEC_EFEC_SYS);
                //result = DataAccess.Variaciones.VariacionIssue.Issue(cod_cia, num_poliza, Fec_Tratamiento, Tip_mvto_batch, "S", "N", "N", fec_efec_cancel, txt_motivo);
                result = DataAccess.Variaciones.VariacionIssue.Issue(cod_cia, num_poliza, Fec_Tratamiento, Tip_mvto_batch, "S", "N", fec_efec_cancel, txt_motivo);

                int countError = 0;
                if (result.ProcessResult?.Count > 0)
                {
                    foreach (var item in result.ProcessResult)
                    {
                        if (!string.IsNullOrEmpty(item.txt_error))
                        {
                            countError = countError + 1;
                            Utilities.Log.ErrorLog("Cancelation: " + num_poliza, item.txt_error, "Variacion.Cancelation.MapfreMas");
                        }
                    }
                }
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
                result.McaError = "S";
                result.ProcessResult.Add(new VariacionIssueProcessResult
                {
                    num_poliza = num_poliza,
                    txt_error = ex.Message
                });
                Utilities.Log.ErrorLog("Cancelacion: " + num_poliza, ex.Message, "Variacion.Cancelation.MapfreMas");
            }

            return result;
        }

        public static VariacionIssueResult ManageAuthorizationCT(int cod_cia, int cod_ramo, string num_poliza, int num_spto, string mca_autoriza)
        {
            VariacionIssueResult result = new VariacionIssueResult();
            (int, string) resultCT = (0, string.Empty);
            string observacion;

            try
            {
                observacion = (mca_autoriza.Equals("S")) ? "Autorizacion CT - ZA" : "Rechazo CT - ZA";
                resultCT = DataAccess.Variaciones.VariacionIssue.ManageAuthorizationCT(cod_ramo, num_poliza, observacion, mca_autoriza, 4004);

                if (resultCT.Item1.Equals(1))
                {
                    result.McaError = "S";
                    result.ProcessResult.Add(new VariacionIssueProcessResult
                    {
                        num_poliza = num_poliza,
                        txt_error = resultCT.Item2
                    });
                    Utilities.Log.ErrorLog("Autorizacion-Rechazo CT: " + num_poliza, resultCT.Item2, "Variacion.Autorizacion-Rechazo.MapfreMas");
                }
                else
                {
                    result = GetCoverageAndReceipts(result, cod_cia, cod_ramo, num_poliza);
                    result.Recibos = DataAccess.Variaciones.VariacionIssue.GetRecibos(cod_cia, num_poliza, null);

                    result.McaError = "N";
                    result.ProcessResult.Add(new VariacionIssueProcessResult
                    {
                        num_poliza = num_poliza,
                        txt_error = (!string.IsNullOrEmpty(resultCT.Item2)) ? resultCT.Item2 : "Se autorizó correctamente el CT"
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
                Utilities.Log.ErrorLog("Autorizacion-Rechazo CT: " + num_poliza, ex.Message, "Variacion.Autorizacion-Rechazo.MapfreMas");
            }

            return result;
        }

        private static VariacionIssueResult GetCoverageAndReceipts(VariacionIssueResult result, int cod_cia, int cod_ramo, string num_poliza)
        {
            List<Architect.API.Tron.Contracts.Poliza.Cobertura> coberturas = DataAccess.LeerPoliza.PP_Lee_A2000040_ZA(cod_cia, num_poliza, null);
            List<Architect.API.Tron.Contracts.Poliza.ReciboCalculado> recibos = Architect.API.Tron.DataAccess.LeerPoliza.PP_Lee_A2990700_Result_ZA(cod_cia, num_poliza, null, 0, 0, null);

            var AvailableCoverages = MapfreMasConvertFrom.getAvailableCoverages(cod_cia, cod_ramo, 0);

            foreach (var item in coberturas)
            {
                var obj = AvailableCoverages.FirstOrDefault(c => c.codigo == item.cod_cob);

                result.coberturas.Add(new Contracts.Comun.Cobertura
                {
                    seleccionado = obj.seleccionado,
                    requerida = obj.mcaObligatorio == "S",
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

            result.plandepagoresumen = Architect.API.Tron.DataAccess.Variaciones.VariacionIssue.GetPlanPagosResumen(cod_cia, num_poliza, null, null, null);

            return result;
        }

    }
}
