using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.General
{
    public partial class ProcessSpecTask
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int FlowId { get; set; }
        /// <summary>
        /// Descripción para identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string FlowIdDesc { get; set; }
    }
}
