using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Tareas vinculadas a un paso o estado de un proceso.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessSpecTask
    {
        /// <summary>
        /// Identificación única de la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación única del paso.
        /// </summary>
        [DataMember(), JsonProperty()] public int StepId { get; set; }
        /// <summary>
        /// Descripción para identificación única del paso.
        /// </summary>
        [DataMember(), JsonProperty()] public string StepIdDesc { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre de la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Descripción de la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Define el tiempo maximo en minutos para que el paso o estado se de por procesado.
        /// </summary>
        [DataMember(), JsonProperty()] public int SLATimeOut { get; set; }
        [DataMember(), JsonProperty()] public bool IsRequired { get; set; }
        [DataMember(), JsonProperty()] public bool IsSelected { get; set; }
        /// <summary>
        /// Orden en que se procesan la tarea.
        /// </summary>
        [DataMember(), JsonProperty()] public int TaskOrder { get; set; }
        /// <summary>
        /// 1=Manual,2=URL,3=HTML,4=Script, 5=Aprobación, 6=Encuesta, 7 =automatico, 10=Goto
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Descripción para 1=manual,2=url,3=html,4=script, 5=aprobación, 6=encuesta, 7 =automatico, 10=goto
        /// </summary>
        [DataMember(), JsonProperty()] public string TypeDesc { get; set; }
        /// <summary>
        /// Especificación de la acción según el tipo.
        /// </summary>
        [DataMember(), JsonProperty()] public string Action { get; set; }
        [DataMember(), JsonProperty()] public int SubStatus { get; set; }
        [DataMember(), JsonProperty()] public string SubLabel { get; set; }
        /// <summary>
        /// Establece un script que es ejecutado al activarse el paso (Script).
        /// </summary>
        [DataMember(), JsonProperty()] public string PreScript { get; set; }
        /// <summary>
        /// Establece un script que es ejecutado al darse por procesado el paso (Script).
        /// </summary>
        [DataMember(), JsonProperty()] public string PostScript { get; set; }
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

