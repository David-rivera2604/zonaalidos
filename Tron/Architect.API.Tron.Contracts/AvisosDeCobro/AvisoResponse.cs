using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro
{
    /// <summary>
    /// Avisos
    /// </summary>
    public class AvisoResponse : AvisosBaseResponse
    {
        /// <summary>
        /// Total de importe de aviso
        /// </summary>
        public double Total_Importe_Aviso { get; set; }

        /// <summary>
        /// Cantidad de recibos no procesados
        /// </summary>
        public int Cantidad_Recibos_No_Procesados { get; set; }
    }
}
