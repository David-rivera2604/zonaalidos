using Architect.Sugese.Utility;
using Architect.Sugese.Utility.Helpers;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Architect.Sugese.PrimasSiniestros.Application
{
    public  class Generate : Architect.Sugese.Domain.GenerateBase
    {
        public static DataTable Execute(string excelFileName, string xmlFileName, int month, int year)
        {
            DataTable response = XmlRespose.ReponseDataTable();
            Domain.ModeloPrimasSiniestros model = ModelInit(new DateTime(year, month, 1));

            LoadExcelFile(model, excelFileName, month, year, response);
            CreateXMLFile(model, xmlFileName, response);
            return response;
        }

        private static Domain.ModeloPrimasSiniestros ModelInit(DateTime period)
        {
            Domain.ModeloPrimasSiniestros model = new Domain.ModeloPrimasSiniestros()
            {
                Encabezado = new Domain.EncabezadoTipo()
                {
                    NombreArchivo = String.Format("{0}-ModeloPrimasSiniestros", ConfigurationManager.AppSettings["sugese.entidadaseguradora"]),
                    Fecha = DateTime.Today,
                    Periodo = period,
                    Periodicidad = Domain.Periodicidad.M,
                    Moneda = Domain.CodMoneda.Item1
                },
                Datos = new Domain.ModeloPrimasSiniestrosDatos()
                {
                    Modelo = new Domain.ModeloPrimasSiniestrosDatosModelo()
                    {
                        EntidadFuente = ConfigurationManager.AppSettings["sugese.codigoaseguradora"],
                        PrimasYSiniestralidad = new Domain.ModeloPrimasSiniestrosDatosModeloPrimasYSiniestralidad()
                        {
                        }
                    }
                }
            };
            return model;
        }

        private static void LoadExcelFile(Domain.ModeloPrimasSiniestros model, string excelFilename, int month, int year, DataTable response)
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

            for (int rowNumber = 3; rowNumber < 10000; rowNumber++)
            {
                value = sheet.Cell(rowNumber, 1).Value.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                }
                else
                {
                    break;
                }
            }

            sheet = null;
            workbook = null;
        }

        private static void CreateXMLFile(Domain.ModeloPrimasSiniestros model, string xmlFileName, DataTable response)
        {
            Utilities.SerializeHandler<Domain.ModeloPrimasSiniestros>.SerializeToFile(model, xmlFileName, false);
            List<string> result = Validate.XsdValidate("ModeloPrimasSiniestrosNIIF17", xmlFileName);

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