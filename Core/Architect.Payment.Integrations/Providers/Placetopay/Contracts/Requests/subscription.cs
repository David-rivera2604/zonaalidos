using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Requests
{
    internal class subscription
    {
        public string type { get; set; }

        public Status status { get; set; }

        public List<InstrumentValue> instrument { get; set; }

    }
}
