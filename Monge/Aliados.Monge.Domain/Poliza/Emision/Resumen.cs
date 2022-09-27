using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Resumen de información asociada al póliza.
    /// </summary>
    public class Resumen
    {
        /// <summary>
        /// Prima neta.
        /// </summary>
        public float primaneta { get; set; }
        /// <summary>
        /// IVA.
        /// </summary>
        public float iVA { get; set; }
        /// <summary>
        /// Recargo por fraccionamiento.
        /// </summary>
        public float recargoporfraccionamiento { get; set; }
        /// <summary>
        /// Importe total.
        /// </summary>
        public float importetotal { get; set; }
        /// <summary>
        /// Cuota.
        /// </summary>
        public int cuotas { get; set; }
    }
}
