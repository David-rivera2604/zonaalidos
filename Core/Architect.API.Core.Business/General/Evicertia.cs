using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Soporte de integración a Evicertia.
    /// </summary>
    public static class Evicertia
    {

        private static HttpClient eviCertiaClient = new HttpClient();


        /// <summary>
        /// Permite la remisión a EVICERTIA de una carta o documento notarial
        /// </summary>
        /// <param name="lookupKey">Identificador asignado por el usuario, que puede ser utilizado posteriormente para localizar una evidencia mediante el servicio web de consultas</param>
        /// <param name="subject"></param>
        /// <param name="signingName">Nombre del destinatario del mensaje.</param>
        /// <param name="signingEmail">Dirección e-mail del destinatario del mensaje</param>
        /// <param name="fileName">Nombre de archivo, documento o carta a firmar por las partes (PDF en Base64).</param>
        /// <param name="signingMethod">Tipo de firma. WebClick</param>
        /// <returns></returns>
        public async static Task<string> EviSignSubmit(string lookupKey, string subject, string signingName, string signingEmail, string fileName, string signingMethod = "WebClick")
        {
            string result = string.Empty;
            var json = JsonConvert.SerializeObject(new Architect.API.Core.Contracts.EviSign.SignSubmit()
            {
                LookupKey = lookupKey,
                Subject = subject,
                Document = Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName)),
                SigningParties = new List<Contracts.EviSign.SigningParty>() {
                    new Architect.API.Core.Contracts.EviSign.SigningParty()
                    {
                        Name = signingName,
                        Address = signingEmail,
                        SigningMethod = signingMethod
                    } }
            });
            eviCertiaClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["Evicertia.Authentication"]);
            HttpResponseMessage response = await eviCertiaClient.PostAsync(ConfigurationManager.AppSettings["Evicertia.URL.EviSignSubmit"], new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string resultResponse = response.Content.ReadAsStringAsync().Result;

                JObject jsonvalues = JObject.Parse(resultResponse);

                result = jsonvalues.SelectToken("uniqueId").Value<string>();
            }
            else
            {
                Utilities.Log.ErrorLog("EviSignSubmit", response.ReasonPhrase);
            }
            return result;
        }

        public async static Task<Architect.API.Core.Contracts.EviSign.EviSignQueryResult> EviSignQuery(string uniqueIds = "4bd687422b4e4a3d9c1dacde016d6938", bool includeAffidavits = false)
        {
            Architect.API.Core.Contracts.EviSign.EviSignQueryResult result = null;
            string urlComplement = string.Empty;
            if (includeAffidavits)
            {
                urlComplement = "&includeAffidavitBlobsOnResult=true&includeAffidavitsOnResult=true";
            }

            eviCertiaClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["Evicertia.Authentication"]);
            eviCertiaClient.DefaultRequestHeaders.Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await eviCertiaClient.GetAsync(ConfigurationManager.AppSettings["Evicertia.URL.EviSignQuery"] + "?WithUniqueIds=" + uniqueIds + "&includeEventsOnResult=true" + urlComplement);
            if (response.IsSuccessStatusCode)
            {
                string resultResponse = response.Content.ReadAsStringAsync().Result;
                //Utilities.Log.TraceLog("EviSignQuery.resultResponse", resultResponse);
                result = JsonConvert.DeserializeObject<Architect.API.Core.Contracts.EviSign.EviSignQueryResult>(resultResponse);
            }
            else
            {
                Utilities.Log.ErrorLog("EviSignQuery", response.ReasonPhrase);
            }
            return result;
        }


    }
}
