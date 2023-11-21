using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts.v2
{
    public class PaymentInformation
    {

        public string ordenId { get; set; }
        public string documentoCliente { get; set; }
        public string total { get; set; }
        public string nombreCliente { get; set; }
        public string emailCliente { get; set; }
        public string telefonoCliente { get; set; }
        public string subtotal { get; set; }
        public string impuestos { get; set; }
        public string concepto { get; set; }

        public string urlReturn { get; set; }
        public string urlWebhook { get; set; }
        public string countryCode { get; set; }
        public bool contratoFrontal { get; set; }
        public Item[] items { get; set; }


        public class Item
        {
            public int cantidad { get; set; }
            public string producto { get; set; }
            public double precio { get; set; }
            public string moneda { get; set; }
        }

        /// <summary>
        /// Estado de una petición o pago.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Código del motivo proporcionado.
        /// </summary>        
        public string Reason { get; set; }
    }
}
