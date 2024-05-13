using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.SICOP.WcfService.Contracts
{
    [DataContract]
    public class ExecGurtRequest
    {
        [DataMember] public string Guarantee_Number { get; set; }

        [DataMember] public string Guarantee_sequencenumber { get; set; }

        [DataMember] public decimal Amount { get; set; }
        [DataMember] public string Contents { get; set; }
        [DataMember] public string Moneda { get; set; }
        [DataMember] public string Metodo { get; set; }

        [DataMember] public string cuenta_Cliente { get; set; }
        [DataMember] public string codigo_proceso { get; set; }

    }

}
