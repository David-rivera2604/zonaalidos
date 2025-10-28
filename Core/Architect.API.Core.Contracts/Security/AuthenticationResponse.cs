using System.Collections.Generic;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Respuesta para una solictud de acceso
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Propietario
        /// </summary>
        public string Tenant { get; set; }

        /// <summary>
        /// En caso de estar en verdadero indica que el usuario deb cambiar la clave de acceso
        /// </summary>
        public bool MustChangePassword { get; set; }

        /// <summary>
        /// Indica la fecha y hora en que expira el acceso.
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Razón o mensajes asociados a la autenticación.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Roles asociados al usuario auntenticado.
        /// </summary>
        public string[] Roles { get; set; }

        /// <summary>
        /// Token de acceso
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Ruta incial
        /// </summary>
        public string InitialPath { get; set; }

        /// <summary>
        /// E-Mail del Usuario.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Indica que se necesita un segundo factor de autenticación (2FA) mediante OTP.
        /// </summary>
        public bool Need2FAOTP { get; set; }

        public List<SettingItem> Settings { get; set; }
    }
    public class SettingItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
