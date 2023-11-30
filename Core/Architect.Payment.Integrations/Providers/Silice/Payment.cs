using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Silice
{
    public static class Payment
    {

        public async static Task<string> signin(HttpClient client)
        {
            string result = string.Empty;
            var json = JsonConvert.SerializeObject(new
            {
                username = Utilities.Helpers.Settings.StringValue("Payment.Silice.Login"),
                password = Utilities.Helpers.Settings.StringValue("Payment.Silice.SecretKey")
            });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            client.DefaultRequestHeaders.Authorization = null;
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Silice.urlBase") + "/v2/auth/signin", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                resultResponse = response.Content.ReadAsStringAsync().Result;

                if (resultResponse.IsNotEmpty())
                {
                    JObject jsonvalues = JObject.Parse(resultResponse);

                    result = jsonvalues.TokenStringValue("data.token");
                }
            }

            return result;
        }

        public async static Task<string> recibo(HttpClient client, Architect.Payment.Integrations.Contracts.v2.PaymentInformation payInfov2)
        {
            string reciboId = string.Empty;


            var json = JsonConvert.SerializeObject(payInfov2);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            // HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Silice.urlBase") + "/v2/recibo/shopping_car", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && resultResponse.IsNotEmpty())
            {
                JObject jsonvalues = JObject.Parse(resultResponse);

                reciboId = jsonvalues.TokenStringValue("reciboId");

            }

            return reciboId;
        }

        public async static Task<string> CobroSendEmail(HttpClient client, string reciboId, string email)
        {
            string result = "Error. Falla al intentar enviar el enlace de pago al correo electrónico " + email + " del cliente";
            var json = JsonConvert.SerializeObject(new { reciboId = reciboId });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Silice.urlBase") + "/v2/cobro/sendEmail", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && resultResponse.IsNotEmpty())
            {
                JObject jsonvalues = JObject.Parse(resultResponse);

                if (jsonvalues.TokenStringValue("status").Equals("true", StringComparison.CurrentCultureIgnoreCase))
                {
                    result = "El enlace de pago fue enviado al correo electrónico " + email + " del cliente";
                }
                else
                {
                    result = "Error. " + jsonvalues.TokenStringValue("menssage");
                }
            }

            return result;
        }

        public async static Task<string> CobroMensajeAutomata(HttpClient client, string reciboId, string phone)
        {
            string result = "Error. Falla al intentar enviar el enlace de pago al teléfono " + phone + " del cliente";
            var json = JsonConvert.SerializeObject(new { reciboId = reciboId });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Silice.urlBase") + "/v2/cobro/mensajeAutomata", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && resultResponse.IsNotEmpty())
            {
                JObject jsonvalues = JObject.Parse(resultResponse);
                if (jsonvalues.TokenStringValue("status").Equals("true", StringComparison.CurrentCultureIgnoreCase))
                {
                    result = "El enlace de pago fue enviado al teléfono " + phone + " del cliente";
                }
                else
                {
                    result = "Error. " + jsonvalues.TokenStringValue("menssage");
                }
            }

            return result;
        }

    }
}
