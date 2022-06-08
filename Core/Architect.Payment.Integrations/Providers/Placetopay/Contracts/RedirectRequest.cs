using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que contiene toda la información acerca de la transacción para ser procesada.
    /// </summary>
    public class RedirectRequest
    {
        public string locale { get; set; }
        public Auth auth { get; set; }
        public Person payer { get; set; }
        public Person buyer { get; set; }
        public PaymentRequest payment { get; set; }
        //subscription SubscriptionRequest
        //fields object
        public string paymentMethod { get; set; }
        public DateTime expiration { get; set; }
        public string returnUrl { get; set; }
        public string cancelUrl { get; set; }
        public string ipAddress { get; set; }        
        public string userAgent { get; set; }
        public bool skipResult { get; set; }
        public bool noBuyerFill { get; set; }
        public string type { get; set; }


    }
}
