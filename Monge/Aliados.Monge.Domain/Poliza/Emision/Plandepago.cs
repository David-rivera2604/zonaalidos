using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    public class Plandepago
    {
        public int cuota { get; set; }
        public DateTime fechadesde { get; set; }
        public DateTime fechahasta { get; set; }
        public float primaneta { get; set; }
        public float iVA { get; set; }
        public float recargoporfraccionamiento { get; set; }
        public float importetotal { get; set; }
    }
}
