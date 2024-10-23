using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que contiene información sobre el proceso de pago de la transacción en PlacetoPay.
    /// </summary>
    internal class PaymentRequest
    {
        /// <summary>
        /// Única referencia para la solicitud de pago
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// Única referencia para la solicitud de pago
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Información del monto a cobrar
        /// </summary>
        public Amount amount { get; set; }

        public bool allowPartial { get; set; }

        //private Person shipping;
        //private List<Item> items;
        //private Recurring recurring;
        //private Instrument instrument;
        //private Transaction transaction { get; set; }
    }
}
