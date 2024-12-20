using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Requests
{
    internal class Information
    {
        public Status status { get; set; }

        public RedirectRequest request { get; set; }

        public List<Transaction> payment { get; set; }

        public subscription subscription { get; set; }


        // subscription SubscriptionResponse

        [JsonIgnore]
        public string rawData { get; set; }

        [JsonIgnore]
        public bool changed { get; set; }

        [JsonIgnore]
        public Architect.Payment.Integrations.Contracts.OnlinePayment OnlinePayment { get; set; }



    }
}
