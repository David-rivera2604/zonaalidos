using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.General
{
    // Clases auxiliares para descarga de archivos
    public class DownloadFileItem
    {
        public int? Id { get; set; }
        public string FileName { get; set; }
        public string StoredFileName { get; set; }
        public bool IsLoaded { get; set; }
    }
}
