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
        /// Información de la pregunta 1 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question1 { get; set; }
        /// <summary>
        /// Información de la pregunta 2 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question2 { get; set; }
        /// <summary>
        /// Información de la pregunta 3 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question3 { get; set; }
        /// <summary>
        /// Información de la pregunta 4 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question4 { get; set; }
        /// <summary>
        /// Información de la pregunta 5 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question5 { get; set; }
        /// <summary>
        /// Información de la pregunta 6 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question6 { get; set; }
        /// <summary>
        /// Información de la pregunta 7 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question7 { get; set; }
        /// <summary>
        /// Información de la pregunta 8 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question8 { get; set; }
        /// <summary>
        /// Información de la pregunta 9 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question9 { get; set; }
        /// <summary>
        /// Información de la pregunta 10 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question10 { get; set; }
        /// <summary>
        /// Información de la pregunta 11 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question11 { get; set; }
        /// <summary>
        /// Información de la pregunta 12 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question12 { get; set; }
        /// <summary>
        /// Información de la pregunta 13 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question13 { get; set; }
        /// <summary>
        /// Información de la pregunta 14 del cuestionario de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question14 { get; set; }


        /// <summary>
        /// Información de la pregunta 1 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question51 { get; set; }
        /// <summary>
        /// Información de la pregunta 2 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question52 { get; set; }
        /// <summary>
        /// Información de la pregunta 3 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question53 { get; set; }
        /// <summary>
        /// Información de la pregunta 4 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question54 { get; set; }
        /// <summary>
        /// Información de la pregunta 5 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question55 { get; set; }
        /// <summary>
        /// Información de la pregunta 6 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question56 { get; set; }
        /// <summary>
        /// Información de la pregunta 7 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question57 { get; set; }
        /// <summary>
        /// Información de la pregunta 8 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question58 { get; set; }
        /// <summary>
        /// Información de la pregunta 9 del cuestionario de covid.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionView Question59 { get; set; }
    }
}

