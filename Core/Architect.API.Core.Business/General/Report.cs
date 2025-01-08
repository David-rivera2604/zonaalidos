using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Funciones de soporte a reportes.
    /// </summary>
    public static class Report
    {

        /// <summary>
        /// Permite la generación de un reporte.
        /// </summary>
        /// <param name="reportName">Nombre del reporte</param>
        /// <param name="data">Objeto con los datos a ser procesado por el reporte</param>
        /// <param name="outputFileName">Nombre del archivo resultante</param>
        /// <returns>Nombre del archivo PDF generado por el reporte.</returns>
        public async static Task<string> GeneratePDFFile(string reportName, object data, string outputFileName = "")
        {
            string result = string.Empty;
            try
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Source = JsonConvert.SerializeObject(data),
                    ReportName = reportName
                });

                using (HttpClient client = new HttpClient())
                {
                    var url = Utilities.Helpers.Settings.StringValue("app.api.base") +
                              Utilities.Helpers.Settings.StringValue("Aliados.URL.Report.Service", "/AliadoServReports/Report/Build");
                    var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string resultResponse = await response.Content.ReadAsStringAsync();
                        JObject jsonvalues = JObject.Parse(resultResponse);

                        JToken dataToken = jsonvalues.SelectToken("data");
                        if (dataToken != null && !string.IsNullOrEmpty(dataToken.Value<string>()))
                        {

                            byte[] imageBytes = Convert.FromBase64String(jsonvalues.SelectToken("data").Value<string>());
                            result = ConfigurationManager.AppSettings["Attachments.Path"];
                            if (!string.IsNullOrEmpty(outputFileName))
                            {
                                result += outputFileName + ".pdf";
                            }
                            else
                            {
                                result += Guid.NewGuid().ToString() + ".pdf";
                            }
                            using (var stream = new FileStream(result, FileMode.Create))
                            {
                                await stream.WriteAsync(imageBytes, 0, imageBytes.Length);
                            }
                        }
                        else
                        {
                            string reason = jsonvalues.TokenStringValue("reason");
                            throw new Exception($"Ha ocurrido un error al tratar de generar el reporte. {reason}");
                        }
                    }
                    else
                    {
                        throw new Utilities.Exceptions.CustomException($"Error in response: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on the logging framework being used)
                throw new Utilities.Exceptions.CustomException("An error occurred while generating the PDF file.", ex);
            }
            return result;
        }

    }
}
