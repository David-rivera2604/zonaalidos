using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts
{
    public class InformationRequest
    {
        public string status { get; set; }
        public string description { get; set; }
        public string reference { get; set; }
        public string currency { get; set; }
        public double total { get; set; }
        public string message { get; set; }

        public string paymentMethodName { get; set; }
        public string lastDigits { get; set; }
        public string authorization { get; set; }
        public string receipt { get; set; }
    }
}
