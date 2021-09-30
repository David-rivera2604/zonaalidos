using Microsoft.Web.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con los proceso de consultas de clientes.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/TronClient")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TronClientController : ApiController
    {

        [HttpGet]
        [Route("Setup")]
        public async Task<IHttpActionResult> Setup()
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            object result = null;
            await Task.Run(() =>
            {
                result = new { url = Architect.API.Tron.Business.Clientes.Support.ExternalURL(tokenInfo.IdentificationType, tokenInfo.Identification) };
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

    }
}
