using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    internal class CollectTransaction : TransactionBase
    {
        public Amount amount { get; set; }
        public AmountConversion conversion { get; set; }

        public string lastDigits { get; set; }
    }
}
