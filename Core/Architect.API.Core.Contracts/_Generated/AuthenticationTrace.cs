using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Auditoria de autenticación de usuarios e intentos de acceso al sistema.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class AuthenticationTrace
    {
        /// <summary>
        /// Identificador único.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Fecha de creación del registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EffectDate { get; set; }
        /// <summary>
        /// Dirección IP/Nombre de la maquina donde se hizo la solicitud.
        /// </summary>
        [DataMember(), JsonProperty()] public string IPAddress { get; set; }
        /// <summary>
        /// Nombre del usuario usado para la autenticación.
        /// </summary>
        [DataMember(), JsonProperty()] public string UserName { get; set; }
        /// <summary>
        /// Identificación del usuario autenticado.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserId { get; set; }
        /// <summary>
        /// Tipo de registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int TraceType { get; set; }
        /// <summary>
        /// Descripción para tipo de registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string TraceTypeDesc { get; set; }
        /// <summary>
        /// Indica la razón de la traza.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reason { get; set; }
        /// <summary>
        /// Información sobre el dispositivo de consulta que efectúa una petición de red.
        /// </summary>
        [DataMember(), JsonProperty()] public string UserAgent { get; set; }

        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }
    }
}

