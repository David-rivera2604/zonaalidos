using Architect.Payment.Integrations.Providers.Placetopay.Contracts;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay
{
    internal static class Webcheckout
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


        public static string NotifySignature(Architect.Payment.Integrations.Contracts.NotifyRequest notify, int currency, int settingId, int companyId)
        {
            return ByteArrayToString(Sha1(notify.requestId + notify.status.status + notify.status.date + SecretKey(0, CurrencyConvert(currency.ToString()), settingId, companyId)));
        }

        /// <summary>
        /// Solicita la creación de la sesión retorna el identificador y la URL de procesamiento.
        /// </summary>
        public async static Task<Integrations.Contracts.SessionInformation> CreateRequest(Integrations.Contracts.PaymentInformation payInfo, string ipAddress, string userAgent, int userId, int companyId)
        {
            Contracts.SessionResponse session;
            string prefix = Utilities.Helpers.Settings.StringValue("EMail.Test", string.Empty);
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
                    email = prefix.IsEmpty() ? payInfo.Email : prefix,
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
                    },
                    subscribe = true
                },
                //subscription = new Subscription()
                //{
                //    reference = $"{payInfo.DocumentType}-{payInfo.Document}",
                //    description = "Suscripción automática en el app de aliados"
                //},
                expiration = DateTime.Now.AddMinutes(Utilities.Helpers.Settings.IntegerValue("Payment.Placetopay.TimeOut", 10)),
                ipAddress = ipAddress,
                returnUrl = payInfo.ReturnUrl,
                userAgent = userAgent,
                paymentMethod = null,
                locale = "es_CR",
                auth = BuildAuth(userId, currency, 0, companyId)
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
                SettingId = Business.PaymentSettings.Retrieve(companyId, userId, currency).Id,
                rawData = resultResponse
            };
        }

        /// <summary>
        /// Obtiene la información de la sesión, si en la sesión hay transacciones se muestra el detalle de las mismas.
        /// </summary>
        public async static Task<Architect.Payment.Integrations.Contracts.InformationRequest> GetRequestInformation(Int64 requestId, int currency, int settingId, int companyId)
        {
            Architect.Payment.Integrations.Contracts.InformationRequest result = null;
            string resultResponse = string.Empty;
            string json = JsonConvert.SerializeObject(new { auth = BuildAuth(0, CurrencyConvert(currency.ToString()), settingId, companyId) });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = new TimeSpan(0, 0, 2) };
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl") + "api/session/" + requestId.ToString(), data);
            if (response.IsSuccessStatusCode)
            {
                resultResponse = await response.Content.ReadAsStringAsync();
                Contracts.Requests.Information internalResult = JsonConvert.DeserializeObject<Contracts.Requests.Information>(resultResponse);
                internalResult.rawData = resultResponse;

                result = new Architect.Payment.Integrations.Contracts.InformationRequest()
                {
                    status = internalResult.status.status,
                    ipAddress = internalResult.request?.userAgent,
                    rawData = resultResponse
                };

                switch (internalResult.status.status)
                {
                    case "APPROVED":
                    case "PENDING":
                        if (internalResult.payment?.Count() > 0)
                        {
                            Contracts.Transaction payment = internalResult.payment.First();
                            result.date = payment.status.date;
                            result.description = internalResult.request.payment.description;
                            result.reference = internalResult.request.payment.reference;
                            result.currency = payment.amount.to.currency;
                            result.total = payment.amount.to.total;
                            result.paymentMethodName = payment.paymentMethodName;
                            result.lastDigits = payment.processorFields?.Find(r => r.keyword == "lastDigits")?.value;
                            result.authorization = payment.authorization;
                            result.receipt = payment.receipt;
                            result.message = payment.status.message;
                            result.payerName = internalResult.request?.payer?.name;
                            result.payerSurname = internalResult.request?.payer?.surname;
                            if (internalResult.request != null && internalResult.request.payment.subscribe)
                            {
                                result.subscribe = internalResult.request.payment.subscribe;
                            }
                            if (result.subscribe && internalResult?.subscription?.status?.status == ST_OK)
                            {
                                result.instrument = internalResult.subscription.instrument;
                            }
                            else
                            {
                                result.subscribe = false;
                            }
                        }
                        else
                        {
                            result = new Architect.Payment.Integrations.Contracts.InformationRequest()
                            {
                                status = ST_FAILED,
                                reason = response.ReasonPhrase,
                                rawData = resultResponse
                            };
                        }

                        break;
                    case "REJECTED":
                        Contracts.PaymentRequest paymentr = internalResult.request.payment;
                        result.description = internalResult.request.payment.description;
                        result.reference = internalResult.request.payment.reference;
                        result.currency = paymentr.amount.currency;
                        result.total = paymentr.amount.total;
                        result.message = internalResult.status.message;
                        result.date = internalResult.status.date;
                        if (internalResult.request != null && internalResult.request.subscribe)
                        {
                            result.subscribe = internalResult.request.subscribe;
                        }
                        break;
                }

            }
            else
            {
                result = new Architect.Payment.Integrations.Contracts.InformationRequest()
                {
                    status = ST_FAILED,
                    reason = response.ReasonPhrase,
                    rawData = resultResponse
                };
            }
            return result;
        }

        internal static string IdentificationTypeConvert(string identificationType)
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
                    type = "PPN";
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

        internal static string Login(int userId, string currency, int settingId, int companyId)
        {

            Integrations.Contracts.PaymentSettings setting = null;

            if (settingId == 0)
            {
                setting = Business.PaymentSettings.Retrieve(companyId, userId, currency);
            }
            else
            {
                setting = Business.PaymentSettings.Retrieve(companyId, settingId);
            }

            string login = setting.ClientId;
            if (login.IsEmpty())
            {
                login = Utilities.Helpers.Settings.StringValue("Payment.Placetopay.Login." + currency);
            }
            return login;
        }

        internal static string SecretKey(int userId, string currency, int settingId, int companyId)
        {

            Integrations.Contracts.PaymentSettings setting;

            if (settingId == 0)
            {
                setting = Business.PaymentSettings.Retrieve(companyId, userId, currency);
            }
            else
            {
                setting = Business.PaymentSettings.Retrieve(companyId, settingId);
            }
            string secret = setting.SecretKey;
            if (secret.IsEmpty())
            {
                secret = Utilities.Helpers.Settings.StringValue("Payment.Placetopay.SecretKey." + currency);
            }

            return secret;
        }

        internal static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        internal static Contracts.Auth BuildAuth(int userId, string currency, int settingId, int companyId)
        {
            string seed = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
            string nonceRaw = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmsszzz");

            return new Contracts.Auth()
            {
                login = Login(userId, currency, settingId, companyId),
                tranKey = Convert.ToBase64String(Sha1(nonceRaw + seed + SecretKey(userId, currency, settingId, companyId))),
                nonce = Convert.ToBase64String(Encoding.ASCII.GetBytes(nonceRaw)),
                seed = seed
            };
        }

        internal static byte[] Sha1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(Encoding.ASCII.GetBytes(input));
            }
        }

        internal static string CurrencyConvert(string currency)
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

        /// <summary>
        /// Realiza la solicitud de tokenización de una tarjeta.
        /// </summary>
        /// <remarks>
        /// Tokenización (tokenize)
        /// https://placetopay-api.stoplight.io/docs/api-services-docs/967841bb68f09-tokenizacion-tokenize
        /// Este servicio permite almacenar un instrumento de pago como: tarjetas de crédito o cuenta bancaria de manera segura, a través de una petición que contenga la información de la misma, se generará un token que puede ser usado en el servicio de procesamiento y para todos los efectos, en PlacetoPay equivale a una tarjeta de crédito o cuenta bancaria, la diferencia es que se envía la estructura token en vez de card o account.
        /// Previamente al consumo de este servicio se debe consultar el de información para saber si es necesario o no generar un OTP al cliente y en caso de ser necesario, solicitar el token a la persona y enviarlo en el consumo.
        /// </remarks>
        public async static Task<Integrations.Providers.Placetopay.Contracts.Responses.Tokenize> Tokenize(Integrations.Providers.Placetopay.Contracts.Requests.Tokenize tokenizeRequest)
        {
            Integrations.Providers.Placetopay.Contracts.Responses.Tokenize tokenizeResponse = null;

            var data = new StringContent(JsonConvert.SerializeObject(tokenizeRequest), Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl.Recurring") + "gateway/tokenize", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                tokenizeResponse = JsonConvert.DeserializeObject<Integrations.Providers.Placetopay.Contracts.Responses.Tokenize>(resultResponse);
            }
            else
            {
                tokenizeResponse = new Contracts.Responses.Tokenize()
                {
                    status = new Contracts.Status()
                    {
                        date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                        status = ST_FAILED,
                        reason = response.ReasonPhrase
                    }
                };
            }
            return tokenizeResponse;
        }

        /// <summary>
        /// Realiza la solicitud para invalidar un token existente.
        /// </summary>
        /// <remarks>
        /// Tokenización (invalidate)
        /// https://placetopay-api.stoplight.io/docs/api-services-docs/90727aada9dc9-tokenizacion-invalidate
        /// Este servicio permite invalidar y eliminar un token asociado a una tarjeta de crédito.
        /// </remarks>
        public async static Task<Integrations.Providers.Placetopay.Contracts.Responses.Tokenize> InvalidateToken(Integrations.Providers.Placetopay.Contracts.Requests.Tokenize tokenizeRequest)
        {
            Integrations.Providers.Placetopay.Contracts.Responses.Tokenize tokenizeResponse = null;

            var data = new StringContent(JsonConvert.SerializeObject(tokenizeRequest), Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl.Recurring") + "gateway/invalidate", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                tokenizeResponse = JsonConvert.DeserializeObject<Integrations.Providers.Placetopay.Contracts.Responses.Tokenize>(resultResponse);
            }
            else
            {
                tokenizeResponse = new Contracts.Responses.Tokenize()
                {
                    status = new Contracts.Status()
                    {
                        date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                        status = ST_FAILED,
                        reason = response.ReasonPhrase
                    }
                };
            }
            return tokenizeResponse;
        }

        /// <summary>
        /// Realiza el cobro a la tarjeta de un cliente
        /// </summary>
        /// <remarks>
        /// Procesamiento de transacción
        /// https://placetopay-api.stoplight.io/docs/api-services-docs/b736ea6925314-procesamiento-de-transaccion
        /// Este servicio permite que se realice el cobro a la tarjeta del usuario, los parámetros del instrument son variables, si no se pide tipo de crédito ni otp no es necesario enviar esas variables, payer es siempre requerido, buyer es opcional pero recomendado.
        /// </remarks>
        public async static Task<CollectTransaction> Collect(string payLoad)
        {
            CollectTransaction collectResponse = null;

            var data = new StringContent(payLoad, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl.Recurring") + "gateway/process", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                collectResponse = JsonConvert.DeserializeObject<Architect.Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction>(resultResponse);
            }
            else
            {
                try
                {
                    collectResponse = JsonConvert.DeserializeObject<Architect.Payment.Integrations.Providers.Placetopay.Contracts.CollectTransaction>(resultResponse);
                }
                catch (Exception)
                {

                    collectResponse = new CollectTransaction()
                    {
                        status = new Contracts.Status()
                        {
                            date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                            status = ST_FAILED,
                            reason = response.ReasonPhrase
                        }
                    };
                }

            }
            return collectResponse;
        }

        /// <summary>
        /// Construye la información de autenticación requerida para la solicitud de pago.
        /// </summary>
        public static Auth BuildAuth(string key, string currency)
        {
            string seed = DateTime.UtcNow.ToString("o");
            Random random = new Random();
            int rawNonce = random.Next(0, 1000000);
            Auth auth;
            byte[] hash;
            string login = Utilities.Helpers.Settings.StringValue($"Payment.Placetopay.Login.{key}.{currency}");
            string secretKey = Utilities.Helpers.Settings.StringValue($"Payment.Placetopay.SecretKey.{key}.{currency}");

            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawNonce.ToString() + seed + secretKey));
            }
            auth = new Auth
            {
                login = login,
                tranKey = Convert.ToBase64String(hash),
                nonce = Convert.ToBase64String(Encoding.UTF8.GetBytes(rawNonce.ToString())),
                seed = seed,
            };

            return auth;
        }

        public async static Task<Contracts.Responses.PaymentLink> PaymentLink(Contracts.Requests.PaymentLink paymentLink)
        {
            Contracts.Responses.PaymentLink paymentLinkResponse = null;

            string json = JsonConvert.SerializeObject(paymentLink, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(3) };
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Placetopay.PaymentUrl.Recurring") + "microsites/api/payment-link", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                paymentLinkResponse = JsonConvert.DeserializeObject<Contracts.Responses.PaymentLink>(resultResponse);
            }
            else
            {
                paymentLinkResponse = new Contracts.Responses.PaymentLink()
                {
                    status = new Contracts.Status()
                    {
                        date = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"),
                        status = ST_FAILED,
                        reason = response.ReasonPhrase
                    }
                };
            }
            return paymentLinkResponse;
        }

    }
}
