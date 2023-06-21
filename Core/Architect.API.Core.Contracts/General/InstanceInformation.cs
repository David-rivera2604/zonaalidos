using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    [Serializable(), DataContract()]
    public class InstanceInformation
    {
        [DataMember(), JsonProperty()] public int CaseId { get; set; }
        [DataMember(), JsonProperty()] public int InstanceId { get; set; }
        [DataMember(), JsonProperty()] public int ActivityId { get; set; }

        /// <summary>
        /// 1 Inicio, 2 En progreso, 3 Finalizado
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }

        [DataMember(), JsonProperty()] public int Progress { get; set; }


        /// <summary>
        /// Etiqueta asociada al paso del proceso
        /// </summary>
        [DataMember(), JsonProperty()] public string Label { get; set; }

        /// <summary>
        /// Tareas vinculadas a un paso o estado de un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<StepInformation> Steps { get; set; }

        /// <summary>
        /// Tareas vinculadas a un paso o estado de un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public List<TaskInformation> Tasks { get; set; }
    }

    public class StepInformation
    {
        [DataMember(), JsonProperty()] public int ActivityId { get; set; }

        [DataMember(), JsonProperty()] public int StepId { get; set; }

        /// <summary>
        /// Nombre del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Descripción del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        [DataMember(), JsonProperty()] public DateTime? StartDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime? DueDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime? FinishDate { get; set; }

        /// <summary>
        /// Observaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string Comments { get; set; }
        /// <summary>
        /// 1 Inicio, 2 En progreso, 3 Finalizado
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Etiqueta asociada al paso del proceso
        /// </summary>
        [DataMember(), JsonProperty()] public string Label { get; set; }


        [DataMember(), JsonProperty()] public int SubStatus { get; set; }

        [DataMember(), JsonProperty()] public string SubLabel { get; set; }

        /// <summary>
        /// Identificación del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserId { get; set; }

        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string UserName { get; set; }

        [DataMember(), JsonProperty()] public string Wait { get; set; }
        /// <summary>
        /// Tipo de progreso.
        /// </summary>
        [DataMember(), JsonProperty()] public int ProgressMode { get; set; }
        [DataMember(), JsonProperty()] public string References { get; set; }
    }
    public class TaskInformation
    {

        [DataMember(), JsonProperty()] public int ActivityId { get; set; }

        [DataMember(), JsonProperty()] public int TaskId { get; set; }

        /// <summary>
        /// Nombre del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Descripción del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }

        [DataMember(), JsonProperty()] public DateTime? FinishDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime? DueDate { get; set; }
        /// <summary>
        /// 1=Manual,2=URL,3=HTML,4=Script, 5=Aprobación, 6=Encuesta, 7 =automatico
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Especificación de la acción según el tipo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Action { get; set; }

        [DataMember(), JsonProperty()] public int NotifyToContact { get; set; }

    }

}
