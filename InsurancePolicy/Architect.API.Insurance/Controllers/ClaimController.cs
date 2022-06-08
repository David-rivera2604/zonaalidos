using Architect.Utilities.Extensions;
using Architect.API.Insurance.Contracts.Product;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Siniestros Manuales
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Claim")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ClaimController : ApiController
    {

        /// <summary>
        /// Recupera la información de un siniestro manual por medio de su identificación única.
        /// </summary>
        /// <param name="id">Identificación única del siniestro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        /// <returns>Información de un siniestro manual</returns>
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Get([FromUri] int id, [FromUri] string include = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Contracts.ManualClaims.Claim result = null;

            await Task.Run(() =>
            {
                result = Business.ManualClaims.Claim.Retrieve(tokenInfo.CompanyId, id, string.Empty, include);
            }).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Recupera la información de un siniestro manual por medio de su identificación de siniestro.
        /// </summary>
        /// <param name="claimId">Identificación del siniestro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        /// <returns>Información de un siniestro manual</returns>
        [HttpGet]
        [Route("{claimId}/ByClaimId")]
        [Authorize]
        public async Task<IHttpActionResult> GetByClaimId([FromUri] string claimId, [FromUri] string include = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Contracts.ManualClaims.Claim result = null;

            await Task.Run(() =>
            {
                result = Business.ManualClaims.Claim.Retrieve(tokenInfo.CompanyId, 0, claimId, include);
            }).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Recupera un registro en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        [HttpGet]
        [Route("Policy/{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> GetPolicy([FromUri] int id, [FromUri] string include = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Contracts.ManualPolicies.Policy result = null;

            await Task.Run(() =>
            {
                result = Business.ManualPolicies.Policy.Retrieve(tokenInfo.CompanyId, id, include);
            }).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        /// <summary>
        /// Recupera un registro en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        [HttpGet]
        [Route("Certificate/{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> GetCertificate([FromUri] int id, [FromUri] string include = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Contracts.ManualPolicies.Certificate result = null;

            await Task.Run(() =>
            {
                result = Business.ManualPolicies.Certificate.Retrieve(tokenInfo.CompanyId, id, include);
            }).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        /// <summary>
        /// Recupera un registro en la tabla ThirdParty por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        [HttpGet]
        [Route("ThirdParty/{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> GetThirdParty([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Contracts.Policy.ThirdParty result = null;

            await Task.Run(() =>
            {
                result = Business.Policy.ThirdParty.Retrieve(tokenInfo.CompanyId, id);
            }).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
