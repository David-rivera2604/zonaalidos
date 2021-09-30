using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Security
{
        /// <summary>
        /// Datos del un usuario para su registrado.
        /// </summary>
    [Serializable(), DataContract()]
    public class Register
    {
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public string Tenant { get; set; }
        /// <summary>
        /// Tipo de identificación del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public int identificacionType { get; set; }
        /// <summary>
        /// Identificación del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string identificacion { get; set; }
        /// <summary>
        /// Nombres del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string FirstName { get; set; }
        /// <summary>
        /// Apellidos del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string LastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento del usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BirthDate { get; set; }
        /// <summary>
        /// E-Mail del Usuario.
        /// </summary>
        [DataMember(), JsonProperty()] public string EMail { get; set; }
        /// <summary>
        /// Clave de acceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string Password { get; set; }
    }
}

