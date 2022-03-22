using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Cuestionarios vinculados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskQuestionDiagnosisView
    {
        [DataMember(), JsonProperty()] public int Id { get; set; }
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
    /// <summary>
    /// Cuestionarios vinculados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskQuestionView : RiskQuestionDiagnosisView
    {
        /// <summary>
        /// Indicador de respuesta, 1 si, 2 no.
        /// </summary>
        [DataMember(), JsonProperty()] public int Confirmation { get; set; }

        [DataMember(), JsonProperty()] public RiskQuestionDiagnosisDetailView Detail { get; set; }
    }

    [Serializable(), DataContract()]
    public partial class RiskQuestionDiagnosisDetailView
    {
        [DataMember(), JsonProperty()] public Boolean Detail1 { get; set; }
        [DataMember(), JsonProperty()] public Boolean Detail2 { get; set; }
        [DataMember(), JsonProperty()] public Boolean Detail3 { get; set; }
        [DataMember(), JsonProperty()] public Boolean Detail4 { get; set; }
        [DataMember(), JsonProperty()] public Boolean Detail5 { get; set; }
        [DataMember(), JsonProperty()] public Boolean Detail6 { get; set; }

    }

}

