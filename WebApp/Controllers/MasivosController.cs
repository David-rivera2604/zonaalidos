using Architect.API.Core.Security;
using aliados.Filters;
using aliados.Models.Masivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class MasivosController : Controller
    {
        private static readonly string[] _extensionesPermitidas = { ".xls", ".xlsx", ".csv" };

        public ActionResult Index()
        {
            return View(GetPlantillas());
        }

        [HttpGet]
        public ActionResult DownloadPlantilla(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return HttpNotFound();
            }

            string safeFileName = Path.GetFileName(fileName);
            if (!string.Equals(safeFileName, fileName, StringComparison.OrdinalIgnoreCase))
            {
                return HttpNotFound();
            }

            string plantillasPath = Server.MapPath("~/Masivos/plantillas");
            string fullPath = Path.Combine(plantillasPath, safeFileName);

            if (!System.IO.File.Exists(fullPath))
            {
                return HttpNotFound();
            }

            string mimeType = MimeMapping.GetMimeMapping(fullPath);
            return File(fullPath, mimeType, safeFileName);
        }

        [ChildActionOnly]
        public PartialViewResult PlantillasModal(IEnumerable<PlantillaDocumentoViewModel> plantillas)
        {
            return PartialView("_PlantillasModal", plantillas ?? GetPlantillas());
        }

        private static List<PlantillaDocumentoViewModel> GetPlantillas()
        {
            string plantillasPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Masivos/plantillas");
            if (string.IsNullOrWhiteSpace(plantillasPath) || !Directory.Exists(plantillasPath))
            {
                return new List<PlantillaDocumentoViewModel>();
            }

            List<PlantillaDocumentoViewModel> result = Directory
                .EnumerateFiles(plantillasPath)
                .Select(filePath => new FileInfo(filePath))
                .Where(fileInfo => _extensionesPermitidas.Contains(fileInfo.Extension, StringComparer.OrdinalIgnoreCase))
                .OrderBy(fileInfo => fileInfo.Name)
                .Select(fileInfo => new PlantillaDocumentoViewModel
                {
                    NombreDocumento = Path.GetFileNameWithoutExtension(fileInfo.Name),
                    NombreArchivo = fileInfo.Name,
                    UrlDescarga = $"/Masivos/DownloadPlantilla?fileName={Uri.EscapeDataString(fileInfo.Name)}"
                })
                .ToList();

            return result;
        }
    }
}
