using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.Seguridad
{
    /// <summary>
    /// Solicitud de acceso.
    /// </summary>
    public sealed class SolicitudAcceso
    {
        /// <summary>
        /// Identificador público de la aplicación.
        /// </summary>
        public string clienteID { get; set; }
        /// <summary>
        /// información de acceso de la aplicación.
        /// </summary>
        public string secretID { get; set; }

    }
}
