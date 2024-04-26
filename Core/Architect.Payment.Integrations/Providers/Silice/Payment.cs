using Architect.Payment.Integrations.Contracts.v2;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
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
            else
            {
                Utilities.Log.ErrorLog("Silice.Payment.signin", response.ReasonPhrase);
                Utilities.Log.ErrorLog("Silice.Payment.signin", resultResponse);
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
            else
            {
                Utilities.Log.ErrorLog("Silice.Payment.recibo", response.ReasonPhrase);
                Utilities.Log.ErrorLog("Silice.Payment.recibo", resultResponse);
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
            else
            {
                Utilities.Log.ErrorLog("Silice.Payment.CobroSendEmail", response.ReasonPhrase);
                Utilities.Log.ErrorLog("Silice.Payment.CobroSendEmail", resultResponse);
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
                else if(!string.IsNullOrEmpty( jsonvalues.TokenStringValue("menssage")))
                {
                    result = "Error. " + jsonvalues.TokenStringValue("menssage");
                } else
                {
                    result = "Error. " + jsonvalues.TokenStringValue("data");
                }
            }
            else
            {
                Utilities.Log.ErrorLog("Silice.Payment.CobroMensajeAutomata", response.ReasonPhrase);
                Utilities.Log.ErrorLog("Silice.Payment.CobroMensajeAutomata", resultResponse);
            }
            return result;
        }

        public async static Task<List<DatosTarjeta>> Tokenize(HttpClient client, List<DatosTarjeta> datosTajetas)
        {
            string claveCifrado = await genpwdcryto(client);

            foreach (DatosTarjeta tarjeta in datosTajetas)
            {
                var json = JsonConvert.SerializeObject(new TokenizerRequest()
                {
                    data0 = CodifTarjeta(JsonConvert.SerializeObject((DatosTarjetaBase)tarjeta), claveCifrado),
                    client = new Client()
                    {
                        email = tarjeta.email,
                        name = tarjeta.holder_name,
                        fiscal_number = tarjeta.cod_docum,
                        dataExtra = new Dataextra()
                        {
                            externalClientId = tarjeta.cod_docum
                        },
                    },
                    origen = "widget",
                    validar = true
                });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Silice.urlBase") + "/v2/tarjetas-dsp/tokenizeapi", data);
                string resultResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode && resultResponse.IsNotEmpty())
                {
                    JObject jsonvalues = JObject.Parse(resultResponse);

                    tarjeta.status = jsonvalues.TokenBoolValue("status");

                    if (tarjeta.status) { 
                    tarjeta.card = jsonvalues.TokenStringValue("data.card");
                    tarjeta.clientId = jsonvalues.TokenStringValue("data.clientId");
                    tarjeta.token = jsonvalues.TokenStringValue("data.token");
                    } else
                    {
                        tarjeta.reason = jsonvalues.TokenStringValue("menssage");
                    }
                }
                else
                {
                    tarjeta.status = false;
                    tarjeta.reason = response.ReasonPhrase;

                    Utilities.Log.ErrorLog("Silice.Payment.Tokenize", response.ReasonPhrase);
                    Utilities.Log.ErrorLog("Silice.Payment.Tokenize", resultResponse);
                }
            }

            return datosTajetas;
        }


        public async static Task<string> RecibosRecurrentes(HttpClient client, ReciboRequest recibos)
        {
            string result = string.Empty;
            var json = JsonConvert.SerializeObject(recibos);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Utilities.Helpers.Settings.StringValue("Payment.Silice.urlBase") + "/v2/recibo/envioCR", data);
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && resultResponse.IsNotEmpty())
            {
                JObject jsonvalues = JObject.Parse(resultResponse);

                result = jsonvalues.TokenStringValue("status");
            }
            else
            {
                Utilities.Log.ErrorLog("Silice.Payment.RecibosRecurrentes", response.ReasonPhrase);
                Utilities.Log.ErrorLog("Silice.Payment.RecibosRecurrentes", resultResponse);
            }
            return result;
        }

        private async static Task<string> genpwdcryto(HttpClient client)
        {
            string claveCifrado = string.Empty;

            var response = await client.GetAsync(Utilities.Helpers.Settings.StringValue("Payment.Silice.urlBase") + "/v2/user/genpwdcryto");
            string resultResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && resultResponse.IsNotEmpty())
            {
                JObject jsonvalues = JObject.Parse(resultResponse);

                claveCifrado = jsonvalues.TokenStringValue("data");

            }

            return claveCifrado;
        }

        private static string CodifTarjeta(string textoPlano, string pwd)
        {
            try
            {
                // Generate a 16-byte random salt
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                // Derive key and IV from password using PBKDF2 with SHA256
                using (var pbkdf2 = new Rfc2898DeriveBytes(pwd, salt, 1000, HashAlgorithmName.SHA256))
                {
                    pbkdf2.IterationCount = 1000; // Specify iteration count separately
                    byte[] key = pbkdf2.GetBytes(32);
                    byte[] iv = pbkdf2.GetBytes(16);

                    // Encrypt the plaintext using AES with the derived key and IV
                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = key;
                        aesAlg.IV = iv;

                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                        using (var msEncrypt = new System.IO.MemoryStream())
                        {
                            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                                {
                                    swEncrypt.Write(textoPlano);
                                }
                            }

                            // Concatenate the salt and ciphertext
                            byte[] ciphertext = msEncrypt.ToArray();
                            byte[] saltedCiphertext = new byte[salt.Length + ciphertext.Length];
                            Array.Copy(salt, saltedCiphertext, salt.Length);
                            Array.Copy(ciphertext, 0, saltedCiphertext, salt.Length, ciphertext.Length);

                            // Convert to Base64
                            string saltCiphertextB64 = Convert.ToBase64String(saltedCiphertext);
                            return saltCiphertextB64;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

    }
}
