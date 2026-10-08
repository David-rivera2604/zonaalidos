using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Architect.Extend.Integrations.Credid
{
    public static class Consultas
    {
        private static readonly CultureInfo CostaRica = CultureInfo.CreateSpecificCulture("es-CR");
        private static readonly string[] FormatosFecha = { "dd/MM/yyyy", "d/M/yyyy", "dd/MM/yyyy HH:mm:ss", "dd-MM-yyyy", "yyyy-MM-dd", "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", "yyyyMMdd" };
        private static readonly Lazy<HttpClient> Client = new Lazy<HttpClient>(() =>
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            return new HttpClient() { Timeout = TimeSpan.FromSeconds(Architect.Utilities.Helpers.Settings.IntegerValue("Credid.TimeoutSeconds", 10)) };
        });

        public async static Task<Architect.API.Insurance.Contracts.Policy.Insured> PersonaPorIdentificacion(string identificacion, int docType = 1)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;
            string token = Architect.Utilities.Helpers.Settings.StringValue("Credid.Token");

            if (token.IsEmpty() || identificacion.IsEmpty())
            {
                return result;
            }

            string cedula = IdentificacionCredid(identificacion, docType);
            if (cedula.IsEmpty())
            {
                return result;
            }

            try
            {
                string url = Architect.Utilities.Helpers.Settings.StringValue("Credid.Url", "https://ws.credid.net/ws/api/reporte") + "?cedula=" + Uri.EscapeDataString(cedula);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    request.Headers.TryAddWithoutValidation("authorization", token);
                    using (HttpResponseMessage response = await Client.Value.SendAsync(request).ConfigureAwait(false))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            Utilities.Log.WarningLog("Credid.PersonaPorIdentificacion",
                                                     string.Format("Identificación '{0}' respondió {1}", cedula, (int)response.StatusCode), "integrations");
                            return result;
                        }

                        string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (body.IsNotEmpty())
                        {
                            using (JsonTextReader reader = new JsonTextReader(new StringReader(body)) { DateParseHandling = DateParseHandling.None })
                            {
                                result = Convertir(JObject.Load(reader), cedula, docType);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Credid.PersonaPorIdentificacion",
                                       string.Format("Falla al tratar de consultar a identificación '{0}'", cedula),
                                       ex, "integrations");
            }
            return result;
        }

        private static string IdentificacionCredid(string identificacion, int docType)
        {
            if (docType == 3)
            {
                string pasaporte = new string(identificacion.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToUpperInvariant();
                return pasaporte.IsEmpty() ? string.Empty : "ext-" + pasaporte;
            }
            return identificacion.OnlyNumbers().TrimStart('0');
        }

        private static Architect.API.Insurance.Contracts.Policy.Insured Convertir(JObject reporte, string cedula, int docType)
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;
            JObject persona = reporte["FiliacionFisica"] as JObject;
            int documentType = 1;

            if (persona == null)
            {
                persona = reporte["FiliacionExtranjero"] as JObject;
                documentType = docType == 3 ? 3 : 2;
            }

            if (persona != null)
            {
                if (Texto(persona, "Nombre").IsEmpty())
                {
                    return result;
                }

                result = Nuevo(documentType, cedula);
                result.FirstName = Nombre(Texto(persona, "Nombre"));
                result.LastName = Nombre(Texto(persona, "Apellido1"));
                result.SecondLastName = Nombre(Texto(persona, "Apellido2"));
                result.BirthDate = Fecha(Texto(persona, "FechaNacimiento"));
                result.Gender = Genero(Texto(persona, "Genero"), Texto(persona, "GeneroLiteral"));
                result.CivilStatus = EstadoCivil(Texto(persona, "EstadoCivil"), Texto(persona, "EstadoCivilLiteral"));
                Domicilio(result, persona["DomicilioElectoral"] as JObject);
            }
            else
            {
                JObject sociedad = reporte["FiliacionJuridica"] as JObject;
                if (sociedad == null || Texto(sociedad, "Nombre").IsEmpty())
                {
                    return result;
                }

                result = Nuevo(4, cedula);
                result.FirstName = Texto(sociedad, "Nombre");
            }

            Localizacion(result, reporte["Localizacion"] as JArray);
            return result;
        }

        private static Architect.API.Insurance.Contracts.Policy.Insured Nuevo(int documentType, string cedula)
        {
            return new Architect.API.Insurance.Contracts.Policy.Insured()
            {
                DocumentType = documentType,
                DocumentNumber = cedula,
                FirstName = string.Empty,
                MiddleName = string.Empty,
                LastName = string.Empty,
                SecondLastName = string.Empty,
                BirthDate = DateTime.MinValue,
                Gender = 0,
                CivilStatus = 0,
                PrimaryEmailAddress = string.Empty,
                Province = 0,
                Canton = 0,
                District = 0,
                AddressDetail = string.Empty,
                PhoneType = 0,
                PhoneNumber = string.Empty,
                Source = "Credid"
            };
        }

        private static void Domicilio(Architect.API.Insurance.Contracts.Policy.Insured result, JObject domicilio)
        {
            if (domicilio == null)
            {
                return;
            }

            string provincia = Texto(domicilio, "CodigoAdministrativo_Provincia").OnlyNumbers();
            string canton = Texto(domicilio, "CodigoAdministrativo_Canton").OnlyNumbers();
            string distrito = Texto(domicilio, "CodigoAdministrativo_Distrito").OnlyNumbers();
            string completo = Texto(domicilio, "CodigoAdministrativo").OnlyNumbers();

            if (completo.Length == 5)
            {
                provincia = completo.Substring(0, 1);
                canton = completo.Substring(0, 3);
                distrito = completo;
            }
            else
            {
                if (provincia.Length == 1 && canton.Length > 0 && canton.Length <= 2)
                {
                    canton = provincia + canton.PadLeft(2, '0');
                }
                if (canton.Length == 3 && distrito.Length > 0 && distrito.Length <= 2)
                {
                    distrito = canton + distrito.PadLeft(2, '0');
                }
            }

            int value;
            if (provincia.Length == 1 && int.TryParse(provincia, out value))
            {
                result.Province = value;
            }
            if (canton.Length == 3 && int.TryParse(canton, out value))
            {
                result.Canton = value;
            }
            if (distrito.Length == 5 && int.TryParse(distrito, out value))
            {
                result.District = value;
            }
        }

        private static void Localizacion(Architect.API.Insurance.Contracts.Policy.Insured result, JArray datos)
        {
            if (datos == null)
            {
                return;
            }

            var titular = datos.OfType<JObject>()
                               .Where(d => Texto(d, "Relacion").IsEmpty() || Texto(d, "Relacion").IndexOf("titular", StringComparison.OrdinalIgnoreCase) >= 0)
                               .OrderByDescending(d => Fecha(Texto(d, "Fecha")))
                               .ToList();

            foreach (string tipo in new[] { "celular", "tel" })
            {
                JObject telefono = titular.FirstOrDefault(d => Contiene(d, "Tipo", tipo) && Texto(d, "Dato").OnlyNumbers().Length >= 8);
                if (telefono != null)
                {
                    string numero = Texto(telefono, "Dato").OnlyNumbers();
                    numero = numero.Substring(numero.Length - 8);
                    result.PhoneNumber = numero.Substring(0, 4) + "-" + numero.Substring(4);
                    result.PhoneType = tipo == "celular" ? 1 : 2;
                    break;
                }
            }

            JObject correo = titular.FirstOrDefault(d => Contiene(d, "Tipo", "mail") && Texto(d, "Dato").Contains("@"));
            if (correo != null)
            {
                result.PrimaryEmailAddress = Texto(correo, "Dato").ToLowerInvariant();
            }

            JObject direccion = titular.FirstOrDefault(d => Contiene(d, "Tipo", "direcc") && Texto(d, "Dato").IsNotEmpty());
            if (direccion != null)
            {
                string detalle = Texto(direccion, "Dato");
                result.AddressDetail = detalle.Length > 120 ? detalle.Substring(0, 120) : detalle;
            }
        }

        private static int Genero(string genero, string literal)
        {
            string value = (genero.IsNotEmpty() ? genero : literal).ToUpperInvariant();
            if (value.StartsWith("M"))
            {
                return 1;
            }
            if (value.StartsWith("F"))
            {
                return 2;
            }
            return 0;
        }

        private static int EstadoCivil(string estado, string literal)
        {
            string value = (literal.IsNotEmpty() ? literal : estado).ToUpperInvariant();
            if (value.StartsWith("CAS") || value == "C")
            {
                return 1;
            }
            if (value.StartsWith("DIV") || value == "D")
            {
                return 2;
            }
            if (value.StartsWith("SOL") || value == "S")
            {
                return 3;
            }
            if (value.StartsWith("VIU") || value == "V")
            {
                return 4;
            }
            if (value.StartsWith("UNI") || value.StartsWith("ACOM") || value.Contains("LIBRE") || value == "U")
            {
                return 7;
            }
            return 0;
        }

        private static DateTime Fecha(string value)
        {
            DateTime result;
            if (value.IsNotEmpty() &&
                (DateTime.TryParseExact(value, FormatosFecha, CostaRica, DateTimeStyles.AllowWhiteSpaces, out result) ||
                 DateTime.TryParse(value, CostaRica, DateTimeStyles.AllowWhiteSpaces, out result)))
            {
                return result.Date;
            }
            return DateTime.MinValue;
        }

        private static string Nombre(string value)
        {
            return value.IsEmpty() ? string.Empty : CostaRica.TextInfo.ToTitleCase(value.ToLower(CostaRica));
        }

        private static bool Contiene(JObject obj, string name, string value)
        {
            return Texto(obj, name).IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string Texto(JObject obj, string name)
        {
            JToken token = obj?[name];
            return token == null || token.Type == JTokenType.Null ? string.Empty : token.ToString().Trim();
        }
    }
}
