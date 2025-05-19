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
    public sealed class RespuestaToken
    {
        /// <summary>
        /// Token de acceso
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Tiempo de expiración del token
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// Token usando para el proceso de refrescamiento.
        /// </summary>
        public string refresh_token { get; set; }
    }
}
