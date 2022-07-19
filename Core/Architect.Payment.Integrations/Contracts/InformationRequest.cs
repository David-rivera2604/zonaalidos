using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts
{
    /// <summary>
    /// Información de la sesión, si en la sesión hay transacciones se muestra el detalle de las mismas.
    /// </summary>
    public class InformationRequest
    {
        /// <summary>
        /// Estado de una petición o pago.
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Código del motivo proporcionado.
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// Descripción del código de razón.
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Referencia enviada por el comercio para la transacción.
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// Moneda acorde al ISO 4217 (alphabetic code).
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Valor total.
        /// </summary>
        public double total { get; set; }
        /// <summary>
        /// Descripción del código de razón.
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Nombre del pagador.
        /// </summary>
        public string payerName { get; set; }
        /// <summary>
        /// Apellido del pagador.
        /// </summary>
        public string payerSurname { get; set; }
        /// <summary>
        /// Nombre del método de pago utilizado.
        /// </summary>
        public string paymentMethodName { get; set; }
        /// <summary>
        /// Últimos 4 dígitos de la tarjeta usada para el pago.
        /// </summary>
        public string lastDigits { get; set; }
        /// <summary>
        /// Código de autorización.
        /// </summary>
        public string authorization { get; set; }
        /// <summary>
        /// Número de recibo de la transacción.
        /// </summary>
        public string receipt { get; set; }

        /// <summary>
        /// Fecha y hora en que se genera el estado de pago.
        /// </summary>
        public string date { get; set; }

        [JsonIgnore]
        public string ipAddress { get; set; }

        [JsonIgnore]
        public string rawData { get; set; }

        [JsonIgnore]
        public bool changed { get; set; }

        [JsonIgnore]
        public Architect.Payment.Integrations.Contracts.OnlinePayment OnlinePayment { get; set; }
    }
}
