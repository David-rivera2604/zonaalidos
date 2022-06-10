using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Información de los prestamos vinculados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskOverdraft
    {
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Inicio del plazo.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime StartTerm { get; set; }
        /// <summary>
        /// Fin del plazo.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTerm { get; set; }
        /// <summary>
        /// Monto del primer prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public double Amount1 { get; set; }
        /// <summary>
        /// Fin del plazo del primer prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTermOnAmount1 { get; set; }
        /// <summary>
        /// Indica si el primer prestado es refundido.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Recast1 { get; set; }
        /// <summary>
        /// Monto del segundo prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public double Amount2 { get; set; }
        /// <summary>
        /// Fin del plazo del segundo prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTermOnAmount2 { get; set; }
        /// <summary>
        /// Indica si el segundo prestado es refundido.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Recast2 { get; set; }
        /// <summary>
        /// Monto del tercer prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public double Amount3 { get; set; }
        /// <summary>
        /// Fin del plazo del tercer prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTermOnAmount3 { get; set; }
        /// <summary>
        /// Indica si el tercer prestado es refundido.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Recast3 { get; set; }
        /// <summary>
        /// Monto del cuarto prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public double Amount4 { get; set; }
        /// <summary>
        /// Fin del plazo del cuarto prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTermOnAmount4 { get; set; }
        /// <summary>
        /// Indica si el cuarto prestado es refundido.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Recast4 { get; set; }
        /// <summary>
        /// Monto del quinto prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public double Amount5 { get; set; }
        /// <summary>
        /// Fin del plazo del quinto prestamo existente.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndTermOnAmount5 { get; set; }
        /// <summary>
        /// Indica si el quinto prestado es refundido.
        /// </summary>
        [DataMember(), JsonProperty()] public bool Recast5 { get; set; }
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

