using Architect.Payment.Integrations.Contracts.v2;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Tron.Controllers.v2
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con pagos online.
    /// </summary>
    [ApiVersion("2.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Pagos")]
    public class PagosController : ApiController
    {


        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        /// <param name="sessionRequest">Datos para la creación de una sesión de pago.</param>
        [HttpPost]
        [Route("Sesion")]
        [ResponseType(typeof(Payment.Integrations.Contracts.v2.PaymentInformation))]
        public async Task<IHttpActionResult> postPayment([FromBody] Contracts.CreateSession sessionRequest)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string ipAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string userAgent = Request.Headers.UserAgent.ToString();

            Payment.Integrations.Contracts.v2.PaymentInformation result = await Business.Backoffice.v2.Pagos.CrearSesion(tokenInfo, ipAddress, userAgent, sessionRequest.num_poliza, sessionRequest.num_recibo);

            return Ok(result);
        }

        [HttpPost]
        [Route("Webhook")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IHttpActionResult> Webhook(Architect.Payment.Integrations.Contracts.v2.WebhookRequest webhookRequest)
        {
            await Business.Backoffice.v2.Pagos.Webhook(webhookRequest);

            return Ok();
        }

        /// <summary>
        /// Permite el envio de un link de pago.
        /// </summary>
        [HttpPost]
        [Route("SendPaymentLink")]
        [ResponseType(typeof(Payment.Integrations.Contracts.v2.PaymentInformation))]
        public async Task<IHttpActionResult> SendPaymentLink([FromBody] Contracts.CreateSession sessionRequest)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            string ipAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string userAgent = Request.Headers.UserAgent.ToString();

            Payment.Integrations.Contracts.v2.PaymentInformation result = await Business.Backoffice.v2.Pagos.SendPaymentLink(tokenInfo, ipAddress, userAgent, sessionRequest.num_poliza, sessionRequest.num_recibo, sessionRequest.mode);

            return Ok(result);
        }

        /// <summary>
        /// Procesar el resultado del pago para los recibos con cobro recurrente.
        /// </summary>
        [HttpPost]
        [Route("RecurringReceipts")]
        [Authorize(Roles = "Silice")]
        public async Task<IHttpActionResult> RecurringReceipts([FromBody] Payment.Integrations.Contracts.v2.ReciboResponse request)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            var json = JsonConvert.SerializeObject(request);
            Utilities.Log.TraceLog("RecurringReceipts", json);

            await Business.Backoffice.v2.Pagos.RecurringReceipts(request);

            return Ok(string.Empty);
        }

        [HttpGet]
        [Route("silicet")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> silicet()
        {
            int recordCount = Architect.API.Tron.Business.Backoffice.v2.Pagos.TokenizeTarjetas();

            return Ok(recordCount);
        }

        [HttpGet]
        [Route("silicer")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> silicer()
        {
            int recordCount = Architect.API.Tron.Business.Backoffice.v2.Pagos.PendientesRecurrentesAlCobro();

            return Ok(recordCount);
        }

    }
}
