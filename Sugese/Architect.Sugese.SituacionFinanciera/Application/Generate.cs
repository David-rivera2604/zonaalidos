using Architect.Sugese.Utility;
using Architect.Sugese.Utility.Helpers;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Architect.Sugese.SituacionFinanciera.Application
{
    public class Generate
    {
        public static DataTable Execute(string excelFileName, string xmlFileName, int month, int year)
        {
            DataTable response = XmlRespose.ReponseDataTable();
            Domain.ModeloSituacionFinanciera model = ModelInit(new DateTime(year, month, 1));

            LoadExcelFile(model, excelFileName, month, year, response);
            CreateXMLFile(model, xmlFileName, response);
            return response;
        }

        private static Domain.ModeloSituacionFinanciera ModelInit(DateTime period)
        {
            Domain.ModeloSituacionFinanciera model = new Domain.ModeloSituacionFinanciera()
            {
                Encabezado = new Domain.EncabezadoTipo()
                {
                    NombreArchivo = String.Format("{0}-ModeloSituacionFinanciera", ConfigurationManager.AppSettings["sugese.entidadaseguradora"]),
                    Fecha = DateTime.Today,
                    Periodo = period,
                    Periodicidad = Domain.Periodicidad.T,
                    Moneda = Domain.CodMoneda.Item1
                },
                Datos = new Domain.ModeloSituacionFinancieraDatos()
                {
                    Modelo = new Domain.ModeloSituacionFinancieraDatosModelo()
                    {
                        EntidadFuente = ConfigurationManager.AppSettings["sugese.codigoaseguradora"],
                        Activo = new Domain.ModeloSituacionFinancieraDatosModeloActivo()
                        {
                        },
                        Pasivo = new Domain.ModeloSituacionFinancieraDatosModeloPasivo()
                        {
                        },
                        PasivoMasPatrimonio = new Domain.ModeloSituacionFinancieraDatosModeloPasivoMasPatrimonio()
                        {
                        },
                        Patrimonio = new Domain.ModeloSituacionFinancieraDatosModeloPatrimonio()
                        {
                        }
                    }
                }
            };
            return model;
        }

        private static void LoadExcelFile(Domain.ModeloSituacionFinanciera model, string excelFilename, int month, int year, DataTable response)
        {
            XLWorkbook workbook = new XLWorkbook(excelFilename);
            IXLWorksheet sheet = null;
            string value = string.Empty;

            try
            {
                sheet = workbook.Worksheet(1);
            }
            catch (Exception ex)
            {
                throw new Exception("No existe una hoja en el archivo de excel con el nombre 'Datos'", ex);
            }

            for (int rowNumber = 3; rowNumber <= 3; rowNumber++)
            {
                value = sheet.Cell(rowNumber, 1).Value.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    model.Datos.Modelo.Activo = Activos.Builder(response, workbook, rowNumber);
                    model.Datos.Modelo.Pasivo = Pasivos.Builder(response, workbook, rowNumber);
                    model.Datos.Modelo.Patrimonio = Patrimonio.Builder(response, workbook, rowNumber);

                    sheet = workbook.Worksheet(5);
                    model.Datos.Modelo.PasivoMasPatrimonio.TotalPasivoMasPatrimonio = sheet.DecimalValue(rowNumber, "A", response);
                }
                else
                {
                    break;
                }
            }

            sheet = null;
            workbook = null;
        }

        private static void CreateXMLFile(Domain.ModeloSituacionFinanciera model, string xmlFileName, DataTable response)
        {
            Utilities.SerializeHandler<Domain.ModeloSituacionFinanciera>.SerializeToFile(model, xmlFileName, false);
            List<string> result = Validate.XsdValidate("ModeloSituacionFinancieraNIIF17", xmlFileName);

            if (result.Count > 0)
            {
                foreach (string item in result)
                {
                    XmlRespose.AddError(response, "error", item);
                }
            }
            else
            {
                decimal total = model.Datos.Modelo.Pasivo.TotalPasivo + model.Datos.Modelo.Patrimonio.TotalPatrimonio;
                if (total != model.Datos.Modelo.PasivoMasPatrimonio.TotalPasivoMasPatrimonio)
                {
                    XmlRespose.AddError(response, "error",
                       string.Format("La suma del total de pasivo {0} más el total de patrimonio {1} ({2}) no es igual a la columna TotalPasivoMasPatrimonio {3} ", model.Datos.Modelo.Pasivo.TotalPasivo + model.Datos.Modelo.Patrimonio.TotalPatrimonio, total, model.Datos.Modelo.PasivoMasPatrimonio.TotalPasivoMasPatrimonio));
                }

                if (total != model.Datos.Modelo.Activo.TotalActivo)
                {
                    XmlRespose.AddError(response, "error",
                       string.Format("La suma del total de pasivo {0} más el total de patrimonio {1} ({2}) no es igual a la columna TotalPasivoMasPatrimonio {3} ", model.Datos.Modelo.Pasivo.TotalPasivo + model.Datos.Modelo.Patrimonio.TotalPatrimonio, total, model.Datos.Modelo.PasivoMasPatrimonio.TotalPasivoMasPatrimonio));
                }
            }
        }
    }
}