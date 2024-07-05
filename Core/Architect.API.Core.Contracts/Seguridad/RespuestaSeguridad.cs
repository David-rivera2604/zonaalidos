using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.Seguridad
{
    /// <summary>
    /// Información de acceso.
    /// </summary>
    public sealed class RespuestaSeguridad
    {
        /// <summary>
        /// Token de acceso
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// Tipo de token
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// Tiempo de expiración del token
        /// </summary>
        public int expires_in { get; set; }

    }
}
