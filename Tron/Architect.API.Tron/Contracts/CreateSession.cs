using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts
{
    /// <summary>
    /// Datos para la creación de una sesión de pago.
    /// </summary>
    public class CreateSession
    {
        /// <summary>
        /// Número de póliza
        /// </summary>
        public string num_poliza { get; set; }
        /// <summary>
        /// Número de recibo
        /// </summary>
        public Int64 num_recibo { get; set; }

    }

}
