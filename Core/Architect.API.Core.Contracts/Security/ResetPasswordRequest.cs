using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Información necesario durante el proceso de restaurar o cambiar al clave de acceso.
    /// </summary>
    [Serializable(), DataContract()]
    public class ResetPasswordRequest
    {
        /// <summary>
        /// Propietario
        /// </summary>
        [DataMember(), JsonProperty()] public string Tenant { get; set; }
        /// <summary>
        /// Usuario o correo electronico
        /// </summary>
        [DataMember(), JsonProperty()] public string EMail { get; set; }
        /// <summary>
        /// Código de verificación para poder establecer una nueva contraseña
        /// </summary>
        [DataMember(), JsonProperty()] public string OTP { get; set; }
        /// <summary>
        /// Clave de acceso actual
        /// </summary>
        [DataMember(), JsonProperty()] public string Current { get; set; }
        /// <summary>
        /// Clave de acceso
        /// </summary>
        [DataMember(), JsonProperty()] public string Password { get; set; }
        /// <summary>
        /// Confirmación de la clave de acceso
        /// </summary>
        [DataMember(), JsonProperty()] public string PasswordConfirm { get; set; }
        /// <summary>
        /// Dirección IP/Nombre de la maquina donde se hizo la solicitud.
        /// </summary>
        [IgnoreDataMember()] public string IPAddress { get; set; }
        /// <summary>
        /// Indica el modo de uso. 2FA para ingreso con doble factor de autenticación, en otros casos restaurar clave de acceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Mode { get; set; }
    }
}
