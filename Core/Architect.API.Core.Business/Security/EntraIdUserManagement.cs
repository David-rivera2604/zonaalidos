using Architect.API.Core.Contracts.Security;
using Architect.API.Core.Contracts.Security.EntraId;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Integración para sincronización de usuarios con la API de Invitados B2B Cloud (One Identity).
    /// </summary>
    public static class EntraIdUserManagement
    {
        private static readonly object _sessionLock = new object();
        private static string _cachedCookieHeader;
        private static DateTime _cachedSessionExpiresUtc = DateTime.MinValue;

        public static bool IsTenantEnabled(int companyId)
        {
            if (!IsSynchronizationEnabled())
                return false;

            string raw = ConfigurationManager.AppSettings["EntraId.SyncUsers.Tenants"];
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

        private static bool IsSynchronizationEnabled()
        {
            string raw = ConfigurationManager.AppSettings["EntraId.SyncUsers.Enabled"];
            if (string.IsNullOrWhiteSpace(raw))
                return true;

            return string.Equals(raw, "true", StringComparison.OrdinalIgnoreCase)
                || string.Equals(raw, "verdadero", StringComparison.OrdinalIgnoreCase)
                || string.Equals(raw, "yes", StringComparison.OrdinalIgnoreCase)
                || string.Equals(raw, "si", StringComparison.OrdinalIgnoreCase)
                || string.Equals(raw, "1", StringComparison.OrdinalIgnoreCase);
        }

        public static string Create(Architect.API.Core.Contracts.Security.UserMember item)
        {
            return Create(BuildUserSyncRequest(item));
        }

        public static string Update(Architect.API.Core.Contracts.Security.UserMember item)
        {
            return Update(BuildUserSyncRequest(item));
        }

        public static string Delete(Architect.API.Core.Contracts.Security.UserMember item)
        {
            return Delete(BuildDeleteRequest(item));
        }

        public static string Create(EntraIdB2BUserSyncRequest request)
        {
            try
            {
                EnsureTls12();
                if (request == null || request.Values == null)
                    return "No se indicó el payload de alta para Invitados B2B Cloud";

                string uid = FindUserId(request.Lookup);
                if (!string.IsNullOrEmpty(uid))
                    return UpdateByUid(uid, request.Values, "alta");

                string url = BuildUrl("api/entity/Person");
                var payload = new EntraIdB2BPersonRequest { Values = request.Values };

                using (var client = BuildApiClient())
                using (var content = BuildJsonContent(payload))
                using (HttpResponseMessage resp = client.PostAsync(url, content).Result)
                {
                    if (resp.IsSuccessStatusCode)
                        return "Usuario creado correctamente en Invitados B2B Cloud";

                    string body = resp.Content.ReadAsStringAsync().Result;
                    return $"No fue posible crear el usuario en Invitados B2B Cloud ({(int)resp.StatusCode}): {body}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al crear el usuario en Invitados B2B Cloud: {ex.Message}";
            }
        }

        public static string Update(EntraIdB2BUserSyncRequest request)
        {
            try
            {
                EnsureTls12();
                if (request == null || request.Values == null)
                    return "No se indicó el payload de actualización para Invitados B2B Cloud";

                string uid = FindUserId(request.Lookup);
                if (string.IsNullOrEmpty(uid))
                    return "No fue posible ubicar el UID_Person del usuario a actualizar en Invitados B2B Cloud";

                return UpdateByUid(uid, request.Values, "actualización");
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el usuario en Invitados B2B Cloud: {ex.Message}";
            }
        }

        public static string Delete(EntraIdB2BDeleteRequest request)
        {
            try
            {
                EnsureTls12();
                if (request == null)
                    return "No se indicó la solicitud de baja para Invitados B2B Cloud";

                string uid = request.UidPerson;
                if (string.IsNullOrWhiteSpace(uid))
                    uid = FindUserId(request.Lookup);

                if (string.IsNullOrWhiteSpace(uid))
                    return "El usuario no existe en Invitados B2B Cloud; no se requiere baja";

                DateTime deactivationDate = request.DeactivationStart ?? DateTime.UtcNow;
                var payload = new EntraIdB2BDeactivateRequest
                {
                    Values = new EntraIdB2BDeactivateValues
                    {
                        DeactivationStart = deactivationDate.ToString("yyyy-MM-dd"),
                        IsTemporaryDeactivated = true,
                        CCC_Fecha_Baja_Meta4 = DateTime.UtcNow.ToString("o")
                    }
                };

                string url = BuildUrl($"api/entity/Person/{Uri.EscapeDataString(uid)}");
                using (var client = BuildApiClient())
                using (var content = BuildJsonContent(payload))
                using (HttpResponseMessage resp = client.PutAsync(url, content).Result)
                {
                    if (resp.IsSuccessStatusCode)
                        return "Usuario dado de baja correctamente en Invitados B2B Cloud";

                    string body = resp.Content.ReadAsStringAsync().Result;
                    return $"No fue posible dar de baja el usuario en Invitados B2B Cloud ({(int)resp.StatusCode}): {body}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al dar de baja el usuario en Invitados B2B Cloud: {ex.Message}";
            }
        }

        public static string FindUserId(EntraIdB2BLookupCriteria criteria)
        {
            if (criteria == null)
                return null;

            if (!string.IsNullOrWhiteSpace(criteria.UidPerson))
                return criteria.UidPerson;

            string url;
            string where = criteria.Where;

            if (!string.IsNullOrWhiteSpace(criteria.CentralAccount))
            {
                url = BuildUrl($"api/entities/Person?CentralAccount={Uri.EscapeDataString(criteria.CentralAccount)}&displayColumns=UID_Person&LoadType=Slim");
            }
            else if (!string.IsNullOrWhiteSpace(criteria.PersonnelNumber))
            {
                url = BuildUrl($"api/entities/Person?PersonnelNumber={Uri.EscapeDataString(criteria.PersonnelNumber)}&displayColumns=UID_Person&LoadType=Slim");
            }
            else if (!string.IsNullOrWhiteSpace(criteria.Nif))
            {
                url = BuildUrl($"api/entities/Person?CCC_NIF={Uri.EscapeDataString(criteria.Nif)}&displayColumns=UID_Person&LoadType=Slim");
            }
            else if (!string.IsNullOrWhiteSpace(where))
            {
                url = BuildUrl("api/entities/Person?displayColumns=UID_Person&LoadType=Slim");
            }
            else
            {
                return null;
            }

            using (var client = BuildApiClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                if (!string.IsNullOrWhiteSpace(where))
                    request.Content = BuildJsonContent(new EntraIdB2BLookupCriteria { Where = where });

                using (HttpResponseMessage resp = client.SendAsync(request).Result)
                {
                    if (!resp.IsSuccessStatusCode)
                        return null;

                    string responseBody = resp.Content.ReadAsStringAsync().Result;
                    List<EntraIdB2BEntityResponse> result = JsonConvert.DeserializeObject<List<EntraIdB2BEntityResponse>>(responseBody);
                    if (result == null || result.Count == 0 || result[0].Values == null)
                        return null;

                    return result[0].Values.UidPerson;
                }
            }
        }

        /// <summary>
        /// Método auxiliar para probar rápidamente la búsqueda de UID_Person.
        /// Devuelve un mensaje legible con el resultado de <see cref="FindUserId(EntraIdB2BLookupCriteria)"/>.
        /// </summary>
        public static string TestFindUserId(EntraIdB2BLookupCriteria criteria)
        {
            try
            {
                EnsureTls12();

                if (criteria == null)
                    return "Prueba FindUserId: no se enviaron criterios";

                string uid = FindUserId(criteria);
                if (string.IsNullOrWhiteSpace(uid))
                    return "Prueba FindUserId: sin resultados para los criterios enviados";

                return $"Prueba FindUserId OK. UID_Person: {uid}";
            }
            catch (Exception ex)
            {
                return $"Prueba FindUserId con error: {ex.Message}";
            }
        }

        private static EntraIdB2BUserSyncRequest BuildUserSyncRequest(Architect.API.Core.Contracts.Security.UserMember item)
        {
            return new EntraIdB2BUserSyncRequest
            {
                Lookup = BuildLookupCriteria(item),
                Values = BuildPersonValues(item)
            };
        }

        private static EntraIdB2BDeleteRequest BuildDeleteRequest(Architect.API.Core.Contracts.Security.UserMember item)
        {
            return new EntraIdB2BDeleteRequest
            {
                Lookup = BuildLookupCriteria(item),
                DeactivationStart = DateTime.UtcNow
            };
        }

        private static EntraIdB2BLookupCriteria BuildLookupCriteria(Architect.API.Core.Contracts.Security.UserMember item)
        {
            if (item == null)
                return null;

            var clauses = new List<string>();

            if (!string.IsNullOrWhiteSpace(item.UserName))
                clauses.Add($"CentralAccount = '{EscapeWhereValue(item.UserName)}'");

            string personnelNumber = ResolvePersonnelNumber(item);
            if (!string.IsNullOrWhiteSpace(personnelNumber))
                clauses.Add($"PersonnelNumber = '{EscapeWhereValue(personnelNumber)}'");

            string nif = NormalizeDocument(item.Identification);
            if (!string.IsNullOrWhiteSpace(nif))
                clauses.Add($"CCC_NIF = '{EscapeWhereValue(nif)}'");

            if (!string.IsNullOrWhiteSpace(item.EMail))
                clauses.Add($"CCC_Email_Ext = '{EscapeWhereValue(item.EMail)}'");

            if (clauses.Count == 0)
                return null;

            return new EntraIdB2BLookupCriteria
            {
                Where = string.Join(" or ", clauses)
            };
        }

        private static EntraIdB2BPersonValuesDto BuildPersonValues(Architect.API.Core.Contracts.Security.UserMember item)
        {
            if (item == null)
                return null;

            string firstSurname = item.LastName;
            string secondSurname = string.Empty;
            if (!string.IsNullOrWhiteSpace(item.LastName))
            {
                string[] surnameParts = item.LastName.Trim().Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (surnameParts.Length > 0)
                    firstSurname = surnameParts[0];
                if (surnameParts.Length > 1)
                    secondSurname = surnameParts[1];
            }

            return new EntraIdB2BPersonValuesDto
            {
                PersonnelNumber = ResolvePersonnelNumber(item),
                CCC_Numero_Ordinal = ResolvePersonnelNumber(item),
                CCC_Fecha_Activacion = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                CCC_Ordinal = "0",
                CCC_ID_HR_Type = "53",
                CCC_Id_Funcion = item.Position > 0 ? item.Position.ToString() : null,
                CCC_DES_FUNCION = item.PositionDesc,
                FirstName = item.FirstName,
                CCC_Apellido1 = firstSurname,
                CCC_Apellido2 = secondSurname,
                CCC_Nif = NormalizeDocument(item.Identification),
                CCC_ID_Tipo_Documento = item.IdentificationType > 0 ? item.IdentificationType.ToString() : null,
                CCC_Email_Ext = item.EMail,
                Phone = item.PhoneNumber,
                CCC_Phone_Ext = item.PhoneNumber,
                CCC_Acceso_Correo = null,
                IsExternal = true,
                CCC_Colaborar = null,
                CCC_Acceso_Sistemas = null,
                CCC_Acceso_App_Cloud = "1",
                IsTemporaryDeactivated = false,
                IsInActive = false
            };
        }

        private static string ResolvePersonnelNumber(Architect.API.Core.Contracts.Security.UserMember item)
        {
            if (item == null)
                return null;

            if (!string.IsNullOrWhiteSpace(item.Reference))
                return item.Reference.Trim();

            if (!string.IsNullOrWhiteSpace(item.AccessKey))
                return item.AccessKey.Trim();

            if (!string.IsNullOrWhiteSpace(item.UserName))
                return item.UserName.Trim();

            if (item.UserId > 0)
                return item.UserId.ToString();

            return null;
        }

        private static string NormalizeDocument(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            return value.Trim().Replace(" ", string.Empty).Replace("-", string.Empty).ToUpperInvariant();
        }

        private static string EscapeWhereValue(string value)
        {
            return value.Replace("'", "''");
        }

        private static string UpdateByUid(string uidPerson, EntraIdB2BPersonValuesDto values, string operation)
        {
            string url = BuildUrl($"api/entity/Person/{Uri.EscapeDataString(uidPerson)}");
            var payload = new EntraIdB2BPersonRequest { Values = values };

            using (var client = BuildApiClient())
            using (var content = BuildJsonContent(payload))
            using (HttpResponseMessage resp = client.PutAsync(url, content).Result)
            {
                if (resp.IsSuccessStatusCode)
                    return $"Usuario sincronizado correctamente con Invitados B2B Cloud ({operation})";

                string body = resp.Content.ReadAsStringAsync().Result;
                return $"No fue posible sincronizar el usuario en Invitados B2B Cloud durante {operation} ({(int)resp.StatusCode}): {body}";
            }
        }

        private static HttpClient BuildApiClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string cookie = GetSessionCookieHeader();
            if (!string.IsNullOrWhiteSpace(cookie))
                client.DefaultRequestHeaders.Add("Cookie", cookie);

            return client;
        }

        private static StringContent BuildJsonContent(object payload)
        {
            string json = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static string GetSessionCookieHeader()
        {
            lock (_sessionLock)
            {
                if (!string.IsNullOrWhiteSpace(_cachedCookieHeader) && DateTime.UtcNow < _cachedSessionExpiresUtc)
                    return _cachedCookieHeader;

                string authString = ConfigurationManager.AppSettings["EntraId.AuthString"]
                                    ?? ConfigurationManager.AppSettings["EntraId.Sync.AuthString"];
                if (string.IsNullOrWhiteSpace(authString))
                    throw new InvalidOperationException("Configuración incompleta: EntraId.AuthString");

                string loginUrl = BuildUrl("auth/apphost/");
                var payload = new EntraIdB2BAuthRequest { AuthString = authString };

                using (var client = new HttpClient())
                using (var content = BuildJsonContent(payload))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (HttpResponseMessage resp = client.PostAsync(loginUrl, content).Result)
                    {
                        string responseBody = resp.Content.ReadAsStringAsync().Result;
                        if (!resp.IsSuccessStatusCode)
                            throw new InvalidOperationException($"No fue posible autenticarse contra Invitados B2B Cloud ({(int)resp.StatusCode}): {responseBody}");

                        IEnumerable<string> setCookieHeaders;
                        if (!resp.Headers.TryGetValues("Set-Cookie", out setCookieHeaders))
                            throw new InvalidOperationException("No se recibieron cookies de sesión desde Invitados B2B Cloud.");

                        string cookieHeader = string.Empty;
                        foreach (string item in setCookieHeaders)
                        {
                            if (string.IsNullOrWhiteSpace(item))
                                continue;

                            string[] parts = item.Split(';');
                            if (parts.Length == 0 || string.IsNullOrWhiteSpace(parts[0]))
                                continue;

                            string keyValue = parts[0].Trim();
                            if (cookieHeader.IndexOf(keyValue, StringComparison.OrdinalIgnoreCase) >= 0)
                                continue;

                            cookieHeader = string.IsNullOrEmpty(cookieHeader)
                                ? keyValue
                                : cookieHeader + "; " + keyValue;
                        }

                        if (string.IsNullOrWhiteSpace(cookieHeader))
                            throw new InvalidOperationException("Respuesta de login sin cookies válidas para Invitados B2B Cloud.");

                        _cachedCookieHeader = cookieHeader;
                        _cachedSessionExpiresUtc = DateTime.UtcNow.AddHours(8).AddMinutes(-5);
                        return _cachedCookieHeader;
                    }
                }
            }
        }

        private static string BuildUrl(string relativePath)
        {
            string baseUrl = ConfigurationManager.AppSettings["EntraId.BaseUrl"]
                             ?? ConfigurationManager.AppSettings["EntraId.Sync.BaseUrl"];

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("Configuración incompleta: EntraId.BaseUrl");

            return string.Format("{0}/{1}", baseUrl.TrimEnd('/'), relativePath.TrimStart('/'));
        }

        private static void EnsureTls12()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }
    }
}
