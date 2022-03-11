using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    [Serializable(), DataContract()]
    public partial class ProcessSpecLink
    {
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int FlowId { get; set; }
        /// <summary>
        /// Descripción para identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string FlowIdDesc { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Descripción del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        [DataMember(), JsonProperty()] public string Icon { get; set; }
        [DataMember(), JsonProperty()] public int Type { get; set; }
        [DataMember(), JsonProperty()] public string TypeDesc { get; set; }
        /// <summary>
        /// Orden en que se procesan la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public int LinkOrder { get; set; }
        [DataMember(), JsonProperty()] public string URL { get; set; }
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

