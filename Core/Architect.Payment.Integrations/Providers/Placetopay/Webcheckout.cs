using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay
{
    public static class Webcheckout
    {
        public const string ST_PENDING = "PENDING";
        public const string ST_REJECTED = "REJECTED";
        public const string ST_APPROVED = "APPROVED";

        public const string ST_OK = "OK";
        public const string ST_INIT = "INIT";
        public const string ST_FAILED = "FAILED";
        public const string ST_APPROVED_PARTIAL = "APPROVED_PARTIAL";
        public const string ST_PENDING_VALIDATION = "PENDING_VALIDATION";
        public const string ST_REFUNDED = "REFUNDED";
        public const string ST_ERROR = "ERROR";
        public const string ST_UNKNOWN = "UNKNOWN";
        public static readonly string[] STATUSES = new string[] { ST_OK, ST_INIT, ST_FAILED, ST_APPROVED, ST_APPROVED_PARTIAL, ST_REJECTED, ST_PENDING, ST_PENDING_VALIDATION, ST_REFUNDED, ST_ERROR, ST_UNKNOWN };


        public static string NotifySignature(Integrations.Providers.Placetopay.Contracts.NotifyRequest notify, int currency)
        {
            return ByteArrayToString(Sha1(notify.requestId + notify.status.status + notify.status.date + Utilities.Helpers.Settings.StringValue("Payment.Placetopay.SecretKey." + CurrencyConvert(currency.ToString()))));
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public async static void Notify(Integrations.Providers.Placetopay.Contracts.NotifyRequest notify, int currency)
        {
            string currentSignature = Convert.ToString(Sha1(notify.requestId + notify.status.status + notify.status.date + Utilities.Helpers.Settings.StringValue("Payment.Placetopay.SecretKey." + currency)));


        }


        /// <summary>
        /// Solicita la creación de la sesión retorna el identificador y la URL de procesamiento.
        /// </summary>
        public async static Task<Integrations.Contracts.SessionInformation> CreateRequest(Integrations.Contracts.PaymentInformation payInfo, string ipAddress, string userAgent)
        {
            Contracts.SessionResponse session;
            string currency = CurrencyConvert(payInfo.Currency.ToString());

            if (string.IsNullOrEmpty(payInfo.ReturnUrl))
            {
                payInfo.ReturnUrl = "https://dnetix.co/p2p/client";
                payInfo.ReturnUrl = Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl") + "?ref=" + payInfo.Reference;
            }
            Contracts.RedirectRequest sessionRequest = new Contracts.RedirectRequest()
            {
                buyer = new Contracts.Person()
                {
                    name = payInfo.FirstName,
                    surname = payInfo.LastName,
                    email = payInfo.Email,
                    document = payInfo.Document,
                    documentType = IdentificationTypeConvert(payInfo.DocumentType.ToString()),
                    mobile = payInfo.Mobile.OnlyNumbers()
                },
                payment = new Contracts.PaymentRequest()
                {
                    reference = payInfo.Reference,
                    description = payInfo.Description,
                    amount = new Contracts.Amount()
                    {
                        currency = currency,
                        total = payInfo.Amount
                    }
                },
                expiration = DateTime.Now.AddMinutes(Utilities.Helpers.Settings.IntegerValue("Payment.Placetopay.TimeOut", 10)),
                ipAddress = ipAddress,
                returnUrl = payInfo.ReturnUrl,
                userAgent = userAgent,
                paymentMethod = null,
                locale = "es_CR",
                auth = BuildAuth(currency)
            };

            var data = new StringContent(JsonConvert.SerializeObject(sessionRequest), Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl") + "api/session", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                session = JsonConvert.DeserializeObject<Contracts.SessionResponse>(resultResponse);
            }
            else
            {
                session = new Contracts.SessionResponse()
                {
                    status = new Contracts.Status()
                    {
                        date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                        status = ST_FAILED,
                        reason = response.ReasonPhrase
                    }
                };
            }
            return new Integrations.Contracts.SessionInformation()
            {
                Status = session.status.status,
                Reason = session.status.reason,
                RequestId = session.requestId,
                ProcessUrl = session.processUrl,
                rawData = resultResponse
            };
        }

        /// <summary>
        /// Obtiene la información de la sesión, si en la sesión hay transacciones se muestra el detalle de las mismas.
        /// </summary>
        public async static Task<Contracts.InformationRequest> GetRequestInformation(Int64 requestId, int currency)
        {
            Contracts.InformationRequest result = null;
            string resultResponse = string.Empty;
            string json = JsonConvert.SerializeObject(new { auth = BuildAuth(CurrencyConvert(currency.ToString())) });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = new TimeSpan(0, 0, 2) };
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl") + "api/session/" + requestId.ToString(), data);
            if (response.IsSuccessStatusCode)
            {
                resultResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Contracts.InformationRequest>(resultResponse);
                result.rawData = resultResponse;
            }
            else
            {
                result = new Contracts.InformationRequest()
                {
                    status = new Contracts.Status()
                    {
                        date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                        status = ST_FAILED,
                        reason = response.ReasonPhrase
                    },
                    rawData = resultResponse
                };
            }
            return result;
        }

        private static Contracts.Auth BuildAuth(string currency)
        {
            string seed = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
            string nonceRaw = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmsszzz");

            return new Contracts.Auth()
            {
                login = Utilities.Helpers.Settings.StringValue("Payment.Placetopay.Login." + currency),
                tranKey = Convert.ToBase64String(Sha1(nonceRaw + seed + Utilities.Helpers.Settings.StringValue("Payment.Placetopay.SecretKey." + currency))),
                nonce = Convert.ToBase64String(Encoding.ASCII.GetBytes(nonceRaw)),
                seed = seed
            };
        }

        private static byte[] Sha1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(Encoding.ASCII.GetBytes(input));
            }
        }

        private static string CurrencyConvert(string currency)
        {
            string result = string.Empty;
            switch (currency)
            {
                case "1":
                    result = "CRC";
                    break;
                case "2":
                    result = "USD";
                    break;
            }
            return result;
        }

        public static string IdentificationTypeConvert(string identificationType)
        {
            string type = string.Empty;

            switch (identificationType)
            {
                case "1": //Cédula
                case "CNA":
                    type = "CRCPF";
                    break;

                case "2": //Residencia
                case "CRE":
                    type = "DIMEX";
                    break;

                case "4": //Cédula jurídica
                case "CJU":
                    type = "CPJ";
                    break;

                case "3": //Pasaporte
                case "PAS":
                    type = "";
                    break;

                    //DIDI
            }

            return type;
        }


        internal static int StatusConvert(string status)
        {
            int result = 0;
            switch (status)
            {
                case Providers.Placetopay.Webcheckout.ST_INIT:
                    result = 2;
                    break;
                case Providers.Placetopay.Webcheckout.ST_PENDING:
                    result = 3;
                    break;

                case Providers.Placetopay.Webcheckout.ST_APPROVED:
                    result = 4;
                    break;
                case Providers.Placetopay.Webcheckout.ST_REJECTED:
                    result = 5;
                    break;

                case Providers.Placetopay.Webcheckout.ST_FAILED:
                    result = 6;
                    break;
                case Providers.Placetopay.Webcheckout.ST_APPROVED_PARTIAL:
                    result = 7;
                    break;
                case Providers.Placetopay.Webcheckout.ST_PENDING_VALIDATION:
                    result = 8;
                    break;
                case Providers.Placetopay.Webcheckout.ST_REFUNDED:
                    result = 9;
                    break;
                case Providers.Placetopay.Webcheckout.ST_ERROR:
                    result = 10;
                    break;
                case Providers.Placetopay.Webcheckout.ST_UNKNOWN:
                    result = 11;
                    break;
            }
            return result;
        }

    }
}
