using Architect.Payment.Integrations.Contracts.v2;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
                foreach (Item item in recibos.items)
                {
                    Providers.Placetopay.Contracts.Requests.Collect collectRequest = new Providers.Placetopay.Contracts.Requests.Collect()
                    {
                        auth = Providers.Placetopay.Webcheckout.BuildAuth("Recurring", item.moneda),
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
                        userAgent = "MAPFRE - Aliados"
                    };
                    Providers.Placetopay.Contracts.Responses.Collect collectResponse = await Providers.Placetopay.Webcheckout.Collect(collectRequest);

                    Architect.Payment.Integrations.Contracts.InformationRequest infoItem = new Architect.Payment.Integrations.Contracts.InformationRequest()
                    {
                        status = collectResponse.status.status,
                        ipAddress = collectResponse.request?.userAgent,
                        rawData = string.Empty
                    };

                    switch (collectResponse.status.status)
                    {
                        case "APPROVED":
                        case "PENDING":
                            Transaction payment = collectResponse.payment.First();
                            infoItem.date = payment.status.date;
                            infoItem.description = collectResponse.request.payment.description;
                            infoItem.reference = collectResponse.request.payment.reference;
                            infoItem.currency = payment.amount.to.currency;
                            infoItem.total = payment.amount.to.total;
                            infoItem.paymentMethodName = payment.paymentMethodName;
                            infoItem.lastDigits = payment.processorFields?.Find(r => r.keyword == "lastDigits")?.value;
                            infoItem.authorization = payment.authorization;
                            infoItem.receipt = payment.receipt;
                            infoItem.message = payment.status.message;
                            infoItem.payerName = collectResponse.request?.payer?.name;
                            infoItem.payerSurname = collectResponse.request?.payer?.surname;
                            break;
                        case "REJECTED":
                            PaymentRequest paymentr = collectResponse.request.payment;
                            infoItem.description = collectResponse.request.payment.description;
                            infoItem.reference = collectResponse.request.payment.reference;
                            infoItem.currency = paymentr.amount.currency;
                            infoItem.total = paymentr.amount.total;
                            infoItem.message = collectResponse.status.message;
                            infoItem.date = collectResponse.status.date;
                            break;
                    }

                    infoResult.Add(infoItem);
                }
            }
            return infoResult;
        }
    }
}
