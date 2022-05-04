using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    public class InformationRequest
    {
        public Status status { get; set; }

        public RedirectRequest request { get; set; }

        public List<Transaction> payment { get; set; }


        // subscription SubscriptionResponse

        [JsonIgnore]
        public string rawData { get; set; }
    }
}
