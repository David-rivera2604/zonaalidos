using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Prespuestos disponibles.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class PolicyProposal
    {
        /// <summary>
        /// Identificación única de la solcitud.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        [DataMember(), JsonProperty()] public int AgentCode { get; set; }
        [DataMember(), JsonProperty()] public string ProposalId { get; set; }
        [DataMember(), JsonProperty()] public string InsuredId { get; set; }
        [DataMember(), JsonProperty()] public string InsuredName { get; set; }
        [DataMember(), JsonProperty()] public string Summary { get; set; }
        /// <summary>
        /// Fecha de alta.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        /// <summary>
        /// Datos personalizables. (CLOB)
        /// </summary>
        [DataMember(), JsonProperty()] public string ProposalData { get; set; }
        [DataMember(), JsonProperty()] public string SigningType { get; set; }
        /// <summary>
        /// Dirección de correo electrónico (principal)
        /// </summary>
        [DataMember(), JsonProperty()] public string PrimaryEmailAddress { get; set; }
        [DataMember(), JsonProperty()] public string SigningRequestId { get; set; }
        [DataMember(), JsonProperty()] public string PolicyId { get; set; }
        /// <summary>
        /// Estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Descripción para estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string StatusDesc { get; set; }
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

