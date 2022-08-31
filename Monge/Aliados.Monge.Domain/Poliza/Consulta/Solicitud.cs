using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Consulta
{

    public class Solicitud
    {
        /// <summary>
        /// identificador único en MAPRE de la solicitud
        /// </summary>
        public string message_id { get; set; }
        /// <summary>
        /// identificador único de MONGE enviado en la solicitud
        /// </summary>
        public string document_id { get; set; }
    }

}
