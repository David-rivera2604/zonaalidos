using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.AvisosDeCobro
{
    /// <summary>
    /// Recibo aviso
    /// </summary>
    public class ReciboAvisoRespose : ReciboRespose
    {
        /// <summary>
        /// Numero de aviso
        /// </summary>
        public string Num_Aviso { get; set; }
    }
}
