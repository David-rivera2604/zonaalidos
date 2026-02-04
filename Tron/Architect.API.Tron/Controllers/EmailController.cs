using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.API.Core.Contracts;
using Architect.API.Core.Contracts.General;
using Architect.API.Core.Contracts.Security;
using Architect.API.Tron.Business.DocumentGenerator;
using Asp.Versioning;
using Newtonsoft.Json;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Permite la consulta centralizada de información de personas.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Email")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class EmailController : ApiController
    {
        /// <summary>
        /// Busqueda de información de Kyc Persona.
        /// </summary>
        /// <param name="id">Identificación.</param>
        /// <returns>Información de la personal.</returns>
        [HttpPost]
        [Route("Send")]
        [Authorize]
        [AllowAnonymous]
        public async Task<IHttpActionResult> SendRequest([FromBody] Solicitud solicitud)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            HttpResponseMessage response = new HttpResponseMessage();

            int TaskResult = 0;

            try
            {
                GeneratedPDF generated = new GeneratedPDF();

                string newpdfname = generated.GeneratePDF(solicitud, tokenInfo);
                string thisDay = DateTime.Today.ToString("d");
                string thisHour = DateTime.Now.ToString("hh:mm:ss");

                HttpClient clientcase = new HttpClient();
                clientcase.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Request.Headers["Authorization"].Substring(7));
                clientcase.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                clientcase.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                List<Attachments> Files = new List<Attachments>();
                FileInfo fileinfo = new FileInfo(newpdfname);
                Files.Add(new Attachments()
                {
                    DocumentType = 1,
                    Description = fileinfo.Name,
                    DocumentTypeDesc = "General",
                    FileName = fileinfo.Name,
                    FileSize = (int)fileinfo.Length,
                    FileContent = Path.Combine(ConfigurationManager.AppSettings["Attachments.Path"], fileinfo.Name)
                });

                Architect.API.Process.Contracts.General.ProcessCase Caso = new Architect.API.Process.Contracts.General.ProcessCase()
                {
                    Attachments = Files,
                    Reference1 = solicitud.Persona.Email,
                    Reference2 = solicitud.Persona.telefono,
                    FlowId = Convert.ToInt32(ConfigurationManager.AppSettings["ClientesSolicitud.FlowId"]),
                    Title = "Solicitud de Seguro: " + solicitud.Seguro.title + " realizada por " + solicitud.Persona.Nombre + " " + solicitud.Persona.Apellido
                };

                string jsondata = JsonConvert.SerializeObject(Caso);
                response = await clientcase.PostAsync(ConfigurationManager.AppSettings["API.Path.ClientesSolicitud.Case"],
                    new StringContent(jsondata, Encoding.UTF8, "application/json"));
                string resultResponsecase = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    return BadRequest();
                }

                Core.Business.General.Mail.SendEmail(
                     new Dictionary<string, string>() { { solicitud.Persona.Email, string.Empty } },
                     "Solicitud Cotizacion", "Su solicitud sera tratada",
                      new string[] { string.Format("{0};Solicitud {1}.pdf", newpdfname, solicitud.Seguro.title + " " + solicitud.Persona.Nombre + " " + thisHour + " " + thisDay) });

                /*
                Core.Business.General.Mail.SendEmail(new Dictionary<string, string>() { { data.Persona.Email, string.Empty } },
                    "Solicitud Cotizacion", "Su solicitud sera tratada",
                        new string[] { });

                Core.Business.General.Mail.SendEmail(
                        new Dictionary<string, string>() { { "sebasbuck221@gmail.com", string.Empty } },
                        "Cotizacion Solicitada", data.Persona.Nombre + " " + data.Persona.Apellido + " ha solicitado una cotizacion de seguro: " + data.Seguro.title + "\n Comentario del Solicitante: " + data.Comentario,
                        new string[] { string.Format("{0};Solicitud {1}.pdf", newpdfname, data.Seguro.title + " " + data.Persona.Nombre + " " + thisHour + " "+ thisDay) });
                */

                TaskResult = 1;
            }
            catch (Exception e)
            {
                TaskResult = 0;
            }

            if (TaskResult == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(TaskResult);
            }
        }

        [HttpPost]
        [Route("SendforRol")]
        [Authorize]
        [AllowAnonymous]
        public async Task<IHttpActionResult> SendforRol([FromBody] string message, [FromUri] string Rol = "")
        {
            Core.Contracts.Security.Token tokenInfo = Architect.API.Core.Security.Token.Info();

            List<UserMember> result = Core.Business.Security.UserMember
                .Retrieve(tokenInfo.CompanyId, tokenInfo.SecurityLevel, Rol, "");

            return Ok();
        }

        [HttpPost]
        [Route("ViajeroReceipt")]
        [Authorize]
        [AllowAnonymous]
        public async Task<IHttpActionResult> SendReceipt([FromBody] Tron.Contracts.Emision.Viajero data)
        {
            Core.Contracts.Security.Token tokenInfo = Core.Security.Token.Info();
            HttpResponseMessage response = new HttpResponseMessage();

            int TaskResult = 1;
            string email = "";
            foreach (var item in data.terceros)
            {
                if (item.tipodetercero == 0 || item.elaseguradoeselmismotomador == 1)
                {
                    email = item.correoelectronico;
                }
            }

            string[] lis = await Core.Business.General.Attachment.ReceiptWeb(data.cantidad_riesgos, data.num_poliza);

            Core.Business.General.Mail.SendEmail(
                 new Dictionary<string, string>() { { email, string.Empty } },
                 "Recibo de compra Seguro", "Recibos Viajero", lis);

            if (TaskResult == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(lis);
            }
        }
    }
}