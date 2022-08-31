using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Certificado
{

    public class Certificado
    {
        /// <summary>
        /// Identificador único de MONGE enviado en la solicitud
        /// </summary>
        public string document_id { get; set; }
        /// <summary>
        /// Número de póliza que se relacionan los documentos a enviar
        /// </summary>
        public string num_poliza { get; set; }
        /// <summary>
        /// Número de certificado generado en Phoenix
        /// </summary>
        public string num_certificado_phx { get; set; }


    }

}
