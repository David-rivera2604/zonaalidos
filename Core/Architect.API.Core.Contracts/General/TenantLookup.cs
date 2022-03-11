using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Configuración de la lista de valores.
    /// </summary>
    [Serializable()]
    public class TenantLookup
    {
        /// <summary>
        /// Indica si la lista se maneja de forma general o por propietario.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Tenant { get; set; }
        /// <summary>
        /// Indica el tipo de la lista de valores.
        /// </summary>
        [DataMember(), JsonProperty()] public int Type { get; set; }
        /// <summary>
        /// Identificación de la lista.
        /// </summary>
        [DataMember(), JsonProperty()] public int LookupId { get; set; }
        /// <summary>
        /// Clave que identifica la lista.
        /// </summary>
        [DataMember(), JsonProperty()] public string Key { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Indica el tipo del comando 1 select, 2 procedure
        /// </summary>
        [DataMember(), JsonProperty()] public int StatementType { get; set; }
        /// <summary>
        /// Instrucción o datos para la generación de la lista
        /// </summary>
        [DataMember(), JsonProperty()] public string Statement { get; set; }
        [DataMember(), JsonProperty()] public string Fields { get; set; }
        /// <summary>
        /// Nombre de la cadena de conexión.
        /// </summary>
        [DataMember(), JsonProperty()] public string ConnectionName { get; set; }

        [DataMember(), JsonProperty()] public string IncludeByRole { get; set; }
        [DataMember(), JsonProperty()] public string ExcludeByRole { get; set; }

        [DataMember(), JsonProperty()] public bool IsCached { get; set; }
    }
}
