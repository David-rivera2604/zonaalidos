using Architect.API.Core.Business;
using Architect.Sugese.Utility;
using Architect.Sugese.Utility.Helpers;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Architect.Sugese.CuentaTecnicaFinanciera.Application
{
    public  class Generate : Architect.Sugese.Domain.GenerateBase
    {
        public static DataTable Execute(string excelFileName, string xmlFileName, int month, int year)
        {
            DataTable response = XmlRespose.ReponseDataTable();
            Domain.ModeloCuentaTecnicaFinanciera model = ModelInit(new DateTime(year, month, 1));

            LoadExcelFile(model, excelFileName, month, year, response);
            CreateXMLFile(model, xmlFileName, response);
            return response;
        }

        private static Domain.ModeloCuentaTecnicaFinanciera ModelInit(DateTime period)
        {
            Domain.ModeloCuentaTecnicaFinanciera model = new Domain.ModeloCuentaTecnicaFinanciera()
            {
                Encabezado = new Domain.EncabezadoTipo()
                {
                    NombreArchivo = String.Format("{0}-ModeloCuentaTecnicaFinanciera", "sugese.entidadaseguradora".StringValue(0, "Mapfre Seguros Costa Rica S.A.")),
                    Fecha = DateTime.Today,
                    Periodo = period,
                    Periodicidad = Domain.Periodicidad.T,
                    Moneda = Domain.CodMoneda.Item1
                },
                Datos = new Domain.ModeloCuentaTecnicaFinancieraDatos()
                {
                    Modelo = new Domain.ModeloCuentaTecnicaFinancieraDatosModelo()
                    {
                        EntidadFuente = "sugese.codigoaseguradora".StringValue(0, "A03"),
                        UtilidadPerdidaNetaAntesImpuestosParticipaciones = new Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipaciones()
                        {
                            ResultadoCuentaTecnicoFinanciera = new List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera>(),
                            ResultadoCuentaNoTecnica = new Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica()
                            {
                                IngresosFinancieros = 0,
                                GastosFinancieros = 0,
                                OtrosIngresosNoTecnicos = 0,
                                OtrosGastosNoTecnicos = 0,
                                TotalCuentaNoTecnica = 0
                            },
                            TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones = 0
                        }
                    }
                }
            };
            return model;
        }

        private static void CreateXMLFile(Domain.ModeloCuentaTecnicaFinanciera model, string xmlFileName, DataTable response)
        {
            Utilities.SerializeHandler.SerializeToFile<Domain.ModeloCuentaTecnicaFinanciera>(model, xmlFileName, false);
            List<string> result = Validate.XsdValidate("ModeloCuentaTecnicaFinancieraNIIF17", xmlFileName);

            if (result.Count > 0)
            {
                foreach (string item in result)
                {
                    XmlRespose.AddError(response, "error", item);
                }
            }
        }

        private static void LoadExcelFile(Domain.ModeloCuentaTecnicaFinanciera model, string excelFilename, int month, int year, DataTable response)
        {
            XLWorkbook workbook = new XLWorkbook(excelFilename);

            // Resultado servicio seguro
            model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera =
                ServicioSeguro.Builder(response, workbook, model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera);

            // Resultado financiero neto
            model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera =
                ResultadoFinancieroNeto.Builder(response, workbook, model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera);

            // Lineas
            model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera =
                Lineas.Builder(response, workbook, model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera);

            // Cuenta No Técnica
            model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaNoTecnica =
                CuentaNoTecnica.Builder(response, workbook, 2);

            model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones =
                model.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera.Sum(r => r.TotalCuentaTecnicoFinanciera);

            workbook = null;
        }

        internal static Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera FindOrAddByRamo(Domain.TipoRamo ramo, List<Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera> resultadoCuentaTecnicoFinanciera)
        {
            Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera result = resultadoCuentaTecnicoFinanciera.Where(r => r.idRamo == ramo).FirstOrDefault();
            if (result == null)
            {
                result = new Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera()
                {
                    idRamo = ramo,
                    TotalCuentaTecnicoFinanciera = 0
                };
                resultadoCuentaTecnicoFinanciera.Add(result);
            }
            return result;
        }
    }
}