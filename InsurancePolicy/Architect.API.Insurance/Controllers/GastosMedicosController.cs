using Architect.Utilities.Extensions;
using Asp.Versioning;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Opciones para la consulta pólizas GastosMedicos
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/GastosMedicos")]
    //[ApiExplorerSettings(IgnoreApi = true)]

    public class GastosMedicosController : ApiController
    {

        /// <summary>
        /// Busqueda de información de clientes que tengan polizas de gastos medicos
        /// </summary>
        /// <param name="id">Identificación.</param>
        /// <returns>Información de la personal.</returns>
        [HttpGet]
        [Route("{id}")]
        //[AllowAnonymous]
        [ResponseType(typeof(Contracts.GastosMedicos.AseguradoGastosMedicos))]
        public async Task<IHttpActionResult> InsuredByIdentification([FromUri] string id)
        {
            Contracts.GastosMedicos.AseguradoGastosMedicos result = null;
            string verbose = string.Empty;

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar la identificación");
            }

            if (result == null)
            {
                Task<Contracts.GastosMedicos.AseguradoGastosMedicos> gastosMedicos = Architect.Extend.Integrations.GastosMedicos.ConsultaAsegurado.PersonaPorIdentificacion(id);

                var tasks = new[] { gastosMedicos };

                var processingTasks = tasks.ToList();

                while (processingTasks.Any())
                {
                    Task<Contracts.GastosMedicos.AseguradoGastosMedicos> ready = await Task.WhenAny(processingTasks);
                    if (ready == gastosMedicos)
                    {
                        verbose += "->gastosMedicos";
                    }


                    if (ready.Result != null)
                    {
                        result = ready.Result;
                        processingTasks.Clear();
                        Utilities.Log.WarningLog("InsuredByIdentification", string.Format("{1} Id={0} {2}", id, verbose, "encontrado"), "integrations");
                    }
                    else
                    {
                        processingTasks.Remove(ready);
                    }
                }
                if (result == null)
                {
                    Utilities.Log.WarningLog("InsuredByIdentification", string.Format("{1} Id={0} {2}", id, verbose, "no encontrado"), "integrations");
                }

            }

            return Ok(result);
        }

    }

}
