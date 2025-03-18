using Newtonsoft.Json;
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

        /// <summary>
        /// Indica el modo de uso
        /// </summary>
        public string mode { get; set; }

        /// <summary>
        /// Indica el email a ser usando para el envio del link de pago.
        /// </summary>
        public string emailCliente { get; set; }

        /// <summary>
        /// Indica agente al que le perteneces el recibo, solo aplica para roles Comercial_Mapfre y Empleado.
        /// </summary>
        public int cod_agt { get; set; }

    }

}
