using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Cuestionarios vinculados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskQuestionnaires
    {
        /// <summary>
        /// Identificación única de la pregunta del questionario.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int PolicyId { get; set; }
        /// <summary>
        /// Tipo de pregunta, 1 generica.
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Identificación de la pregunta.
        /// </summary>
        [DataMember(), JsonProperty()] public int QuestionId { get; set; }
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
        /// <summary>
        /// Usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int UpdateUserCode { get; set; }
        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string UpdateUserName { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }
    }
}

