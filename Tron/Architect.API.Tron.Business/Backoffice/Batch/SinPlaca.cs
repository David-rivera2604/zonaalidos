using Architect.API.Tron.Contracts.Comun;
using Architect.API.Tron.Contracts.Poliza;
using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>  
        /// Ubica los vehículos que no tienen placa para solicitar su información.  
        /// </summary>  
        public static async Task SolicitarInformacionDeVehiculosAsync(int endIndex = 0)
        {

            string callbackUrl = Utilities.Helpers.Settings.StringValue("Batch.SinPlaca.Callback", "https://webhook.site/041ed213-07ae-4584-af92-d6e6ed43ad0f");
            string dataapiUrl = Utilities.Helpers.Settings.StringValue("Aliados.URL.DataApi", "https://appqa.mapfrecr.com/datapides/api/entity");
            string robotsUrl = Utilities.Helpers.Settings.StringValue("Aliados.URL.Robots", "https://appqa.mapfrecr.com/robots.registro.cr/api");

            if (endIndex == 0)
            {
                endIndex = Utilities.Helpers.Settings.IntegerValue("Batch.SinPlaca.Cantidad.Vehiculos", 9);
            }

            List<object> vehiculos = new List<object>();
            using (var client = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await client.GetAsync($"{dataapiUrl}/sinplaca?endIndex={endIndex}");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        if (responseBody.IsNotEmpty())
                        {
                            JObject jsonvalues = JObject.Parse(responseBody);
                            foreach (var item in jsonvalues.Value<JArray>("Sinplaca").Children())
                            {
                                vehiculos.Add(new { identificationType = "Chassis", identification = item.SelectToken("Chasis").Value<string>() });
                            }
                        }
                        else
                        {
                            throw new Architect.Utilities.Exceptions.CustomException("Falla al tratar de obtener la lista de vehículos sin placa.");
                        }
                    }
                    else
                    {
                        throw new Architect.Utilities.Exceptions.CustomException("Falla al tratar de obtener la lista de vehículos sin placa.");
                    }
                }
                catch (HttpRequestException e)
                {
                    throw new Architect.Utilities.Exceptions.CustomException(string.Empty, e);
                }
                if (vehiculos.Count > 0)
                {
                    using (var postClient = new HttpClient())
                    {
                        try
                        {



                            var json = JsonConvert.SerializeObject(new { callbackUrl = callbackUrl, queries = vehiculos });
                            var data = new StringContent(json, Encoding.UTF8, "application/json");
                            var response = await postClient.PostAsync($"{robotsUrl}/v1/VehicleInformation/Information", data).ConfigureAwait(false);
                            response.EnsureSuccessStatusCode();
                            if (response.IsSuccessStatusCode)
                            {

                                string responseBody = response.Content.ReadAsStringAsync().Result;
                                JObject jsonvalues = JObject.Parse(responseBody);
                                string id = jsonvalues.SelectToken("id").Value<string>();
                                Core.Business.General.ChangeSet.Create(2500, 1, 0, $"Se solicita de información de vehículos ({id})", $"Se solicita información para {vehiculos.Count} vehículos", 0, vehiculos);

                            }

                        }
                        catch (HttpRequestException e)
                        {
                            throw new Architect.Utilities.Exceptions.CustomException(string.Empty, e);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Procesa la información de vehículos sin placa, para la asignación de la misma.
        /// </summary>
        public static async Task AplicaCambioDePlacaAsync(List<Contracts.Robots.CivilRegistrationRequest> vehicles)
        {
            string dataapiUrl = Utilities.Helpers.Settings.StringValue("Aliados.URL.DataApi", "https://appqa.mapfrecr.com/datapides/api/entity");

            foreach (Contracts.Robots.CivilRegistrationRequest vehicleInf in vehicles)
            {
                if (string.IsNullOrEmpty(vehicleInf.GeneralCharacteristicsVehicle?.LicensePlate))
                {
                    continue;
                }

                using (var client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"{dataapiUrl}/sinplaca/poliza?chasis={vehicleInf.Identification}");
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            if (responseBody.IsNotEmpty())
                            {
                                JObject jsonvalues = JObject.Parse(responseBody);
                                if (jsonvalues.SelectToken("Poliza") != null)
                                {
                                    JObject poliza = jsonvalues.SelectToken("Poliza").Value<JObject>();
                                    string licensePlate = poliza.SelectToken("VAL_CAMPO").Value<string>();
                                    if (licensePlate != vehicleInf.GeneralCharacteristicsVehicle.LicensePlate)
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
                                }

                            }
                            else
                            {
                                throw new Architect.Utilities.Exceptions.CustomException("Falla al tratar de obtener información de la póliza.");
                            }
                        }
                        else
                        {
                            throw new Architect.Utilities.Exceptions.CustomException("Falla al tratar de obtener información de la póliza.");
                        }
                    }
                    catch (HttpRequestException e)
                    {
                        throw new Architect.Utilities.Exceptions.CustomException("Falla al tratar de obtener información de la póliza.", e);
                    }
                }
            }
        }
    }
}
