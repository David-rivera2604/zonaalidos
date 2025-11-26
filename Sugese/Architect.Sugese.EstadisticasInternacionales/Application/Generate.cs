using Architect.Sugese.Utility;
using Architect.Sugese.Utility.Helpers;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Architect.Sugese.EstadisticasInternacionales.Application
{
    public  class Generate : Architect.Sugese.Domain.GenerateBase
    {
        public static DataTable Execute(string excelFileName, string xmlFileName, int month, int year)
        {
            DataTable response = XmlRespose.ReponseDataTable();
            Domain.ModeloEstadisticasInternacionales model = ModelInit(new DateTime(year, month, 1));

            LoadExcelFile(model, excelFileName, month, year, response);
            CreateXMLFile(model, xmlFileName, response);
            return response;
        }

        private static Domain.ModeloEstadisticasInternacionales ModelInit(DateTime period)
        {
            Domain.ModeloEstadisticasInternacionales model = new Domain.ModeloEstadisticasInternacionales()
            {
                Encabezado = new Domain.EncabezadoTipo()
                {
                    NombreArchivo = String.Format("{0}-ModeloEstadisticasInternacionales", ConfigurationManager.AppSettings["sugese.entidadaseguradora"]),
                    Fecha = DateTime.Today,
                    Periodo = period,
                    Periodicidad = Domain.Periodicidad.M,
                    Moneda = Domain.CodMoneda.Item1
                },
                Datos = new Domain.ModeloEstadisticasInternacionalesDatos()
                {
                    Modelo = new Domain.ModeloEstadisticasInternacionalesDatosModelo()
                    {
                        EntidadFuente = ConfigurationManager.AppSettings["sugese.codigoaseguradora"],
                        Estadisticas = new Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticas()
                        {
                            TotalDePrimas = 0,
                            TotalDePrimasPorSeguroDirecto = 0,
                            TotalDePrimasPorReaseguroAceptado = 0,
                            TotalDePrimasCedidas = 0,
                            TotalDePrimasCedidasPorSeguroDirecto = 0,
                            TotalDePrimasCedidasPorReaseguroAceptado = 0,
                            TotalDeSiniestralidad = 0,
                            TotalDeSiniestralidadPorSeguroDirecto = 0,
                            TotalDeSiniestralidadPorReaseguroAceptado = 0,
                            TotalDeGastosDeAdquisicion = 0,
                            TotalDeGastosDeAdquisicionPorSeguroDirecto = 0,
                            TotalDeGastosDeAdquisicionPorReaseguroAceptado = 0,
                            TotalDeGastosDeAdministracion = 0,
                            TotalDeGastosDeAdministracionPorSeguroDirecto = 0,
                            TotalDeGastosDeAdministracionPorReaseguroAceptado = 0,
                            TotalPasivosContratosDeSegurosReaseguros = 0
                        }
                    }
                }
            };
            return model;
        }

        private static void LoadExcelFile(Domain.ModeloEstadisticasInternacionales model, string excelFilename, int month, int year, DataTable response)
        {
            XLWorkbook workbook = new XLWorkbook(excelFilename);
            IXLWorksheet sheet = null;
            string value = string.Empty;

            List<Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamo> rows = new List<Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamo>();

            try
            {
                sheet = workbook.Worksheet(1);
            }
            catch (Exception ex)
            {
                throw new Exception("No existe una hoja en el archivo de excel con el nombre 'Datos'", ex);
            }

            for (int rowNumber = 3; rowNumber < 10000; rowNumber++)
            {
                value = sheet.Cell(rowNumber, 1).Value.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamo row = RamoInstance();
                    rows.Add(row);

                    try
                    {
                        row.id = (Domain.TipoRamo)Enum.Parse(typeof(Domain.TipoRamo), value);
                    }
                    catch (Exception)
                    {
                        row.id = Domain.TipoRamo.G01;
                        XmlRespose.AddError(response, "error", String.Format("El ramo '{0}' no es valido.", value));
                    }

                    row.Primas.PorSeguroDirecto = DecimalValue(sheet, rowNumber, "B", response);
                    row.Primas.PorReaseguroAceptado = DecimalValue(sheet, rowNumber, "C", response);
                    row.Primas.Total = row.Primas.PorSeguroDirecto + row.Primas.PorReaseguroAceptado;
                    model.Datos.Modelo.Estadisticas.TotalDePrimas += row.Primas.Total;
                    model.Datos.Modelo.Estadisticas.TotalDePrimasPorSeguroDirecto += row.Primas.PorSeguroDirecto;
                    model.Datos.Modelo.Estadisticas.TotalDePrimasPorReaseguroAceptado += row.Primas.PorReaseguroAceptado;

                    row.PrimasCedidas.PorSeguroDirecto = DecimalValue(sheet, rowNumber, "D", response);
                    row.PrimasCedidas.PorReaseguroAceptado = DecimalValue(sheet, rowNumber, "E", response);
                    row.PrimasCedidas.Total = row.PrimasCedidas.PorSeguroDirecto + row.PrimasCedidas.PorReaseguroAceptado;
                    model.Datos.Modelo.Estadisticas.TotalDePrimasCedidas += row.PrimasCedidas.Total;
                    model.Datos.Modelo.Estadisticas.TotalDePrimasCedidasPorSeguroDirecto += row.PrimasCedidas.PorSeguroDirecto;
                    model.Datos.Modelo.Estadisticas.TotalDePrimasCedidasPorReaseguroAceptado += row.PrimasCedidas.PorReaseguroAceptado;

                    row.Siniestralidad.PorSeguroDirecto = DecimalValue(sheet, rowNumber, "F", response);
                    row.Siniestralidad.PorReaseguroAceptado = DecimalValue(sheet, rowNumber, "G", response);
                    row.Siniestralidad.Total = row.Siniestralidad.PorSeguroDirecto + row.Siniestralidad.PorReaseguroAceptado;
                    model.Datos.Modelo.Estadisticas.TotalDeSiniestralidad += row.Siniestralidad.Total;
                    model.Datos.Modelo.Estadisticas.TotalDeSiniestralidadPorSeguroDirecto += row.Siniestralidad.PorSeguroDirecto;
                    model.Datos.Modelo.Estadisticas.TotalDeSiniestralidadPorReaseguroAceptado += row.Siniestralidad.PorReaseguroAceptado;

                    row.GastosDeAquisicion.PorSeguroDirecto = DecimalValue(sheet, rowNumber, "H", response);
                    row.GastosDeAquisicion.PorReaseguroAceptado = DecimalValue(sheet, rowNumber, "I", response);
                    row.GastosDeAquisicion.Total = row.GastosDeAquisicion.PorSeguroDirecto + row.GastosDeAquisicion.PorReaseguroAceptado;
                    model.Datos.Modelo.Estadisticas.TotalDeGastosDeAdquisicion += row.GastosDeAquisicion.Total;
                    model.Datos.Modelo.Estadisticas.TotalDeGastosDeAdquisicionPorSeguroDirecto += row.GastosDeAquisicion.PorSeguroDirecto;
                    model.Datos.Modelo.Estadisticas.TotalDeGastosDeAdquisicionPorReaseguroAceptado += row.GastosDeAquisicion.PorReaseguroAceptado;

                    row.GastosDeAdministracion.PorSeguroDirecto = DecimalValue(sheet, rowNumber, "J", response);
                    row.GastosDeAdministracion.PorReaseguroAceptado = DecimalValue(sheet, rowNumber, "K", response);
                    row.GastosDeAdministracion.Total = row.GastosDeAdministracion.PorSeguroDirecto + row.GastosDeAdministracion.PorReaseguroAceptado;
                    model.Datos.Modelo.Estadisticas.TotalDeGastosDeAdministracion += row.GastosDeAdministracion.Total;
                    model.Datos.Modelo.Estadisticas.TotalDeGastosDeAdministracionPorSeguroDirecto += row.GastosDeAdministracion.PorSeguroDirecto;
                    model.Datos.Modelo.Estadisticas.TotalDeGastosDeAdministracionPorReaseguroAceptado += row.GastosDeAdministracion.PorReaseguroAceptado;

                    row.PasivosPorContratoDeSeguroReaseguro = DecimalValue(sheet, rowNumber, "L", response);
                    model.Datos.Modelo.Estadisticas.TotalPasivosContratosDeSegurosReaseguros += row.PasivosPorContratoDeSeguroReaseguro;
                }
                else
                {
                    break;
                }
            }
            model.Datos.Modelo.Estadisticas.Ramo = rows.ToArray();

            sheet = null;
            workbook = null;
        }

        private static decimal DecimalValue(IXLWorksheet sheet, int rowNumber, string column, DataTable response)
        {
            try
            {
                if (!string.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value.ToString()))
                {
                    return Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);
                }
            }
            catch (Exception ex)
            {
                DataRow errorRow = response.NewRow();

                errorRow["tipo"] = "error";
                errorRow["message"] = String.Format("La celda '{0}:{1}' presenta un error '{2}'", rowNumber, column, ex.Message);
                response.Rows.Add(errorRow);
            }
            return 0;
        }

        private static Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamo RamoInstance()
        {
            return new Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamo()
            {
                Primas = new Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamoPrimas()
                {
                    PorSeguroDirecto = 0,
                    PorReaseguroAceptado = 0,
                    Total = 0
                },
                PrimasCedidas = new Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamoPrimasCedidas()
                {
                    PorSeguroDirecto = 0,
                    PorReaseguroAceptado = 0,
                    Total = 0
                },
                Siniestralidad = new Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamoSiniestralidad()
                {
                    PorSeguroDirecto = 0,
                    PorReaseguroAceptado = 0,
                    Total = 0
                },
                GastosDeAquisicion = new Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamoGastosDeAquisicion()
                {
                    PorSeguroDirecto = 0,
                    PorReaseguroAceptado = 0,
                    Total = 0
                },
                GastosDeAdministracion = new Domain.ModeloEstadisticasInternacionalesDatosModeloEstadisticasRamoGastosDeAdministracion()
                {
                    PorSeguroDirecto = 0,
                    PorReaseguroAceptado = 0,
                    Total = 0
                },
                PasivosPorContratoDeSeguroReaseguro = 0
            };
        }

        private static void CreateXMLFile(Domain.ModeloEstadisticasInternacionales model, string xmlFileName, DataTable response)
        {
            Utilities.SerializeHandler<Domain.ModeloEstadisticasInternacionales>.SerializeToFile(model, xmlFileName, false);
            List<string> result = Validate.XsdValidate("ModeloEstadisticasInternacionalesNIIF17", xmlFileName);

            if (result.Count > 0)
            {
                foreach (string item in result)
                {
                    XmlRespose.AddError(response, "error", item);
                }
            }
        }
    }
}