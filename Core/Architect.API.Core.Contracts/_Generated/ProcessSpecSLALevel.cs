using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// ProcessSpecSLALevel
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessSpecSLALevel
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        [DataMember(), JsonProperty()] public int SLAId { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Define el tiempo maximo en horas para que el paso o estado se de por procesado.
        /// </summary>
        [DataMember(), JsonProperty()] public int SLATimeOut { get; set; }
        [DataMember(), JsonProperty()] public int SLATimeMode { get; set; }
        [DataMember(), JsonProperty()] public int MailForSLAExpiration { get; set; }
        [DataMember(), JsonProperty()] public string MailForSLAExpirationDesc { get; set; }
        [DataMember(), JsonProperty()] public string MailForSLAExpirationCustom { get; set; }
        [DataMember(), JsonProperty()] public int MailForSLAExpirationTmpl { get; set; }
        [DataMember(), JsonProperty()] public string MailForSLAExpirationTmplDesc { get; set; }
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

