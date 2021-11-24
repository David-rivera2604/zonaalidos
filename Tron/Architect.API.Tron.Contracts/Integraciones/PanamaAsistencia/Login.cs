using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia
{
    [Serializable(), DataContract()]
    public partial class Login
    {
        [DataMember(), JsonProperty()] public string user { get; set; }
        [DataMember(), JsonProperty()] public string pass { get; set; }
        [DataMember(), JsonProperty()] public int country { get; set; }
        [DataMember(), JsonProperty()] public string remote_addr { get; set; }

    }
}
