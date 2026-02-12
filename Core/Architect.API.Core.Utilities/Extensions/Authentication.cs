using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Helpers;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Security.Extensions
{
    public static class AuthenticationExtensions
    {
        private static readonly HttpClient _httpClient;

        static AuthenticationExtensions()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("app.setting.api.core".StringValue())
            };

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <summary>
        /// Authenticates a user asynchronously by sending an authentication request to the core API.
        /// </summary>
        /// <param name="request">The authentication request containing user credentials.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an
        /// <see cref="AuthenticationResponse"/> with authentication details or error information.
        /// </returns>
        /// <remarks>
        /// This method handles various response scenarios:
        /// <list type="bullet">
        /// <item><description>Returns unauthorized response for 401 status codes</description></item>
        /// <item><description>Returns error message for other HTTP failures</description></item>
        /// <item><description>Returns deserialized response for successful requests</description></item>
        /// <item><description>Handles timeouts and network errors gracefully</description></item>
        /// </list>
        /// </remarks>
        /// <exception cref="TaskCanceledException">Handled internally, returns timeout message.</exception>
        /// <exception cref="HttpRequestException">Handled internally, returns error message.</exception>
        /// <exception cref="Exception">Handled internally, returns unexpected error message.</exception>
        public static async Task<AuthenticationResponse> AuthenticateAsync(
            this AuthenticationRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(
                    "api/v1/Security/Authentication",
                    content
                );

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new AuthenticationResponse
                    {
                        Reason = "No autorizado"
                    };
                }

                if (!response.IsSuccessStatusCode)
                {
                    return new AuthenticationResponse
                    {
                        Reason = await response.Content.ReadAsStringAsync()
                    };
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuthenticationResponse>(responseJson);

                return result ?? new AuthenticationResponse
                {
                    Reason = "Empty response from server"
                };
            }
            catch (TaskCanceledException)
            {
                return new AuthenticationResponse
                {
                    Reason = "Request timeout"
                };
            }
            catch (HttpRequestException ex)
            {
                return new AuthenticationResponse
                {
                    Reason = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new AuthenticationResponse
                {
                    Reason = $"Unexpected error: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Validates an OTP (One-Time Password) asynchronously by sending a validation request to the core API.
        /// </summary>
        /// <param name="request">The OTP validation request containing tenant, email, OTP code, and optional password information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an
        /// <see cref="AOTPResponse"/> with validation results or error information.
        /// </returns>
        /// <remarks>
        /// This method validates OTP codes for two-factor authentication (2FA) scenarios.
        /// It handles various response scenarios including unauthorized access, validation failures, and network errors.
        /// </remarks>
        /// <exception cref="TaskCanceledException">Handled internally, returns timeout message.</exception>
        /// <exception cref="HttpRequestException">Handled internally, returns error message.</exception>
        /// <exception cref="Exception">Handled internally, returns unexpected error message.</exception>
        public static async Task<AOTPResponse> ValidateOTPAsync(this Architect.API.Core.Contracts.Security.ResetPasswordRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(
                    "api/v1/Security/IsOTPValid",
                    content
                );

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new AOTPResponse
                    {
                        Successful = false,
                        Reason = "No autorizado"
                    };
                }

                if (!response.IsSuccessStatusCode)
                {
                    return new AOTPResponse
                    {
                        Successful = false,
                        Reason = await response.Content.ReadAsStringAsync()
                    };
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AOTPResponse>(responseJson);

                return result ?? new AOTPResponse
                {
                    Successful = false,
                    Reason = "Empty response from server"
                };
            }
            catch (TaskCanceledException)
            {
                return new AOTPResponse
                {
                    Successful = false,
                    Reason = "Request timeout"
                };
            }
            catch (HttpRequestException ex)
            {
                return new AOTPResponse
                {
                    Successful = false,
                    Reason = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new AOTPResponse
                {
                    Successful = false,
                    Reason = $"Unexpected error: {ex.Message}"
                };
            }
        }
    }
}