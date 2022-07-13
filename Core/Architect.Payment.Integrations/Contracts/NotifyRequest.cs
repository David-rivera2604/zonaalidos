using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts
{
    public class NotifyRequest
    {
        public Status status { get; set; }
        public string requestId { get; set; }
        public string signature { get; set; }
    }

    public class Status
    {
        /// <summary>
        /// Estado de una petición o pago
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Código del motivo proporcionado.
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// Descripción del código de razón.
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Fecha y hora en que se genera el estado de pago.
        /// </summary>
        public string date { get; set; }

    }

}
