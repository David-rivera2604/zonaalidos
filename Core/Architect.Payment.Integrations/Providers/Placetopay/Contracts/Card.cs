using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que contiene la información de la tarjeta.
    /// </summary>
    internal class Card
    {
        public string number { get; set; }
        public string expiration { get; set; }
        public string cvv { get; set; }
        public int installments { get; set; }

    }
}
