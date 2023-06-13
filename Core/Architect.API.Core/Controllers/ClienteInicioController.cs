using Microsoft.Web.Http;
using System.Web.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Architect.Utilities.Extensions;
using System.Web.Http.Description;
using System.Diagnostics.Contracts;
using Architect.API.Core.Contracts;
using Architect.API.Core.Business.Security;


namespace Architect.API.Core.Controllers

{
    public class ClienteInicioController : ApiController
    {

        [ApiVersion("1.0")]
        [Authorize]
        [RoutePrefix("api/v{version:apiVersion}/Clientes")]
        public class ClientesController : ApiController
        {

            [HttpGet]
            [Route("GetInicio")]
            [AllowAnonymous]
            public async Task<IHttpActionResult> GetInicio()
            {
                Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
                IHttpActionResult result = null;

                Architect.API.Core.Contracts.Security.ClientesInicioResponse inicio = new Architect.API.Core.Contracts.Security.ClientesInicioResponse();

                await Task.Run(() => {

                    inicio = Architect.API.Core.Business.Security.Accounts.ReadInicio(tokenInfo);
                
                
                })
                .ConfigureAwait(false);
                
                
                result = Ok(inicio);

                return result;
            }

            [HttpPost]
            [Route("PostInicio")]
            [Authorize]
            public async Task<IHttpActionResult> PostInicio([FromBody] Architect.API.Core.Contracts.Security.ClientesInicioResponse item)
            {

                Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
                IHttpActionResult result = null;
                await Task.Run(() =>
                {
                    Architect.API.Core.Contracts.General.ChangeInicioResult newcreate = Architect.API.Core.Business.General.ChangeInicio.Update(item, tokenInfo);
                    result = Ok(newcreate);
                })
                    .ConfigureAwait(false);

                return result;
            }


        }



    }
}
