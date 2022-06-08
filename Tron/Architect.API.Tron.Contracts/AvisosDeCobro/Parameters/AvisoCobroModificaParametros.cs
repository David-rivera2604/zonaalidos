using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro.Parameters
{
    /// <summary>
    /// Parámetro para la modificación de un aviso cobro.
    /// </summary>
    public class AvisoCobroModificaParametros 
    {
        /// <summary>
        /// Numero de aviso
        /// </summary>
        public Int64 Num_Aviso { get; set; }

        /// <summary>
        /// Lista de números de recibos a ser excluidos del aviso de cobro
        /// </summary>
        public string Lista_Recibos { get; set; }

    }
}
