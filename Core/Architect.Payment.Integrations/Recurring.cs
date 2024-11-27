using Architect.Payment.Integrations.Contracts.v2;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations
{
    public static class Recurring
    {

        public async static void Request(string provider, HttpClient client, Architect.Payment.Integrations.Contracts.v2.ReciboRequest recibos)
        {
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
                        ipAddress = "127.0.0.1",
                        userAgent = "MAPFRE - Aliados"
                    };
                    Providers.Placetopay.Contracts.Responses.Collect collectResponse = await Providers.Placetopay.Webcheckout.Collect(collectRequest);
                }
            }
        }
    }
}
