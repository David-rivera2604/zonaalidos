using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.GTI.Integrations.Domain.CargarDocumento
{
    /// <summary>
    /// Representa la solicitud para cargar documentos electrónicos en el sistema GTI.
    /// </summary>
    public class DocumentoRequest
    {
        /// <summary>
        /// Número de cuenta de la empresa, este dato es brindado por GTI.
        /// Campo requerido para todos los tipos de documentos (FE, ND, NC, TE, FEC, FEE, REP).
        /// </summary>
        public int NumCuenta { get; set; }

        /// <summary>
        /// Colección de documentos electrónicos a cargar en el sistema.
        /// </summary>
        public Request.Documento[] Documentos { get; set; }
    }
}
