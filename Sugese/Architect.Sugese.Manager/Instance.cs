using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Architect.Sugese.Manager
{
    /// <summary>
    /// Gestor de procesamiento de archivos Excel para modelos SUGESE
    /// </summary>
    public class Instance
    {
        // Diccionario para mapear modelos a sus procesadores correspondientes
        private static readonly Dictionary<string, Func<string, string, int, int, DataTable>> ModelProcessors =
            new Dictionary<string, Func<string, string, int, int, DataTable>>(StringComparer.OrdinalIgnoreCase)
            {
                // NIFF17
                ["NIFF17SaldosContables"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.SaldosContables.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["NIIF17EstadisticasInternacionales"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.EstadisticasInternacionales.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["NIFF17CuentaTecnicaFinanciera"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.CuentaTecnicaFinanciera.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["NIFF17PrimasSiniestros"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.PrimasSiniestros.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["NIFF17RendimientoFinanciero"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.RendimientoFinanciero.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["NIFF17SituacionFinanciera"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.SituacionFinanciera.Application.Generate.Execute(xlsx, xml, periodo, ano),

                // Modelos
                ["ModeloCuentaTecnicaFinanciera"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.CuentaTecnicaFinanciera.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["ModeloPrimasSiniestros"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.PrimasSiniestros.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["ModeloRendimientoFinanciero"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.RendimientoFinanciero.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["ModeloSituacionFinanciera"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.SituacionFinanciera.Application.Generate.Execute(xlsx, xml, periodo, ano),

                // Mensuales
                ["Bomberos"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.AporteBomberos.Generate.Execute(xlsx, xml, periodo, ano),
                ["Inversiones"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.InversionesFinancieras.Generate.Execute(xlsx, xml, periodo, ano),
                ["SaldosContables"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.SaldosContables.Application.Generate.Execute(xlsx, xml, periodo, ano),
                ["RUB"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.Polizas.Generate.Execute(xlsx, xml, periodo, ano),
                ["AportesINEC"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.AportesINEC.Generate.Execute(xlsx, xml, periodo, ano),
                ["PrimasSiniestros"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.PrimasSiniestros.Application.Generate.Execute(xlsx, xml, periodo, ano),

                // Trimestrales
                ["BalanceGeneral"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.BalanceGeneral.Generate.Execute(xlsx, xml, periodo, ano),
                ["Canales"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.Canales.Generate.Execute(xlsx, xml, periodo, ano),
                ["CuentasTecnicas"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.CuentaTecnica.Generate.Execute(xlsx, xml, periodo, ano),
                ["Patrimonio"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.Patrimonio.Generate.Execute(xlsx, xml, periodo, ano),
                ["Produccion"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.Produccion.Generate.Execute(xlsx, xml, periodo, ano),
                ["Resultados"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.EstadoResultados.Generate.Execute(xlsx, xml, periodo, ano),
                ["RunOff"] = (xlsx, xml, periodo, ano) =>
                    Architect.Sugese.RunOff.Generate.Execute(xlsx, xml, periodo, ano)
            };

        /// <summary>
        /// Procesa un archivo Excel para generar XML de modelos SUGESE
        /// </summary>
        /// <param name="modelo">Nombre del modelo a procesar</param>
        /// <param name="periodoMensual">Periodo mensual (1-12)</param>
        /// <param name="periodoTrimestral">Periodo trimestral (1-4)</param>
        /// <param name="ano">Año de procesamiento</param>
        /// <param name="excelFileName">Nombre del archivo Excel original</param>
        /// <param name="internalFileName">Nombre interno del archivo</param>
        /// <returns>Resultado del procesamiento</returns>
        public static Architect.Sugese.Domain.Result ProcesaArchivo(string modelo, int periodoMensual, int periodoTrimestral, int ano, string excelFileName, string internalFileName)
        {
            // Validación de parámetros de entrada
            if (modelo.IsEmpty())
                return CreateErrorResult("El parámetro 'modelo' es requerido.", -1);

            if (internalFileName.IsEmpty())
                return CreateErrorResult("El parámetro 'internalFileName' es requerido.", -2);

            var result = new Architect.Sugese.Domain.Result
            {
                Success = false,
                Code = 0,
                Reason = string.Empty
            };

            string serverPath = null;
            string xmlFileName = null;
            string xlsxFileName = null;
            string lastXlsxFileName = null;

            try
            {
                // Autorización de seguridad
                //Architect.API.Core.Business.Common.RoleAuthorized("Sugese");

                // Construcción de rutas de archivos
                serverPath = System.Web.HttpContext.Current.Server.MapPath("../files");
                xmlFileName = Path.Combine(serverPath, $"{modelo}.xml");
                xlsxFileName = Path.Combine(serverPath, internalFileName);
                lastXlsxFileName = Path.Combine(serverPath, $"{modelo}.xlsx");

                // Validación de existencia del archivo
                if (!File.Exists(xlsxFileName))
                {
                    return CreateErrorResult($"El archivo '{xlsxFileName}' no existe.", -3);
                }

                // Copia de seguridad del archivo
                File.Copy(xlsxFileName, lastXlsxFileName, true);

                // Procesamiento del modelo
                DataTable excelProcessResult = ProcessModel(modelo, xlsxFileName, xmlFileName, periodoMensual, periodoTrimestral, ano);

                // Evaluación de resultados
                if (excelProcessResult != null && excelProcessResult.Rows.Count > 0)
                {
                    Utility.Helpers.XmlRespose.ExcelUpdateResult(lastXlsxFileName, excelProcessResult);
                    result.Code = 100;
                    result.Reason = $"La validación del modelo ha generado {excelProcessResult.Rows.Count} error(es)";
                }
                else
                {
                    result.Success = true;
                }

                // Archivo histórico con timestamp
                string archivoHistorico = Path.Combine(
                    serverPath,
                    $"{modelo}.{ano}.{periodoTrimestral}.{periodoMensual}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
                );
                File.Copy(xlsxFileName, archivoHistorico, true);

                // Registro de auditoría
                string mensajeAuditoria = $"  Se procesó {(result.Success ? "de forma exitosa" : "con errores")} el archivo {xlsxFileName} para el modelo {modelo}";
                //API.Core.DataAccess.Extend.NavigationTrace.Track(mensajeAuditoria);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                result.Success = false;
                result.Code = -100;
                result.Reason = "No tiene permisos para ejecutar esta operación.";
                result.Detail = uaEx.Message;

                Architect.Utilities.Log.ErrorLog("ProcesaArchivo", "Error de autorización", uaEx);
                //API.Core.DataAccess.Extend.NavigationTrace.Track($"  Error de autorización: {uaEx.Message}");
            }
            catch (FileNotFoundException fnfEx)
            {
                result.Success = false;
                result.Code = -101;
                result.Reason = $"Archivo no encontrado: {fnfEx.FileName}";
                result.Detail = fnfEx.Message;

                Architect.Utilities.Log.ErrorLog("ProcesaArchivo", "Archivo no encontrado", fnfEx);
                //API.Core.DataAccess.Extend.NavigationTrace.Track($"  Error: Archivo no encontrado - {fnfEx.FileName}");
            }
            catch (IOException ioEx)
            {
                result.Success = false;
                result.Code = -102;
                result.Reason = "Error de entrada/salida al procesar el archivo.";
                result.Detail = ioEx.Message;

                Architect.Utilities.Log.ErrorLog("ProcesaArchivo", "Error de I/O", ioEx);
                //API.Core.DataAccess.Extend.NavigationTrace.Track($"  Error de I/O: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Code = -999;
                result.Reason = "Ha ocurrido un error inesperado al tratar de procesar el archivo excel.";
                result.Detail = $"{ex.GetType().Name}: {ex.Message}";

                Architect.Utilities.Log.ErrorLog("ProcesaArchivo", result.Reason, ex);
                //API.Core.DataAccess.Extend.NavigationTrace.Track($"  Error inesperado: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Procesa el modelo específico utilizando el procesador correspondiente
        /// </summary>
        private static DataTable ProcessModel(string modelo, string xlsxFileName, string xmlFileName, int periodoMensual, int periodoTrimestral, int ano)
        {
            if (!ModelProcessors.TryGetValue(modelo, out var processor))
            {
                throw new ArgumentException($"El modelo '{modelo}' no es válido o no está soportado.", nameof(modelo));
            }

            // Determinar si el modelo es trimestral
            bool esTrimestral = EsModeloTrimestral(modelo);
            int periodo = esTrimestral ? periodoTrimestral : periodoMensual;

            return processor(xlsxFileName, xmlFileName, periodo, ano);
        }

        /// <summary>
        /// Determina si un modelo es trimestral basado en su nombre
        /// </summary>
        private static bool EsModeloTrimestral(string modelo)
        {
            var modelosTrimestrales = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "BalanceGeneral",
                "Canales",
                "CuentasTecnicas",
                "Patrimonio",
                "Produccion",
                "Resultados",
                "RunOff"
            };

            return modelosTrimestrales.Contains(modelo);
        }

        /// <summary>
        /// Crea un objeto Result con un error específico
        /// </summary>
        private static Architect.Sugese.Domain.Result CreateErrorResult(string reason, int code)
        {
            return new Architect.Sugese.Domain.Result
            {
                Success = false,
                Code = code,
                Reason = reason,
                Detail = string.Empty
            };
        }
    }
}