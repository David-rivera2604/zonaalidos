using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Póliza
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Policy
    {
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        [DataMember(), JsonProperty()] public int Sector { get; set; }
        [DataMember(), JsonProperty()] public int LineOfBusiness { get; set; }
        [DataMember(), JsonProperty()] public string PolicyID { get; set; }
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime EffectiveDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime EndingDate { get; set; }
        /// <summary>
        /// Inicio de vigencia en la póliza del proveedor anterior.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EffectiveOtherPolicyDate { get; set; }
        [DataMember(), JsonProperty()] public int ProducerId { get; set; }
        /// <summary>
        /// Datos personalizables.
        /// </summary>
        [DataMember(), JsonProperty()] public string CustomData { get; set; }
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

