using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Permite la consulta centralizada de información de personas.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Insured")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class InsuredController : ApiController
    {

        /// <summary>
        /// Busqueda de información de residentes de Costa Rica.
        /// </summary>
        /// <param name="id">Identificación.</param>
        /// <param name="docType">Tipo de Identificacion.</param>																 
        /// <returns>Información de la personal.</returns>
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ResponseType(typeof(Contracts.Policy.Insured))]
        public async Task<IHttpActionResult> InsuredByIdentification([FromUri] string id, int docType)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Contracts.Policy.Insured result = null;
            string verbose = string.Empty;

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar la identificación");
            }
            if (result == null && tokenInfo.CompanyId == 11)   //Sur Química
            {
                verbose += "->thirdparty";
                result = await Architect.Extend.Integrations.Aliados.Consultas.ThirdParty(id);
            }

            if (result == null)
            {
                verbose += "->Aliados";
                result = await Architect.Extend.Integrations.Aliados.Consultas.RiskRoles(id);
            }
            if (result == null && tokenInfo.CompanyId == 1)   //Coopeservidores
            {
                verbose += "->coope";
                result = Architect.Extend.Integrations.Coope.Consultas.ClientePorIdentificacion(id);
            }

            if (result == null)
            {
                Task<Contracts.Policy.Insured> tron = Architect.Extend.Integrations.Tron.Consultas.TerceroPorIdentificacion(id, docType);
                Task<Contracts.Policy.Insured> ins = Architect.Extend.Integrations.InstitutoNacionalDeSeguros.Consultas.PersonaPorIdentificacion(id);
                Task<Contracts.Policy.Insured> padron = Architect.Extend.Integrations.My.Consultas.PersonaPorIdentificacion(id);

                var tasks = new[] { tron, ins, padron };

                var processingTasks = tasks.ToList();

                while (processingTasks.Any())
                {
                    Task<Contracts.Policy.Insured> ready = await Task.WhenAny(processingTasks);
                    if (ready == tron)
                    {
                        verbose += "->tron";
                    }
                    else if (ready == ins)
                    {
                        verbose += "->ins";
                    }
                    else
                    {
                        verbose += "->padron";
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
                //await Task.WhenAll(tron, ins, padron);
                //if (tron.Status == TaskStatus.RanToCompletion)
                //{
                //    verbose += "->tron";
                //    result = tron.Result;
                //    LogHandler.WarningLog("InsuredByIdentification", string.Format("{1} Id={0} {2}", id, verbose, result == null ? "no encontrado" : "encontrado"), "integrations");
                //}
                //if (result == null && ins.Status == TaskStatus.RanToCompletion)
                //{
                //    verbose += "->ins";
                //    result = ins.Result;
                //    LogHandler.WarningLog("InsuredByIdentification", string.Format("{1} Id={0} {2}", id, verbose, result == null ? "no encontrado" : "encontrado"), "integrations");
                //}
                //if (result == null && padron.Status == TaskStatus.RanToCompletion)
                //{
                //    verbose += "->padron";
                //    result = padron.Result;
                //    LogHandler.WarningLog("InsuredByIdentification", string.Format("{1} Id={0} {2}", id, verbose, result == null ? "no encontrado" : "encontrado"), "integrations");
                //}
            }

            //if (result == null)
            //{
            //    verbose += "->Tron";
            //    result = await Architect.Extend.Integrations.Tron.Consultas.TerceroPorIdentificacion(id);
            //}
            //if (result == null)
            //{
            //    verbose += "->ins";
            //    result = await Architect.Extend.Integrations.InstitutoNacionalDeSeguros.Consultas.PersonaPorIdentificacion(id);
            //}
            //if (result == null)
            //{
            //    verbose += "->my";
            //    result = await Architect.Extend.Integrations.My.Consultas.PersonaPorIdentificacion(id);
            //}

            //LogHandler.WarningLog("InsuredByIdentification", string.Format("{1} Id={0} {2}", id, verbose, result == null ? "no encontrado" : "encontrado"), "integrations");

            if (result != null)
            {
                result.FullName = result.FirstName.CompleteFullName(result.MiddleName, result.LastName, result.SecondLastName);
            }
            return Ok(result);
        }

        /// <summary>
        /// Recupera la información de un cuestionario, asociado a la identificación de un asegurado.
        /// </summary>
        /// <param name="id">Número de documento del asegurado</param>
        /// <param name="name">Nombre del cuestionario</param>
        /// <returns>Información del cuestionario</returns>
        [HttpGet]
        [Route("{id:int}/Questionary/{name}")]
        [ResponseType(typeof(List<Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires>))]
        public async Task<IHttpActionResult> QuestionnairyByIdentification([FromUri] string id, [FromUri] string name)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            List<Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires> result = null;
            string verbose = string.Empty;

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar la identificación");
            }

            result = Architect.API.Insurance.Business.Policy.RiskQuestionnaires.RetrieveByDocumentNumber(id, name, tokenInfo.CompanyId);

            return Ok(result);
        }
    }
}
