using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Prestamos existentes
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RuleLoans
    {
        /// <summary>
        /// Número del préstamo.
        /// </summary>
        [DataMember(), JsonProperty()] public int LoanNumber { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Documento o número de identificación.
        /// </summary>
        [DataMember(), JsonProperty()] public string DocumentNumber { get; set; }
        /// <summary>
        /// Nombre completo.
        /// </summary>
        [DataMember(), JsonProperty()] public string FullName { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime BirthDate { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int Gender { get; set; }
        /// <summary>
        /// Descripción para sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public string GenderDesc { get; set; }
        /// <summary>
        /// Inicio del plazo.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime StartTerm { get; set; }
        /// <summary>
        /// Fin del plazo.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTerm { get; set; }
        /// <summary>
        /// Duración en años.
        /// </summary>
        [DataMember(), JsonProperty()] public int Duration { get; set; }
        /// <summary>
        /// Monto original del préstamo.
        /// </summary>
        [DataMember(), JsonProperty()] public double Amount { get; set; }
        /// <summary>
        /// Saldo actual del préstamo.
        /// </summary>
        [DataMember(), JsonProperty()] public double Balance { get; set; }
    }
}

