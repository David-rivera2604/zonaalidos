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
using Swashbuckle.Swagger;

namespace aliados.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Colors")]
    public class ColorsController : ApiController
    {

        [HttpGet]
        [Route("GetColor")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetColors()
        {
            IHttpActionResult result = null;

            List<Architect.API.Core.Contracts.Security.ColoresResponse> colores = new List<Architect.API.Core.Contracts.Security.ColoresResponse>();

            await Task.Run(() => colores = Architect.API.Core.Business.Security.Accounts.ReadColor()).ConfigureAwait(false);

            result = Ok(colores);

            return result;
        }


        [HttpPost]
        [Route("PostColor")]
        [Authorize]
        public async Task<IHttpActionResult> PostColor([FromBody] Architect.API.Core.Contracts.Security.ColoresResponse item)
        {
            
            IHttpActionResult result = null;
            
            
            await Task.Run(() =>
            {
                Architect.API.Core.Contracts.General.ChangeColorResult created = Architect.API.Core.Business.General.ChangeColor.Update(item);
                result = Ok(created);
            })
                .ConfigureAwait(false);
            
            return result;
        }
    }

    




}