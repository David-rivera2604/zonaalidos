using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro
{
    /// <summary>
    /// Clase base de aviso
    /// </summary>
    public class AvisosBaseResponse
    {
        /// <summary>
        /// Numero de aviso
        /// </summary>
        public Int64 Num_Aviso { get; set; }

        /// <summary>
        /// Cantidad de recibos
        /// </summary>
        public int Cantidad_Recibos { get; set; }
    }
}
