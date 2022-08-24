using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    public class RespuestaDetalle
    {
        public string num_poliza { get; set; }
        public string num_certificado_phx { get; set; }
        public Resumen resumen { get; set; }
        public List<Plandepago> plandepago { get; set; }
    }
}
