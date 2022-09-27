using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Certificado
{
    /// <summary>
    /// Estructura de Respuesta - PDF Certificado Póliza
    /// </summary>
    public class RespuestaCertificado : Comun.RespuestaBase
    {
        /// <summary>
        /// Cuerpo y detalle de la respuesta
        /// </summary>
        public RespuestaCertificadoDetalle message_body { get; set; }
    }


}
