using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Acciones relacionas con la seguridad de la aplicación.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Rules")]
    public class RulesController : ApiController
    {

        [HttpPost]
        [Route("post")]
        public async Task<IHttpActionResult> Post([FromBody]Architect.API.Core.Contracts.General.Rules item)
        {
            Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            List<Contracts.General.Error> errors = null;
            if (item.IsEmpty())
                return BadRequest("Debe indicar un rules");
            else
            {
                await Task.Run(() =>
                {
                    errors = Architect.API.Core.Business.General.Rules.Validate(item, true);
                });
                if (errors.Count == 0)
                {
                    await Task.Run(() =>
                    {
                        item = Architect.API.Core.Business.General.Rules.Create(tokenInfo.CompanyId, tokenInfo.UserId, item);
                    });

                    return Created(string.Format("{0}/get?id={1}", Request.RequestUri.AbsoluteUri.Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")), item.Id), new { Id = item.Id });
                }
                else
                {
                    ModelState.Clear();
                    foreach (Contracts.General.Error errorItem in errors)
                    {
                        //string.Format("{0}.{1}:{2}", s.Group, s.Key, s.Message)
                        ModelState.AddModelError(errorItem.Key, errorItem.Message);
                    }
                    return BadRequest(ModelState);
                }
            }
        }

        [HttpGet]
        [Route("get")]
        [Authorize]
        public async Task<IHttpActionResult> Get(string filter = "")
        {
            Contracts.Security.Token tokenInfo = Business.Security.Token.Info();

            List<Architect.API.Core.Contracts.General.Rules> result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Core.Business.General.Rules.Retrieve(tokenInfo.CompanyId, filter);
            });

            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        [HttpGet]
        [Route("getbyid")]
        [Authorize]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Contracts.Security.Token tokenInfo = Business.Security.Token.Info();
            IHttpActionResult result = null;
            Architect.API.Core.Contracts.General.Rules data = null;

            if (id.IsEmpty())
                result = BadRequest("Debe indicar el identificador del rules");
            else
            {
                await Task.Run(() =>
                {
                    data = Architect.API.Core.Business.General.Rules.RetrieveById(tokenInfo.CompanyId, id);
                    if (data.IsEmpty())
                        result = NotFound();
                    else
                        result = Ok(data);
                });
            }
            return result;
        }

        [HttpPut]
        [Route("put")]
        [Authorize]
        public async Task<IHttpActionResult> Put(int id, [FromBody]Architect.API.Core.Contracts.General.Rules item)
        {
            IHttpActionResult result = null;

            if (id.IsEmpty())
                result = BadRequest("Debe indicar el identificador del rules");
            else
            {
                Contracts.Security.Token tokenInfo = Business.Security.Token.Info();

                List<Contracts.General.Error> errors = null;
                await Task.Run(() =>
                {
                    errors = Architect.API.Core.Business.General.Rules.Validate(item, false);
                });

                if (errors.Count == 0)
                {
                    await Task.Run(() =>
                    {
                        item = Architect.API.Core.Business.General.Rules.Update(tokenInfo.CompanyId, tokenInfo.UserId, id, item);
                    });
                    result = Ok(new { Id = item.Id });
                }
                else
                {
                    ModelState.Clear();
                    foreach (Contracts.General.Error errorItem in errors)
                    {
                        //string.Format("{0}.{1}:{2}", s.Group, s.Key, s.Message)
                        ModelState.AddModelError(errorItem.Key, errorItem.Message);
                    }
                    result = BadRequest(ModelState);
                }
            }
            return result;
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public async Task<IHttpActionResult> Delete(int id)
        {
            IHttpActionResult result = null;

            if (id.IsEmpty())
                result = BadRequest("Debe indicar el identificador del rules");
            else
            {
                Contracts.Security.Token tokenInfo = Business.Security.Token.Info();
                bool deleted;
                await Task.Run(() =>
                {
                    deleted = Architect.API.Core.Business.General.Rules.Delete(tokenInfo.CompanyId, tokenInfo.UserId, id);
                });
                result = Ok(new { Id = id });
            }
            return result;
        }
    }
}
