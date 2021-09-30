using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Core.Controllers
{
    /// <summary>
    /// Acciones para obtener cualquier lista de valores disponible de la aplicación.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Support")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class FileManagerController : ApiController
    {


        [Route("Download")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Download([FromUri] string id)
        {
            string filename = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(id));
            var dataBytes = File.ReadAllBytes(filename);
            var dataStream = new MemoryStream(dataBytes);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = System.IO.Path.GetFileName(filename);
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }

        [HttpGet]
        [Route("View")]
        [AllowAnonymous]
        public HttpResponseMessage View()
        {
            string path = Request.RequestUri.AbsoluteUri;
            path = path .Substring(0, path.LastIndexOf("/"));
            string body = Resources.Support.FileManager;
            body = body.Replace("%PATH%", path);
            var response = new HttpResponseMessage();
            response.Content = new StringContent(body);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        [HttpGet]
        [Route("Content")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Content(string path = "")
        {
            string root = System.Web.Hosting.HostingEnvironment.MapPath( string.Format("~/{0}", path.Trim()));
            List<PathContent> result = new List<PathContent>();

            //List<object> result = new List<object>();
            await Task.Run(() =>
            {
                //const string baseDir = @"/App_Data/userfiles/";

                //dir = Server.UrlDecode(dir);
                //string realDir = Server.MapPath(baseDir + dir);

                ////validate to not go above basedir
                //if (!realDir.StartsWith(Server.MapPath(baseDir)))
                //{
                //    realDir = Server.MapPath(baseDir);
                //    dir = "/";
                //}

                DirectoryInfo di = new DirectoryInfo(root);
                foreach (DirectoryInfo directoryItem in di.GetDirectories())
                {
                    result.Add(new PathContent() { Name = directoryItem.Name, Folder = true, LastWrite = directoryItem.LastWriteTime });
                }
                result = result.OrderBy(o => o.Name).ToList();

                List<PathContent> files = new List<PathContent>();
                foreach (FileInfo fileitem in di.GetFiles())
                {
                    files.Add(new PathContent() { Name = fileitem.Name, Folder = false, LastWrite = fileitem.LastWriteTime, Size = fileitem.Length });
                }
                files = files.OrderBy(o => o.Name).ToList();

                result.AddRange(files);
            }).ConfigureAwait(false);

            return Ok(new { path = root.Replace(@"\\", @"\"), content = result });
        }

        private class PathContent
        {
            public string Name { get; set; }
            public bool Folder { get; set; }
            public DateTime LastWrite { get; set; }
            public Int64 Size { get; set; }
        }
    }
}
