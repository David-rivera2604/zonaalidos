using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    public class RespuestaDetalle
    {
        /// <summary>
        /// Número de póliza.
        /// </summary>
        public string num_poliza { get; set; }
        /// <summary>
        /// Número de certificado phoenix.
        /// </summary>
        public string num_certificado_phx { get; set; }
        /// <summary>
        /// Resumen de información asociada al póliza.
        /// </summary>
        public Resumen resumen { get; set; }
        /// <summary>
        /// Plan de pago asociado a la póliza.
        /// </summary>
        public List<Plandepago> plandepago { get; set; }
    }
}
