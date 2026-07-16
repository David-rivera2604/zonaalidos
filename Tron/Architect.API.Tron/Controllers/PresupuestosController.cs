using Architect.Utilities.Extensions;
using Asp.Versioning;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite ejecutar las acciones vinculadas con presupuestos.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Presupuestos")]
    public class PresupuestosController : ApiController
    {
        /// <summary>
        /// Elimina un presupuesto por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del presupuesto.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IHttpActionResult> Delete([FromUri] string id)
        {
            IHttpActionResult result = NotFound();

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar el identificador del presupuesto");
            }

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            await Task.Run(() =>
            {
                Architect.API.Tron.Contracts.Presupuesto.PresupuestoResult deleted = Business.Backoffice.Presupuestos.Delete(tokenInfo.CompanyId, tokenInfo.UserId, id);

                if (deleted.Errors.Count == 0)
                {
                    result = Ok(new { Success = deleted.Success, Message = deleted.Message });
                }
                else
                {
                    result = ErrorHandler(deleted.Errors);
                }
            }).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Maneja los errores devolviendo un BadRequest con los detalles de los errores.
        /// </summary>
        /// <param name="errors">Lista de errores.</param>
        /// <returns>BadRequest con información de los errores.</returns>
        private IHttpActionResult ErrorHandler(System.Collections.Generic.List<Core.Contracts.General.Error> errors)
        {
            if (errors.IsNotEmpty())
            {
                return BadRequest(string.Join("; ", errors.ConvertAll(e => e.Message)));
            }
            return BadRequest("Error desconocido");
        }
    }
}
