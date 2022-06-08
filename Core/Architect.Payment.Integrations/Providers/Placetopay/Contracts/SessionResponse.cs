using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    public class SessionResponse
    {
        public Status status { get; set; }
        public string requestId { get; set; }
        public string processUrl { get; set; }
    }
}
