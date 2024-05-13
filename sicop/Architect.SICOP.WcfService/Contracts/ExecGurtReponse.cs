using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.SICOP.WcfService.Contracts
{
    [DataContract]
    public class ExecGurtReponse
    {
        [DataMember] public string Confirmation { get; set; }

        [DataMember] public string Msg_err { get; set; }

    }
}
