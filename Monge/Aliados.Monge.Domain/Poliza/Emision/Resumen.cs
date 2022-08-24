using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Domain.Poliza.Emision
{
    public class Resumen
    {
        public float primaneta { get; set; }
        public float iVA { get; set; }
        public float recargoporfraccionamiento { get; set; }
        public float importetotal { get; set; }
        public int cuotas { get; set; }
    }
}
