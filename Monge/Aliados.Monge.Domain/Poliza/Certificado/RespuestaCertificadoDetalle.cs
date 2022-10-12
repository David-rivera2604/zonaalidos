using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Certificado
{
    /// <summary>
    /// Detalle del certificado solicitado.
    /// </summary>
    public class RespuestaCertificadoDetalle
    {

        /// <summary>
        /// Lista de certificados uno por cada riesgo asegurado.
        /// </summary>
        public List<Documento> certificados { get; set; }

    }
}
