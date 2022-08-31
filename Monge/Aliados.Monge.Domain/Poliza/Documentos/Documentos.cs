using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Documentos
{
    /// <summary>
    /// Documentos a ser asociados a una póliza.
    /// </summary>
    public class Documentos
    {
        /// <summary>
        /// Identificador único de la solicitud.
        /// </summary>
        public string document_id { get; set; }
        /// <summary>
        /// Número de póliza que se relaciona con los documentos.
        /// </summary>
        public string num_poliza { get; set; }
        /// <summary>
        /// Lista de documentos.
        /// </summary>
        public Documento[] documentos { get; set; }
    }



}
