using Architect.API.Core.Business;
using Architect.Sugese.Utility;
using Architect.Sugese.Utility.Helpers;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Architect.Sugese.RendimientoFinanciero.Application
{
    public class Generate : Architect.Sugese.Domain.GenerateBase
    {
        public static DataTable Execute(string excelFileName, string xmlFileName, int month, int year)
        {
            DataTable response = XmlRespose.ReponseDataTable();
            Domain.ModeloRendimientoFinanciero model = ModelInit(new DateTime(year, month, 1));

            LoadExcelFile(model, excelFileName, month, year, response);
            CreateXMLFile(model, xmlFileName, response);
            return response;
        }

        private static Domain.ModeloRendimientoFinanciero ModelInit(DateTime period)
        {
            Domain.ModeloRendimientoFinanciero model = new Domain.ModeloRendimientoFinanciero()
            {
                Encabezado = new Domain.EncabezadoTipo()
                {
                    NombreArchivo = String.Format("{0}-ModeloRendimientoFinanciero", "sugese.entidadaseguradora".StringValue(0, "Mapfre Seguros Costa Rica S.A.")),
                    Fecha = DateTime.Today,
                    Periodo = period,
                    Periodicidad = Domain.Periodicidad.T,
                    Moneda = Domain.CodMoneda.Item1
                },
                Datos = new Domain.ModeloRendimientoFinancieroDatos()
                {
                    Modelo = new Domain.ModeloRendimientoFinancieroDatosModelo()
                    {
                        EntidadFuente = "sugese.codigoaseguradora".StringValue(0, "A03"),
                        ResultadosIntegralesTotalesDelPeriodo = new Domain.ModeloRendimientoFinancieroDatosModeloResultadosIntegralesTotalesDelPeriodo()
                        {
                        },
                        UtilidadOPerdidaNetaDelPeriodo = new Domain.ModeloRendimientoFinancieroDatosModeloUtilidadOPerdidaNetaDelPeriodo()
                        {
                        }
                    }
                }
            };
            return model;
        }

        private static void LoadExcelFile(Domain.ModeloRendimientoFinanciero model, string excelFilename, int month, int year, DataTable response)
        {
            XLWorkbook workbook = new XLWorkbook(excelFilename);
            IXLWorksheet sheet = null;
            string value = string.Empty;
            int rowNumber = 6;
            try
            {
                sheet = workbook.Worksheet(1);
            }
            catch (Exception ex)
            {
                throw new Exception("No existe una hoja en el archivo de excel con el nombre 'Datos'", ex);
            }

            model.Datos.Modelo.UtilidadOPerdidaNetaDelPeriodo = UtilidadOPerdida.Builder(response, workbook, rowNumber);
            model.Datos.Modelo.ResultadosIntegralesTotalesDelPeriodo = ResultadosIntegrales.Builder(response, workbook, rowNumber);

            model.Datos.Modelo.ResultadosIntegralesTotalesDelPeriodo.TotalResultadosIntegralesTotalesDelPeriodo =
                model.Datos.Modelo.UtilidadOPerdidaNetaDelPeriodo.TotalUtilidadOPerdidaNetaDelPeriodo +
                model.Datos.Modelo.ResultadosIntegralesTotalesDelPeriodo.OtrosResultadosIntegrales.TotalOtrosResultadosIntegrales;

            sheet = null;
            workbook = null;
        }

        private static void CreateXMLFile(Domain.ModeloRendimientoFinanciero model, string xmlFileName, DataTable response)
        {
            Utilities.SerializeHandler<Domain.ModeloRendimientoFinanciero>.SerializeToFile(model, xmlFileName, false);
            List<string> result = Validate.XsdValidate("ModeloRendimientoFinancieroNIIF17", xmlFileName);

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