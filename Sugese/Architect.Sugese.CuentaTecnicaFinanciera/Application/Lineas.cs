using Architect.Sugese.CuentaTecnicaFinanciera.Domain;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.CuentaTecnicaFinanciera.Application
{
    internal static class Lineas
    {

        internal static List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera> Builder(DataTable response, XLWorkbook workbook, List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera> resultadoCuentaTecnicoFinanciera)
        {
            IXLWorksheet sheet = workbook.Worksheet(3);
            string value = string.Empty;
            Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera cuentaTecnicoFinanciera;

            for (int rowNumber = 6; rowNumber < 10000; rowNumber++)
            {
                value = sheet.Cell(rowNumber, 1).Value.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    TipoRamo ramoActual = sheet.EnumValue<TipoRamo>(rowNumber, "A", response);

                    Linea linea = sheet.EnumValue<Linea>(rowNumber, "B", response);

                    cuentaTecnicoFinanciera = Generate.FindOrAddByRamo(ramoActual, resultadoCuentaTecnicoFinanciera);

                    if (cuentaTecnicoFinanciera.Lineas == null)
                    {
                        cuentaTecnicoFinanciera.Lineas = new List<ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea>();
                    }

                    ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea
                        item = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea()
                        {
                            idLinea = linea,
                            ResultadoCuentaTecnicoFinanciera_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_ln()
                            {

                            }
                        };
                    cuentaTecnicoFinanciera.Lineas.Add(item);
                    ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_ln
                    resultadoServicioSeguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_ln()
                    {
                        IngresosPorContratosSeguroNetosReaseguro_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_ln()
                        {
                            IngresosPorContratosSeguro_ln = Build_IngresosPorContratosSeguro_ln(response, sheet, rowNumber),
                            GastosPorContratosReaseguro_ln = Build_GastosPorContratosReaseguro_ln(response, sheet, rowNumber)
                        }
                    };

                    resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro_ln.TotalIngresosPorContratosSeguroNetosReaseguro_ln =
                        resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro_ln.IngresosPorContratosSeguro_ln.TotalIngresosPorContratosSeguro_ln -
                        resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro_ln.GastosPorContratosReaseguro_ln.TotalGastosPorContratosReaseguro_ln;

                    resultadoServicioSeguro.GastosPorSiniestralidadNetosReaseguro_ln = Build_GastosPorSiniestralidadNetosReaseguro_ln(response, sheet, rowNumber);
                    resultadoServicioSeguro.OtrosGastosOperativosAdminisYAdquisicion_ln = Build_OtrosGastosOperativosAdminisYAdquisicion_ln(response, sheet, rowNumber);
                    resultadoServicioSeguro.ProvisionRiesgoCatastrofico_ln = sheet.DecimalValue(rowNumber, "Y", response);

                    resultadoServicioSeguro.TotalResultadoServicioSeguro_ln =
                        resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro_ln.TotalIngresosPorContratosSeguroNetosReaseguro_ln -
                        resultadoServicioSeguro.GastosPorSiniestralidadNetosReaseguro_ln.TotalGastosPorSiniestralidadNetosReaseguro_ln -
                        resultadoServicioSeguro.OtrosGastosOperativosAdminisYAdquisicion_ln.TotalOtrosGastosOperativosAdminisYAdquisicion_ln -
                        resultadoServicioSeguro.ProvisionRiesgoCatastrofico_ln;


                    //cuentaTecnicoFinanciera.TotalCuentaTecnicoFinanciera += resultadoServicioSeguro.TotalResultadoServicioSeguro_ln;

                    item.ResultadoCuentaTecnicoFinanciera_ln.ResultadoServicioSeguro_ln = resultadoServicioSeguro;

                    item.ResultadoCuentaTecnicoFinanciera_ln.ResultadoFinancieroNeto_ln = Build_resultadoFinancieroNeto_ln(response, sheet, rowNumber);

                    item.ResultadoCuentaTecnicoFinanciera_ln.TotalCuentaTecnicoFinanciera_ln =
                        item.ResultadoCuentaTecnicoFinanciera_ln.ResultadoServicioSeguro_ln.TotalResultadoServicioSeguro_ln +
                        item.ResultadoCuentaTecnicoFinanciera_ln.ResultadoFinancieroNeto_ln.TotalResultadoFinancieroNeto_ln;
                }
                else
                {
                    break;
                }
            }

            return resultadoCuentaTecnicoFinanciera;
        }


        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_ln Build_IngresosPorContratosSeguro_ln(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_ln
                ingresosPorContratosSeguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_ln()
                {
                    MargenServicioContractual_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_lnMargenServicioContractual_ln()
                    {
                        DesgloseMargenServicioContractual_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_lnMargenServicioContractual_lnDesgloseMargenServicioContractual_ln()
                        {
                            SeguroDirecto_ln = sheet.DecimalValue(rowNumber, "C", response),
                            ReaseguroAceptado_ln = sheet.DecimalValue(rowNumber, "D", response)
                        }
                    },
                    CambiosAjustePorRiesgoEstimaciones_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_lnCambiosAjustePorRiesgoEstimaciones_ln()
                    {
                        DesgloseCambiosAjustePorRiesgoEstimaciones_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_lnCambiosAjustePorRiesgoEstimaciones_lnDesgloseCambiosAjustePorRiesgoEstimaciones_ln()
                        {
                            SeguroDirecto_ln = sheet.DecimalValue(rowNumber, "E", response),
                            ReaseguroAceptado_ln = sheet.DecimalValue(rowNumber, "F", response)
                        }
                    },
                    PrimaGanada_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_lnPrimaGanada_ln()
                    {
                        DesglosePrimaGanada_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnIngresosPorContratosSeguro_lnPrimaGanada_lnDesglosePrimaGanada_ln()
                        {
                            SeguroDirecto_ln = sheet.DecimalValue(rowNumber, "G", response),
                            ReaseguroAceptado_ln = sheet.DecimalValue(rowNumber, "H", response)
                        }
                    }
                };


            ingresosPorContratosSeguro.MargenServicioContractual_ln.TotalMargenServicioContractual_ln =
                ingresosPorContratosSeguro.MargenServicioContractual_ln.DesgloseMargenServicioContractual_ln.SeguroDirecto_ln +
                ingresosPorContratosSeguro.MargenServicioContractual_ln.DesgloseMargenServicioContractual_ln.ReaseguroAceptado_ln;

            ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones_ln.TotalCambiosAjustePorRiesgoEstimaciones_ln =
                ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones_ln.DesgloseCambiosAjustePorRiesgoEstimaciones_ln.SeguroDirecto_ln +
                ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones_ln.DesgloseCambiosAjustePorRiesgoEstimaciones_ln.ReaseguroAceptado_ln;

            ingresosPorContratosSeguro.PrimaGanada_ln.TotalPrimaGanada_ln =
                ingresosPorContratosSeguro.PrimaGanada_ln.DesglosePrimaGanada_ln.SeguroDirecto_ln +
                ingresosPorContratosSeguro.PrimaGanada_ln.DesglosePrimaGanada_ln.ReaseguroAceptado_ln;

            ingresosPorContratosSeguro.TotalIngresosPorContratosSeguro_ln =
                ingresosPorContratosSeguro.MargenServicioContractual_ln.TotalMargenServicioContractual_ln +
                ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones_ln.TotalCambiosAjustePorRiesgoEstimaciones_ln +
                ingresosPorContratosSeguro.PrimaGanada_ln.TotalPrimaGanada_ln;

            return ingresosPorContratosSeguro;
        }

        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnGastosPorContratosReaseguro_ln Build_GastosPorContratosReaseguro_ln(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnGastosPorContratosReaseguro_ln
                gastosPorContratosReaseguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnGastosPorContratosReaseguro_ln()
                {
                    DesgloseGastosPorContratosReaseguro_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnIngresosPorContratosSeguroNetosReaseguro_lnGastosPorContratosReaseguro_lnDesgloseGastosPorContratosReaseguro_ln()
                    {
                        CostosContratoReaseguro_ln = sheet.DecimalValue(rowNumber, "I", response),
                        CostoNetoServicioReaseguro_ln = sheet.DecimalValue(rowNumber, "J", response),
                        CambiosAjustePorRiesgoNoFinancieroYEstimaciones_ln = sheet.DecimalValue(rowNumber, "K", response)
                    }
                };

            gastosPorContratosReaseguro.TotalGastosPorContratosReaseguro_ln =
                gastosPorContratosReaseguro.DesgloseGastosPorContratosReaseguro_ln.CostosContratoReaseguro_ln +
                gastosPorContratosReaseguro.DesgloseGastosPorContratosReaseguro_ln.CostoNetoServicioReaseguro_ln +
                gastosPorContratosReaseguro.DesgloseGastosPorContratosReaseguro_ln.CambiosAjustePorRiesgoNoFinancieroYEstimaciones_ln;

            return gastosPorContratosReaseguro;
        }

        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_ln Build_GastosPorSiniestralidadNetosReaseguro_ln(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_ln
                gastosPorSiniestralidadNetosReaseguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_ln()
                {
                    GastosPorSiniestralidadSeguro_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_lnGastosPorSiniestralidadSeguro_ln()
                    {
                        GastosPorSiniestros_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_lnGastosPorSiniestralidadSeguro_lnGastosPorSiniestros_ln()
                        {
                            DesgloseGastosPorSiniestros_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_lnGastosPorSiniestralidadSeguro_lnGastosPorSiniestros_lnDesgloseGastosPorSiniestros_ln()
                            {
                                ContratosOnerosos_ln = sheet.DecimalValue(rowNumber, "L", response),
                                ContratosNoOnerosos_ln = sheet.DecimalValue(rowNumber, "M", response),
                                ImputablesSiniestros_ln = sheet.DecimalValue(rowNumber, "N", response)
                            }
                        },
                        PerdidasContratosOnerosos_ln = sheet.DecimalValue(rowNumber, "O", response)
                    },
                    IngresosPorRecupSiniestralidadDeContratosReaseguro_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_lnIngresosPorRecupSiniestralidadDeContratosReaseguro_ln()
                    {
                        RecuperacionesYComisionesRelacionadasConSiniestralidad_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_lnIngresosPorRecupSiniestralidadDeContratosReaseguro_lnRecuperacionesYComisionesRelacionadasConSiniestralidad_ln()
                        {
                            DesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnGastosPorSiniestralidadNetosReaseguro_lnIngresosPorRecupSiniestralidadDeContratosReaseguro_lnRecuperacionesYComisionesRelacionadasConSiniestralidad_lnDesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad_ln()
                            {
                                ComisionesReaseguroCedidoRelacSiniestralidad_ln = sheet.DecimalValue(rowNumber, "P", response),
                                RecuperacionesSiniestros_ln = sheet.DecimalValue(rowNumber, "Q", response)
                            }
                        },
                        CambiosAjustePorRiesgoNoFinancieroYEstimaciones_ln = sheet.DecimalValue(rowNumber, "R", response),
                        GananciaNetaServicioReaseguro_ln = sheet.DecimalValue(rowNumber, "S", response)
                    }
                };
            gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.GastosPorSiniestros_ln.TotalGastosPorSiniestros_ln =
               gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.GastosPorSiniestros_ln.DesgloseGastosPorSiniestros_ln.ContratosOnerosos_ln +
               gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.GastosPorSiniestros_ln.DesgloseGastosPorSiniestros_ln.ContratosNoOnerosos_ln +
               gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.GastosPorSiniestros_ln.DesgloseGastosPorSiniestros_ln.ImputablesSiniestros_ln;

            gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.TotalGastosPorSiniestralidadSeguro_ln =
                gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.GastosPorSiniestros_ln.TotalGastosPorSiniestros_ln +
                gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.PerdidasContratosOnerosos_ln;



            gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.RecuperacionesYComisionesRelacionadasConSiniestralidad_ln.TotalRecuperacionesYComisionesRelacionadasConSiniestralidad_ln =
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.RecuperacionesYComisionesRelacionadasConSiniestralidad_ln.DesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad_ln.ComisionesReaseguroCedidoRelacSiniestralidad_ln +
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.RecuperacionesYComisionesRelacionadasConSiniestralidad_ln.DesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad_ln.RecuperacionesSiniestros_ln;

            gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.TotalIngresosPorRecupSiniestralidadDeContratosReaseguro_ln =
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.RecuperacionesYComisionesRelacionadasConSiniestralidad_ln.TotalRecuperacionesYComisionesRelacionadasConSiniestralidad_ln +
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.CambiosAjustePorRiesgoNoFinancieroYEstimaciones_ln +
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.GananciaNetaServicioReaseguro_ln;



            gastosPorSiniestralidadNetosReaseguro.TotalGastosPorSiniestralidadNetosReaseguro_ln =
                gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro_ln.TotalGastosPorSiniestralidadSeguro_ln -
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro_ln.TotalIngresosPorRecupSiniestralidadDeContratosReaseguro_ln;
            return gastosPorSiniestralidadNetosReaseguro;
        }

        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnOtrosGastosOperativosAdminisYAdquisicion_ln Build_OtrosGastosOperativosAdminisYAdquisicion_ln(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnOtrosGastosOperativosAdminisYAdquisicion_ln
                otrosGastosOperativosAdminisYAdquisicion = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnOtrosGastosOperativosAdminisYAdquisicion_ln()
                {
                    DesgloseOtrosGastosOperativosAdminisYAdquisicion_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoServicioSeguro_lnOtrosGastosOperativosAdminisYAdquisicion_lnDesgloseOtrosGastosOperativosAdminisYAdquisicion_ln()
                    {
                        GastosAdquisicionPorContratosSeguro_ln = sheet.DecimalValue(rowNumber, "T", response),
                        GastosAdquisicionPorContratosReaseguro_ln = sheet.DecimalValue(rowNumber, "U", response),
                        OtrosGastosRelacionadosConServicioSeguro_ln = sheet.DecimalValue(rowNumber, "V", response),
                        OtrosGastosRelacionadosConServicioReaseguro_ln = sheet.DecimalValue(rowNumber, "W", response),
                        ComisionesPorReaseguroCedidoNoRelacionadasConSiniestralidad_ln = sheet.DecimalValue(rowNumber, "X", response)
                    }
                };
            otrosGastosOperativosAdminisYAdquisicion.TotalOtrosGastosOperativosAdminisYAdquisicion_ln =
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion_ln.GastosAdquisicionPorContratosSeguro_ln +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion_ln.GastosAdquisicionPorContratosReaseguro_ln +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion_ln.OtrosGastosRelacionadosConServicioSeguro_ln +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion_ln.OtrosGastosRelacionadosConServicioReaseguro_ln +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion_ln.ComisionesPorReaseguroCedidoNoRelacionadasConSiniestralidad_ln;

            return otrosGastosOperativosAdminisYAdquisicion;
        }

        internal static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoFinancieroNeto_ln Build_resultadoFinancieroNeto_ln(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoFinancieroNeto_ln
                resultadoFinancieroNeto = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoFinancieroNeto_ln()
                {
                    RetornoInversion_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoFinancieroNeto_lnRetornoInversion_ln()
                    {
                        DesgloseRetornoInversion_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoFinancieroNeto_lnRetornoInversion_lnDesgloseRetornoInversion_ln()
                        {
                            IngresoPorInteresesActivosFinancieros_ln = sheet.DecimalValue(rowNumber, "Z", response),
                            OtrosIngresosPorInversiones_ln = sheet.DecimalValue(rowNumber, "AA", response),
                            PerdidaNetaPorDeterioroActivosFinancieros_ln = sheet.DecimalValue(rowNumber, "AB", response)
                        }
                    },

                    IngresosPorContratosSegurosYContratosInversion_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoFinancieroNeto_lnIngresosPorContratosSegurosYContratosInversion_ln()
                    {
                        DesgloseIngresosPorContratosSegurosYContratosInversion_ln = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoFinancieroNeto_lnIngresosPorContratosSegurosYContratosInversion_lnDesgloseIngresosPorContratosSegurosYContratosInversion_ln()
                        {
                            IngresosYGastosFinancierosNetosContratosSeguros_ln = sheet.DecimalValue(rowNumber, "AC", response),
                            IngresosYGastosFinancierosNetosContratosReaseguros_ln = sheet.DecimalValue(rowNumber, "AD", response),
                            MovimientoEnPasivosPorContratosInversion_ln = sheet.DecimalValue(rowNumber, "AE", response)
                        }
                    }
                };

            resultadoFinancieroNeto.RetornoInversion_ln.TotalRetornoInversion_ln =
                resultadoFinancieroNeto.RetornoInversion_ln.DesgloseRetornoInversion_ln.IngresoPorInteresesActivosFinancieros_ln +
                resultadoFinancieroNeto.RetornoInversion_ln.DesgloseRetornoInversion_ln.OtrosIngresosPorInversiones_ln +
                resultadoFinancieroNeto.RetornoInversion_ln.DesgloseRetornoInversion_ln.PerdidaNetaPorDeterioroActivosFinancieros_ln;

            resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion_ln.TotalIngresosPorContratosSegurosYContratosInversion_ln =
                resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion_ln.DesgloseIngresosPorContratosSegurosYContratosInversion_ln.IngresosYGastosFinancierosNetosContratosSeguros_ln +
                resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion_ln.DesgloseIngresosPorContratosSegurosYContratosInversion_ln.IngresosYGastosFinancierosNetosContratosReaseguros_ln +
                resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion_ln.DesgloseIngresosPorContratosSegurosYContratosInversion_ln.MovimientoEnPasivosPorContratosInversion_ln;


            resultadoFinancieroNeto.TotalResultadoFinancieroNeto_ln =
                resultadoFinancieroNeto.RetornoInversion_ln.TotalRetornoInversion_ln +
                resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion_ln.TotalIngresosPorContratosSegurosYContratosInversion_ln;


            return resultadoFinancieroNeto;
        }

    }
}
