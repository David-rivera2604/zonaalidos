using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que contiene la información acerca del medio de pago a usar en una transacción, esta estructura es variable de acuerdo a la solicitud que se genere, cada servicio requiere que se usen unos u otros datos.
    /// </summary>
    public class Instrument
    {
        /// <summary>
        /// Estructura que contiene la información de la tarjeta.
        /// </summary>
        public Card card { get; set; }

        /// <summary>
        /// Estructura que contiene la información del token que asocia a la tarjeta
        /// </summary>
        public Token token { get; set; }


    }
}
