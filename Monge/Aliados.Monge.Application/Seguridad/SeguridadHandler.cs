using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Extensions;
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


        public static Dictionary<string,string> AutorizacionInternal(string clienteID, string secretID, string ipAddress, string userAgent)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (string.IsNullOrEmpty(clienteID) || string.IsNullOrEmpty(secretID))
                {
                    return result;
                }
                else
                {
                    Architect.API.Core.Contracts.Security.Token token = new Token();

                    AuthenticationResponse response = Architect.API.Core.Business.Security.Accounts.Authentication(new AuthenticationRequest()
                    {
                        Tenant = "Aliados",
                        Email = clienteID,
                        Password = secretID,
                        IPAddress = ipAddress,
                        UserAgent = userAgent
                    },  ref token);

                    if (response.Token != null && token != null)
                    {
                        result.Add("UserName", token.UserName);
                        result.Add("UserId", token.UserId.ToString());
                        result.Add("Body", Architect.Utilities.Helpers.CryptSupport.EncryptString(Architect.Utilities.SerializeHandler<Architect.API.Core.Contracts.Security.Token>.Serialize(token).CompressString()) );
                    }
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);
            }


            return result;
        }
        /// <summary>
        /// Permite autenticar un usuario por medio de sus credenciales.
        public static async Task<Domain.Seguridad.RespuestaSeguridad> Autorizacion(string clienteID, string secretID, string ipAddress, string userAgent)
        {
            Domain.Seguridad.RespuestaSeguridad result = null;
            try
            {
                if (string.IsNullOrEmpty(clienteID) || string.IsNullOrEmpty(secretID))
                {
                    return result;
                }
                else
                {
                    Architect.API.Core.Contracts.Security.Token token = null;

                    AuthenticationResponse response = Architect.API.Core.Business.Security.Accounts.Authentication(new AuthenticationRequest()
                    {
                        Tenant = "Aliados",
                        Email = clienteID,
                        Password = secretID,
                        IPAddress = ipAddress,
                        UserAgent = userAgent
                    }, ref token);

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
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);
            }


            return result;
        }

    }
}
