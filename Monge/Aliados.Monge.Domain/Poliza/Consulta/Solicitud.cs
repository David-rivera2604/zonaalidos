using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Consulta
{

    /// <summary>
    /// Datos consultar una solicitud.
    /// </summary>
    public class Solicitud
    {
        /// <summary>
        /// Identificador único de la solicitud.
        /// </summary>
        public string document_id { get; set; }
        /// <summary>
        /// Identificador único de la respuesta.
        /// </summary>
        public string message_id { get; set; }

    }

}
