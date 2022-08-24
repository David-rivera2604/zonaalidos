using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Solicitud de acceso
    /// </summary>
    [Serializable(), DataContract()]
    public class AuthenticationRequest
    {
        /// <summary>
        /// Propietario
        /// </summary>
        [DataMember(), JsonProperty()] public string Tenant { get; set; }
        /// <summary>
        /// Usuario o correo electrónico
        /// </summary>
        [DataMember(), JsonProperty()] public string Email { get; set; }
        /// <summary>
        /// Clave de acceso
        /// </summary>
        [DataMember(), JsonProperty()] public string Password { get; set; }

        /// <summary>
        /// Dirección IP/Nombre de la maquina donde se hizo la solicitud.
        /// </summary>
        [DataMember(), JsonProperty()] public string IPAddress { get; set; }
        /// <summary>
        /// Información sobre el dispositivo de consulta que efectúa una petición de red.
        /// </summary>
        [DataMember(), JsonProperty()] public string UserAgent { get; set; }

        /// <summary>
        /// Indica si el acceso es por medio de una cuenta de empleado de Mapfre
        /// </summary>
        [DataMember(), JsonProperty()] public bool EmployeeMode { get; set; }

        
    }
}
