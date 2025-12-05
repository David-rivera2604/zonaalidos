using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Architect.Utilities
{

    /// <summary>
    /// 
    /// </summary>
    /// <example>
    ///   string baseUrl = "https://tu-api-rest.com/api/"; // Reemplaza con tu URL base
    ///   var restClient = new RestClient(baseUrl);
    ///   
    ///   var requestData = new RequestData { Nombre = "Nuevo Nombre", Edad = 40 };
    ///   
    ///   // Ejemplos de uso de los nuevos métodos
    ///   (ResponseData getResponse, string getError) = await restClient.GetAsync<ResponseData>("endpoint/1");
    ///   if(getError != null) Console.WriteLine($"Error en GET: {getError}");
    ///   else Console.WriteLine($"GET: ID: {getResponse.Id}, Mensaje: {getResponse.Mensaje}");
    ///   
    ///   (ResponseData postResponse, string postError) = await restClient.PostAsync<RequestData, ResponseData>("endpoint", requestData);
    ///   if (postError != null) Console.WriteLine($"Error en POST: {postError}");
    ///   else Console.WriteLine($"POST: ID: {postResponse.Id}, Mensaje: {postResponse.Mensaje}");
    ///   
    ///   (ResponseData putResponse, string putError) = await restClient.PutAsync<RequestData, ResponseData>("endpoint/1", requestData);
    ///   if(putError != null) Console.WriteLine($"Error en PUT: {putError}");
    ///   else Console.WriteLine($"PUT: ID: {putResponse.Id}, Mensaje: {putResponse.Mensaje}");
    ///   
    ///   (VoidResponse deleteResponse, string deleteError) = await restClient.DeleteAsync<VoidResponse>("endpoint/1");
    ///   if(deleteError != null) Console.WriteLine($"Error en DELETE: {deleteError}");
    ///   else Console.WriteLine("DELETE ejecutado");
    /// </example>
    public class RestClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _source;

        public string ResponseContent { get; set; }
        public bool ThrowException { get; set; }

        public RestClient(string baseUrl, string source)
        {
            _baseUrl = baseUrl;
            _source = source;
            //_httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ThrowException = true;
        }

        public RestClient(string baseUrl, string source, bool throwException)
        {
            _baseUrl = baseUrl;
            _source = source;
            //_httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ThrowException = throwException;
        }

        public RestClient(string baseUrl, string source, bool throwException, TimeSpan timeout)
        {
            _baseUrl = baseUrl;
            _source = source;
            //_httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            _httpClient = new HttpClient();
            _httpClient.Timeout = timeout;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ThrowException = throwException;
        }

        private async Task<TResponse> SendAsync<TRequest, TResponse>(HttpMethod method, string endpoint, TRequest data = default(TRequest))
        {
            string stringResponse = null;
            string message = null;
            string json = null;
            try
            {
                string url = _baseUrl.EndsWith("/") ? $"{_baseUrl}{endpoint}" : $"{_baseUrl}/{endpoint}";
                var request = new HttpRequestMessage(method, url);

                if (data != null && !data.Equals(default(TRequest))) // Comprobación mejorada para tipos de valor
                {
                    json = JsonConvert.SerializeObject(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                using (var response = await _httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        if (typeof(TResponse) == typeof(string))
                        {
                            stringResponse = await response.Content.ReadAsStringAsync();
                            ResponseContent = stringResponse;
                            return (TResponse)(object)stringResponse;
                        }
                        else if (typeof(TResponse) == typeof(byte[]))
                        {
                            var bytesResponse = await response.Content.ReadAsByteArrayAsync();
                            return (TResponse)(object)bytesResponse;
                        }
                        else if (typeof(TResponse) == typeof(VoidResponse))
                        {
                            return default(TResponse);
                        }
                        else
                        {
                            stringResponse = await response.Content.ReadAsStringAsync();
                            ResponseContent = stringResponse;
                            var responseObject = JsonConvert.DeserializeObject<TResponse>(stringResponse);
                            return responseObject;
                        }
                    }
                    else
                    {
                        stringResponse = await response.Content.ReadAsStringAsync();
                        ResponseContent = stringResponse;
                        message = $"Se ha recibido una respuesta fallida al hacer el llamado REST del tipo {method.Method} a la URL {_baseUrl}/{endpoint}. Detalle de la respuesta:\n {stringResponse}";
                        if (ThrowException)
                        {
                            var customEx =  new Utilities.Exceptions.CustomException(message, stringResponse);
                            customEx.Data?.Add("json", json);
                            throw customEx;
                        }
                        else
                        {
                            Log.ErrorLog("RestClient", message);
                        }


                    }
                }
            }
            catch (HttpRequestException ex)
            {
                message = $"Ha ocurrido un error de comunicación al intentar realizar un llamado REST del tipo {method.Method} a la URL {_baseUrl}/{endpoint}";
                if (ThrowException)
                {
                    throw new Utilities.Exceptions.CustomException(message, ex, stringResponse);
                }
                else
                {
                    Log.ErrorLog("RestClient", message);
                }
            }
            catch (JsonException ex)
            {
                message = $"Ha ocurrido un error al intentar deserializar la respuesta JSON del llamado REST del tipo {method.Method} a la URL {_baseUrl}/{endpoint}";
                if (ThrowException)
                {
                    throw new Utilities.Exceptions.CustomException(message, ex, stringResponse);
                }
                else
                {
                    Log.ErrorLog("RestClient", message);
                }
            }
            catch (Utilities.Exceptions.CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                message = $"Ha ocurrido un error inesperado al intentar realizar un llamado REST del tipo {method.Method} a la URL {_baseUrl}/{endpoint}";
                if (ThrowException)
                {
                    throw new Utilities.Exceptions.CustomException(message, ex, stringResponse);
                }
                else
                {
                    Log.ErrorLog("RestClient", message);
                }
            }
            return default(TResponse);
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            return await SendAsync<object, TResponse>(HttpMethod.Get, endpoint);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            return await SendAsync<TRequest, TResponse>(HttpMethod.Post, endpoint, data);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            return await SendAsync<TRequest, TResponse>(HttpMethod.Put, endpoint, data);
        }

        public async Task<TResponse> DeleteAsync<TRequest, TResponse>(string endpoint)
        {
            return await SendAsync<TRequest, TResponse>(HttpMethod.Delete, endpoint);
        }

        public async Task DeleteAsync(string endpoint)
        {
            await SendAsync<object, VoidResponse>(HttpMethod.Delete, endpoint);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

    }

    //Clase para cuando no se espera una respuesta
    internal class VoidResponse
    {

    }

}
