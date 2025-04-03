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
            string token = await Login.GenerateToken();
            string result = String.Empty;

            string json = JsonConvert.SerializeObject(clientInformation);

            Utilities.Log.WarningLog("load.payload", json, "compliance");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


            HttpResponseMessage response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Compliance.URL.Load") + "/Customers/SendCustomers",
                                                                    new StringContent(json, Encoding.UTF8, "application/json"));
            string resultResponse = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                JObject jsonvalues = JObject.Parse(resultResponse);
                result = jsonvalues.SelectToken("status").Value<string>();
                Utilities.Log.WarningLog("load.result", resultResponse, "compliance");
            }
            else
            {
                Utilities.Log.ErrorLog("Compliance.Customers", response.ReasonPhrase);
                Utilities.Log.ErrorLog("Compliance.Customers", resultResponse);
            }

            return result;
        }
    }

}
