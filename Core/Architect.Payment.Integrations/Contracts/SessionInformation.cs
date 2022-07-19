using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts
{
    /// <summary>
    /// Información de una sesión de pago.
    /// </summary>
    public class SessionInformation
    {
        /// <summary>
        /// Estado de una petición o pago.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Código del motivo proporcionado.
        /// </summary>        
        public string Reason { get; set; }
        /// <summary>
        /// Identificador de la sessión de pago.
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Dirección web usada para el despligue de la página o modal de pago.
        /// </summary>
        public string ProcessUrl { get; set; }
        /// <summary>
        /// Referencia enviada por el comercio para la transacción.
        /// </summary>
        public string Reference { get; set; }

        [JsonIgnore]
        public string rawData { get; set; }
    }
}
