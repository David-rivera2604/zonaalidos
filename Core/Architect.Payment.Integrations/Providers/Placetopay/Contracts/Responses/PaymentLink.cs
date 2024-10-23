using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Responses
{
    internal class PaymentLink
    {
        public Status status { get; set; }
        public string id { get; set; }
        public string link { get; set; }
 
    }
}
