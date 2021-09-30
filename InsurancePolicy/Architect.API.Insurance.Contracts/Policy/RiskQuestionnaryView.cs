using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Resouestas de un cuestionario.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskQuestionaryView
    {
        /// <summary>
        /// Información de la pregunta 1.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question1 { get; set; }
        /// <summary>
        /// Información de la pregunta 2.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question2 { get; set; }
        /// <summary>
        /// Información de la pregunta 3.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question3 { get; set; }
        /// <summary>
        /// Información de la pregunta 4.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question4 { get; set; }
        /// <summary>
        /// Información de la pregunta 5.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question5 { get; set; }
        /// <summary>
        /// Información de la pregunta 6.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question6 { get; set; }
        /// <summary>
        /// Información de la pregunta 7.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question7 { get; set; }
        /// <summary>
        /// Información de la pregunta 8.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question8 { get; set; }
        /// <summary>
        /// Información de la pregunta 9.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question9 { get; set; }
        /// <summary>
        /// Información de la pregunta 10.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question10 { get; set; }
    }
}

