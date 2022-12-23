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
        public double primaneta { get; set; }
        /// <summary>
        /// IVA.
        /// </summary>
        public double iVA { get; set; }
        /// <summary>
        /// Recargo por fraccionamiento.
        /// </summary>
        public double recargoporfraccionamiento { get; set; }
        /// <summary>
        /// Importe total.
        /// </summary>
        public double importetotal { get; set; }
    }
}
