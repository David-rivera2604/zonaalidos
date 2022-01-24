using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Presupuesto.API
{
    /// <summary>
    ///  Conceptos de desglose económico del presupuesto (p2100170)
    /// </summary>
    public class DesgloseEconomico
    {
       
        /// <summary>
        ///  Concepto de desglose económico
        /// </summary>
        public int cod_desglose { get; set; }

        /// <summary>
        ///  Concepto económico de recibo
        /// </summary>
        public int cod_eco { get; set; }

        /// <summary>
        ///  Importe anual
        /// </summary>
        public double imp_anual { get; set; }

    }
}
