using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    internal class AmountConversion
    {
        public Amount from { get; set; }
        public Amount to { get; set; }
        public double factor { get; set; }
    }
}
