using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Responses
{
    public class Tokenize
    {
        public Status status { get; set; }
        public string provider { get; set; }
        public Instrument instrument { get; set; }
 
    }
}
