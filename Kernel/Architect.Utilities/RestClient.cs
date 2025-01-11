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
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </example>
    public class RestClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RestClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<(TResponse, ApiError)> SendAsync<TRequest, TResponse>(HttpMethod method, string endpoint, TRequest data = default(TRequest))
        {
            try
            {
                var request = new HttpRequestMessage(method, endpoint);

                if (data != null && !data.Equals(default(TRequest))) // Comprobación mejorada para tipos de valor
                {
                    var json = JsonConvert.SerializeObject(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                using (var response = await _httpClient.SendAsync(request))
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        if (typeof(TResponse) == typeof(VoidResponse))
                            return (default(TResponse), null);

                        var responseObject = JsonConvert.DeserializeObject<TResponse>(responseContent);
                        return (responseObject, null);
                    }
                    else
                    {
                        return (default(TResponse), new ApiError
                        {
                            StatusCode = (int)response.StatusCode,
                            Message = responseContent
                        });
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return (default(TResponse), new ApiError { Message = $"Error de red: {ex.Message}" });
            }
            catch (JsonException ex)
            {
                return (default(TResponse), new ApiError { Message = $"Error al deserializar JSON: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return (default(TResponse), new ApiError { Message = $"Error inesperado: {ex.Message}" });
            }
        }

        public async Task<(TResponse, ApiError)> GetAsync<TResponse>(string endpoint)
        {
            return await SendAsync<object, TResponse>(HttpMethod.Get, endpoint);
        }

        public async Task<(TResponse, ApiError)> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            return await SendAsync<TRequest, TResponse>(HttpMethod.Post, endpoint, data);
        }

        public async Task<(TResponse, ApiError)> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            return await SendAsync<TRequest, TResponse>(HttpMethod.Put, endpoint, data);
        }

        public async Task<(TResponse, ApiError)> DeleteAsync<TResponse>(string endpoint)
        {
            return await SendAsync<object, TResponse>(HttpMethod.Delete, endpoint);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

    }

    public class ApiError
    {
        public string Message { get; set; }
        public int? StatusCode { get; set; }
    }


    //Clase para cuando no se espera una respuesta
    public class VoidResponse
    {

    }

}
