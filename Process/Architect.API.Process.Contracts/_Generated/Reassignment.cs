using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Reasignaciones de actividades del proceso.
    /// </summary>
    [Serializable(), DataContract(), DebuggerDisplay("Id:{Id}, ActivityId:{ActivityId}, UserAssigned:{UserAssigned}, State:{State}")]
    public partial class Reassignment
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }

        /// <summary>
        /// Identificación de la actividad reasignada.
        /// </summary>
        [DataMember(), JsonProperty()] public int ActivityId { get; set; }

        /// <summary>
        /// Usuario al que se reasignó la actividad.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserAssigned { get; set; }

        /// <summary>
        /// Fecha en que se realizó la reasignación.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UserAssignedDate { get; set; }

        /// <summary>
        /// Estado de la reasignación. Ver LookupMaster Id:161 (ProcessState).
        /// </summary>
        [DataMember(), JsonProperty()] public ReassignmentState State { get; set; }

        /// <summary>
        /// Descripción del estado. Ver LookupMaster Id:161 (ProcessState).
        /// </summary>
        [DataMember(), JsonProperty()] public string StateDesc { get; set; }
    }
}
