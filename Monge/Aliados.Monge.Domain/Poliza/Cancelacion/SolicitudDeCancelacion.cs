using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Cancelacion
{

    public class SolicitudDeCancelacion
    {
        /// <summary>
        /// identificador único de MONGE enviado en la solicitud
        /// </summary>
        public string document_id { get; set; }
        /// <summary>
        /// número de póliza que se relacionan los documentos a enviar
        /// </summary>
        public string num_poliza { get; set; }
        /// <summary>
        /// código correspondiente a la causa de anulación
        /// </summary>
        public string codigo_causa { get; set; }
        /// <summary>
        /// descripción del motivo de anulación
        /// </summary>
        public string descripcion_causa { get; set; }
        /// <summary>
        /// Usuario que realiza la anulación
        /// </summary>
        public string nombre_vendedor { get; set; }
        /// <summary>
        /// identificación del usuario que hace la anulación
        /// </summary>
        public string identificacion_vendedor { get; set; }
  
    }

}
