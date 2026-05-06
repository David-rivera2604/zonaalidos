using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Compliance.Integrations.Business
{
    public static class Customers
    {

        public async static Task<string> SendCustomers(Contracts.Clientes clientInformation)
        {
            var session = Architect.API.Core.Business.Traza.TrackRequest.NewSession(
                new Architect.API.Core.Contracts.Security.Token() { CompanyId = clientInformation.codigoCompania, UserId = clientInformation.usuario },
                "Compliance/Customers/SendCustomers",
                clientInformation,
                "",
                clientInformation.clientesPolizas != null && clientInformation.clientesPolizas.Count > 0 ? clientInformation.clientesPolizas[0].numeroPoliza : string.Empty,
                clientInformation.numeroIdentificacion,
                clientInformation.nombreCliente);

            string token = await Login.GenerateToken();
            string result = String.Empty;
            string resultResponse = string.Empty;

            try
            {
                string json = JsonConvert.SerializeObject(clientInformation);

                Utilities.Log.WarningLog("load.payload", json, "compliance");

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


                HttpResponseMessage response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Compliance.URL.Load") + "/Customers/SendCustomers",
                                                                        new StringContent(json, Encoding.UTF8, "application/json"));
                resultResponse = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    JObject jsonvalues = JObject.Parse(resultResponse);
                    result = jsonvalues.SelectToken("status").Value<string>();
                    Utilities.Log.WarningLog("load.result", resultResponse, "compliance");
                }
                else
                {
                    session.ResponseStatus = (int)response.StatusCode;
                    session.ResponseText = response.ReasonPhrase;

                    Utilities.Log.ErrorLog("Compliance.Customers", response.ReasonPhrase);
                    Utilities.Log.ErrorLog("Compliance.Customers", resultResponse);
                }
            }
            catch (Exception ex)
            {
                string code = Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 500;
                session.ResponseText = $"{ex.Message} ({code})";
            }

            Architect.API.Core.Business.Traza.TrackRequest.CloseSession(session, string.IsNullOrEmpty(resultResponse) ? result : resultResponse);

            return result;
        }
    }

}
