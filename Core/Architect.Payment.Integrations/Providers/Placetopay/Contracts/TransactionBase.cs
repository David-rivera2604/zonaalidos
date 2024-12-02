using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    internal class TransactionBase
    {

        public Status status { get; set; }        
        public int internalReference { get; set; }
        public string reference { get; set; }
        public string paymentMethod { get; set; }
        public string paymentMethodName { get; set; }
        public string issuerName { get; set; }
        public string receipt { get; set; }
        public string franchise { get; set; }
        public bool refunded { get; set; }
        public string authorization { get; set; }        

        //dispersion Transaction
        public string agreement { get; set; }
        public string agreementType { get; set; }
    }
}
