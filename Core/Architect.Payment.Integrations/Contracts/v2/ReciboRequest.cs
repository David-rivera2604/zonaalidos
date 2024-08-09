using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts.v2
{

    public class ReciboRequest
    {
        public string procesoId { get; set; }
        public string bankCode { get; set; }
        public string convenioType { get; set; }
        public string convenioCode { get; set; }
        public double totalCompleto { get; set; }
        public int totalItems { get; set; }
        public string envioType { get; set; }
        public DateTime envioDate { get; set; }
        public string numPlan { get; set; }
        public bool trnExterna { get; set; }
        public List<Item> items { get; set; }

        public string urlWebhook { get; set; }
    }

    public class Item
    {
        public string productCode { get; set; }
        public string subtotal { get; set; }
        public string impuestos { get; set; }
        public string emailCliente { get; set; }
        public string total { get; set; }
        public string ordenId { get; set; }
        public string origen { get; set; }
        public DateTime expectedCollectionPaidDate { get; set; }
        public string moneda { get; set; }
        public string concepto { get; set; }
        public string token { get; set; }

    }


}
