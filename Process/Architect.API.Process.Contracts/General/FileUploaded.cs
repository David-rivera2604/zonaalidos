using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Process.Contracts.Contracts.General
{
    public class FileUploaded
    {
        public string Stored { get; set; }
        public string FileSize { get; set; }
        public string FileName { get; set; }
    }
}