using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts.v2
{
    public class WebhookRequest
    {
        public bool resultado { get; set; }
        public string status { get; set; }
        public bool contratoFrontal { get; set; }
        public string statusProcesador { get; set; }
        public string ordenId { get; set; }
        public string transaccionId { get; set; }
        public string sessionId { get; set; }
        public string card_number { get; set; }
        public Resultado_Pasarela resultado_pasarela { get; set; }
    }

    public class Resultado_Pasarela
    {
        public string receipt { get; set; }
        public string type { get; set; }
        public bool refunded { get; set; }
        public string provider { get; set; }
        public object discount { get; set; }
        public string b24 { get; set; }
        public string authorization { get; set; }
        public string id { get; set; }
        public int internalReference { get; set; }
    }
}
