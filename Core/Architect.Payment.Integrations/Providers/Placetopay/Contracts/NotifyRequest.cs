using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    public class NotifyRequest
    {
        public Status status { get; set; }
        public string requestId { get; set; }
        public string signature { get; set; }
    }
}
