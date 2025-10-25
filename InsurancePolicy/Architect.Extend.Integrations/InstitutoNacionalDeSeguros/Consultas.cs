using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Extend.Integrations.InstitutoNacionalDeSeguros
{
    /// <summary>
    /// Consultas de integración por parte del Instituto Nacional de Seguros.
    /// </summary>
    public static class Consultas
    {

        /// <summary>
        /// Permite recuperar la información personal de un cliente por medio de su identificación.
        /// </summary>
        /// <remarks>
        /// tipo
        /// 0 Cédula Física Nacional
        /// 2 Cédula Jurídica Gobierno Central
        /// 3 Cédula Persona Jurídica Nacional
        /// 4 Cédula Institución Autónoma
        /// 6 Documento Migratorio (DIMEX)
        /// 9 Pasaporte
        /// 12 DIDI (Identificación de Diplomáticos)
        /// 
        /// url: https://www.grupo-ins.com/public/seguroescolar?step=1
        /// </remarks>
        public async static Task<Architect.API.Insurance.Contracts.Policy.Insured> PersonaPorIdentificacion(string identificacion, string tipo = "0")
        {
            Architect.API.Insurance.Contracts.Policy.Insured result = null;
            string resultResponse = string.Empty;
            try
            {
                var json = JsonConvert.SerializeObject(new { Identificacion = identificacion, CodigoTipoIdentificacion = tipo });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient() { Timeout = new TimeSpan(0, 0, 2) };
                var response = await client.PostAsync("https://grupo-ins.com/api/ins/svc/clientSearch", data).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    resultResponse = response.Content.ReadAsStringAsync().Result;

                    if (resultResponse.IsNotEmpty())
                    {
                        JObject jsonvalues = JObject.Parse(resultResponse);

                        if (jsonvalues.SelectToken("PrimerNombre") != null)
                        {
                            result = new API.Insurance.Contracts.Policy.Insured()
                            {
                                DocumentType = 1,
                                DocumentNumber = identificacion,
                                FirstName = jsonvalues.SelectStringToken("PrimerNombre"),
                                MiddleName = jsonvalues.SelectStringToken("SegundoNombre"),
                                LastName = jsonvalues.SelectStringToken("PrimerApellido"),
                                SecondLastName = jsonvalues.SelectStringToken("SegundoApellido"),
                                Gender = 0,
                                CivilStatus = 0,
                                PrimaryEmailAddress = jsonvalues.SelectStringToken("email"),
                                Province = 0,
                                Canton = 0,
                                District = 0,
                                AddressDetail = string.Empty,
                                PhoneType = 0,
                                PhoneNumber = jsonvalues.SelectStringToken("phone"),
                                Source = "INS"
                            };
                            switch (jsonvalues.SelectStringToken("CodigoSexo"))
                            {
                                case "F":
                                    result.Gender = 2;
                                    break;
                                case "M":
                                    result.Gender = 1;
                                    break;
                            }
                            switch (jsonvalues.SelectStringToken("CodigoEstadoCivil"))
                            {
                                case "1":
                                    result.CivilStatus = 3;  // Soltero(a)
                                    break;
                                case "2":
                                    result.CivilStatus = 1;  // Casado(a)
                                    break;
                                default:
                                    result.CivilStatus = 5; //5 Otro
                                    break;
                                    //2 Divorciado(a)
                                    //4 Viudo(a)
                                    //6 Acompañado(a)
                            }
                            if (jsonvalues.Value<JArray>("Direcciones") != null)
                            {
                                int conseEmail = 0;
                                int conseAddress = 0;
                                foreach (var item in jsonvalues.Value<JArray>("Direcciones").Children())
                                {
                                    if (item.SelectToken("TipoDireccion").Value<string>() == "06")
                                    {
                                        if (item.SelectToken("ConsecutivoDireccion").Value<int>() > conseEmail)
                                        {
                                            result.PrimaryEmailAddress = item.SelectToken("DireccionCompleta").Value<string>();
                                            conseEmail = item.SelectToken("ConsecutivoDireccion").Value<int>();
                                        }
                                    }
                                    else
                                    {
                                        if (item.SelectToken("ConsecutivoDireccion").Value<int>() > conseAddress)
                                        {
                                            result.Province = item.SelectToken("CodigoProvincia").Value<int>();
                                            result.Canton = Convert.ToInt32(item.SelectToken("CodigoProvincia").Value<string>() + item.SelectToken("CodigoCanton").Value<string>());
                                            result.District = Convert.ToInt32(item.SelectToken("CodigoProvincia").Value<string>() + item.SelectToken("CodigoCanton").Value<string>() + item.SelectToken("CodigoDistrito").Value<string>());
                                            result.AddressDetail = item.SelectToken("DireccionCompleta").Value<string>();
                                            conseAddress = item.SelectToken("ConsecutivoDireccion").Value<int>();
                                        }
                                    }
                                }
                            }
                            if (jsonvalues.Value<JArray>("Telefonos") != null)
                            {
                                int consePhone = 0;
                                foreach (var item in jsonvalues.Value<JArray>("Telefonos").Children())
                                {
                                    if (item.SelectToken("ConsecutivoTelefono").Value<int>() > consePhone)
                                    {
                                        result.PhoneType = item.SelectToken("TipoTelefono").Value<int>();
                                        result.PhoneNumber = item.SelectToken("Numero").Value<string>();
                                        consePhone = item.SelectToken("ConsecutivoTelefono").Value<int>();
                                    }
                                }
                            }

                            result.FirstName = result.FirstName.Trim().Capitalize();
                            result.MiddleName = result.MiddleName.Trim().Capitalize();
                            result.LastName = result.LastName.Trim().Capitalize();
                            result.SecondLastName = result.SecondLastName.Trim().Capitalize();
                            result.AddressDetail = result.AddressDetail.Trim().Capitalize();

                            string birthDate = jsonvalues.SelectToken("FechaNacimiento").Value<string>();

                            result.BirthDate = DateTime.Parse(birthDate);


                            if (result.PhoneNumber.IsNotEmpty())
                            {
                                result.PhoneNumber = result.PhoneNumber.Replace("-", string.Empty).Trim();
                                result.PhoneNumber = result.PhoneNumber.Replace("(", string.Empty).Trim();
                                result.PhoneNumber = result.PhoneNumber.Replace(")", string.Empty).Trim();
                                if (result.PhoneNumber.StartsWith("506"))
                                {
                                    result.PhoneNumber = result.PhoneNumber.Substring(3).Trim();
                                }
                                result.PhoneNumber = result.PhoneNumber.Substring(0, 4) + "-" + result.PhoneNumber.Substring(4, 4);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Data.Add("resultResponse", resultResponse);
                Architect.Utilities.Log.ErrorLog("INS.PersonaPorIdentificacion",
                                                         string.Format("Falla al tratar de consultar a identificación '{0}' tipo '{2}'", identificacion, tipo),
                                                         ex, "integrations");
            }
            return result;
        }

        public static string DocTypeConvert(int docType)
        {
            string instipo = "0";
            switch (docType)
            {
                case 1:
                    instipo = "0";
                    break;
                case 2:
                    instipo = "6";
                    break;
                case 3:
                    instipo = "9";
                    break;
                case 4:
                    instipo = "3";
                    break;
                default:
                    instipo = "0";
                    break;
            }

            return instipo;
        }
    }
    public static class JObjectExtensions
    {

        public static string SelectStringToken(this JObject value, string path, string defaultValue = "" )
        {
            string result = defaultValue;
            JToken token = value.SelectToken(path);
            if (token != null)
            {
                result = token.Value<string>();
            }

            return result;            
        }

    }
}
