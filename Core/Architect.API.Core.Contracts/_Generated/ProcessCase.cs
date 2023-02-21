using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// ProcessCase
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessCase
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }

        /// <summary>
        /// ID del usuario enviando el caso.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserSend { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        [DataMember(), JsonProperty()] public string Title { get; set; }
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Nivel de prioridad
        /// </summary>
        [DataMember(), JsonProperty()] public int Priority { get; set; }
        /// <summary>
        /// Descripción para nivel de prioridad
        /// </summary>
        [DataMember(), JsonProperty()] public string PriorityDesc { get; set; }
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int InstanceId { get; set; }
        [DataMember(), JsonProperty()] public int CurrentStepId { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference1 { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference2 { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference3 { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference4 { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference5 { get; set; }
        /// <summary>
        /// Nombre completo del contacto externo.
        /// </summary>
        [DataMember(), JsonProperty()] public string ContactMainName { get; set; }
        /// <summary>
        /// Correo electrónico del contacto externo.
        /// </summary>
        [DataMember(), JsonProperty()] public string ContactMainEmail { get; set; }
        /// <summary>
        /// 1 Inicio, 2 En progreso, 3 Finalizado
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Descripción para 1 inicio, 2 en progreso, 3 finalizado
        /// </summary>
        [DataMember(), JsonProperty()] public string StatusDesc { get; set; }
        /// <summary>
        /// Etiqueta asociada al paso del proceso
        /// </summary>
        [DataMember(), JsonProperty()] public string Label { get; set; }
        [DataMember(), JsonProperty()] public int SubStatus { get; set; }
        [DataMember(), JsonProperty()] public string SubLabel { get; set; }
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int FlowId { get; set; }
        /// <summary>
        /// Descripción para identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string FlowIdDesc { get; set; }
        [DataMember(), JsonProperty()] public int UserId { get; set; }
        [DataMember(), JsonProperty()] public string UserIdDesc { get; set; }
        [DataMember(), JsonProperty()] public int SLA { get; set; }
        [DataMember(), JsonProperty()] public string SLADesc { get; set; }
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

