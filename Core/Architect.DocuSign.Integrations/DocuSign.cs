using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Architect.DocuSign.Integrations
{

    public static class DocuSign
    {
        //     private static HttpClient eviCertiaClient = new HttpClient();

        /// <summary>
        /// Permite la remisión a EVICERTIA de una carta o documento notarial
        /// </summary>
        /// <param name="lookupKey">Identificador asignado por el usuario, que puede ser utilizado posteriormente para localizar una evidencia mediante el servicio web de consultas</param>
        /// <param name="subject"></param>
        /// <param name="signingName">Nombre del destinatario del mensaje.</param>
        /// <param name="signingEmail">Dirección e-mail del destinatario del mensaje</param>
        /// <param name="fileName">Nombre de archivo, documento o carta a firmar por las partes (PDF en Base64).</param>
        /// <param name="signingMethod">Tipo de firma. WebClick</param>
        public async static Task<Contracts.SubmitResult> Submit(string lookupKey, string subject, string signingName, string signingEmail, string fileName, string signingMethod = "WebClick", bool includeCallback = false)
        {
            Contracts.SubmitResult result = new Contracts.SubmitResult() { UniqueId = String.Empty };
            string callbackURL = string.Empty;
            if (includeCallback)
            {
                //https://www.google.com/?uniqueId=890ead9f-9c78-4a34-acbf-aeb4003dedbf&accepted=True
                callbackURL = $"{Utilities.Helpers.Settings.StringValue("Aliados.URL.Base")}/DocuSign/Notify";
            }
            if (lookupKey.Length > 35)
            {
                lookupKey = lookupKey.Substring(0, 35);
            }


            string json = JsonConvert.SerializeObject(new Providers.Evicertia.Contracts.SignSubmit()
            {
                LookupKey = lookupKey,
                Subject = subject,
                Document = Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName)),
                Options = new Providers.Evicertia.Contracts.Options()
                {
                    signedRedirectUrl = callbackURL
                },
                SigningParties = new List<Providers.Evicertia.Contracts.SigningParty>() {
                    new Providers.Evicertia.Contracts.SigningParty()
                    {
                        Name = signingName,
                        Address = signingEmail,
                        SigningMethod = signingMethod
                    } }
            });
            HttpClient eviCertiaClient = new HttpClient();
            eviCertiaClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Utilities.Helpers.Settings.StringValue("Evicertia.Authentication"));
            eviCertiaClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            eviCertiaClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            try
            {
                HttpResponseMessage response = await eviCertiaClient.PostAsync(Utilities.Helpers.Settings.StringValue("Evicertia.URL.EviSignSubmit"), new StringContent(json, Encoding.UTF8, "application/json"));
                string resultResponse = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    JObject jsonvalues = JObject.Parse(resultResponse);
                    result.UniqueId = jsonvalues.SelectToken("uniqueId").Value<string>();
                }
                else
                {
                    Utilities.Log.ErrorLog("EviSignSubmit", response.ReasonPhrase);
                    Utilities.Log.ErrorLog("EviSignSubmit", resultResponse);
                }
            }
            catch (Exception ex)
            {
                eviCertiaClient.Dispose();
                eviCertiaClient = new HttpClient();
                throw ex;
            }


            return result;
        }

        public async static Task<Contracts.QueryResult> Query(string uniqueIds = "4bd687422b4e4a3d9c1dacde016d6938", bool includeAffidavits = false)
        {
            Contracts.QueryResult result = null;
            string urlComplement = string.Empty;
            if (includeAffidavits)
            {
                urlComplement = "&includeAffidavitBlobsOnResult=true&includeAffidavitsOnResult=true";
            }
            HttpClient eviCertiaClient = new HttpClient();
            eviCertiaClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Utilities.Helpers.Settings.StringValue("Evicertia.Authentication"));
            eviCertiaClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            eviCertiaClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            try
            {
                HttpResponseMessage response = await eviCertiaClient.GetAsync($"{Utilities.Helpers.Settings.StringValue("Evicertia.URL.EviSignQuery")}?WithUniqueIds={uniqueIds}&includeEventsOnResult=true{urlComplement}");
                string resultResponse = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    //Utilities.Log.TraceLog("EviSignQuery.resultResponse", resultResponse);
                    Providers.Evicertia.Contracts.EviSignQueryResult iresult = JsonConvert.DeserializeObject<Providers.Evicertia.Contracts.EviSignQueryResult>(resultResponse);
                    if (iresult?.results?.Length > 0)
                    {
                        result = new Contracts.QueryResult()
                        {
                            outcome = iresult.results[0].outcome,
                            affidavits = new List<Contracts.affidavits>()
                        };
                        foreach (Providers.Evicertia.Contracts.affidavits affidavit in iresult.results[0].affidavits)
                        {
                            result.affidavits.Add(new Contracts.affidavits()
                            {
                                description = affidavit.description,
                                bytes = affidavit.bytes,
                                kind = affidavit.kind,
                                Signed = affidavit.kind.Equals("EviSign:Main", StringComparison.CurrentCultureIgnoreCase)
                            });
                        }
                    }
                }
                else
                {
                    Utilities.Log.ErrorLog("EviSignQuery", response.ReasonPhrase);
                    Utilities.Log.ErrorLog("EviSignSubmit", resultResponse);
                }
            }
            catch (Exception ex)
            {
                eviCertiaClient.Dispose();
                eviCertiaClient = new HttpClient();
                throw ex;
            }
            return result;
        }

    }
}
