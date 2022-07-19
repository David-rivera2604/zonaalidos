using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessSpecFlow
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Descripción del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Alieas del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Alias { get; set; }
        [DataMember(), JsonProperty()] public int MailServer { get; set; }
        [DataMember(), JsonProperty()] public string MailServerDesc { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceCaption1 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceLookupList1 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceCaption2 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceLookupList2 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceCaption3 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceLookupList3 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceCaption4 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceLookupList4 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceCaption5 { get; set; }
        [DataMember(), JsonProperty()] public string ReferenceLookupList5 { get; set; }
        [DataMember(), JsonProperty()] public int SLA { get; set; }
        /// <summary>
        /// Estado (Activo/Inactivo)
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Descripción para estado (activo/inactivo)
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

