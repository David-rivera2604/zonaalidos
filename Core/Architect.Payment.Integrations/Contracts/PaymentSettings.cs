using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts
{
    /// <summary>
    /// Configuración para cuenta externas de pago.
    /// </summary>
    public partial class PaymentSettings
    {
        public int Id { get; set; }
        /// <summary>
        /// Nombre Usuario.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Descripción para nombre usuario.
        /// </summary>
        public string UserIdDesc { get; set; }
        /// <summary>
        /// Moneda.
        /// </summary>
        public int Currency { get; set; }
        public string ClientId { get; set; }
        public string SecretKey { get; set; }

    }
}
