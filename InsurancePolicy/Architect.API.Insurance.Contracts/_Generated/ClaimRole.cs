using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualClaims
{
    /// <summary>
    /// Beneficiarios, Asociado.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ClaimRole
    {
        /// <summary>
        /// Identificación única del siniestro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        [DataMember(), JsonProperty()] public int ClaimInternalId { get; set; }
        [DataMember(), JsonProperty()] public int ThirdPartyId { get; set; }
        [DataMember(), JsonProperty()] public int ThirdPartyRole { get; set; }
        /// <summary>
        /// Parentesco de los beneficiarios.
        /// </summary>
        [DataMember(), JsonProperty()] public int Relationship { get; set; }
        /// <summary>
        /// Descripción para parentesco de los beneficiarios.
        /// </summary>
        [DataMember(), JsonProperty()] public string RelationshipDesc { get; set; }
        /// <summary>
        /// Porcentaje de participación del beneficiario.
        /// </summary>
        [DataMember(), JsonProperty()] public int ParticipationRate { get; set; }
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

