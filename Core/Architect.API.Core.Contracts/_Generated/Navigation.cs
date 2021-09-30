using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Navegación disponible.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Navigation
    {
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int NavigationId { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Código padre. Este código permite definir jerarquia entre registros de esta tabla.
        /// </summary>
        [DataMember(), JsonProperty()] public string ParentCode { get; set; }
        /// <summary>
        /// Descripción para código padre. este código permite definir jerarquia entre registros de esta tabla.
        /// </summary>
        [DataMember(), JsonProperty()] public string ParentCodeDesc { get; set; }
        /// <summary>
        /// Código que identifica el registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Code { get; set; }
        /// <summary>
        /// Tipo de registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Descripción para tipo de registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string TypeDesc { get; set; }
        /// <summary>
        /// Título del registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Title { get; set; }
        /// <summary>
        /// Descripción asociada al registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Título usando en el ménu principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string MenuTitle { get; set; }
        /// <summary>
        /// Ruta física de la página a ser ejecutada.
        /// </summary>
        [DataMember(), JsonProperty()] public string URLPath { get; set; }
        /// <summary>
        /// URL Help
        /// </summary>
        [DataMember(), JsonProperty()] public string URLHelp { get; set; }
        /// <summary>
        /// Ruta física para la imagen pequeña usada para representar el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string SmallImage { get; set; }
        /// <summary>
        /// Ruta física para la imagen grande usada para representar el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string BigImage { get; set; }
        /// <summary>
        /// Orden de aparición.
        /// </summary>
        [DataMember(), JsonProperty()] public int Sequence { get; set; }
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

