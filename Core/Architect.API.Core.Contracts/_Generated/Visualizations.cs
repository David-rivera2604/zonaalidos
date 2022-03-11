using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Visualizaciones de datos en forma de widget, reportes, dashboard.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Visualizations
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Clave que identificac la lista.
        /// </summary>
        [DataMember(), JsonProperty()] public string Key { get; set; }
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
        /// Identificación secuencial asociada al identificador único del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Sequence { get; set; }
        /// <summary>
        /// Tipo de visualizacion, 1 consultas.
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Descripción para tipo de visualizacion, 1 consultas.
        /// </summary>
        [DataMember(), JsonProperty()] public string TypeDesc { get; set; }
        /// <summary>
        /// Caption.
        /// </summary>
        [DataMember(), JsonProperty()] public string Caption { get; set; }
        /// <summary>
        /// Description.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Indica el tipo del comando 1 select, 2 procedure
        /// </summary>
        [DataMember(), JsonProperty()] public int StatementType { get; set; }
        /// <summary>
        /// Descripción para indica el tipo del comando 1 select, 2 procedure
        /// </summary>
        [DataMember(), JsonProperty()] public string StatementTypeDesc { get; set; }
        /// <summary>
        /// Statement.
        /// </summary>
        [DataMember(), JsonProperty()] public string Statement { get; set; }
        /// <summary>
        /// Statement Extend
        /// </summary>
        [DataMember(), JsonProperty()] public string StatementExtend { get; set; }
        /// <summary>
        /// Especificación. (CLOB)
        /// </summary>
        [DataMember(), JsonProperty()] public string Specification { get; set; }
        /// <summary>
        /// Dialog.
        /// </summary>
        [DataMember(), JsonProperty()] public string Dialog { get; set; }
        /// <summary>
        /// Icon.
        /// </summary>
        [DataMember(), JsonProperty()] public string Icon { get; set; }
        /// <summary>
        /// Icon Class.
        /// </summary>
        [DataMember(), JsonProperty()] public string IconClass { get; set; }
        /// <summary>
        /// Value Format.
        /// </summary>
        [DataMember(), JsonProperty()] public string ValueFormat { get; set; }
        /// <summary>
        /// Nombre de la cadena de conexión.
        /// </summary>
        [DataMember(), JsonProperty()] public string ConnectionName { get; set; }
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

