using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Documentos
{
        public class RespuestaDocumentos : Comun.RespuestaBase
    {
        /// <summary>
        /// Cuerpo y detalle de la respuesta
        /// </summary>
        public RespuestaDocumentosDetalle message_body { get; set; }
    }


}
