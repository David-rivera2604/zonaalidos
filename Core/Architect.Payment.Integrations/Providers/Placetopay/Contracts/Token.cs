using Architect.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que contiene la información del token que asocia a la tarjeta
    /// Para la entrada solo es necesario el token o el subtoken y el cvv si se trata de una operación donde el usuario está presente
    /// Para la salida si se devuelven todos los datos al tokenizar
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Código generado para identificar la tarjeta en el sistema
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// Código alterno generado para identificar la tarjeta
        /// </summary>
        public string subtoken { get; set; }
        /// <summary>
        /// Codigo de la franquicia asociada al token (Solo como respuesta no es necesario enviarla)
        /// </summary>
        public string franchise { get; set; }

        public string franchiseName { get; set; }
        public string lastDigits { get; set; }
        public string validUntil { get; set; }

    }
}
