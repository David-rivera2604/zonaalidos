using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.ManualClaims
{
    [Serializable(), DataContract()]
    public partial class ClaimDocumentRequest
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
        [DataMember(), JsonProperty()] public int DocumentType { get; set; }
        [DataMember(), JsonProperty()] public string Description { get; set; }
        [DataMember(), JsonProperty()] public DateTime RequestDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime DueDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime ReceivedDate { get; set; }
        [DataMember(), JsonProperty()] public int Status { get; set; }
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

