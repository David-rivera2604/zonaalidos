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
    internal static class ServicioSeguro
    {

        internal static List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera> Builder(DataTable response, XLWorkbook workbook, List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera> resultadoCuentaTecnicoFinanciera)
        {
            IXLWorksheet sheet = workbook.Worksheet(1);
            string value = string.Empty;
            Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera cuentaTecnicoFinanciera;

            for (int rowNumber = 6; rowNumber < 10000; rowNumber++)
            {
                value = sheet.Cell(rowNumber, 1).Value.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    TipoRamo ramoActual = sheet.EnumValue<TipoRamo>(rowNumber, "A", response);

                    cuentaTecnicoFinanciera = Generate.FindOrAddByRamo(ramoActual, resultadoCuentaTecnicoFinanciera);

                    ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguro resultadoServicioSeguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguro();
                    cuentaTecnicoFinanciera.ResultadoServicioSeguro = resultadoServicioSeguro;
                    resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguro()
                    {
                        IngresosPorContratosSeguro = Build_IngresosPorContratosSeguro(response, sheet, rowNumber, resultadoServicioSeguro),
                        GastosPorContratosReaseguro = Build_GastosPorContratosReaseguro(response, sheet, rowNumber, resultadoServicioSeguro)
                    };
                    resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro.TotalIngresosPorContratosSeguroNetosReaseguro =
                        resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro.IngresosPorContratosSeguro.TotalIngresosPorContratosSeguro -
                        resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro.GastosPorContratosReaseguro.TotalGastosPorContratosReaseguro;

                    resultadoServicioSeguro.GastosPorSiniestralidadNetosReaseguro = Build_GastosPorSiniestralidadNetosReaseguro(response, sheet, rowNumber);
                    resultadoServicioSeguro.OtrosGastosOperativosAdminisYAdquisicion = Build_OtrosGastosOperativosAdminisYAdquisicion(response, sheet, rowNumber);
                    resultadoServicioSeguro.ProvisionRiesgoCatastrofico = sheet.DecimalValue(rowNumber, "X", response);

                    resultadoServicioSeguro.TotalResultadoServicioSeguro =
                        resultadoServicioSeguro.IngresosPorContratosSeguroNetosReaseguro.TotalIngresosPorContratosSeguroNetosReaseguro -
                        resultadoServicioSeguro.GastosPorSiniestralidadNetosReaseguro.TotalGastosPorSiniestralidadNetosReaseguro -
                        resultadoServicioSeguro.OtrosGastosOperativosAdminisYAdquisicion.TotalOtrosGastosOperativosAdminisYAdquisicion -
                        resultadoServicioSeguro.ProvisionRiesgoCatastrofico;


                    cuentaTecnicoFinanciera.TotalCuentaTecnicoFinanciera += resultadoServicioSeguro.TotalResultadoServicioSeguro;

                }
                else
                {
                    break;
                }

            }

            return resultadoCuentaTecnicoFinanciera;
        }

        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroOtrosGastosOperativosAdminisYAdquisicion Build_OtrosGastosOperativosAdminisYAdquisicion(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroOtrosGastosOperativosAdminisYAdquisicion
                otrosGastosOperativosAdminisYAdquisicion = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroOtrosGastosOperativosAdminisYAdquisicion()
                {
                    DesgloseOtrosGastosOperativosAdminisYAdquisicion = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroOtrosGastosOperativosAdminisYAdquisicionDesgloseOtrosGastosOperativosAdminisYAdquisicion()
                    {
                        GastosAdquisicionPorContratosSeguro = sheet.DecimalValue(rowNumber, "S", response),
                        GastosAdquisicionPorContratosReaseguro = sheet.DecimalValue(rowNumber, "T", response),
                        OtrosGastosRelacionadosConServicioSeguro = sheet.DecimalValue(rowNumber, "U", response),
                        OtrosGastosRelacionadosConServicioReaseguro = sheet.DecimalValue(rowNumber, "V", response),
                        ComisionesPorReaseguroCedidoNoRelacionadasConSiniestralidad = sheet.DecimalValue(rowNumber, "W", response)
                    }
                };
            otrosGastosOperativosAdminisYAdquisicion.TotalOtrosGastosOperativosAdminisYAdquisicion =
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion.GastosAdquisicionPorContratosSeguro +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion.GastosAdquisicionPorContratosReaseguro +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion.OtrosGastosRelacionadosConServicioSeguro +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion.OtrosGastosRelacionadosConServicioReaseguro +
                otrosGastosOperativosAdminisYAdquisicion.DesgloseOtrosGastosOperativosAdminisYAdquisicion.ComisionesPorReaseguroCedidoNoRelacionadasConSiniestralidad;

            return otrosGastosOperativosAdminisYAdquisicion;
        }

        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguro Build_GastosPorSiniestralidadNetosReaseguro(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguro
                gastosPorSiniestralidadNetosReaseguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguro()
                {
                    GastosPorSiniestralidadSeguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguroGastosPorSiniestralidadSeguro()
                    {
                        GastosPorSiniestros = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguroGastosPorSiniestralidadSeguroGastosPorSiniestros()
                        {
                            DesgloseGastosPorSiniestros = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguroGastosPorSiniestralidadSeguroGastosPorSiniestrosDesgloseGastosPorSiniestros()
                            {
                                ContratosOnerosos = sheet.DecimalValue(rowNumber, "K", response),
                                ContratosNoOnerosos = sheet.DecimalValue(rowNumber, "L", response),
                                ImputablesSiniestros = sheet.DecimalValue(rowNumber, "M", response)
                            }
                        },
                        PerdidasContratosOnerosos = sheet.DecimalValue(rowNumber, "N", response)
                    },
                    IngresosPorRecupSiniestralidadDeContratosReaseguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguroIngresosPorRecupSiniestralidadDeContratosReaseguro()
                    {
                        RecuperacionesYComisionesRelacionadasConSiniestralidad = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguroIngresosPorRecupSiniestralidadDeContratosReaseguroRecuperacionesYComisionesRelacionadasConSiniestralidad()
                        {
                            DesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroGastosPorSiniestralidadNetosReaseguroIngresosPorRecupSiniestralidadDeContratosReaseguroRecuperacionesYComisionesRelacionadasConSiniestralidadDesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad()
                            {
                                ComisionesReaseguroCedidoRelacSiniestralidad = sheet.DecimalValue(rowNumber, "O", response),
                                RecuperacionesSiniestros = sheet.DecimalValue(rowNumber, "P", response)
                            }
                        },
                        CambiosAjustePorRiesgoNoFinancieroYEstimaciones = sheet.DecimalValue(rowNumber, "Q", response),
                        GananciaNetaServicioReaseguro = sheet.DecimalValue(rowNumber, "R", response)
                    },


                };
            gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.GastosPorSiniestros.TotalGastosPorSiniestros =
               gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.GastosPorSiniestros.DesgloseGastosPorSiniestros.ContratosOnerosos +
               gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.GastosPorSiniestros.DesgloseGastosPorSiniestros.ContratosNoOnerosos +
               gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.GastosPorSiniestros.DesgloseGastosPorSiniestros.ImputablesSiniestros;

            gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.TotalGastosPorSiniestralidadSeguro =
                gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.GastosPorSiniestros.TotalGastosPorSiniestros +
                gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.PerdidasContratosOnerosos;



            gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.RecuperacionesYComisionesRelacionadasConSiniestralidad.TotalRecuperacionesYComisionesRelacionadasConSiniestralidad =
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.RecuperacionesYComisionesRelacionadasConSiniestralidad.DesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad.ComisionesReaseguroCedidoRelacSiniestralidad +
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.RecuperacionesYComisionesRelacionadasConSiniestralidad.DesgloseRecuperacionesYComisionesRelacionadasConSiniestralidad.RecuperacionesSiniestros;

            gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.TotalIngresosPorRecupSiniestralidadDeContratosReaseguro =
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.RecuperacionesYComisionesRelacionadasConSiniestralidad.TotalRecuperacionesYComisionesRelacionadasConSiniestralidad +
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.CambiosAjustePorRiesgoNoFinancieroYEstimaciones +
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.GananciaNetaServicioReaseguro;



            gastosPorSiniestralidadNetosReaseguro.TotalGastosPorSiniestralidadNetosReaseguro =
                gastosPorSiniestralidadNetosReaseguro.GastosPorSiniestralidadSeguro.TotalGastosPorSiniestralidadSeguro -
                gastosPorSiniestralidadNetosReaseguro.IngresosPorRecupSiniestralidadDeContratosReaseguro.TotalIngresosPorRecupSiniestralidadDeContratosReaseguro;
            return gastosPorSiniestralidadNetosReaseguro;
        }

        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguro Build_IngresosPorContratosSeguro(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguro resultadoServicioSeguro)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguro
                ingresosPorContratosSeguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguro()
                {
                    MargenServicioContractual = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguroMargenServicioContractual()
                    {
                        DesgloseMargenServicioContractual = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguroMargenServicioContractualDesgloseMargenServicioContractual()
                        {
                            SeguroDirecto = sheet.DecimalValue(rowNumber, "B", response),
                            ReaseguroAceptado = sheet.DecimalValue(rowNumber, "C", response)
                        }
                    },
                    CambiosAjustePorRiesgoEstimaciones = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguroCambiosAjustePorRiesgoEstimaciones()
                    {
                        DesgloseCambiosAjustePorRiesgoEstimaciones = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguroCambiosAjustePorRiesgoEstimacionesDesgloseCambiosAjustePorRiesgoEstimaciones()
                        {
                            SeguroDirecto = sheet.DecimalValue(rowNumber, "D", response),
                            ReaseguroAceptado = sheet.DecimalValue(rowNumber, "E", response)
                        }
                    },
                    PrimaGanada = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguroPrimaGanada()
                    {
                        DesglosePrimaGanada = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroIngresosPorContratosSeguroPrimaGanadaDesglosePrimaGanada()
                        {
                            SeguroDirecto = sheet.DecimalValue(rowNumber, "F", response),
                            ReaseguroAceptado = sheet.DecimalValue(rowNumber, "G", response)
                        }
                    }
                };


            ingresosPorContratosSeguro.MargenServicioContractual.TotalMargenServicioContractual =
                ingresosPorContratosSeguro.MargenServicioContractual.DesgloseMargenServicioContractual.SeguroDirecto +
                ingresosPorContratosSeguro.MargenServicioContractual.DesgloseMargenServicioContractual.ReaseguroAceptado;

            ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones.TotalCambiosAjustePorRiesgoEstimaciones =
                ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones.DesgloseCambiosAjustePorRiesgoEstimaciones.SeguroDirecto +
                ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones.DesgloseCambiosAjustePorRiesgoEstimaciones.ReaseguroAceptado;

            ingresosPorContratosSeguro.PrimaGanada.TotalPrimaGanada =
                ingresosPorContratosSeguro.PrimaGanada.DesglosePrimaGanada.SeguroDirecto +
                ingresosPorContratosSeguro.PrimaGanada.DesglosePrimaGanada.ReaseguroAceptado;

            ingresosPorContratosSeguro.TotalIngresosPorContratosSeguro =
                ingresosPorContratosSeguro.MargenServicioContractual.TotalMargenServicioContractual +
                ingresosPorContratosSeguro.CambiosAjustePorRiesgoEstimaciones.TotalCambiosAjustePorRiesgoEstimaciones +
                ingresosPorContratosSeguro.PrimaGanada.TotalPrimaGanada;

            return ingresosPorContratosSeguro;
        }

        private static ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroGastosPorContratosReaseguro Build_GastosPorContratosReaseguro(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguro resultadoServicioSeguro)
        {
            ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroGastosPorContratosReaseguro
                gastosPorContratosReaseguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroGastosPorContratosReaseguro()
                {
                    DesgloseGastosPorContratosReaseguro = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoServicioSeguroIngresosPorContratosSeguroNetosReaseguroGastosPorContratosReaseguroDesgloseGastosPorContratosReaseguro()
                    {
                        CostosContratoReaseguro = sheet.DecimalValue(rowNumber, "H", response),
                        CostoNetoServicioReaseguro = sheet.DecimalValue(rowNumber, "I", response),
                        CambiosAjustePorRiesgoNoFinancieroYEstimaciones = sheet.DecimalValue(rowNumber, "J", response)
                    }
                };

            gastosPorContratosReaseguro.TotalGastosPorContratosReaseguro =
                gastosPorContratosReaseguro.DesgloseGastosPorContratosReaseguro.CostosContratoReaseguro +
                gastosPorContratosReaseguro.DesgloseGastosPorContratosReaseguro.CostoNetoServicioReaseguro +
                gastosPorContratosReaseguro.DesgloseGastosPorContratosReaseguro.CambiosAjustePorRiesgoNoFinancieroYEstimaciones;

            return gastosPorContratosReaseguro;
        }

    }
}
