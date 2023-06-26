using Architect.Utilities.Extensions;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Acciones relacionas con la seguridad de la aplicación.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/UserMember")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserMemberController : ApiController
    {
        [HttpPost]
        [Route("post")]
        public async Task<IHttpActionResult> Post([FromBody] Architect.API.Core.Contracts.Security.UserMember item)
        {
            Contracts.Security.Token tokenInfo = Security.Token.Info();

            List<Contracts.General.Error> errors = null;
            if (item.IsEmpty())
            {
                return BadRequest("Debe indicar un usuario");
            }
            else
            {
                await Task.Run(() =>
                {
                    if (item.SecurityLevel > tokenInfo.SecurityLevel)
                    {
                        item.SecurityLevel = tokenInfo.SecurityLevel;
                    }

                    errors = Architect.API.Core.Business.Security.UserMember.Validate(item, true);
                }).ConfigureAwait(false);
                if (errors.Count == 0)
                {
                    await Task.Run(() =>
                    {
                        item = Architect.API.Core.Business.Security.UserMember
                            .Create(tokenInfo.CompanyId, tokenInfo.UserId, item, tokenInfo.AgentCode);
                    })
                        .ConfigureAwait(false);

                    return Created(string.Format("{0}/get?id={1}",
                                                 Request.RequestUri.AbsoluteUri
                        .Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")),
                                                 item.UserId),
                                   new { Id = item.UserId });
                }
                else
                {
                    ModelState.Clear();
                    foreach (Contracts.General.Error errorItem in errors)
                    {
                        ModelState.AddModelError(string.Format("{0}.{1}", errorItem.Group, errorItem.Key),
                                                 errorItem.Message);
                    }
                    return BadRequest(ModelState);
                }
            }
        }

        [HttpGet]
        [Route("get")]
        [Authorize]
        public async Task<IHttpActionResult> Get(string filter = "", string recordStatus = "")
        {
            Contracts.Security.Token tokenInfo = Security.Token.Info();

            List<Architect.API.Core.Contracts.Security.UserMember> result = null;

            await Task.Run(() =>
            {
                result = Architect.API.Core.Business.Security.UserMember
                    .Retrieve(tokenInfo.CompanyId, tokenInfo.SecurityLevel, filter, recordStatus);
            }).ConfigureAwait(false);

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
            Contracts.Security.Token tokenInfo = Security.Token.Info();
            IHttpActionResult result = null;
            Architect.API.Core.Contracts.Security.UserMember data = null;

            if (id.IsEmpty())
            {
                result = BadRequest("Debe indicar el identificador del usuario");
            }
            else
            {
                await Task.Run(() =>
                {
                    data = Architect.API.Core.Business.Security.UserMember.RetrieveById(tokenInfo.CompanyId, id, true);

                    if (data.IsEmpty())
                        result = NotFound();
                    else
                        result = Ok(data);
                })
                    .ConfigureAwait(false);
            }
            return result;
        }

        [HttpPut]
        [Route("put")]
        [Authorize]
        public async Task<IHttpActionResult> Put(int id,
                                                 [FromBody] Architect.API.Core.Contracts.Security.UserMember item)
        {
            IHttpActionResult result = null;

            if (id.IsEmpty())
            {
                result = BadRequest("Debe indicar el identificador del usuario");
            }
            else
            {
                Contracts.Security.Token tokenInfo = Security.Token.Info();

                List<Contracts.General.Error> errors = null;
                await Task.Run(() =>
                {
                    if (item.SecurityLevel > tokenInfo.SecurityLevel)
                    {
                        item.SecurityLevel = tokenInfo.SecurityLevel;
                    }
                    errors = Architect.API.Core.Business.Security.UserMember.Validate(item, false);
                }).ConfigureAwait(false);

                if (errors.Count == 0)
                {
                    await Task.Run(() =>
                    {
                        item = Architect.API.Core.Business.Security.UserMember
                            .Update(tokenInfo.CompanyId, tokenInfo.UserId, id, item, tokenInfo.AgentCode);
                    }).ConfigureAwait(false);
                    result = Ok(new { Id = item.UserId });
                }
                else
                {
                    ModelState.Clear();
                    foreach (Contracts.General.Error errorItem in errors)
                    {
                        ModelState.AddModelError(string.Format("{0}.{1}", errorItem.Group, errorItem.Key),
                                                 errorItem.Message);
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
            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar el identificador del usuario");
            }
            else
            {
                Contracts.Security.Token tokenInfo = Security.Token.Info();
                bool deleted;
                await Task.Run(() =>
                {
                    deleted = Architect.API.Core.Business.Security.UserMember
                        .Delete(tokenInfo.CompanyId, tokenInfo.UserId, id);
                }).ConfigureAwait(false);
                return Ok(new { Id = id });
            }
        }


        [HttpPost]
        [Route("sendcredentials")]
        public async Task<IHttpActionResult> SendCredentials([FromUri] int id)
        {
            Contracts.Security.Token tokenInfo = Security.Token.Info();

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar un usuario");
            }
            else
            {
                await Task.Run(() =>
                {
                    Architect.API.Core.Business.Security.UserMember.SendCredentials(tokenInfo.CompanyId, tokenInfo.UserId, id);
                }).ConfigureAwait(false);

                return Ok(new { });


            }
        }

    }
}
