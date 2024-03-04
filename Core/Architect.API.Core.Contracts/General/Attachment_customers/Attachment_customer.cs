using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Architect.API.Core.Contracts.General.Attachment_customers
{
    /// <summary>
    /// Documento a ser asociados a una póliza.
    /// </summary>
    public class Attachment_customer
    {
        /// <summary>
        /// Código del documento. Lista de valores:
        /// </summary>
        public int document_type { get; set; }
        /// <summary>
        /// Nombre del archivo original, el mismo debe posee la extensión del archivo. Ejemplo cédula.pdf.
        /// </summary>
        public string file_name { get; set; }
        /// <summary>
        /// Tamaño del documento en bytes.
        /// </summary>
        public string file_size { get; set; }
        /// <summary>
        /// Contenido del documento en formato base64.
        /// </summary>
        public string file_content_base64 { get; set; }
    }
}