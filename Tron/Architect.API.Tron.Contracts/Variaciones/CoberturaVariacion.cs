using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public class CoberturaVariacion: Comun.Cobertura
    {
        [DataMember(), JsonProperty()] public string mcaObligatorio { get; set; }
        [DataMember(), JsonProperty()] public string mcaSeleccion { get; set; }
    }
}
