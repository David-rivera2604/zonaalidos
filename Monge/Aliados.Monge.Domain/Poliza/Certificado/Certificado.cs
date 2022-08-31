using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Certificado
{
    /// <summary>
    /// Información necesaria para recuperar de un certificado.
    /// </summary>
    public class Certificado
    {
        /// <summary>
        /// Identificador único de la solicitud.
        /// </summary>
        public string document_id { get; set; }
        /// <summary>
        /// Número de póliza.
        /// </summary>
        public string num_poliza { get; set; }
        /// <summary>
        /// Número de certificado generado en Phoenix
        /// </summary>
        public string num_certificado_phx { get; set; }


    }

}
