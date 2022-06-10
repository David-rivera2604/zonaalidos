using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

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
