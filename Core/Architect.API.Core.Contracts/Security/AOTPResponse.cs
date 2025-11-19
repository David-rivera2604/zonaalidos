using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Respuesta para una solicitud de acceso mediante AOTP (Access One-Time Password).
    /// Encapsula la información de autenticación y el token de acceso generado.
    /// </summary>
    public class AOTPResponse 
    {
        /// <summary>
        /// Información de la respuesta de autenticación del usuario.
        /// Contiene los datos del usuario autenticado y el resultado del proceso de autenticación.
        /// </summary>
        public AuthenticationResponse Context { get; set; }
        
        /// <summary>
        /// Token de seguridad generado para el acceso.
        /// Contiene la información del token JWT o token de sesión para las peticiones subsecuentes.
        /// </summary>
        public Contracts.Security.Token Token { get; set; }

        /// <summary>
        /// Indica si la acción ejecutada se realizó de forma exitosa.
        /// True si la operación fue exitosa, False en caso contrario.
        /// </summary>
        [DataMember(), JsonProperty()]
        public bool Successful { get; set; }

        /// <summary>
        /// Detalle o mensaje informativo sobre el resultado de la operación.
        /// Puede contener mensajes de error, advertencias o información adicional.
        /// </summary>
        [DataMember(), JsonProperty()]
        public string Reason { get; set; }

    } 
}
