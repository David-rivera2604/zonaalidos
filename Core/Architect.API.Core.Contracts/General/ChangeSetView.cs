using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Auditoria de cambios por entidad del sistema.
    /// </summary>
    [Serializable(), DataContract()]
    public class ChangeSetView
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Acción que genera la traza.
        /// </summary>
        [DataMember(), JsonProperty()] public string Action { get; set; }
        /// <summary>
        /// Detalle o razón de la traza.
        /// </summary>
        [DataMember(), JsonProperty()] public string Summary { get; set; }
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

