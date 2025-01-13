using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.General
{
    public class Report
    {
        public string ReportName { get; set; }
        public string Source { get; set; }
        public string data { get; set; }
        public string reason { get; set; }

    }
}
