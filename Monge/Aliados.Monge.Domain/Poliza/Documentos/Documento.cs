using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Documentos
{
    public class Documento
    {
        /// <summary>
        /// Código del documento. Lista de valores:
        /// </summary>
        public int codigo_documento { get; set; }
        /// <summary>
        /// Nombre del archivo original. Ejemplo cédula.pdf.
        /// </summary>
        public string nombre_documento { get; set; }
        /// <summary>
        /// Tamaño del documento en bytes.
        /// </summary>
        public string peso_documento { get; set; }
        /// <summary>
        /// Contenido del documento en formato base64.
        /// </summary>
        public string documento_base64 { get; set; }
    }
}
