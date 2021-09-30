using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Bayer
{
    /// <summary>
    /// Resume de solicitudes de inclusión.
    /// </summary>
    public class InclusionView
    {
        /// <summary>
        /// Identificación única.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Fecha de ingreso a póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        /// <summary>
        /// Identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentNumber { get; set; }
        /// <summary>
        /// Nombre completo del aseguado.
        /// </summary>
        [DataMember(), JsonProperty()] public string InsuredFullName { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BirthDate { get; set; }
        /// <summary>
        /// Teléfono.
        /// </summary>
        [DataMember(), JsonProperty()] public string PhoneNumber { get; set; }
        /// <summary>
        /// Correo electrónico.
        /// </summary>
        [DataMember(), JsonProperty()] public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// Estado de la inclusion.
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Descripción para estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string StatusDesc { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }

    }
}
