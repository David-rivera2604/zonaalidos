using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.GTI.Integrations.Domain.Response
{

    /// <summary>
    /// Representa la respuesta individual para cada documento cargado en el sistema GTI.
    /// </summary>
    public class Respuesta
    {
        /// <summary>
        /// Código de error. La lista completa puede observarse en las últimas páginas de la documentación.
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Número de documento cargado.
        /// </summary>
        public int NumDoc { get; set; }

        /// <summary>
        /// Identificador del documento.
        /// </summary>
        public float IdDocumento { get; set; }

        /// <summary>
        /// Número de factura interno que se envía.
        /// </summary>
        public string NumInterno { get; set; }

        /// <summary>
        /// Número de 20 dígitos enviado a Hacienda.
        /// </summary>
        public string Consecutivo { get; set; }

        /// <summary>
        /// Número de 50 dígitos enviado a Hacienda.
        /// </summary>
        public string ClaveNumerica { get; set; }

        /// <summary>
        /// Descripción del código de error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Descripción detallada que explica con mayor detalle el código de error.
        /// </summary>
        public string Detalle { get; set; }
    }

}
