using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.GTI.Integrations.Domain.CargarDocumento
{
    /// <summary>
    /// Representa la respuesta del API de GTI al cargar documentos.
    /// </summary>
    public class DocumentoResponse
    {
        /// <summary>
        /// Número interno que utiliza GTI para diferenciar todas las cargas de los documentos que se realicen.
        /// </summary>
        public int NumCarga { get; set; }

        /// <summary>
        /// Código que representa el mismo estado de la petición HTTP.
        /// </summary>
        public int Estado { get; set; }

        /// <summary>
        /// Descripción general de la respuesta del API.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Fecha de carga del documento.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Contiene todas las respuestas para cada documento cargado.
        /// </summary>
        public Response.Respuesta[] Respuestas { get; set; }
    }

}
