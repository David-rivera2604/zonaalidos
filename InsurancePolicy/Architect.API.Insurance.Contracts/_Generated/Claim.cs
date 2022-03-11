using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualClaims
{
    [Serializable(), DataContract()]
    public partial class Claim
    {
        /// <summary>
        /// Identificación única del siniestro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        [DataMember(), JsonProperty()] public string ClaimId { get; set; }
        [DataMember(), JsonProperty()] public DateTime StatementDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime OccurrenceDate { get; set; }
        [DataMember(), JsonProperty()] public double ReserveAmount { get; set; }
        [DataMember(), JsonProperty()] public double PaidAmount { get; set; }
        [DataMember(), JsonProperty()] public DateTime PaidDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime DeclinedDate { get; set; }
        [DataMember(), JsonProperty()] public string IncidentDetail { get; set; }
        /// <summary>
        /// Identificación internal de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int PolicyInternalId { get; set; }
        /// <summary>
        /// Identificación internal del certificado.
        /// </summary>
        [DataMember(), JsonProperty()] public int CertificatInternalId { get; set; }
        /// <summary>
        /// Identificación internal de la cobertura afectada.
        /// </summary>
        [DataMember(), JsonProperty()] public int CoverageInternalId { get; set; }
        /// <summary>
        /// él asociado es el asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public bool AssociateIsTheInsured { get; set; }
        [DataMember(), JsonProperty()] public DateTime DisabilityDate { get; set; }
        [DataMember(), JsonProperty()] public bool Disputability { get; set; }
        [DataMember(), JsonProperty()] public int Status { get; set; }
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

