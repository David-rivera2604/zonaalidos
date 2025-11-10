using Architect.Sugese.RendimientoFinanciero.Domain;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.RendimientoFinanciero.Application
{
    internal static class UtilidadOPerdida
    {

        internal static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodo Builder(DataTable response, XLWorkbook workbook, int rowNumber)
        {
            IXLWorksheet sheet;
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodo utilidad = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodo();

            sheet = workbook.Worksheet(1);
            rowNumber = 6;

            utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones()
            {
                ResultadoDelServicioDeSeguro = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguro(),
                ResultadoFinancieroNeto = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNeto(),
                OtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro()
            };

            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguro resultadoDelServicioDeSeguro =
                utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones.ResultadoDelServicioDeSeguro;

            resultadoDelServicioDeSeguro.IngresosPorContratosDeSeguro = IngresosPorContratosDeSeguro(response, sheet, rowNumber);
            resultadoDelServicioDeSeguro.GastosPorOperacionesDeSeguro = GastosPorOperacionesDeSeguro(response, sheet, rowNumber);
            resultadoDelServicioDeSeguro.IngresosYGastosNetosPorContratosReasegMantenido = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenido();
            resultadoDelServicioDeSeguro.IngresosYGastosNetosPorContratosReasegMantenido.IngresosPorContratosDeReaseguro = IngresosPorContratosDeReaseguro(response, sheet, rowNumber);
            resultadoDelServicioDeSeguro.IngresosYGastosNetosPorContratosReasegMantenido.GastosPorOperacionesDeReaseguro = GastosPorOperacionesDeReaseguro(response, sheet, rowNumber);
            resultadoDelServicioDeSeguro.IngresosYGastosNetosPorContratosReasegMantenido.TotalIngresosYGastosNetosPorContratosReasegMantenido =
                resultadoDelServicioDeSeguro.IngresosYGastosNetosPorContratosReasegMantenido.IngresosPorContratosDeReaseguro.TotalIngresosPorContratosDeReaseguro -
                resultadoDelServicioDeSeguro.IngresosYGastosNetosPorContratosReasegMantenido.GastosPorOperacionesDeReaseguro.TotalGastosPorOperacionesDeReaseguro;
            resultadoDelServicioDeSeguro.ProvisionRiesgoCatastrofico = sheet.DecimalValue(rowNumber, "P", response);
            resultadoDelServicioDeSeguro.TotalResultadoDelServicioDeSeguro =
                 resultadoDelServicioDeSeguro.IngresosPorContratosDeSeguro.TotalIngresosPorContratosDeSeguro -
                 resultadoDelServicioDeSeguro.GastosPorOperacionesDeSeguro.TotalGastosPorOperacionesDeSeguro +
                 resultadoDelServicioDeSeguro.IngresosYGastosNetosPorContratosReasegMantenido.TotalIngresosYGastosNetosPorContratosReasegMantenido +
                 resultadoDelServicioDeSeguro.ProvisionRiesgoCatastrofico;

            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNeto resultadoFinancieroNeto =
                utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones.ResultadoFinancieroNeto;

            resultadoFinancieroNeto.RetornoDeInversion = RetornoDeInversion(response, sheet, rowNumber);
            resultadoFinancieroNeto.IngresosPorContratosDeSegurosYContratosDeInversion = IngresosPorContratosDeSegurosYContratosDeInversion(response, sheet, rowNumber);
            resultadoFinancieroNeto.TotalResultadoFinancieroNeto =
                resultadoFinancieroNeto.RetornoDeInversion.TotalRetornoDeInversion +
                resultadoFinancieroNeto.IngresosPorContratosDeSegurosYContratosDeInversion.TotalIngresosPorContratosDeSegurosYContratosDeInversion;

            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro otrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro =
                utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones.OtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro;

            otrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro.OtrosIngresosFinancierosYOperativos = OtrosIngresosFinancierosYOperativos(response, sheet, rowNumber);
            otrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro.OtrosGastosFinancierosYOperativos = OtrosGastosFinancierosYOperativos(response, sheet, rowNumber);
            otrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro.TotalOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro =
                otrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro.OtrosIngresosFinancierosYOperativos.TotalOtrosIngresosFinancierosYOperativos -
                otrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro.OtrosGastosFinancierosYOperativos.TotalOtrosGastosFinancierosYOperativos;

            utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones.TotalUtilidadOPerdidaNetaAntesImpuestosYParticipaciones =
                utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones.ResultadoDelServicioDeSeguro.TotalResultadoDelServicioDeSeguro +
                utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones.ResultadoFinancieroNeto.TotalResultadoFinancieroNeto +
                utilidad.UtilidadOPerdidaNetaAntesDeImpuestosYParticipaciones.OtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro.TotalOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguro;

            utilidad.ImpuestoYParticipacionesSobreLaUtilidad = sheet.DecimalValue(rowNumber, "AD", response);
            utilidad.AtribuidoAParticipacionesNoControladoras = sheet.DecimalValue(rowNumber, "AE", response);
            utilidad.AtribuidoALaControladora = sheet.DecimalValue(rowNumber, "AF", response);
            utilidad.TotalUtilidadOPerdidaNetaDelPeriodo =
                utilidad.AtribuidoAParticipacionesNoControladoras +
                utilidad.AtribuidoALaControladora;


            return utilidad;
        }


        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosGastosFinancierosYOperativos OtrosGastosFinancierosYOperativos(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosGastosFinancierosYOperativos data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosGastosFinancierosYOperativos()
            {
                DesgloceOtrosGastosFinancierosYOperativos = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosGastosFinancierosYOperativosDesgloceOtrosGastosFinancierosYOperativos()
                {
                    GastoPorEstimacionDeDeterioroDeActivos = sheet.DecimalValue(rowNumber, "Z", response),
                    GastosOperativosDiversos = sheet.DecimalValue(rowNumber, "AA", response),
                    GastosDeAdministracion = sheet.DecimalValue(rowNumber, "AB", response),
                    GastosFinancieros = sheet.DecimalValue(rowNumber, "AC", response)
                }
            };
            data.TotalOtrosGastosFinancierosYOperativos =
                data.DesgloceOtrosGastosFinancierosYOperativos.GastoPorEstimacionDeDeterioroDeActivos +
                data.DesgloceOtrosGastosFinancierosYOperativos.GastosOperativosDiversos +
                data.DesgloceOtrosGastosFinancierosYOperativos.GastosDeAdministracion +
                data.DesgloceOtrosGastosFinancierosYOperativos.GastosFinancieros;
            return data;
        }

        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosIngresosFinancierosYOperativos OtrosIngresosFinancierosYOperativos(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosIngresosFinancierosYOperativos data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosIngresosFinancierosYOperativos()
            {
                DesgloceOtrosIngresosFinancierosYOperativos = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesOtrosIngresosYGastosNoRelacionadosConOperacionesDeSeguroOtrosIngresosFinancierosYOperativosDesgloceOtrosIngresosFinancierosYOperativos()
                {
                    IngresosRecupActivosYDismDeEstimacYProv = sheet.DecimalValue(rowNumber, "W", response),
                    IngresosOperativosDiversos = sheet.DecimalValue(rowNumber, "X", response),
                    IngresosFinancieros = sheet.DecimalValue(rowNumber, "Y", response)
                }
            };
            data.TotalOtrosIngresosFinancierosYOperativos =
                data.DesgloceOtrosIngresosFinancierosYOperativos.IngresosRecupActivosYDismDeEstimacYProv +
                data.DesgloceOtrosIngresosFinancierosYOperativos.IngresosOperativosDiversos +
                data.DesgloceOtrosIngresosFinancierosYOperativos.IngresosFinancieros;
            return data;
        }

        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoIngresosPorContratosDeSegurosYContratosDeInversion IngresosPorContratosDeSegurosYContratosDeInversion(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoIngresosPorContratosDeSegurosYContratosDeInversion data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoIngresosPorContratosDeSegurosYContratosDeInversion()
            {
                DesgloceIngresosPorContratosDeSegurosYContratosDeInversion = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoIngresosPorContratosDeSegurosYContratosDeInversionDesgloceIngresosPorContratosDeSegurosYContratosDeInversion()
                {
                    IngresosYGastosFinancierosNetosDeContratosDeSeguros = sheet.DecimalValue(rowNumber, "T", response),
                    IngresosYGastosFinancNetosDeContratosReaseg = sheet.DecimalValue(rowNumber, "U", response),
                    MovimientoEnPasivosPorContratosDeInversion = sheet.DecimalValue(rowNumber, "V", response)
                }
            };
            data.TotalIngresosPorContratosDeSegurosYContratosDeInversion =
                data.DesgloceIngresosPorContratosDeSegurosYContratosDeInversion.IngresosYGastosFinancierosNetosDeContratosDeSeguros +
                data.DesgloceIngresosPorContratosDeSegurosYContratosDeInversion.IngresosYGastosFinancNetosDeContratosReaseg +
                data.DesgloceIngresosPorContratosDeSegurosYContratosDeInversion.MovimientoEnPasivosPorContratosDeInversion;
            return data;
        }

        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoRetornoDeInversion RetornoDeInversion(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoRetornoDeInversion data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoRetornoDeInversion()
            {
                DesgloceRetornoDeInversion = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoFinancieroNetoRetornoDeInversionDesgloceRetornoDeInversion()
                {
                    IngresoPorInteresesDeActivosFinancieros = sheet.DecimalValue(rowNumber, "Q", response),
                    OtrosIngresosPorInversiones = sheet.DecimalValue(rowNumber, "R", response),
                    PerdidaNetaPorDeterioroDeActivosFinancieros = sheet.DecimalValue(rowNumber, "S", response)
                }
            };
            data.TotalRetornoDeInversion =
                data.DesgloceRetornoDeInversion.IngresoPorInteresesDeActivosFinancieros +
                data.DesgloceRetornoDeInversion.OtrosIngresosPorInversiones +
                data.DesgloceRetornoDeInversion.PerdidaNetaPorDeterioroDeActivosFinancieros;
            return data;
        }

        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoGastosPorOperacionesDeReaseguro GastosPorOperacionesDeReaseguro(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoGastosPorOperacionesDeReaseguro data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoGastosPorOperacionesDeReaseguro()
            {
                DesgloceGastosPorOperacionesDeReaseguro = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoGastosPorOperacionesDeReaseguroDesgloceGastosPorOperacionesDeReaseguro()
                {
                    CostosDelContratoDeReaseguro = sheet.DecimalValue(rowNumber, "K", response),
                    GastosDeAdquisicionDelContratoDeReaseguro = sheet.DecimalValue(rowNumber, "L", response),
                    OtrosGastosRelacionadosConElServicioDeReaseguro = sheet.DecimalValue(rowNumber, "M", response),
                    CostoNetoDelServicioDeReaseguro = sheet.DecimalValue(rowNumber, "N", response),
                    CambiosEnAjustePorRiesgoNoFinancieroYEstimaciones = sheet.DecimalValue(rowNumber, "O", response)
                }
            };
            data.TotalGastosPorOperacionesDeReaseguro =
                data.DesgloceGastosPorOperacionesDeReaseguro.CostosDelContratoDeReaseguro +
                data.DesgloceGastosPorOperacionesDeReaseguro.GastosDeAdquisicionDelContratoDeReaseguro +
                data.DesgloceGastosPorOperacionesDeReaseguro.OtrosGastosRelacionadosConElServicioDeReaseguro +
                data.DesgloceGastosPorOperacionesDeReaseguro.CostoNetoDelServicioDeReaseguro +
                data.DesgloceGastosPorOperacionesDeReaseguro.CambiosEnAjustePorRiesgoNoFinancieroYEstimaciones;
            return data;
        }

        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoIngresosPorContratosDeReaseguro IngresosPorContratosDeReaseguro(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoIngresosPorContratosDeReaseguro data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoIngresosPorContratosDeReaseguro()
            {
                DesgloceIngresosPorContratosDeReaseguro = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosYGastosNetosPorContratosReasegMantenidoIngresosPorContratosDeReaseguroDesgloceIngresosPorContratosDeReaseguro()
                {
                    RecuperacionesDeSiniestros = sheet.DecimalValue(rowNumber, "H", response),
                    CambiosEnAjustePorRiesgoNoFinancieroYEstimaciones = sheet.DecimalValue(rowNumber, "I", response),
                    GananciaNetaDelServicioDeReaseguro = sheet.DecimalValue(rowNumber, "J", response)
                }
            };
            data.TotalIngresosPorContratosDeReaseguro =
                data.DesgloceIngresosPorContratosDeReaseguro.RecuperacionesDeSiniestros +
                data.DesgloceIngresosPorContratosDeReaseguro.CambiosEnAjustePorRiesgoNoFinancieroYEstimaciones +
                data.DesgloceIngresosPorContratosDeReaseguro.GananciaNetaDelServicioDeReaseguro;
            return data;
        }

        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroGastosPorOperacionesDeSeguro GastosPorOperacionesDeSeguro(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroGastosPorOperacionesDeSeguro data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroGastosPorOperacionesDeSeguro()
            {
                DesgloceGastosPorOperacionesDeSeguro = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroGastosPorOperacionesDeSeguroDesgloceGastosPorOperacionesDeSeguro()
                {
                    GastosPorSiniestros = sheet.DecimalValue(rowNumber, "D", response),
                    GastosDeAdquisicion = sheet.DecimalValue(rowNumber, "E", response),
                    OtrosGastosRelacionadosConElServicioDeSeguro = sheet.DecimalValue(rowNumber, "F", response),
                    PerdidasPorContratosOnerosos = sheet.DecimalValue(rowNumber, "G", response)
                }
            };
            data.TotalGastosPorOperacionesDeSeguro =
                data.DesgloceGastosPorOperacionesDeSeguro.GastosPorSiniestros +
                data.DesgloceGastosPorOperacionesDeSeguro.GastosDeAdquisicion +
                data.DesgloceGastosPorOperacionesDeSeguro.OtrosGastosRelacionadosConElServicioDeSeguro +
                data.DesgloceGastosPorOperacionesDeSeguro.PerdidasPorContratosOnerosos;
            return data;
        }

        private static ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosPorContratosDeSeguro IngresosPorContratosDeSeguro(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosPorContratosDeSeguro data = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosPorContratosDeSeguro()
            {
                DesgloseIngresosPorContratosDeSeguro = new ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodoUtilidadOPerdidaNetaAntesDeImpuestosYParticipacionesResultadoDelServicioDeSeguroIngresosPorContratosDeSeguroDesgloseIngresosPorContratosDeSeguro()
                {
                    MargenServicioContractual = sheet.DecimalValue(rowNumber, "A", response),
                    CambiosEnAjustePorRiesgoYEstimaciones = sheet.DecimalValue(rowNumber, "B", response),
                    PrimaGanada = sheet.DecimalValue(rowNumber, "C", response)
                }
            };
            data.TotalIngresosPorContratosDeSeguro =
                data.DesgloseIngresosPorContratosDeSeguro.MargenServicioContractual +
                data.DesgloseIngresosPorContratosDeSeguro.CambiosEnAjustePorRiesgoYEstimaciones +
                data.DesgloseIngresosPorContratosDeSeguro.PrimaGanada;
            return data;
        }


    }
}
