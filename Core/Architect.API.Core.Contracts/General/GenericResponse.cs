using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Respuesta de uso general para operaciones de la API.
    /// Encapsula el resultado de una operación, incluyendo el contexto de autenticación,
    /// el estado de éxito y mensajes informativos.
    /// </summary>
    [Serializable(), DataContract()]
    public class GenericResponse
    {
            /// <summary>
        /// Contexto de autenticación y autorización de la respuesta.
        /// Contiene la información de autenticación del usuario y el token de acceso generado.
        /// </summary>
        [DataMember(), JsonProperty()] 
        public Contracts.Security.AOTPResponse Context { get; set; }

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
