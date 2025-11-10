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
    internal static class ResultadoFinancieroNeto
    {

        internal static List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera> Builder(DataTable response, XLWorkbook workbook, List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera> resultadoCuentaTecnicoFinanciera)
        {
            IXLWorksheet sheet = workbook.Worksheet(2);
            string value = string.Empty;
            Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera cuentaTecnicoFinanciera;

            for (int rowNumber = 3; rowNumber < 10000; rowNumber++)
            {
                value = sheet.Cell(rowNumber, 1).Value.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    TipoRamo ramoActual = sheet.EnumValue<TipoRamo>(rowNumber, "A", response);

                    cuentaTecnicoFinanciera = Generate.FindOrAddByRamo(ramoActual, resultadoCuentaTecnicoFinanciera);

                    ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoFinancieroNeto resultadoFinancieroNeto = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoFinancieroNeto();
                    cuentaTecnicoFinanciera.ResultadoFinancieroNeto = resultadoFinancieroNeto;

                    resultadoFinancieroNeto.RetornoInversion = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoFinancieroNetoRetornoInversion()
                    {
                        DesgloseRetornoInversion = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoFinancieroNetoRetornoInversionDesgloseRetornoInversion()
                        {
                            IngresoPorInteresesActivosFinancieros = sheet.DecimalValue(rowNumber, "B", response),
                            OtrosIngresosPorInversiones = sheet.DecimalValue(rowNumber, "C", response),
                            PerdidaNetaPorDeterioroActivosFinancieros = sheet.DecimalValue(rowNumber, "D", response)
                        }
                    };
                    resultadoFinancieroNeto.RetornoInversion.TotalRetornoInversion =
                        resultadoFinancieroNeto.RetornoInversion.DesgloseRetornoInversion.IngresoPorInteresesActivosFinancieros +
                        resultadoFinancieroNeto.RetornoInversion.DesgloseRetornoInversion.OtrosIngresosPorInversiones +
                        resultadoFinancieroNeto.RetornoInversion.DesgloseRetornoInversion.PerdidaNetaPorDeterioroActivosFinancieros;

                    resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoFinancieroNetoIngresosPorContratosSegurosYContratosInversion()
                    {
                        DesgloseIngresosPorContratosSegurosYContratosInversion = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoFinancieroNetoIngresosPorContratosSegurosYContratosInversionDesgloseIngresosPorContratosSegurosYContratosInversion()
                        {
                            IngresosYGastosFinancierosNetosContratosSeguros = sheet.DecimalValue(rowNumber, "E", response),
                            IngresosYGastosFinancierosNetosContratosReaseguros = sheet.DecimalValue(rowNumber, "F", response),
                            MovimientoEnPasivosPorContratosInversion = sheet.DecimalValue(rowNumber, "G", response)
                        }
                    };
                    resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion.TotalIngresosPorContratosSegurosYContratosInversion =
                        resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion.DesgloseIngresosPorContratosSegurosYContratosInversion.IngresosYGastosFinancierosNetosContratosSeguros +
                        resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion.DesgloseIngresosPorContratosSegurosYContratosInversion.IngresosYGastosFinancierosNetosContratosReaseguros +
                        resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion.DesgloseIngresosPorContratosSegurosYContratosInversion.MovimientoEnPasivosPorContratosInversion;


                    resultadoFinancieroNeto.TotalResultadoFinancieroNeto =
                        resultadoFinancieroNeto.RetornoInversion.TotalRetornoInversion +
                        resultadoFinancieroNeto.IngresosPorContratosSegurosYContratosInversion.TotalIngresosPorContratosSegurosYContratosInversion;

                    cuentaTecnicoFinanciera.TotalCuentaTecnicoFinanciera += resultadoFinancieroNeto.TotalResultadoFinancieroNeto;
                }
                else
                {
                    break;
                }
            }

            return resultadoCuentaTecnicoFinanciera;
        }

    }
}
