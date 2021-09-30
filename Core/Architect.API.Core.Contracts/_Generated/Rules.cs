using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Reglas a ser ejecutar despues de un evento asociado a un entidad de la aplicaciión.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Rules
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
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
        /// Acción que genera la traza.
        /// </summary>
        [DataMember(), JsonProperty()] public string Action { get; set; }
        /// <summary>
        /// Identificación secuencial asociada al identificador único del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Sequence { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Código a ser ejecutado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Statement { get; set; }
        /// <summary>
        /// Estado general del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int RecordStatus { get; set; }
        /// <summary>
        /// Descripción para estado general del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string RecordStatusDesc { get; set; }
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

