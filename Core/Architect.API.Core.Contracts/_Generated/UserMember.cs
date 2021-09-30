using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Usuarios registrados.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class UserMember
    {
        /// <summary>
        /// Identificación del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public int UserId { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre Usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string UserName { get; set; }
        /// <summary>
        /// E-Mail del Usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string EMail { get; set; }
        /// <summary>
        /// Clave de acceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Password { get; set; }
        /// <summary>
        /// Clave de acceso anteriores.
        /// </summary>
        [DataMember(), JsonProperty()] public string OldPassword { get; set; }
        /// <summary>
        /// Tipo de documento.
        /// </summary>
        [DataMember(), JsonProperty()] public int IdentificationType { get; set; }
        /// <summary>
        /// Descripción para tipo de documento.
        /// </summary>
        [DataMember(), JsonProperty()] public string IdentificationTypeDesc { get; set; }
        /// <summary>
        /// Documento o número de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string Identification { get; set; }
        /// <summary>
        /// Primer Nombre
        /// </summary>
        [DataMember(), JsonProperty()] public string FirstName { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        [DataMember(), JsonProperty()] public string LastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BirthDate { get; set; }
        /// <summary>
        /// Intentos fallidos de clave del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public int FailedPasswordCount { get; set; }
        /// <summary>
        /// Nivel de seguridad.
        /// </summary>
        [DataMember(), JsonProperty()] public int SecurityLevel { get; set; }
        /// <summary>
        /// Está bloqueada el usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public bool IsLockedOut { get; set; }
        /// <summary>
        /// Fecha de bloqueo.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime LockedOutDate { get; set; }
        /// <summary>
        /// Ultimo Cambio de Clave de Usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime PasswordChangedDate { get; set; }
        /// <summary>
        /// Cambiar una clave va a ameritar un campo nuevo que permite establecer una codigo random
        /// </summary>
        [DataMember(), JsonProperty()] public string OneTimePassword { get; set; }
        /// <summary>
        /// Último conexión o inicio de sesión de usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime LoginDate { get; set; }
        /// <summary>
        /// Identificación del usuario supervisor.
        /// </summary>
        [DataMember(), JsonProperty()] public int ManagerId { get; set; }
        /// <summary>
        /// valor usado para identificar un usuario para servicios.
        /// </summary>
        [DataMember(), JsonProperty()] public string AccessKey { get; set; }
        /// <summary>
        /// Sucursal a la que pertenece el usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public int BranchOffice { get; set; }
        /// <summary>
        /// Descripción para sucursal a la que pertenece el usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string BranchOfficeDesc { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference { get; set; }
        /// <summary>
        /// Cargo que desempeña el usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public int Position { get; set; }
        /// <summary>
        /// Descripción para cargo que desempeña el usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string PositionDesc { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumber { get; set; }
        /// <summary>
        /// Canal de ventas.
        /// </summary>
        [DataMember(), JsonProperty()] public int SalesChannel { get; set; }
        /// <summary>
        /// Descripción para canal de ventas.
        /// </summary>
        [DataMember(), JsonProperty()] public string SalesChannelDesc { get; set; }
        /// <summary>
        /// Datos personalizables.
        /// </summary>
        [DataMember(), JsonProperty()] public string CustomData { get; set; }
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

