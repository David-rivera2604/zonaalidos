using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Consulta
{

    public class Respuesta : Comun.RespuestaBase
    {
        /// <summary>
        /// Cuerpo y detalle de la respuesta
        /// </summary>
        public RespuestaDetalle message_body { get; set; }
    }
}
