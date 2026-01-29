using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.API.Core.Business.Security;
using Architect.API.Core.Contracts.Security;
using System;
using System.Web;




namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Gestion de procesos para la autenticacion del usuario gestor del Tenant.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/CasesSecurity")]
    public class SecurityCasesController : ApiController
    {
        /// <summary>
        /// Creacion del token de autorizacion para los casos 
        /// </summary>
        [HttpGet]
        [Route("Create")]

        public async Task<IHttpActionResult> Create([FromUri] string Tenant)
        {
            Core.Contracts.Security.Token tokenInfo = Security.Token.Info();
            IHttpActionResult result = null;
            string UserWebConfi = "Security.Users.Cases." + Tenant;
            string UserCreate = Architect.Utilities.Helpers.Settings.StringValue(UserWebConfi);
            string currentToken = string.Empty;
            if (UserCreate == "")
            {
                result = BadRequest("Necesita un encargado gestionado los casos");
            }
            else
            {

                var ck = HttpContext.Current?.Request?.Cookies["AuthToken"];

                if (ck.IsNotEmpty() && ck.Value.IsNotEmpty())
                {
                    currentToken = ck.Value;
                }

                string[] ListElement = UserCreate.Split(';');


                AuthenticationRequest Envio = new AuthenticationRequest()
                {
                    Email = ListElement[1],
                    EmployeeMode = false,
                    IPAddress = null,
                    Password = ListElement[2],
                    Tenant = ListElement[0],
                    UserAgent = null,
                };

                if (Envio.IsEmpty())
                {
                    result = BadRequest("Debe indicar los datos");
                }
                else
                {
                    AuthenticationResponse responseItem = null;
                    Envio.IPAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
                    Envio.UserAgent = Request.Headers.UserAgent.ToString();
                    Architect.API.Core.Contracts.Security.Token token = new Architect.API.Core.Contracts.Security.Token();

                    await Task.Run(() => responseItem = Architect.API.Core.Business.Security.Accounts.Authentication(Envio, ref token, false)).ConfigureAwait(false);

                    Token_Al TokenJs = new Token_Al()
                    {
                        TokenAliado = responseItem.Token,
                        user = ListElement[1].ToLower(),
                        CurrentUserId = tokenInfo.UserId,
                        CurrentToken = currentToken
                    };
                    if (responseItem.Reason.IsNotEmpty())
                    {
                        if (responseItem.Reason.Equals("No autorizado", StringComparison.CurrentCultureIgnoreCase))
                            result = Unauthorized();
                        else
                            result = BadRequest(responseItem.Reason);
                    }
                    else
                    {
                        result = Ok(TokenJs);
                    }
                }

                return result;
            }
            return result;

        }
    }

    /// <summary>
    /// Clase con el Token gestor de los casos
    /// </summary>
    public class Token_Al
    {
        /// <summary>
        /// Token de el usuario gestor de los casos.
        /// </summary>
        public string TokenAliado { get; set; }
        public string user { get; set; }
        public int CurrentUserId { get; set; }
        public string CurrentToken { get; set; }
        

    }
}
