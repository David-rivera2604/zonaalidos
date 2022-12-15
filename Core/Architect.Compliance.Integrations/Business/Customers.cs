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

        public async static Task<int> SendCustomers(Contracts.Clientes clientInformation)
        {
            string token = await Login.GenerateToken();
            int result = 0;

            string json = JsonConvert.SerializeObject(clientInformation);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


            HttpResponseMessage response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Compliance.URL") + "/mapfre-serv-api-load/Customers/SendCustomers",
                                                                    new StringContent(json, Encoding.UTF8, "application/json"));
            string resultResponse = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                JObject jsonvalues = JObject.Parse(resultResponse);
                result = jsonvalues.SelectToken("statusCode").Value<int>();
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
