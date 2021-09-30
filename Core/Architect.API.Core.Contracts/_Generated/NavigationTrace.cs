using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Auditoria de navegación de los usuarios.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class NavigationTrace
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
        /// Código de la página ejecutada.
        /// </summary>
        [DataMember(), JsonProperty()] public string Code { get; set; }
        /// <summary>
        /// Identificación del usuario autenticado.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserId { get; set; }
        /// <summary>
        /// Fecha en que la página fue ejecutada.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EffectDate { get; set; }
    }
}

