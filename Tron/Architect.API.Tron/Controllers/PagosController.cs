using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con pagos online.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Pagos")]
    public class PagosController : ApiController
    {

        [HttpPost]
        [Route("Sesion")]
        public async Task<IHttpActionResult> postPayment([FromBody] Contracts.CreateSession sessionRequest)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            string ipAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string userAgent = Request.Headers.UserAgent.ToString();

            Payment.Integrations.Contracts.SessionInformation result = await Business.Backoffice.Pagos.CrearSesion(tokenInfo.CompanyId, tokenInfo.UserId, ipAddress, userAgent, tokenInfo.AgentCode, sessionRequest.num_poliza, sessionRequest.num_recibo);

            return Ok(result);
        }

        [HttpPost]
        [Route("Sesion/{requestId}")]
        public async Task<IHttpActionResult> Refresh([FromUri] Int64 requestId)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Payment.Integrations.Providers.Placetopay.Contracts.InformationRequest result = await Payment.Integrations.Payment.GetRequestInformation(tokenInfo.CompanyId, tokenInfo.UserId, requestId, true);

            return Ok(result);
        }

        [HttpPost]
        [Route("Sesion/ref={reference}")]
        public async Task<IHttpActionResult> Refresh([FromUri] string reference)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Payment.Integrations.Providers.Placetopay.Contracts.InformationRequest result = await Payment.Integrations.Payment.GetRequestInformation(tokenInfo.CompanyId, tokenInfo.UserId, reference, true);

            return Ok(result);
        }

        [HttpPost]
        [Route("Notificar")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Notify(Payment.Integrations.Providers.Placetopay.Contracts.NotifyRequest notify)
        {
            await Payment.Integrations.Payment.Notify(1, 1, notify);

            return Ok();
        }

    }
}
