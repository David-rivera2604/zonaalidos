using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.API.Core.Contracts.General;
using Architect.Utilities.Extensions;
using Microsoft.Web.Http;

namespace Architect.API.Process.WebApi.Controllers
{
    /// <summary>
    /// Acciones para manipular la tabla ProcessSpecFlow. Especificación de un proceso.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/ProcessSpecFlow")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProcessSpecFlowController : ApiController
    {
        /// <summary>
        /// Crea un registro en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="item">Instancia del objecto ProcessSpecFlow.</param>
        /// <returns>Información del registro creado en la tabla ProcessSpecFlow.</returns>
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] Architect.API.Process.Contracts.General.ProcessSpecFlow item)
        {
            IHttpActionResult result = BadRequest();
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar un process spec flow");
            }
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Task.Run(() =>
            {
                Architect.API.Process.Contracts.General.ProcessSpecFlowResult created = Architect.API.Process.Business.General.ProcessSpecFlow.Create(tokenInfo.CompanyId, tokenInfo.UserId, item);
                if (created.Errors.Count == 0)
                {
                    result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), created.ProcessSpecFlow.Id), new { Id = created.ProcessSpecFlow.Id, UpdateDate = created.ProcessSpecFlow.UpdateDate });
                }
                else
                {
                    result = ErrorHandler(created.Errors);
                }
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="filter">Filtro a ser aplicado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de objetos ProcessSpecFlow.</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Get([FromUri] string filter = "", int beginIndex = 1, int endIndex = int.MaxValue)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            List<Architect.API.Process.Contracts.General.ProcessSpecFlow> result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Process.Business.General.ProcessSpecFlow.Retrieve(tokenInfo.CompanyId, filter, beginIndex, endIndex);
            }).ConfigureAwait(false);

            if (result.IsEmpty())
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlow que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Filtro a ser aplicado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        [HttpGet]
        [Route("Count")]
        [Authorize]
        public async Task<IHttpActionResult> Count([FromUri] string filter = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            int result = 0;

            await Task.Run(() =>
            {
                result = Architect.API.Process.Business.General.ProcessSpecFlow.Count(tokenInfo.CompanyId, filter);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecFlow por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <returns>Instancia del objecto ProcessSpecFlow.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            IHttpActionResult result = null;
            Architect.API.Process.Contracts.General.ProcessSpecFlow data = null;

            if (id.IsEmpty())
            {
                result = BadRequest("Debe indicar el identificador del process spec flow");
            }
            else
            {
                await Task.Run(() =>
                {
                    data = Architect.API.Process.Business.General.ProcessSpecFlow.RetrieveById(tokenInfo.CompanyId, id);
                    if (data.IsEmpty())
                    {
                        result = NotFound();
                    }
                    else
                    {
                        result = Ok(data);
                    }
                }).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecFlow por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="item">Instancia del objecto ProcessSpecFlow.</param>
        /// <returns>Información del registro actualizado en la tabla ProcessSpecFlow.</returns>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Architect.API.Process.Contracts.General.ProcessSpecFlow item)
        {
            IHttpActionResult result = NotFound();

            if (id.IsEmpty() || item.IsEmpty())
            {
                return BadRequest("Debe indicar el identificador y una instancia de process spec flow");
            }

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Task.Run(() =>
            {
                item.Id = id;
                Architect.API.Process.Contracts.General.ProcessSpecFlowResult updated = Architect.API.Process.Business.General.ProcessSpecFlow.Update(tokenInfo.CompanyId, tokenInfo.UserId, id, item);
                if (updated.Errors.Count == 0)
                {
                    result = Ok(new
                    {
                        Id = updated.ProcessSpecFlow.Id,
                        UpdateDate = updated.ProcessSpecFlow.UpdateDate,
                        Warnings = updated.Warnings
                    });
                }
                else
                {
                    result = ErrorHandler(updated.Errors);
                }
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla Reclamos por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <returns>Información del registro eliminado en la tabla Visualizations.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            IHttpActionResult result = NotFound();

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar el identificador del process spec flow");
            }

            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Task.Run(() =>
            {
                Architect.API.Process.Contracts.General.ProcessSpecFlowResult deleted = Architect.API.Process.Business.General.ProcessSpecFlow.Delete(tokenInfo.CompanyId, tokenInfo.UserId, id);
                if (deleted.Errors.Count == 0)
                {
                    result = Ok(deleted.ProcessSpecFlow);
                }
                else
                {
                    result = ErrorHandler(deleted.Errors);
                }
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Manejo general de los error de validación.
        /// </summary>
        /// <param name="errors">Lista de errores de validación.</param>
        /// <returns>Repuesta de tipo BadRequest con el detalle de los errores de validación.</returns>
        private IHttpActionResult ErrorHandler(List<Core.Contracts.General.Error> errors)
        {
            ModelState.Clear();
            foreach (Core.Contracts.General.Error errorItem in errors)
            {
                //string.Format("{0}.{1}:{2}", s.Group, s.Key, s.Message)
                //ModelState.AddModelError(errorItem.Key, errorItem.Message);
                ModelState.AddModelError(string.Format("{0}.{1}", errorItem.Group, errorItem.Key), errorItem.Message);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecFlow por medio de su identificador único.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <returns>Instancia del objecto ProcessSpecFlow.</returns>
        [HttpPost]
        [Route("{id:int}/Duplicate")]
        [Authorize]
        public async Task<IHttpActionResult> Duplicate([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            IHttpActionResult result = null;
            Architect.API.Process.Contracts.General.ProcessSpecFlow data = null;

            if (id.IsEmpty())
            {
                result = BadRequest("Debe indicar el identificador del process spec flow");
            }
            else
            {
                await Task.Run(() =>
                {
                    Architect.API.Process.Contracts.General.ProcessSpecFlowResult created = Architect.API.Process.Business.General.ProcessSpecFlow.DuplicateById(tokenInfo.CompanyId, tokenInfo.UserId, id);
                    if (created.Errors.Count == 0)
                    {
                        result = Created(string.Format("{0}/{1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), created.ProcessSpecFlow.Id), new { Id = created.ProcessSpecFlow.Id, UpdateDate = created.ProcessSpecFlow.UpdateDate });
                    }
                    else
                    {
                        result = ErrorHandler(created.Errors);
                    }
                }).ConfigureAwait(false);
            }
            return result;
        }

        [HttpGet]
        [Route("{id:int}/Export")]
        [Authorize]
        public async Task<HttpResponseMessage> Export([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            string ou = Architect.API.Process.Business.General.ProcessSpecFlow.Export(tokenInfo.CompanyId, tokenInfo.UserId, id);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ou, Encoding.Default, "application/json")
            };
            //result.Flush();
            //result.Close();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping("json"));
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "process_" + id.ToString() + ".json"
            };
            return response;
        }

        [HttpPost]
        [Route("Import")]
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] FileUploaded item)
        {
            IHttpActionResult result = BadRequest();
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar información del archivo cargado");
            }
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            await Task.Run(() =>
            {
                bool imported = Process.Business.General.ProcessSpecFlow.Import(tokenInfo.CompanyId, tokenInfo.UserId, item.Stored, item.FileSize, item.FileName);
                if (imported)
                {
                    result = Ok(new
                    {
                        Imported = imported
                    });
                }
                else
                {
                    result = BadRequest();
                }
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Recupera una lista con los campos de referencia de un proceso.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <returns>Lista de objetos ReferenceField.</returns>
        [HttpGet]
        [Route("{id:int}/References")]
        [Authorize]
        public async Task<IHttpActionResult> GetReferencesById([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            IHttpActionResult result = null;
            List<Architect.Utilities.Contracts.LookUpValue> data = null;

            if (id.IsEmpty())
            {
                result = BadRequest("Debe indicar el identificador del process spec flow");
            }
            else
            {
                await Task.Run(() =>
                {
                    data = Architect.API.Process.Business.General.ProcessSpecFlow.RetrieveReferencesById(tokenInfo.CompanyId, id);
                    if (data.IsEmpty())
                    {
                        result = NotFound();
                    }
                    else
                    {
                        result = Ok(data);
                    }
                }).ConfigureAwait(false);
            }
            return result;
        }

        [HttpGet]
        [Route("{id:int}/diagram/{diagramType}")]
        [Authorize]
        public async Task<IHttpActionResult> Diagram([FromUri] int id, [FromUri] string diagramType)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();

            string ou = Architect.API.Process.Business.General.ProcessSpecFlow.Diagram(tokenInfo.CompanyId, tokenInfo.UserId, id, diagramType);

            return Ok(new
            {
                source = ou
            });
        }

        //[HttpGet]
        //[Route("{id:int}/diagram/{diagramType}")]
        //[Authorize]
        //public async Task<HttpResponseMessage> Diagram([FromUri] int id, [FromUri] string diagramType)
        //{
        //    Contracts.Security.Token tokenInfo = Security.Token.Info();

        //    string ou = Architect.API.Core.Business.General.ProcessSpecFlow.Diagram(tokenInfo.CompanyId, tokenInfo.UserId, id, diagramType);

        //    var response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(ou, Encoding.Default, "application/text")

        //    };
        //    //result.Flush();
        //    //result.Close();
        //    //response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping("json"));
        //    //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //    //{
        //    //    FileName = "process_" + id.ToString() + ".json"
        //    //};
        //    return response;
        //}
    }
}