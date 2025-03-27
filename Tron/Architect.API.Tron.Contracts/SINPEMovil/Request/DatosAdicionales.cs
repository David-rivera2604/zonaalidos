using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.SINPEMovil.Request
{

    /// <summary>
    /// Lista de datos adicionales (llave, valor) que se requieran enviar.
    /// </summary>
    public class DatosAdicionales
    {
        /// <summary>
        /// Nombre de la llave adicional.
        /// </summary>
        public string Llave { get; set; }

        /// <summary>
        /// Valor asociado a la llave.
        /// </summary>
        public string Valor { get; set; }
    }

}
