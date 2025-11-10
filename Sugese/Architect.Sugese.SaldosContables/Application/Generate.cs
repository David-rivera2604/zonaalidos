using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using ClosedXML.Excel;
using Architect.Sugese.Utility.Helpers;
using Architect.Sugese.Utility;
using Architect.Sugese.SaldosContables.Domain;

namespace Architect.Sugese.SaldosContables.Application
{
    public  class Generate
    {
        public static DataTable Execute(string excelFileName, string xmlFileName, int month, int year)
        {
            DataTable response = XmlRespose.ReponseDataTable();
            ModeloSaldosContablesNIIF17 model = ModelInit(new DateTime(year, month, 1));

            LoadExcelFile(model, excelFileName, month, year);
            CreateXMLFile(model, xmlFileName, response);

            return response;
        }

        private static ModeloSaldosContablesNIIF17 ModelInit(DateTime period)
        {
            Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17 model = new ModeloSaldosContablesNIIF17()
            {
                Encabezado = new EncabezadoTipo()
                {
                    NombreArchivo = String.Format("{0}-ModeloSaldosContables", ConfigurationManager.AppSettings["sugese.entidadaseguradora"]),
                    Fecha = DateTime.Today,
                    Periodo = period,
                    Periodicidad = Periodicidad.M,
                    Moneda = CodMoneda.Item1
                },
                Datos = new ModeloSaldosContablesNIIF17Datos()
                {
                    Modelo = new ModeloSaldosContablesNIIF17DatosModelo()
                    {
                        EntidadFuente = ConfigurationManager.AppSettings["sugese.codigoaseguradora"]
                    }
                }
            };
            return model;
        }

        private static void LoadExcelFile(ModeloSaldosContablesNIIF17 model, string excelFilename, int month, int year)
        {
            XLWorkbook workbook = new XLWorkbook(excelFilename);
            IXLWorksheet sheet = null;
            string cuenta = string.Empty;
            System.Nullable<decimal> value;

            try
            {
                sheet = workbook.Worksheet(1);
            }
            catch (Exception ex)
            {
                throw new Exception("No existe una hoja en el archivo de excel con el nombre 'Saldos'", ex);
            }
            try
            {
                for (int rowNumber = 2; rowNumber < 10000; rowNumber++)
                {
                    cuenta = sheet.Cell(rowNumber, 1).Value.ToString();
                    if (!string.IsNullOrEmpty(cuenta))
                    {
                        if (String.IsNullOrEmpty(sheet.Cell(rowNumber, 2).Value.ToString()))
                        {
                            value = (decimal?)0.0;
                        }
                        else
                        {
                            value = (decimal?)Math.Round(Convert.ToDecimal(sheet.Cell(rowNumber, 2).Value), 2);
                        }
                        switch (cuenta.Substring(0, 1))
                        {
                            case "1":
                                switch (cuenta.Substring(0, 3))
                                {
                                    case "101":
                                        Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta101.Mapper(cuenta, model.Datos.Modelo, value, true);
                                        break;

                                    case "102":
                                        Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta102a.Mapper(cuenta, model.Datos.Modelo, value, true);
                                        Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta102b.Mapper(cuenta, model.Datos.Modelo, value, true);
                                        break;

                                    case "103":
                                        Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta103.Mapper(cuenta, model.Datos.Modelo, value, true);
                                        break;

                                    default:
                                        Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta104Other.Mapper(cuenta, model.Datos.Modelo, value, true);
                                        break;
                                }
                                break;

                            case "2":
                                Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta2.Mapper(cuenta, model.Datos.Modelo, value, true);
                                break;

                            case "3":
                                Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta3.Mapper(cuenta, model.Datos.Modelo, value, true);
                                break;

                            case "4":
                                Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta4.Mapper(cuenta, model.Datos.Modelo, value, true);
                                break;

                            case "5":
                                Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta5.Mapper(cuenta, model.Datos.Modelo, value, true);
                                break;

                            case "6":
                                Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta6.Mapper(cuenta, model.Datos.Modelo, value, true);
                                break;

                            case "8":
                                Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta8.Mapper(cuenta, model.Datos.Modelo, value, true);
                                Architect.Sugese.SaldosContables.Domain.Mapper.MapeoCuenta8ext.Mapper(cuenta, model.Datos.Modelo, value, true);
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta1a.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta1b.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta1c.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta2.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta3.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta4.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta5.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta6.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta8.Mapper(string.Empty, model.Datos.Modelo, null, true);
                Architect.Sugese.SaldosContables.Domain.Application.Total.TotalCuenta8ext.Mapper(string.Empty, model.Datos.Modelo, null, true);
            }
            catch (Exception ex)
            {
                throw;
            }
            //Total1.Mapper(_SaldosContables)
            sheet = null;
            workbook = null;
        }

        private static void CreateXMLFile(ModeloSaldosContablesNIIF17 model, string xmlFileName, DataTable response)
        {
            Utilities.SerializeHandler<ModeloSaldosContablesNIIF17>.SerializeToFile(model, xmlFileName, false);
            List<string> result = Validate.XsdValidate("ModeloSaldosContablesNIIF17", xmlFileName);

            if (result.Count > 0)
            {
                foreach (string item in result)
                {
                    XmlRespose.AddError(response, "error", item);
                }
            }

            Architect.Sugese.Validadores.Application.Inspection.Create(xmlFileName);
        }
    }
}