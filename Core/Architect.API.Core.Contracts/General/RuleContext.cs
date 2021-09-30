using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Contexto de ejecución para las reglas dinamicas.
    /// </summary>
    [Serializable(), DataContract()]
    public class RuleContext
    {
        /// <summary>
        /// Datos usados en el contexto.
        /// </summary>
        [DataMember(), JsonProperty()] public object Data { get; set; }
    }
}
