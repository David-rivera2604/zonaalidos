using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Cancelacion
{

    public class RespuestaCancelacion : Comun.RespuestaBase
    {
        /// <summary>
        /// Cuerpo y detalle de la respuesta
        /// </summary>
        public RespuestaCancelacionDetalle message_body { get; set; }
    }
}
