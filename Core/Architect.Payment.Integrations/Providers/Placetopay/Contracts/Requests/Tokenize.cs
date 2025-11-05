using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Requests
{
    public class Tokenize
    {
        /// <summary>
        /// Estructura que contiene la información de autenticación del sitio generada de acuerdo al WSSE UsernameToken Profile 1.1
        /// </summary>
        public Auth auth { get; set; }

        /// <summary>
        /// Estructura que refleja la información de una persona involucrada en una transacción.
        /// </summary>
        public Person payer { get; set; }

        /// <summary>
        /// Estructura que contiene la información acerca del medio de pago a usar en una transacción, esta estructura es variable de acuerdo a la solicitud que se genere, cada servicio requiere que se usen unos u otros datos.
        /// </summary>
        public Instrument instrument { get; set; }

        public string ipAddress { get; set; }
        public string userAgent { get; set; }
 
    }
}
