using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Certificado
{
    /// <summary>
    /// Detalle del certificado solicitado.
    /// </summary>
    public class Documento
    {
        /// <summary>
        /// Número de Riesgo
        /// </summary>
        public int numeroderiesgo { get; set; }

        /// <summary>
        /// Contenido del documento en formato base64.
        /// </summary>
        public string certificado { get; set; }

    }
}
