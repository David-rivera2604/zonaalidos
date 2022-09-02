using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    /// <summary>
    /// Plan de pago asociado a la póliza.
    /// </summary>
    public class Plandepago
    {
        /// <summary>
        /// Cuota.
        /// </summary>
        public int cuota { get; set; }
        /// <summary>
        /// Fecha desde.
        /// </summary>
        public DateTime fechadesde { get; set; }
        /// <summary>
        /// Fecha hasta.
        /// </summary>
        public DateTime fechahasta { get; set; }
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
    }
}
