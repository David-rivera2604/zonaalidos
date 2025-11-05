using Newtonsoft.Json;
using System;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts
{
    /// <summary>
    /// Estructura que contiene la información de la respuesta sobre una solicitud o pago, e informa el estado actual de la misma.
    /// </summary>
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
