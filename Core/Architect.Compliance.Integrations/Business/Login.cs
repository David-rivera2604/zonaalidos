using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Architect.Compliance.Integrations.Business
{
    internal static class Login
    {

        public async static Task<string> GenerateToken()
        {
            string result = string.Empty;

            string json = JsonConvert.SerializeObject(new Contracts.Autenticacion()
            {
                UserName = Utilities.Helpers.Settings.StringValue("Compliance.Username"),
                Password = Utilities.Helpers.Settings.StringValue("Compliance.Password")
            });

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


            HttpResponseMessage response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Compliance.URL.Login") + "/Login",
                                                                    new StringContent(json, Encoding.UTF8, "application/json"));
            string resultResponse = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                JObject jsonvalues = JObject.Parse(resultResponse);
                result = jsonvalues.SelectToken("token").Value<string>();
            }
            else
            {
                Utilities.Log.ErrorLog("Compliance.Login", response.ReasonPhrase);
                Utilities.Log.ErrorLog("Compliance.Login", resultResponse);
            }

            return result;
        }
    }

}
