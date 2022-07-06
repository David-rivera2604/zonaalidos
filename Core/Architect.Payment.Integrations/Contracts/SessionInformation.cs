using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts
{
    public class SessionInformation
    {
        public string Status { get; set; }
        public string Reason { get; set; }
        public string RequestId { get; set; }
        public string ProcessUrl { get; set; }
        public string Reference { get; set; }

        [JsonIgnore]
        public string rawData { get; set; }
    }
}
