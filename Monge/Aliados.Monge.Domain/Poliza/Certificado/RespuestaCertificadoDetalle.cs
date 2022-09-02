using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Certificado
{
    /// <summary>
    /// Detalle del certificado solictado.
    /// </summary>
    public class RespuestaCertificadoDetalle
    {
        /// <summary>
        /// Contenido del documento en formato base64.
        /// </summary>
        public string certificado { get; set; }
    }
}
