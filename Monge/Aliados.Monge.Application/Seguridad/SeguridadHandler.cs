using Architect.API.Core.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace Aliados.Monge.Application.Seguridad
{
    public sealed class SeguridadHandler
    {

        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        public static async Task<Domain.Seguridad.RespuestaSeguridad> Autorizacion(string clienteID, string secretID, string ipAddress, string userAgent)
        {
            Domain.Seguridad.RespuestaSeguridad result = null;
            if (string.IsNullOrEmpty(clienteID) || string.IsNullOrEmpty(secretID))
            {
                return result;
            }
            else
            {
                AuthenticationResponse response = Architect.API.Core.Business.Security.Accounts.Authentication(new AuthenticationRequest()
                {
                    Tenant = "Aliados",
                    Email = clienteID,
                    Password = secretID,
                    IPAddress = ipAddress,
                    UserAgent = userAgent
                });

                if (response != null)
                {
                    result = new Domain.Seguridad.RespuestaSeguridad()
                    {
                        access_token = response.Token,
                        token_type = "Bearer",
                        expires_in = response.ExpiresIn
                    };
                }
            }
            return result;
        }

    }
}
