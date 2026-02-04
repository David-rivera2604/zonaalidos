using Asp.Versioning;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Siniestros Manuales
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/DocuSign")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DocuSignController : ApiController
    {

        /// <summary>
        /// Recupera la información de un siniestro manual por medio de su identificación única.
        /// </summary>
        [HttpGet]
        [Route("{uniqueId}")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Verify([FromUri] string uniqueId)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            string result = string.Empty;

            await Task.Run(() =>
            {
                result = Business.Policy.DigitalSignature.Verify(uniqueId);
            }).ConfigureAwait(false);

            return Ok(result);
        }

    }
}
