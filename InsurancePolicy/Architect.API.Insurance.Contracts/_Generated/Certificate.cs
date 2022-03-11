using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    [Serializable(), DataContract()]
    public partial class Certificate
    {
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Identificación internal de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int PolicyInternalId { get; set; }
        [DataMember(), JsonProperty()] public string CertificateId { get; set; }
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime EffectiveDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime EndingDate { get; set; }
        /// <summary>
        /// Suma asegurada.
        /// </summary>
        [DataMember(), JsonProperty()] public double InsuredAmount { get; set; }
        /// <summary>
        /// Gastos funerarios.
        /// </summary>
        [DataMember(), JsonProperty()] public double FuneralExpenses { get; set; }
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

