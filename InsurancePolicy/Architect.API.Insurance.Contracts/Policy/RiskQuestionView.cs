using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Cuestionarios vinculados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskQuestionView
    {
        /// <summary>
        /// Indicador de respuesta, 1 si, 2 no.
        /// </summary>
        [DataMember(), JsonProperty()] public int Confirmation { get; set; }
        /// <summary>
        /// Diagnóstico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Diagnosis { get; set; }
        /// <summary>
        /// Tratamiento.
        /// </summary>
        [DataMember(), JsonProperty()] public string Treatment { get; set; }
        /// <summary>
        /// Médico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Doctor { get; set; }
        /// <summary>
        /// Fecha.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime When { get; set; }
    }
}

