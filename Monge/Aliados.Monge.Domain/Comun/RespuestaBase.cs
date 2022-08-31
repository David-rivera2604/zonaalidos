using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Comun
{
    public class RespuestaBase
    {
        /// <summary>
        /// Código de respuesta
        /// </summary>
        public int message_status { get; set; }
        /// <summary>
        /// Detalle de la respuesta
        /// </summary>
        public string message_text { get; set; }
        /// <summary>
        /// Identificador único de la respuesta.
        /// </summary>
        public string message_id { get; set; }
        /// <summary>
        /// Identificador único de la solicitud.
        /// </summary>
        public string document_id { get; set; }

    }
}
