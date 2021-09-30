using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Respuesta de uso general.
    /// </summary>
    [Serializable(), DataContract()]
    public class GenericResponse
    {
        /// <summary>
        /// Indica que la acción ejecutada se realizo de forma exitosa.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Successful { get; set; }
        /// <summary>
        /// Detalle a ser informado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reason { get; set; }
    }
}
