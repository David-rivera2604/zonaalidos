using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Información para procesar un cambio de estado de la póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskStatus
    {
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Nuevo estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int NewStatus { get; set; }
        /// <summary>
        /// Descripción del nuevo estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string NewStatusDesc { get; set; }
        /// <summary>
        /// Importe de recargo.
        /// </summary>
        [DataMember(), JsonProperty()] public double Surcharge { get; set; }
        /// <summary>
        /// Observaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string Comments { get; set; }
        /// <summary>
        /// Fecha de anulación.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime CancellationDate { get; set; }
        /// <summary>
        /// Razón vinculada al estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int ReasonForStatus { get; set; }
    }
}