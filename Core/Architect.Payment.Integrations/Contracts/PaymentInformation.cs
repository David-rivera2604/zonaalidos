using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts
{
    public class PaymentInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public int DocumentType { get; set; }
        public string Mobile { get; set; }
        public string PolicyId { get; set; }
        public Int64 BillNumber { get; set; }

        public string Description { get; set; }
        public int Currency { get; set; }
        public double Amount { get; set; }

        public string ReturnUrl { get; set; }

        [JsonIgnore]
        public string Reference { get; set; }

    }
}
