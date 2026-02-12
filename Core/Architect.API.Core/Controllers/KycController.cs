using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.API.Core.Business.General;
using Architect.API.Core.Contracts;
using Architect.Utilities.Extensions;
using Asp.Versioning;
using Newtonsoft.Json;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Permite la consulta centralizada de información de personas.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/KYC")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class KycController : ApiController
    {
        /// <summary>
        /// Busqueda de información de Kyc Persona.
        /// </summary>
        /// <param name="id">Identificación.</param>
        /// <returns>Información de la personal.</returns>
        [HttpGet]
        [Route("persona")]
        [AllowAnonymous]
        [ResponseType(typeof(Kycpersona))]
        public async Task<IHttpActionResult> KycpersonaByIdentification([FromUri] string id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            Kycpersona result = null;

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar la identificación");
            }
            else
            {
                result = KycBussines.RetrieveKycPersona(id);
            }
            if (result == null)
            {
            }

            return Ok(result);
        }

        /// <summary>
        /// Busqueda de información de Kyc Juridico.
        /// </summary>
        /// <param name="id">Identificación.</param>
        /// <returns>Información de la personal.</returns>
        [HttpGet]
        [Route("juridico")]
        [AllowAnonymous]
        [ResponseType(typeof(KycJuridico))]
        public async Task<IHttpActionResult> KycJuridicoByIdentification([FromUri] string id)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            KycJuridico result = null;

            if (id.IsEmpty())
            {
                return BadRequest("Debe indicar la identificación");
            }
            else
            {
                result = KycBussines.RetrieveKycJuridico(id);
            }
            if (result == null)
            {
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("ActEco")]
        [AllowAnonymous]
        [ResponseType(typeof(KycJuridico))]
        public async Task<IHttpActionResult> ActividadEconomica()
        {
            List<Actividad_Economica> result = null;
            if (Utilities.Cache.Exist("ActividadesEconomicas_Aliados"))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Actividad_Economica>>(Architect.Utilities.Cache.GetItem("ActividadesEconomicas_Aliados").ToString());
            }
            else
            {
                try
                {
                    result = Utilities.SerializeHandler.DeserializeJSONFromFile<List<Actividad_Economica>>(string.Format(@"{0}\{1}.json", ConfigurationManager.AppSettings["Product.Definition.Path"], "Actividad_Economica_List"));
                    Utilities.Cache.SetItem("ActividadesEconomicas_Aliados", JsonConvert.SerializeObject(result), -1);
                }
                catch (Exception e)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    HttpResponseMessage response = await client.GetAsync("https://www.snap-testing.com/mapfre/PoliticaClientes/CargarFiltroActividadesEcon?text=");
                    string resultResponse = response.Content.ReadAsStringAsync().Result;
                    result = System.Text.Json.JsonSerializer.Deserialize<List<Actividad_Economica>>(resultResponse);
                    Utilities.Cache.SetItem("ActividadesEconomicas_Aliados", resultResponse, -1);
                }
            }
            return Ok(result);
        }
    }

    public class Actividad_Economica
    {
        public int CodigoActividadEconomica { get; set; }
        public string Descripcion { get; set; }
    }
}