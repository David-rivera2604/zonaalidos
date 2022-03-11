using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualPolicies
{
    /// <summary>
    /// Coberturas.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class PolicyCoverage
    {
        /// <summary>
        /// Identificación única del rol.
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
        /// <summary>
        /// Suma asegurada.
        /// </summary>
        [DataMember(), JsonProperty()] public double InsuredAmount { get; set; }
        /// <summary>
        /// Código de cobertura
        /// </summary>
        [DataMember(), JsonProperty()] public string Code { get; set; }
        /// <summary>
        /// Descripción de la cobertura.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 Description { get; set; }
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

