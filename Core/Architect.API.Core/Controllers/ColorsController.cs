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

namespace aliados.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Colors")]
    public class ColorsController : ApiController
    {

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetColors()
        {
            IHttpActionResult result = null;

            List<Architect.API.Core.Contracts.Security.ColoresResponse> colores = new List<Architect.API.Core.Contracts.Security.ColoresResponse>();

            await Task.Run(() => colores = Architect.API.Core.Business.Security.Accounts.ReadColor()).ConfigureAwait(false);

            result = Ok(colores);

            return result;
        }


    }
}
