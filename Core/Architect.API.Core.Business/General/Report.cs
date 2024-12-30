using Architect.API.Core.Contracts.Security;
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
            string json = JsonConvert.SerializeObject(new
            {
                Source = JsonConvert.SerializeObject(data),
                ReportName = reportName
            });

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("app.api.base") + Utilities.Helpers.Settings.StringValue("Aliados.URL.Report.Service", "/AliadoServReports/Report/Build"), new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string resultResponse = response.Content.ReadAsStringAsync().Result;

                JObject jsonvalues = JObject.Parse(resultResponse);

                byte[] imageBytes = Convert.FromBase64String(jsonvalues.SelectToken("data").Value<string>());
                result = ConfigurationManager.AppSettings["Attachments.Path"];
                if (outputFileName != "")
                {
                    result += outputFileName + ".pdf";
                }
                else
                {
                    result += Guid.NewGuid().ToString() + ".pdf";
                }
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    stream.Write(imageBytes, 0, imageBytes.Length);
                    stream.Flush();
                }
            }
            return result;
        }

    }
}
