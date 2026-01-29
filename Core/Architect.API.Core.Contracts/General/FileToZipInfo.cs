using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.General
{
    public class FileToZipInfo
    {
        public string FullPath { get; set; }
        public byte[] Content { get; set; }
        public string ZipEntryName { get; set; }
    }
}
