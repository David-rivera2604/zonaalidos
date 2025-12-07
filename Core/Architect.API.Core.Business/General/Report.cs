using Architect.API.Core.Contracts.Security;
using Architect.Utilities;
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
using System.Text.Json.Nodes;
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
        public async static Task<string> Generate(int companyId, string reportName, object data, string outputFileName = "")
        {
            string result = string.Empty;

            RestClient client = new RestClient(Settings.URLRelativeAndFullValue(companyId, "aliados.api.report.url", "aliados.api.url.base", "AliadoServReports"),
                                               $"Generación de PDF o reporte {reportName}");
            Contracts.General.Report report = await client.PostAsync<Contracts.General.Report, Contracts.General.Report>(
                                                "Report/Build",
                                                new Contracts.General.Report
                                                {
                                                    Source = JsonConvert.SerializeObject(data),
                                                    ReportName = reportName
                                                });

            if (!string.IsNullOrEmpty(report?.data))
            {
                byte[] imageBytes = Convert.FromBase64String(report.data);
                result =  "aliados.app.path.temp".StringValue(companyId);
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
                throw new Exception($"Ha ocurrido un error al tratar de generar el reporte {reportName}. {report.reason}");
            }

            return result;
        }

    }
}
