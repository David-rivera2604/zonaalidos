using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    [Serializable(), DataContract()]
    public partial class PaymentSettings
    {
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre Usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserId { get; set; }
        /// <summary>
        /// Descripción para nombre usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string UserIdDesc { get; set; }
        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int Currency { get; set; }
        /// <summary>
        /// Descripción para moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public string CurrencyDesc { get; set; }
        [DataMember(), JsonProperty()] public string ClientId { get; set; }
        [DataMember(), JsonProperty()] public string SecretKey { get; set; }
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

