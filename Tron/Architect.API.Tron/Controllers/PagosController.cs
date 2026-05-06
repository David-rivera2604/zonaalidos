using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.Utilities.Extensions;
using Asp.Versioning;

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
        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        /// <param name="sessionRequest">Datos para la creación de una sesión de pago.</param>
        [HttpPost]
        [Route("Sesion")]
        [ResponseType(typeof(Payment.Integrations.Contracts.SessionInformation))]
        public async Task<IHttpActionResult> postPayment([FromBody] Contracts.CreateSession sessionRequest)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Payment.Integrations.Contracts.SessionInformation result = null;
            global::Architect.API.Core.Contracts.Traza.TrackSession session = global::Architect.API.Core.Business.Traza.TrackRequest.NewSession(tokenInfo, "Pagos/CrearSesion", sessionRequest);
            try
            {
                string ipAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
                string userAgent = Request.Headers.UserAgent.ToString();
                int agentCode = tokenInfo.AgentCode;
                if (sessionRequest.cod_agt == 0 && (tokenInfo.Roles.Contain("Empleado") || tokenInfo.Roles.Contain("Comercial_Mapfre")))
                {
                    agentCode = 999999; //sessionRequest.cod_agt;
                }
                result = await Business.Backoffice.Pagos.CrearSesion(tokenInfo, ipAddress, userAgent, sessionRequest.num_poliza, sessionRequest.num_recibo, agentCode);
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex, session.MessageId);

                session.ResponseStatus = 400;
                session.ResponseText = ex.Message;
            }

            global::Architect.API.Core.Business.Traza.TrackRequest.CloseSession(session, result);

            return Ok(result);
        }

        /// <summary>
        /// Recupera la información de una sesión de pago, en caso de haber algún cambio de estado, se actualiza la tabla interna.
        /// </summary>
        /// <param name="requestId">Identificador de la sessión de pago.</param>
        [HttpPost]
        [Route("Sesion/{requestId}")]
        [ResponseType(typeof(Payment.Integrations.Contracts.InformationRequest))]
        public async Task<IHttpActionResult> Refresh([FromUri] Int64 requestId)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Payment.Integrations.Contracts.InformationRequest result = await Business.Backoffice.Pagos.GetRequestInformation(tokenInfo.CompanyId, tokenInfo.UserId, requestId, string.Empty);

            return Ok(result);
        }

        /// <summary>
        /// Recupera la información de una sesión de pago, en caso de haber algún cambio de estado, se actualiza la tabla interna.
        /// </summary>
        /// <param name="reference">Referencia enviada por el comercio para la transacción.</param>
        [HttpPost]
        [Route("Sesion/ref={reference}")]
        [ResponseType(typeof(Payment.Integrations.Contracts.InformationRequest))]
        public async Task<IHttpActionResult> Refresh([FromUri] string reference)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Payment.Integrations.Contracts.InformationRequest result = await Business.Backoffice.Pagos.GetRequestInformation(tokenInfo.CompanyId, tokenInfo.UserId, 0, reference);

            return Ok(result);
        }

        /// <summary>
        /// Procesa y valida una notificación de pago.
        /// </summary>
        [HttpPost]
        [Route("Notificar")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Notify(Architect.Payment.Integrations.Contracts.NotifyRequest notify)
        {
            await Business.Backoffice.Pagos.Notificacion(notify);

            return Ok();
        }

        [HttpGet]
        [Route("Monitor")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Monitor()
        {
            Business.Backoffice.Pagos.Monitor();

            return Ok();
        }

        [HttpPost]
        [Route("Recobro")]
        public async Task<IHttpActionResult> Recobro([FromBody] Contracts.Pagos.RecibosParaRecobro recibos)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            string ipAddress = Architect.Utilities.Helpers.Connection.UserHostAddress();
            string userAgent = Request.Headers.UserAgent.ToString();
            int agentCode = tokenInfo.AgentCode;

            Hangfire.BackgroundJob.Enqueue(() => Architect.API.Tron.Business.Backoffice.v2.Pagos.PendientesRecurrentesAlCobro(DateTime.Now, recibos));

            string result = "Ejecución exitosa";

            return Ok(result);
        }
    }
}