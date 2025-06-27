using Architect.Payment.Integrations.Contracts.v2;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Architect.Payment.Integrations.Providers.Placetopay;
using System.Text;

namespace Architect.Payment.Integrations
{
    public static class Recurring
    {

        public async static Task<List<Architect.Payment.Integrations.Contracts.InformationRequest>> Request(string provider, HttpClient client, Architect.Payment.Integrations.Contracts.v2.ReciboRequest recibos)
        {
            List<Architect.Payment.Integrations.Contracts.InformationRequest> infoResult = new List<Contracts.InformationRequest>();

            if (provider.Equals("Silice", StringComparison.CurrentCultureIgnoreCase))
            {

                string token = Architect.Payment.Integrations.Providers.Silice.Payment.signin(client).Result;
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string result = Architect.Payment.Integrations.Providers.Silice.Payment.RecibosRecurrentes(client, recibos).Result;
            }
            else //Placetopay Provider 
            {
                var trace = new StringBuilder();

                trace.AppendFormat("\nProceso #{1}, cantidad de recibos a procesar #{0}\n", recibos.items.Count, recibos.procesoId);

                foreach (Item item in recibos.items)
                {
                    Providers.Placetopay.Contracts.Requests.Collect collectRequest = new Providers.Placetopay.Contracts.Requests.Collect()
                    {
                        auth = Providers.Placetopay.Webcheckout.BuildAuth("Recurring", item.moneda),
                        payer = new Person()
                        {
                            name = item.firstname,
                            surname = item.lastname,
                            email = item.emailCliente,
                            document = item.document,
                            documentType = Webcheckout.IdentificationTypeConvert(item.documenttype),
                            mobile = item.mobile
                        },
                        payment = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.PaymentRequest()
                        {
                            reference = item.ordenId,
                            description = item.concepto,
                            amount = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.Amount()
                            {
                                currency = item.moneda,
                                total = Convert.ToDouble(item.total)
                            }
                        },
                        instrument = new Architect.Payment.Integrations.Providers.Placetopay.Contracts.Instrument()
                        {
                            token = new Token()
                            {
                                token = item.token
                            }
                        },
                        expiration = DateTime.Now.AddMinutes(Utilities.Helpers.Settings.IntegerValue("Payment.Placetopay.TimeOut", 10)),
                        locale = "es_CR",
                        ipAddress = "127.0.0.1",
                        userAgent = "MAPFRE - Aliados",
                        returnUrl = Utilities.Helpers.Settings.StringValue("Payment.Placetopay.ReturnUrl.Recurring")
                    };
                    string json = JsonConvert.SerializeObject(collectRequest, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                    
                    trace.AppendFormat("  Información: {0}\n", item.concepto);
                    trace.AppendFormat("    Solicitud: {0}\n",  json);
                    
                    CollectTransaction collectResponse = await Providers.Placetopay.Webcheckout.Collect(json);
                    trace.AppendFormat("    Respuesta: {0}\n", collectResponse.rawresponse);

                    Architect.Payment.Integrations.Contracts.InformationRequest infoItem = new Architect.Payment.Integrations.Contracts.InformationRequest()
                    {
                        status = collectResponse.status.status,
                        ipAddress = collectRequest.userAgent,
                        rawData = collectResponse.rawresponse
                    };

                    switch (collectResponse.status.status)
                    {
                        case "APPROVED":

                            infoItem.description = item.concepto;
                            infoItem.reference = collectResponse.reference;

                            infoItem.payerName = item.firstname;
                            infoItem.payerSurname = item.lastname;
                            infoItem.date = collectResponse.status.date;
                            infoItem.currency = collectResponse.amount.currency;
                            infoItem.total = collectResponse.amount.total;
                            infoItem.paymentMethodName = collectResponse.franchise;
                            infoItem.lastDigits = collectResponse.lastDigits;
                            infoItem.authorization = collectResponse.authorization;
                            infoItem.receipt = collectResponse.receipt;
                            infoItem.message = collectResponse.status.message;

                            break;
                        case "REJECTED":
                            infoItem.description = item.concepto;
                            infoItem.reference = collectResponse.reference;
                            infoItem.currency = item.moneda;
                            infoItem.total = collectResponse.amount.total;
                            infoItem.message = collectResponse.status.message;
                            infoItem.date = collectResponse.status.date;
                            break;
                        default:
                            infoItem.reference = item.ordenId;
                            infoItem.message = collectResponse.status.message;
                            break;

                    }

                    infoResult.Add(infoItem);
                }

                Utilities.Log.TraceLog("Recurring.Request", trace.ToString(), "payment");
            }
            return infoResult;
        }
    }
}
