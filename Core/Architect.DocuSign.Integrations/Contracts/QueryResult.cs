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
<<<<<<< HEAD
        
=======
>>>>>>> 2603d8692335166cf5801e413f5bc98d7a338de7
    }
}
