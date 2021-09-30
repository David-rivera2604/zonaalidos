using Microsoft.Web.Http;
using System.Web.Http;
using Architect.Utilities.Extensions;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Acciones relacionas con la seguridad de la aplicación.
    /// </summary>
    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/Research")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ResearchController : ApiController
    {

        private static HttpClient xlient = new HttpClient();

        ///// <summary>
        ///// Pruebas para el envio de documento a evicertia
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[AllowAnonymous]
        //[Route("test")]
        //public async Task<HttpResponseMessage> test()
        //{

        //    var json = JsonConvert.SerializeObject(new Architect.API.Core.Contracts.EviSign.SignSubmit()
        //    {
        //        LookupKey = "6329255",  //Numero de la poliza
        //        Subject = "Solicitud de la póliza 6329255",
        //        Document = Convert.ToBase64String(System.IO.File.ReadAllBytes(@"c:\my\Invoice.pdf")),
        //        SigningParties = new List<Contracts.EviSign.SigningParty>() {
        //            new Architect.API.Core.Contracts.EviSign.SigningParty()
        //            {
        //                Name = "Nelson Soler",
        //                Address = "solernelson@hotmail.com",
        //                SigningMethod = "WebClick"
        //            } }
        //    });

        //    xlient.DefaultRequestHeaders.Authorization
        //                 = new AuthenticationHeaderValue("Basic", "cm95bmVyLmFjb3N0YUBtYXBmcmVjci5jb206TWFwZnIzLjU2");
        //    var response = await xlient.PostAsync("https://app.ecertia.com/api/json/reply/EviSignSubmit", new StringContent(json, Encoding.UTF8, "application/json"));

        //    string result = response.Content.ReadAsStringAsync().Result;
        //    var resp = new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        //    return resp;
        //}


        //[HttpPost]
        //[AllowAnonymous]
        //[Route("Rules")]
        //public async Task<IHttpActionResult> Rules()
        //{
        //    string result = await Request.Content.ReadAsStringAsync();
        //    result = "";
        //    //if (!string.IsNullOrEmpty(result))
        //    //{
        //    //    JObject o = JObject.Parse(result);

        //    //    string value1 = (string)o.SelectToken("Tenant");
        //    //    string value2 = (string)o.SelectToken("Email");
        //    //    string value3 = (string)o.SelectToken("Password");
        //    //}

        //    ////Find the operation
        //    //IOperation operation = _supportedOperations.FirstOrDefault(x => x.Name == operationName);
        //    //if (operation == null)
        //    //    return BadRequest($"'{operationName}' is not supported.");

        //    //Get the request body as string
        //    //string jsonBody = await Request.Content.ReadAsStringAsync();
        //    //object operationParams = null;

        //    try
        //    {
        //        ////Parse the JSON data in the request body t construct operation's parameter object
        //        //if (operation.ParameterClassType != null)
        //        //    operationParams = Newtonsoft.Json.JsonConvert.DeserializeObject
        //        //                      (jsonBody, operation.ParameterClassType);

        //        //object result = operation.Execute(operationParams);

        //        //Return the result value as JSON to the caller
        //        //if (result != null)
        //        //    return Json(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }

        //    //Return Ok if the operation has no return value
        //    return Ok();
        //}

    }
}



