using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.DocuSign.Integrations.Contracts
{
    public class QueryResult
    {
        public string outcome { get; set; }
        public List<affidavits> affidavits { get; set; }
    }
    public class affidavits
    {
        public string kind { get; set; }
        public string bytes { get; set; }
        public string description { get; set; }

        public bool Signed { get; set; }
    }
}
