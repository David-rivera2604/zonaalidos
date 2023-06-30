using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Seguridad
{
    /// <summary>
    /// Solicitud de acceso.
    /// </summary>
    public sealed class SolicitudAcceso
    {
        /// <summary>
        /// Identificador público de la aplicación.
        /// </summary>
        [Required()] public string clienteID { get; set; }
        /// <summary>
        /// información de acceso de la aplicación.
        /// </summary>
        [Required()] public string secretID { get; set; }

    }
}
