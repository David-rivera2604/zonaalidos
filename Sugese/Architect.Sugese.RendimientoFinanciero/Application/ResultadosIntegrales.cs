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
    internal static class ResultadosIntegrales
    {
        internal static ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodo Builder(DataTable response, XLWorkbook workbook, int rowNumber)
        {
            IXLWorksheet sheet;
            ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodo resultados = new ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodo()
            {
                OtrosResultadosIntegrales = new ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodoOtrosResultadosIntegrales()
            };

            sheet = workbook.Worksheet(2);
            rowNumber = 5;

            resultados.OtrosResultadosIntegrales = OtrosResultadosIntegrales(response, sheet, rowNumber);
            resultados.AtribuidoAParticipacionesNoControladoras = sheet.DecimalValue(rowNumber, "F", response);
            resultados.AtribuidoALaControladora = sheet.DecimalValue(rowNumber, "G", response);

            return resultados;
        }


        private static ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodoOtrosResultadosIntegrales OtrosResultadosIntegrales(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodoOtrosResultadosIntegrales data = new ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodoOtrosResultadosIntegrales()
            {
                DesgloceOtrosResultadosIntegrales = new ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodoOtrosResultadosIntegralesDesgloceOtrosResultadosIntegrales()
                {
                    AjustesAlValorDeLosActivos = sheet.DecimalValue(rowNumber, "A", response),
                    AjustePorValuacionDeParticipacionesEnOtrasEmpresas = sheet.DecimalValue(rowNumber, "B", response),
                    AjustePorConversionDeEstadosFinancieros = sheet.DecimalValue(rowNumber, "C", response),
                    AjustePorValuacionDeLosPasivos = sheet.DecimalValue(rowNumber, "D", response),
                    AjustesPorValuacionDeContratosDeSeguro = sheet.DecimalValue(rowNumber, "E", response)
                }
            };
            data.TotalOtrosResultadosIntegrales =
                data.DesgloceOtrosResultadosIntegrales.AjustesAlValorDeLosActivos +
                data.DesgloceOtrosResultadosIntegrales.AjustePorValuacionDeParticipacionesEnOtrasEmpresas +
                data.DesgloceOtrosResultadosIntegrales.AjustePorConversionDeEstadosFinancieros +
                data.DesgloceOtrosResultadosIntegrales.AjustePorValuacionDeLosPasivos +
                data.DesgloceOtrosResultadosIntegrales.AjustesPorValuacionDeContratosDeSeguro;
            return data;
        }

    }
}
