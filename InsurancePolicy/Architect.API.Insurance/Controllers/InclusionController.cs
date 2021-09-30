using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Opciones para la emisión de las pólizas
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Inclusion")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class InclusionController : ApiController
    {

        /// <summary>
        /// Lista de inclusiones por número de inclusión.
        /// </summary>
        /// <param name="idFrom">Número de inclusión de inicio del rango.</param>
        /// <param name="idTo">Número de inclusión de fin del rango.</param>
        /// <returns>Lista de inclusiones.</returns>
        [HttpGet]
        [Route("bayer/{idFrom:int}/{idTo:int}")]
        public async Task<IHttpActionResult> BayerGetPorSolictud([FromUri] int idFrom, [FromUri] int idTo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Contracts.Bayer.InclusionView> result = null;

            await Task.Run(() =>
            {
                result = Business.Bayer.Inclusion.View(tokenInfo.CompanyId, idFrom, idTo);

            }).ConfigureAwait(false);

            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Lista de inclusiones por fecha de inclusión.
        /// </summary>
        /// <param name="issueDateFrom">Fecha de inicio del rango.</param>
        /// <param name="issueDateTo">Fecha de fin del rango.</param>
        /// <returns>Lista de inclusiones.</returns>
        [HttpGet]
        [Route("bayer/{issueDateFrom:datetime}/{issueDateTo:datetime}")]
        public async Task<IHttpActionResult> BayerGetPorFechaInclusion([FromUri] DateTime issueDateFrom, [FromUri] DateTime issueDateTo)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Contracts.Bayer.InclusionView> result = null;

            await Task.Run(() =>
            {
                result = Business.Bayer.Inclusion.View(tokenInfo.CompanyId, issueDateFrom, issueDateTo);

            }).ConfigureAwait(false);

            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Información completa de una inclusión.
        /// </summary>
        /// <param name="id">Identificción interna de una inclusión.</param>
        /// <returns>Información de una inclusión.</returns>
        [HttpGet]
        [Route("bayer/{id:int}")]
        public async Task<IHttpActionResult> BayerGet([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Contracts.Bayer.InclusionRequest result = null;
            await Task.Run(() =>
            {
                if (id == 0)
                {
                    result = Business.Bayer.Inclusion.Setup(tokenInfo);
                }
                else
                {
                    result = Business.Bayer.Inclusion.Retrieve(id, tokenInfo);
                }

            }).ConfigureAwait(false);

            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Permite registrar una inclusión
        /// </summary>
        /// <param name="item">Información de la inclusión</param>
        [HttpPost]
        [Route("bayer")]
        public async Task<IHttpActionResult> BayerPost([FromBody] Contracts.Bayer.InclusionRequest item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Architect.API.Insurance.Contracts.Bayer.InclusionRequest result = null;

            await Task.Run(() =>
            {
                result = Business.Bayer.Inclusion.Issue(item, tokenInfo);
            }).ConfigureAwait(false);

            return Created(string.Format("{0}/bayer/{1}", Request.RequestUri.AbsoluteUri
                            .Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), result.Id),
                                       new
                                       {
                                           result.Id,
                                           result.Status,
                                           result.StatusDesc,
                                           Message = result.Message,
                                           result.Errors
                                       });
        }


        [HttpGet]
        [Route("VerifySignature")]
        public async Task<IHttpActionResult> VerifySignature([FromUri] int id, [FromUri] string fileName, [FromUri] int size, [FromUri] string originalFileName)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            bool result = false;
            await Task.Run(() =>
            {
                result = Business.Bayer.Inclusion.VerifySignature(id, fileName, size, originalFileName, tokenInfo);
            }).ConfigureAwait(false);
            string message = null;

            if (result)
            {
                message = "La solicitud fue procesada y su firma debidamente verificada por medio de su identificación.";
            } else
            {
                message = "La verificación de la firma por medio de su identificación, no se pudo realizar de forma exitosa, por favor aplique nuevamente la firma digital al documento enviado por correo y repita el proceso de carga.";
            }

            return Ok(new { Valid  = result, Message = message });
        }

    }
}
