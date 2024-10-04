using Architect.API.Tron.Contracts.Robots;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Backoffice.Batch
{
    /// <summary>  
    /// Funcionalidad para buscar información de vehículos en el registro nacional por medio de su placa.  
    /// </summary>  
    public static class SinPlaca
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>  
        /// Ubica los vehículos que no tienen placa para solicitar su información.  
        /// </summary>  
        public static async Task RetrieveUnregisteredVehiclesAsync(int offset, int size)
        {
            string dataapiUrlSetting = Core.Business.Settings.StringValue("Aliados.URL.DataApi", "https://appqa.mapfrecr.com/datapides/api/entity");

            if (size == 0)
            {
                size = Core.Business.Settings.IntegerValue("Batch.SinPlaca.Cantidad.Vehiculos", 9);
            }

            List<object> vehiculos = new List<object>();

            JObject response = await GetDataFromDataAPIAsync($"{dataapiUrlSetting}/sinplaca?beginIndex={offset + 1}&endIndex={offset + size}").ConfigureAwait(false);

            if (response.IsSuccess())
            {
                foreach (var item in response.Value<JArray>("Sinplaca").Children())
                {
                    vehiculos.Add(new { identificationType = "Chassis", identification = item.SelectToken("Chasis").Value<string>() });
                }
                if (vehiculos.Count > 0)
                {
                    await SubmitVehicleInfoQueryAsync(vehiculos).ConfigureAwait(false);
                }
            }
            else
            {
                throw new Architect.Utilities.Exceptions.CustomException("Falla al tratar de obtener la lista de vehículos sin placa.");
            }
        }


        /// <summary>
        /// Procesa la información de vehículos sin placa, para la asignación de la misma.
        /// </summary>
        public static async Task ProcessLicensePlateUpdateAsync(List<Contracts.Robots.CivilRegistrationRequest> vehicles)
        {
            string dataapiUrlSetting = Core.Business.Settings.StringValue("Aliados.URL.DataApi", "https://appqa.mapfrecr.com/datapides/api/entity");

            foreach (var vehicleInf in vehicles)
            {
                if (string.IsNullOrEmpty(vehicleInf.GeneralCharacteristicsVehicle?.LicensePlate))
                {
                    continue;
                }

                JObject response = await GetDataFromDataAPIAsync($"{dataapiUrlSetting}/sinplaca/poliza?chasis={vehicleInf.Identification}").ConfigureAwait(false);
                if (response.IsSuccess())
                {
                    var poliza = response.SelectToken("Poliza")?.Value<JObject>();
                    if (poliza != null)
                    {
                        string licensePlate = poliza.SelectToken("VAL_CAMPO").Value<string>();
                        if (licensePlate != vehicleInf.GeneralCharacteristicsVehicle.LicensePlate)
                        {
                            await ApplyLicensePlateVariationAsync(vehicleInf, poliza).ConfigureAwait(false);
                        }
                    }
                }
                else
                {
                    throw new Architect.Utilities.Exceptions.CustomException("Falla al tratar de obtener información de la póliza.");
                }
            }
        }

        /// <summary>
        /// Envía la solicitud de información de vehículos sin placa al servicio de robots.
        /// </summary>
        private static async Task SubmitVehicleInfoQueryAsync(List<object> vehiculos)
        {
            string callbackUrlSetting = Core.Business.Settings.StringValue("Batch.SinPlaca.Callback", "https://webhook.site/041ed213-07ae-4584-af92-d6e6ed43ad0f");
            string robotsUrlSetting = Core.Business.Settings.StringValue("Aliados.URL.Robots", "https://appqa.mapfrecr.com/robots.registro.cr/api");

            var json = JsonConvert.SerializeObject(new { callbackUrl = callbackUrlSetting, queries = vehiculos });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{robotsUrlSetting}/v1/VehicleInformation/Information", data).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject jsonvalues = JObject.Parse(responseBody);
                string id = jsonvalues.SelectToken("Id").Value<string>();
                Core.Business.General.ChangeSet.Create(2500, 1, 0, $"Se solicita de información de vehículos ({id})", $"Se solicita información para {vehiculos.Count} vehículos", 0, vehiculos);
            }
            catch (HttpRequestException e)
            {
                throw new Architect.Utilities.Exceptions.CustomException("Error al enviar la solicitud de información de vehículos sin placa.", e);
            }
        }

        /// <summary>
        /// Aplica la variación de placa para un vehículo sin placa.
        /// </summary>
        private static async Task ApplyLicensePlateVariationAsync(CivilRegistrationRequest vehicleInf, JObject poliza)
        {
            string num_poliza = poliza.SelectToken("NUM_POLIZA").Value<string>();
            string oldValue = poliza.SelectToken("VAL_CAMPO").Value<string>();
            Core.Business.General.ChangeSet.Create(2500, 2, 0, $"Procesa la información de un vehículo sin placa ({vehicleInf.Reference})", $"Se aplicar variación de placa {oldValue} a {vehicleInf.GeneralCharacteristicsVehicle.LicensePlate}, para la póliza #{num_poliza}", 0, null);

            DataAccess.DatosVariables.AplicarVariacion(
                poliza.SelectToken("COD_RAMO").Value<int>(),
                num_poliza,
                poliza.SelectToken("NUM_RIESGO").Value<int>(),
                "NUM_MATRICULA",
                oldValue,
                vehicleInf.GeneralCharacteristicsVehicle.LicensePlate, DateTime.Today, "ZA: Asignación de placa");
        }



        /// <summary>
        /// Indica si la respuesta de la API es exitosa.
        /// </summary>
        private static bool IsSuccess(this JObject value)
        {
            return value.SelectToken("_error") == null;
        }

        /// <summary>
        /// Realiza una solicitud HTTP GET a la URL proporcionada y devuelve la respuesta como un objeto JObject.
        /// </summary>
        private static async Task<JObject> GetDataFromDataAPIAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return responseBody.IsNotEmpty() ? JObject.Parse(responseBody) : new JObject { ["_error"] = "Empty response" };
                }
                else
                {
                    return new JObject { ["_error"] = "Request not success. " + response.ReasonPhrase };
                }
            }
            catch (HttpRequestException e)
            {
                Utilities.Log.ErrorLog("DataApiGetAsync", $"Falla al tratar de ejecutar el request para la url {url}.", e);
                return new JObject { ["_error"] = "Fail. " + e.Message };
            }
        }

    }
}
