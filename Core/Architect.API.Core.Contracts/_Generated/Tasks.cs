using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Lista de tareas o chequeo.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Tasks
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación secuencial asociada al identificador único del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Sequence { get; set; }
        /// <summary>
        /// Título de la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public string Title { get; set; }
        /// <summary>
        /// Descripción detallada de la tarea
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Fecha de vencimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime DueDate { get; set; }
        /// <summary>
        /// Usuario que debe atender la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public int AssignedTo { get; set; }
        /// <summary>
        /// Tipo de tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// fecha de completada.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime CompletedDate { get; set; }
        /// <summary>
        /// Estado de la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Tipo de entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int EntityType { get; set; }
        /// <summary>
        /// Descripción para tipo de entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string EntityTypeDesc { get; set; }
        /// <summary>
        /// Identificador de la entidad u objeto que genera el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 EntityId { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
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

