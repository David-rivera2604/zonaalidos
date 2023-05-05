using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.Security
{
    public class ColoresResponse
    {
        public string CompanyID { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Tenant { get; set; }
        public string Logo { get; set; }

    }
}
