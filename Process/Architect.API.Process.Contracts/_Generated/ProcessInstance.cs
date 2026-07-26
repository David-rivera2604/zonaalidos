using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Procesos ejecutados o en ejecución.
    /// </summary>
    [Serializable(), DataContract(), DebuggerDisplay("ActivityId:{ActivityId}, InstanceId:{InstanceId}, CompanyId:{CompanyId}")] 
    public partial class ProcessInstance
    {
        [DataMember(), JsonProperty()] public int ActivityId { get; set; }
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int InstanceId { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
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
        [DataMember(), JsonProperty()] public int CaseId { get; set; }
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int FlowId { get; set; }
        /// <summary>
        /// Identificación única del paso.
        /// </summary>
        [DataMember(), JsonProperty()] public int StepId { get; set; }
        /// <summary>
        /// Identificación única de la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public int TaskId { get; set; }
        [DataMember(), JsonProperty()] public DateTime Created { get; set; }
        [DataMember(), JsonProperty()] public DateTime StartDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime EarlyDueDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime DueDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime FinishDate { get; set; }
        [DataMember(), JsonProperty()] public int PreviousActivityId { get; set; }
        [DataMember(), JsonProperty()] public int UserId { get; set; }
        /// <summary>
        /// Observaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string Comments { get; set; }
        /// <summary>
        /// Last Over Due Notify
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime LastOverDueNotify { get; set; }

        /// <summary>
        /// Usuario asignado a la etapa.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserAssigned  { get; set; }
        /// <summary>
        /// Fecha en que se asignó el usuario a la etapa.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UserAssignedDate { get; set; }

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

