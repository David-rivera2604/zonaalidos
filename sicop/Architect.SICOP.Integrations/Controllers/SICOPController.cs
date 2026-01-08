using Architect.SICOP.Integrations.RcvGurtWS;
using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.SICOP.Integrations.Controllers
{
    /// <summary>
    /// .
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/SICOP")]
    public class SICOPController : ApiController
    {

        [HttpGet]
        [Route("InformacionProveedor")]
        public async Task<IHttpActionResult> InformacionProveedor([FromUri] string id)
        {
            API.Core.Contracts.Security.Token tokenInfo = API.Core.Security.Token.Info();
            Contracts.SUPPLIER_INFO result = null;
            await Task.Run(() =>
            {
                result = Business.InformacionProveedor.SupplierInfo(id, tokenInfo.CompanyId);
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("NotificarGarantia")]
        public async Task<IHttpActionResult> NotificarGarantia([FromBody] RcvGurtBean request)
        {
            API.Core.Contracts.Security.Token tokenInfo = API.Core.Security.Token.Info();
            GurtResponseBean result = null;
            await Task.Run(() =>
            {
                result = Business.NotificarGarantia.RcvGurtWService(request, tokenInfo.CompanyId);
            });

            return Created(string.Empty, result);
        }

        [HttpPost]
        [Route("NotificarLiberacion")]
        public async Task<IHttpActionResult> NotificarLiberacion([FromBody] ResultGurtWS.ResultGurtBean request)
        {
            API.Core.Contracts.Security.Token tokenInfo = API.Core.Security.Token.Info();
            ResultGurtWS.GurtResponseBean result = null;
            await Task.Run(() =>
            {
                result = Business.NotificarLiberacion.ResultGurtWService(request, tokenInfo.CompanyId);
            });

            return Created(string.Empty, result);
        }

    }
}



