using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Consulta
{
    /// <summary>
    /// Estructura de Respuesta - Consulta Estatus de Solicitud
    /// </summary>
    public class RespuestaConsulta : Comun.RespuestaBase
    {
        /// <summary>
        /// Cuerpo y detalle de la respuesta
        /// </summary>
        public object message_body { get; set; }
    }
}
