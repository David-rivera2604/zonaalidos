using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.SICOP.Integrations.Contracts
{
    public class ExecGurtRequest
    {
        public string Guarantee_Number { get; set; }

        public string Guarantee_sequencenumber { get; set; }

        public decimal Amount { get; set; }
        public string Contents { get; set; }
        public string Moneda { get; set; }
        public string Metodo { get; set; }

        public string cuenta_Cliente { get; set; }
        public string codigo_proceso { get; set; }

    }

}
