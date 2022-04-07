using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Contracts.GastosMedicos
{
    /// <summary>
    /// Información de beneficios  de un asegurado en gastos medicos.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Beneficios
    {
        /// <summary>
        /// Primer nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string benef { get; set; }
    }
}
