using Architect.Utilities.Extensions;
using Architect.API.Insurance.Contracts.Product;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Opciones para la emisión de las pólizas
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Policy")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PolicyController : ApiController
    {
        /// <summary>
        /// Información imprimible de una póliza.
        /// </summary>
        /// <param name="id">Identificción interna de una poliza.</param>
        /// <returns>Información de una póliza</returns>
        [HttpGet]
        [Route("Information")]
        public async Task<IHttpActionResult> Information([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Contracts.Policy.RiskView result = null;
            await Task.Run(() =>
            {
                result = Business.Policy.Risk.Information(id, tokenInfo.CompanyId);
            })
                .ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Lista de pólizas existen según los criterio definidos en los filtros.
        /// </summary>
        /// <param name="filter">
        /// Permite filtrar por póliza o por la identificación, nombre, apellido, teléfono o correo electrónico del
        /// asegurado.
        /// </param>
        /// <param name="lineOfBusiness">Opción para filtrar por ramo o linea de negocio.</param>
        /// <param name="product">Opción para filtrar por producto vincaulado a un ramo.</param>
        /// <param name="status">Opción para filtrar por multiples esta de las pólizas.</param>
        /// <returns>Lista de pólizas según los criterio definidos en el filtro.</returns>
        [HttpGet]
        [Route("view")]
        public async Task<IHttpActionResult> View(string filter = "",
                                                  int lineOfBusiness = 0,
                                                  int product = 0,
                                                  string status = "")
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Contracts.Policy.PolicyView> result = null;
            await Task.Run(() =>
            {
                result = Business.Policy.Risk.View(tokenInfo.CompanyId, filter, lineOfBusiness, product, status);
            }).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Información completa de una póliza.
        /// </summary>
        /// <param name="id">Identificción interna de una poliza.</param>
        /// <returns>Información de una póliza</returns>
        [HttpGet]
        [Route("get")]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Contracts.Policy.Risk result = null;
            await Task.Run(() =>
            {
                result = Business.Policy.Risk.RetrievePolicyByKey(id, tokenInfo.CompanyId);
            })
                .ConfigureAwait(false);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Permite emitir una póliza
        /// </summary>
        /// <param name="item">Información de la póliza</param>
        [HttpPost]
        [Route("post")]
        public async Task<IHttpActionResult> Post([FromBody] Contracts.Policy.Risk item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            string message = "";
            Architect.API.Insurance.Business.Structure.IssuePolicyResult result = null;

            await Task.Run(() =>
            {
                result = Business.Policy.Risk.IssuePolicy(tokenInfo, item, "Post");
                item = result.Risk;
            })
                .ConfigureAwait(false);

            //var jsonString = item.ToString();
            //Contracts.Policy.Risk result2 = JsonConvert.DeserializeObject<Contracts.Policy.Risk>(jsonString );

            //return CreatedAtRoute("api/v1/Policy/get", new { id = 1 }, item);
            //return Created<("api/v1/Policy/get", new { id = 1 }, item);

            //return Created(new Uri($"{Request.Path}/{item.Id}", UriKind.Relative), item);

            //return Created($"api/v1/Asegurado/{item.Id}", item);

            //var message = Request.CreateResponse(HttpStatusCode.Created, employee);
            //message.Headers.Location = );
            //return message;

            if (result.Errors.Count > 0)
            {
                message = string.Format("No se puede emitir la póliza ya que existen {0} error(es) que ameritan su atención",
                                        result.Errors.Count);
            }
            else
            {
                switch (item.Status)
                {
                    case 2:
                        message = "La póliza fue debidamente almacenada, pero dadas las condiciones de la misma, queda pendiente de revisión";
                        break;
                    case 10:
                        message = string.Format("La póliza fue emitida de forma exitosa, bajo el número #{0}",
                                                item.PolicyId);
                        break;
                }
            }

            return Created(string.Format("{0}/get?id={1}",
                                         Request.RequestUri.AbsoluteUri
                .Substring(0, Request.RequestUri.AbsoluteUri.LastIndexOf("/")),
                                         item.Id),
                           new
                           {
                               item.Id,
                               item.Status,
                               item.StatusDesc,
                               PrimaryInsuredId = item.PrimaryInsured.RoleId,
                               item.PolicyId,
                               Message = message,
                               result.Errors
                           });
        }

        /// <summary>
        /// Permite almacenar o emitir una póliza
        /// </summary>
        /// <param name="item">Información de la póliza</param>
        [HttpPut]
        [Route("put")]
        public async Task<IHttpActionResult> Put([FromBody] Contracts.Policy.Risk item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Architect.API.Insurance.Business.Structure.IssuePolicyResult result = null;
            string message = "";
            await Task.Run(() =>
            {
                result = Business.Policy.Risk.IssuePolicy(tokenInfo, item, "Put");
                item = result.Risk;
            })
                .ConfigureAwait(false);

            if (result.Errors.Count > 0)
            {
                message = string.Format("No se puede emitir la póliza ya que existen {0} error(es) que ameritan su atención",
                                        result.Errors.Count);
            }
            else
            {
                switch (item.Status)
                {
                    case 2:
                        message = "La póliza fue debidamente almacenada, pero dadas sus condiciones la misma quedo pendiente de revisión";
                        break;
                    case 10:
                        message = string.Format("La póliza fue emitida de forma exitosa, bajo el número #{0}",
                                                item.PolicyId);
                        break;
                }
            }
            return Ok(new
            {
                Id = item.Id,
                Status = item.Status,
                StatusDesc = item.StatusDesc,
                PrimaryInsuredId = item.PrimaryInsured.RoleId,
                PolicyId = item.PolicyId,
                Message = message,
                Errors = result.Errors
            });
        }

        /// <summary>
        /// Permite modificar una póliza ya emitida
        /// </summary>
        /// <param name="item">Información de la póliza</param>
        [HttpPut]
        [Route("Modify")]
        public async Task<IHttpActionResult> Modify([FromBody] Contracts.Policy.Risk item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Architect.API.Insurance.Business.Structure.IssuePolicyResult result = null;
            string message = "";
            await Task.Run(() =>
            {
                result = Business.Policy.Risk.ModifyPolicy(tokenInfo, item);
                item = result.Risk;
            })
                .ConfigureAwait(false);

            if (result.Errors.Count > 0)
            {
                message = string.Format("No se puede emitir la póliza ya que existen {0} error(es) que ameritan su atención",
                                        result.Errors.Count);
            }
            else
            {
                message = "La póliza fue modifica de forma exitosa";
            }

            return Ok(new
            {
                Id = item.Id,
                Status = item.Status,
                StatusDesc = item.StatusDesc,
                PrimaryInsuredId = item.PrimaryInsured.RoleId,
                PolicyId = item.PolicyId,
                Message = message,
                Errors = result.Errors
            });
        }

        /// <summary>
        /// Permite realizar los cambios de estado a una póliza que se encuentra en modo de subscripción.
        /// </summary>
        /// <param name="item">Datos para el cambio de estado.</param>
        /// <returns>Información del cambio realizado.</returns>
        [HttpPut]
        [Route("ChangeStatus")]
        public async Task<IHttpActionResult> ChangeStatus([FromBody] Contracts.Policy.RiskStatus item)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            List<Core.Contracts.General.Error> errors = null;
            string message = string.Empty;

            await Task.Run(() =>
            {
                Business.Policy.Risk
                    .ChangeStatus(item, tokenInfo.CompanyId, tokenInfo.UserId, tokenInfo.Roles, ref message);
            })
                .ConfigureAwait(false);

            return Ok(new
            {
                Id = item.Id,
                Status = item.NewStatus,
                StatusDesc = item.NewStatusDesc,
                Message = message,
                Errors = errors
            });
        }

        /// <summary>
        /// Verifica si el número de documento de un asegurado ya tiene pólizas registrada para un producto especifico.
        /// </summary>
        /// <param name="productAlias">Alias de un producto.</param>
        /// <param name="recordId">Número de póliza.</param>
        /// <param name="documentType">Tipo de documento.</param>
        /// <param name="documentNumber">Documento o número de identificación.</param>
        /// <returns>Información del estado de la póliza registrada con el número de documento asociado al asegurado.</returns>
        [HttpGet]
        [Route("InsuredHasPolicies")]
        public async Task<IHttpActionResult> InsuredHasPolicies([FromUri] string productAlias,
                                                                [FromUri] int recordId,
                                                                [FromUri] int documentType,
                                                                [FromUri] string documentNumber)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            Utilities.Contracts.LookUpValue result = null;
            await Task.Run(() =>
            {
                result = Business.Policy.Risk
                    .RetrieveByDocumentNumber(tokenInfo.CompanyId, productAlias, recordId, documentType, documentNumber);
            })
                .ConfigureAwait(false);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Devuelva la lista de prestamos de una persona por medio de su identificación.
        /// </summary>
        /// <param name="documentNumber">Documento o número de identificación.</param>
        /// <returns>lista de prestamos.</returns>
        [HttpGet]
        [Route("Loans")]
        public async Task<IHttpActionResult> Loans([FromUri] string documentNumber)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();

            List<Contracts.Policy.RuleLoans> result = null;
            await Task.Run(() =>
            {
                result = Business.Policy.RuleLoans
                        .RetrieveByDocumentNumber(tokenInfo.CompanyId, documentNumber);
            })
                .ConfigureAwait(false);
            if (result.IsEmpty())
                return NotFound();
            else
                return Ok(result);
        }

        /// <summary>
        /// Permite la carga de información de la tabla "RuleLoans" por medio de un archivo excel.
        /// </summary>
        /// <param name="fileName">Nombre del archivo excel en el servidor.</param>
        /// <param name="originalFileName">nombre original del archivo excel.</param>
        /// <returns>Cantidad de registros procesador</returns>
        [HttpPost]
        [Route("LoadLoans")]
        [Authorize(Roles = "Préstamos")]
        public async Task<IHttpActionResult> LoadLoans([FromUri] string fileName, [FromUri] string originalFileName)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            string message = string.Empty;

            await Task.Run(() =>
            {
                message = Business.Policy.RuleLoans.Load(Path.Combine(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["Files.Path"]), fileName), originalFileName, tokenInfo.CompanyId, tokenInfo.UserId);
            }).ConfigureAwait(false);

            return Ok(new { Message = message });
        }

        /// <summary>
        /// Devuelve un definición abreviada de un producto a partir del alias del mismo.
        /// </summary>
        /// <param name="productAlias">Alias de un producto.</param>
        /// <returns>Definición abreviada de un producto.</returns>
        [HttpGet]
        [Route("ProductDefinition")]
        public IHttpActionResult ProductDefinition([FromUri] string productAlias)
        {
            if (productAlias.IsEmpty())
                return BadRequest("Debe indicar una clave de producto");
            ProductDefinition result = Business.Products.Specification.DefinitionByAlias(productAlias);

            if (result.IsNotEmpty())
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("import")]
        [AllowAnonymous]
        public IHttpActionResult Import([FromUri] string excelFilename,[FromUri] string specificactionFilename)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Business.Security.Token.Info();
            Core.Contracts.General.GenericResponse result = Business.Policy.Risk.Import(excelFilename, specificactionFilename, tokenInfo);

            if (result.IsNotEmpty())
                return Ok(result);
            else
                return NotFound();
        }
    }
}
