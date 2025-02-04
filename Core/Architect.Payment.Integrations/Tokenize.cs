using Architect.Payment.Integrations.Contracts.v2;
using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations
{
    public static class Tokenize
    {
        public async static Task<List<DatosTarjeta>> Request(string provider, HttpClient client, List<DatosTarjeta> datosTajetas)
        {
            List<DatosTarjeta> result = null;

            if (provider.Equals("Silice", StringComparison.CurrentCultureIgnoreCase))
            {
                string token = Architect.Payment.Integrations.Providers.Silice.Payment.signin(client).Result;
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                result = Architect.Payment.Integrations.Providers.Silice.Payment.Tokenize(client, datosTajetas).Result;
            }
            else
            {
                Integrations.Providers.Placetopay.Contracts.Responses.Tokenize tokenResult;
                Utilities.Log.TraceLog("Placetopay Tokenize list", JsonConvert.SerializeObject(datosTajetas), "payment");

                foreach (DatosTarjeta tarjeta in datosTajetas)
                {
                    Auth auth = Providers.Placetopay.Webcheckout.BuildAuth("Recurring", "CRC");
                    tarjeta.key = tarjeta.number;
                    var body = new Providers.Placetopay.Contracts.Requests.Tokenize()
                    {
                        auth = auth,
                        payer = new Person()
                        {
                            name = tarjeta.holder_name,
                            email = tarjeta.email
                        },
                        instrument = new Instrument()
                        {
                            card = new Card()
                            {
                                number = tarjeta.number,
                                expiration = $"{tarjeta.expiry_month}/{tarjeta.expiry_year}"
                            }
                        },
                        ipAddress = "127.0.0.1",
                        userAgent = "MAPFRE - Aliados"
                    };
                    tokenResult = await Architect.Payment.Integrations.Providers.Placetopay.Webcheckout.Tokenize(body);

                    if (tokenResult.status.status == Providers.Placetopay.Webcheckout.ST_OK)
                    {
                        tarjeta.status = true;
                        tarjeta.token = tokenResult.instrument.token.token;                        
                        tarjeta.card = new string('*', tarjeta.number.Length - tokenResult.instrument.token.lastDigits.Length) + tokenResult.instrument.token.lastDigits;
                        
                    }
                    else
                    {
                        tarjeta.status = false;
                        tarjeta.reason = tokenResult.status.message;

                        Utilities.Log.ErrorLog("Placetopay.Payment.Tokenize", tokenResult.status.message);
                        Utilities.Log.ErrorLog("Placetopay.Payment.Tokenize", tokenResult.status.reason);
                    }

                }
                result = datosTajetas;
            }

            return result;
        }

        public async static Task Invalid(string provider, HttpClient client, string token)
        {
            List<DatosTarjeta> result = null;

            if (provider.Equals("Evertec", StringComparison.CurrentCultureIgnoreCase))
            {

                Integrations.Providers.Placetopay.Contracts.Responses.Tokenize tokenResult;
                Auth auth = Providers.Placetopay.Webcheckout.BuildAuth("Recurring", "CRC");
                var body = new Providers.Placetopay.Contracts.Requests.Tokenize()
                {
                    auth = auth,
                    instrument = new Instrument()
                    {
                        token = new Token()
                        {
                            token = token
                        }
                    },
                    ipAddress = "127.0.0.1",
                    userAgent = "MAPFRE - Aliados"
                };
                tokenResult = await Architect.Payment.Integrations.Providers.Placetopay.Webcheckout.InvalidateToken(body);

            }

        }

    }
}
