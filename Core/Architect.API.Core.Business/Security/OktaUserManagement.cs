using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Sincronización de usuarios de Aliados contra la Users API de Okta.
    /// </summary>
    /// <remarks>
    /// Autenticación: OAuth 2.0 Service App con <c>private_key_jwt</c> (RFC 7523).
    /// Se firma un JWT con la clave privada en formato JWK y se intercambia por un
    /// <c>access_token</c> de cliente (grant <c>client_credentials</c>) que luego se
    /// envía como Bearer a la Users API.
    ///
    /// Settings requeridos en Web.config:
    ///  - Okta.Domain                     : URL base del tenant (ej. https://loginpre.mapfrecr.com).
    ///  - Okta.ServiceApp.ClientId        : Client ID de la Service App.
    ///  - Okta.ServiceApp.PrivateKeyJwk   : Clave privada en formato JWK (JSON serializado, incluye kid)
    ///                                      codificada en Base64 en una sola línea.
    ///  - Okta.ServiceApp.Scopes          : Scopes solicitados (por defecto "okta.users.manage").
    ///  - Okta.SyncUsers.Tenants          : CompanyId habilitados, separados por ';'.
    ///
    /// Endpoints utilizados:
    ///  - POST   /oauth2/v1/token (client_credentials + client_assertion)
    ///  - GET    /api/v1/users?search=profile.login eq "{email}"
    ///  - POST   /api/v1/users?activate=true
    ///  - POST   /api/v1/users/{id}
    ///  - POST   /api/v1/users/{id}/lifecycle/deactivate
    ///  - DELETE /api/v1/users/{id}
    /// </remarks>
    public static class OktaUserManagement
    {
        private static readonly object _tokenLock = new object();
        private static string _cachedAccessToken;
        private static DateTime _cachedAccessTokenExpiresUtc = DateTime.MinValue;

        private static readonly object _groupLock = new object();
        private static string _cachedAssignGroupName;
        private static string _cachedAssignGroupId;
        private static DateTime _cachedAssignGroupExpiresUtc = DateTime.MinValue;

        /// <summary>
        /// Indica si el <paramref name="companyId"/> tiene la sincronización con Okta habilitada
        /// según el setting <c>Okta.SyncUsers.Tenants</c>.
        /// </summary>
        public static bool IsTenantEnabled(int companyId)
        {
            string raw = ConfigurationManager.AppSettings["Okta.SyncUsers.Tenants"];
            if (string.IsNullOrWhiteSpace(raw))
                return false;

            string target = companyId.ToString();
            foreach (string tenant in raw.Split(';'))
            {
                if (string.Equals(tenant.Trim(), target, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Crea (o reactiva) un usuario en Okta. Si ya existe (mismo login/email), actualiza el perfil.
        /// </summary>
        public static string Create(Architect.API.Core.Contracts.Security.UserMember item)
        {
            try
            {
                EnsureTls12();
                string existingId = FindUserIdByLogin(item.EMail);

                if (!string.IsNullOrEmpty(existingId))
                    return UpdateProfile(existingId, item, "creación");

                var payload = new JObject { ["profile"] = BuildProfile(item) };
                if (!string.IsNullOrEmpty(item.Password) && item.Password != "XXXX" && item.Password != "XXXXXXXX")
                {
                    payload["credentials"] = new JObject
                    {
                        ["password"] = new JObject { ["value"] = item.Password }
                    };
                }

                string assignGroupId = ResolveAssignGroupId();
                if (!string.IsNullOrEmpty(assignGroupId))
                {
                    payload["groupIds"] = new JArray(assignGroupId);
                }

                string url = BaseUrl() + "/api/v1/users?activate=true";
                using (var client = BuildApiClient())
                using (var content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json"))
                using (HttpResponseMessage resp = client.PostAsync(url, content).Result)
                {
                    string body = resp.Content.ReadAsStringAsync().Result;
                    if (resp.IsSuccessStatusCode)
                        return "Usuario creado correctamente en Okta";

                    return $"No fue posible crear el usuario en Okta ({(int)resp.StatusCode}): {body}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al crear el usuario en Okta: {ex.Message}";
            }
        }

        /// <summary>
        /// Actualiza el perfil de un usuario en Okta. Si no existe, lo crea.
        /// </summary>
        public static string Update(Architect.API.Core.Contracts.Security.UserMember item)
        {
            try
            {
                EnsureTls12();
                string existingId = FindUserIdByLogin(item.EMail);

                if (string.IsNullOrEmpty(existingId))
                    return Create(item);

                return UpdateProfile(existingId, item, "actualización");
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el usuario en Okta: {ex.Message}";
            }
        }

        /// <summary>
        /// Desactiva y elimina (hard delete) un usuario en Okta.
        /// </summary>
        public static string Delete(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    return "No se indicó el correo del usuario para eliminar en Okta";

                EnsureTls12();
                string existingId = FindUserIdByLogin(email);
                if (string.IsNullOrEmpty(existingId))
                    return "El usuario no existe en Okta; no se requiere eliminar";

                using (var client = BuildApiClient())
                {
                    string deactivateUrl = $"{BaseUrl()}/api/v1/users/{existingId}/lifecycle/deactivate?sendEmail=false";
                    using (HttpResponseMessage resp = client.PostAsync(deactivateUrl, new StringContent(string.Empty)).Result)
                    {
                        if (!resp.IsSuccessStatusCode && resp.StatusCode != HttpStatusCode.NotFound)
                        {
                            string body = resp.Content.ReadAsStringAsync().Result;
                            return $"No fue posible desactivar el usuario en Okta ({(int)resp.StatusCode}): {body}";
                        }
                    }

                    string deleteUrl = $"{BaseUrl()}/api/v1/users/{existingId}";
                    using (HttpResponseMessage resp = client.DeleteAsync(deleteUrl).Result)
                    {
                        if (resp.IsSuccessStatusCode || resp.StatusCode == HttpStatusCode.NotFound)
                            return "Usuario eliminado correctamente en Okta";

                        string body = resp.Content.ReadAsStringAsync().Result;
                        return $"No fue posible eliminar el usuario en Okta ({(int)resp.StatusCode}): {body}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el usuario en Okta: {ex.Message}";
            }
        }

        private static string UpdateProfile(string userId, Architect.API.Core.Contracts.Security.UserMember item, string operation)
        {
            var payload = new JObject { ["profile"] = BuildProfile(item) };

            // Incluir password en la actualización si fue proporcionado y cambió
            if (!string.IsNullOrEmpty(item.Password) && item.Password != "XXXX" && item.Password != "XXXXXXXX")
            {
                payload["credentials"] = new JObject
                {
                    ["password"] = new JObject { ["value"] = item.Password }
                };
            }

            string url = $"{BaseUrl()}/api/v1/users/{userId}";
            using (var client = BuildApiClient())
            using (var content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json"))
            using (HttpResponseMessage resp = client.PostAsync(url, content).Result)
            {
                string body = resp.Content.ReadAsStringAsync().Result;
                if (!resp.IsSuccessStatusCode)
                    return $"No fue posible sincronizar el usuario con Okta en {operation} ({(int)resp.StatusCode}): {body}";
            }

            EnsureUserInAssignGroup(userId);
            return $"Usuario sincronizado correctamente con Okta ({operation})";
        }

        /// <summary>
        /// Garantiza que el usuario pertenezca al grupo configurado en
        /// <c>Okta.ServiceApp.AssignGroupName</c>. Si no hay grupo configurado o no se
        /// puede resolver su id, no realiza ninguna acción.
        /// </summary>
        private static void EnsureUserInAssignGroup(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return;

            string groupId = ResolveAssignGroupId();
            if (string.IsNullOrEmpty(groupId))
                return;

            string url = $"{BaseUrl()}/api/v1/groups/{groupId}/users/{userId}";
            using (var client = BuildApiClient())
            using (var content = new StringContent(string.Empty))
            using (HttpResponseMessage resp = client.PutAsync(url, content).Result)
            {
                // 204 NoContent indica éxito; si falla se ignora silenciosamente
                // para no abortar el flujo de actualización del usuario.
                if (!resp.IsSuccessStatusCode && resp.StatusCode != HttpStatusCode.NoContent)
                {
                    // Forzar refresco del cache si el grupo dejó de existir.
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                        InvalidateAssignGroupCache();
                }
            }
        }

        /// <summary>
        /// Resuelve el <c>id</c> del grupo configurado en <c>Okta.ServiceApp.AssignGroupName</c>
        /// consultando la API de grupos de Okta. El valor se cachea por 10 minutos.
        /// </summary>
        private static string ResolveAssignGroupId()
        {
            string groupName = ConfigurationManager.AppSettings["Okta.ServiceApp.AssignGroupName"];
            if (string.IsNullOrWhiteSpace(groupName))
                return null;
            groupName = groupName.Trim();

            lock (_groupLock)
            {
                if (string.Equals(_cachedAssignGroupName, groupName, StringComparison.Ordinal)
                    && !string.IsNullOrEmpty(_cachedAssignGroupId)
                    && DateTime.UtcNow < _cachedAssignGroupExpiresUtc)
                {
                    return _cachedAssignGroupId;
                }

                string url = $"{BaseUrl()}/api/v1/groups?q={Uri.EscapeDataString(groupName)}&limit=10";
                using (var client = BuildApiClient())
                using (HttpResponseMessage resp = client.GetAsync(url).Result)
                {
                    if (!resp.IsSuccessStatusCode)
                        return null;

                    string body = resp.Content.ReadAsStringAsync().Result;
                    JArray arr = JArray.Parse(body);
                    foreach (JToken g in arr)
                    {
                        string name = g["profile"]?["name"]?.ToString();
                        if (string.Equals(name, groupName, StringComparison.OrdinalIgnoreCase))
                        {
                            _cachedAssignGroupName = groupName;
                            _cachedAssignGroupId = g["id"]?.ToString();
                            _cachedAssignGroupExpiresUtc = DateTime.UtcNow.AddMinutes(10);
                            return _cachedAssignGroupId;
                        }
                    }
                }

                return null;
            }
        }

        private static void InvalidateAssignGroupCache()
        {
            lock (_groupLock)
            {
                _cachedAssignGroupId = null;
                _cachedAssignGroupName = null;
                _cachedAssignGroupExpiresUtc = DateTime.MinValue;
            }
        }

        private static JObject BuildProfile(Architect.API.Core.Contracts.Security.UserMember item)
        {
            var profile = new JObject
            {
                ["login"] = item.EMail,
                ["email"] = item.EMail,
                ["firstName"] = item.FirstName,
                ["lastName"] = item.LastName
            };
            if (!string.IsNullOrEmpty(item.PhoneNumber))
                profile["mobilePhone"] = item.PhoneNumber;
            return profile;
        }

        private static string FindUserIdByLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return null;

            string filter = Uri.EscapeDataString($"profile.login eq \"{login}\"");
            string url = $"{BaseUrl()}/api/v1/users?search={filter}&limit=1";

            using (var client = BuildApiClient())
            using (HttpResponseMessage resp = client.GetAsync(url).Result)
            {
                if (!resp.IsSuccessStatusCode)
                    return null;

                string body = resp.Content.ReadAsStringAsync().Result;
                JArray arr = JArray.Parse(body);
                if (arr.Count == 0)
                    return null;

                return arr[0]["id"]?.ToString();
            }
        }

        /// <summary>
        /// Construye un <see cref="HttpClient"/> con el access_token Bearer obtenido por private_key_jwt.
        /// </summary>
        private static HttpClient BuildApiClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string accessToken = GetAccessToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return client;
        }

        /// <summary>
        /// Obtiene (y cachea) un access_token de la Service App vía private_key_jwt.
        /// </summary>
        private static string GetAccessToken()
        {
            lock (_tokenLock)
            {
                if (!string.IsNullOrEmpty(_cachedAccessToken) && DateTime.UtcNow < _cachedAccessTokenExpiresUtc)
                    return _cachedAccessToken;

                string clientId = ConfigurationManager.AppSettings["Okta.ServiceApp.ClientId"];
                string jwk = ResolvePrivateKeyJwk();
                string scopes = ConfigurationManager.AppSettings["Okta.ServiceApp.Scopes"];
                if (string.IsNullOrWhiteSpace(scopes))
                    scopes = "okta.users.manage";

                string tokenEndpoint = BaseUrl() + "/oauth2/v1/token";
                string assertion = BuildClientAssertion(clientId, jwk, tokenEndpoint);

                var form = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("scope", scopes),
                    new KeyValuePair<string, string>("client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"),
                    new KeyValuePair<string, string>("client_assertion", assertion)
                };

                EnsureTls12();
                using (var client = new HttpClient())
                using (var content = new FormUrlEncodedContent(form))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (HttpResponseMessage resp = client.PostAsync(tokenEndpoint, content).Result)
                    {
                        string body = resp.Content.ReadAsStringAsync().Result;
                        if (!resp.IsSuccessStatusCode)
                            throw new InvalidOperationException($"No fue posible obtener access_token de Okta ({(int)resp.StatusCode}): {body}");

                        JObject json = JObject.Parse(body);
                        string token = json["access_token"]?.ToString();
                        int expiresIn = json["expires_in"]?.Value<int>() ?? 3600;

                        _cachedAccessToken = token;
                        // Margen de 60s para no usar el token justo en el borde de expiración.
                        _cachedAccessTokenExpiresUtc = DateTime.UtcNow.AddSeconds(Math.Max(60, expiresIn - 60));
                        return token;
                    }
                }
            }
        }

        /// <summary>
        /// Construye y firma el client_assertion JWT (RS256) requerido por private_key_jwt.
        /// </summary>
        private static string BuildClientAssertion(string clientId, string jwkJson, string audience)
        {
            JObject jwk = JObject.Parse(jwkJson);
            string kid = jwk["kid"]?.ToString();
            string alg = jwk["alg"]?.ToString();
            if (string.IsNullOrWhiteSpace(alg))
                alg = "RS256";

            var headerObj = new JObject
            {
                ["alg"] = alg,
                ["typ"] = "JWT"
            };
            if (!string.IsNullOrEmpty(kid))
                headerObj["kid"] = kid;

            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var payloadObj = new JObject
            {
                ["iss"] = clientId,
                ["sub"] = clientId,
                ["aud"] = audience,
                ["iat"] = now,
                ["exp"] = now + 300,
                ["jti"] = Guid.NewGuid().ToString("N")
            };

            string headerSegment = Base64UrlEncode(Encoding.UTF8.GetBytes(headerObj.ToString(Formatting.None)));
            string payloadSegment = Base64UrlEncode(Encoding.UTF8.GetBytes(payloadObj.ToString(Formatting.None)));
            string signingInput = headerSegment + "." + payloadSegment;

            using (RSA rsa = BuildRsaFromJwk(jwk))
            {
                byte[] signature = rsa.SignData(
                    Encoding.UTF8.GetBytes(signingInput),
                    HashAlgorithmName.SHA256,
                    RSASignaturePadding.Pkcs1);
                return signingInput + "." + Base64UrlEncode(signature);
            }
        }

        /// <summary>
        /// Construye una instancia <see cref="RSA"/> a partir de un JWK RSA privado.
        /// </summary>
        private static RSA BuildRsaFromJwk(JObject jwk)
        {
            string kty = jwk["kty"]?.ToString();
            if (!string.Equals(kty, "RSA", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"JWK no soportado: kty={kty}. Se requiere RSA.");

            var parameters = new RSAParameters
            {
                Modulus = Base64UrlDecode(jwk["n"]?.ToString()),
                Exponent = Base64UrlDecode(jwk["e"]?.ToString()),
                D = Base64UrlDecode(jwk["d"]?.ToString()),
                P = Base64UrlDecode(jwk["p"]?.ToString()),
                Q = Base64UrlDecode(jwk["q"]?.ToString()),
                DP = Base64UrlDecode(jwk["dp"]?.ToString()),
                DQ = Base64UrlDecode(jwk["dq"]?.ToString()),
                InverseQ = Base64UrlDecode(jwk["qi"]?.ToString())
            };

            RSA rsa = RSA.Create();
            rsa.ImportParameters(parameters);
            return rsa;
        }

        private static string Base64UrlEncode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes)
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');
        }

        private static byte[] Base64UrlDecode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new byte[0];

            string s = input.Replace('-', '+').Replace('_', '/');
            switch (s.Length % 4)
            {
                case 2: s += "=="; break;
                case 3: s += "="; break;
            }
            return Convert.FromBase64String(s);
        }

        private static string BaseUrl()
        {
            return (ConfigurationManager.AppSettings["Okta.Domain"] ?? string.Empty).TrimEnd('/');
        }

        /// <summary>
        /// Resuelve el contenido JSON del JWK (clave privada) a partir del setting
        /// <c>Okta.ServiceApp.PrivateKeyJwk</c>, que debe contener el JSON codificado en Base64
        /// (una sola línea, sin comillas ni saltos de línea) para evitar problemas de
        /// escapado de comillas dobles en XML.
        /// </summary>
        private static string ResolvePrivateKeyJwk()
        {
            string value = ConfigurationManager.AppSettings["Okta.ServiceApp.PrivateKeyJwk"];
            if (string.IsNullOrWhiteSpace(value))
                return null;

            value = value.Trim();

            // Caso 1: ya es JSON crudo.
            if (value.StartsWith("{"))
                return value;

            // Caso 2: viene en Base64 (posiblemente con doble codificación, sin padding,
            // o en variante URL-safe). Intentamos decodificar hasta 2 veces.
            string decoded = value;
            for (int i = 0; i < 2; i++)
            {
                if (!TryDecodeBase64(decoded, out string next))
                    break;

                decoded = next;
                if (decoded.TrimStart().StartsWith("{"))
                    return decoded;
            }

            // Compatibilidad: si no se pudo interpretar, se devuelve tal cual y
            // BuildClientAssertion arrojará un error claro al intentar parsearlo.
            return decoded;
        }

        /// <summary>
        /// Intenta decodificar una cadena Base64 a su contenido UTF-8, tolerando
        /// la ausencia de padding y la variante URL-safe (caracteres '-' y '_').
        /// </summary>
        private static bool TryDecodeBase64(string input, out string decoded)
        {
            decoded = null;
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string normalized = input.Trim()
                .Replace('-', '+')
                .Replace('_', '/');

            // Agregar padding si falta.
            int mod = normalized.Length % 4;
            if (mod == 2) normalized += "==";
            else if (mod == 3) normalized += "=";
            else if (mod == 1) return false; // longitud inválida para Base64.

            try
            {
                byte[] bytes = Convert.FromBase64String(normalized);
                decoded = Encoding.UTF8.GetString(bytes);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static void EnsureTls12()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }
    }
}
