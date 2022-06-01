using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro.Parameters
{
    /// <summary>
    /// Parámetro para la generación de un aviso cobro.
    /// </summary>
    public class AvisoCobroGenerarParametros : AvisoCobroBaseParametros
    {
        /// <summary>
        /// Lista de números de recibos usados para crear el aviso de cobro, la misma debe estar separada por punto y coma
        /// </summary>
        public string Lista_Recibos { get; set; }

    }
}
