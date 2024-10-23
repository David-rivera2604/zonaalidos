using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Responses
{

    internal class Collect : Requests.Information
    {
        public string requestId { get; set; }

    }
}
