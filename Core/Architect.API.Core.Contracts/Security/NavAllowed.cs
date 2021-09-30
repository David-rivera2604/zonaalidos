using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Navegación disponible para el rol.
    /// </summary>
    [Serializable(), DataContract()]
    public class NavAllowed
    {
        /// <summary>
        /// Código padre. Este código permite definir jerarquia entre registros de esta tabla.
        /// </summary>
        [DataMember(), JsonProperty()] public string ParentCode { get; set; }
        /// <summary>
        /// Código que identifica el registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Code { get; set; }
        /// <summary>
        /// Tipo de registro, 1 menú, 2 página.
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Título del registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Title { get; set; }
        /// <summary>
        /// Título usando en el ménu principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string MenuTitle { get; set; }
        /// <summary>
        /// Descripción asociada al registro de navegación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        /// <summary>
        /// Ruta física de la página a ser ejecutada.
        /// </summary>
        [DataMember(), JsonProperty()] public string URLPath { get; set; }
        /// <summary>
        /// Ruta física para la imagen pequeña usada para representar el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string SmallImage { get; set; }
    }
}