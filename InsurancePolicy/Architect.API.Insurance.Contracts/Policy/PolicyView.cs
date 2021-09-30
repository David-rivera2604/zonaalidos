using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Pólizas registradas.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class PolicyView
    {
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Fecha de alta.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        /// <summary>
        /// Descripción para ramo
        /// </summary>
        [DataMember(), JsonProperty()] public string LineOfBusiness { get; set; }
        /// <summary>
        /// Descripción para producto.
        /// </summary>
        [DataMember(), JsonProperty()] public string Product { get; set; }
        /// <summary>
        /// Número de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string PolicyId { get; set; }
        /// <summary>
        /// Nombre completo del asegurado principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string InsuredName { get; set; }
        /// <summary>
        /// Identificación del asegurado principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string InsuredNumber { get; set; }
        /// <summary>
        /// Descripción para plan.
        /// </summary>
        [DataMember(), JsonProperty()] public string Module  { get; set; }
        /// <summary>
        /// Inicio de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndingDate { get; set; }
        /// <summary>
        /// Descripción para estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string Status { get; set; }
        /// <summary>
        /// Estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int StatusCode { get; set; }
        /// <summary>
        /// Descripción para moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public string Currency { get; set; }
        /// <summary>
        /// Fecha de anulación.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime CancellationDate { get; set; }
        /// <summary>
        /// Descripción para razón vinculada al estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string ReasonForStatus { get; set; }
        /// <summary>
        /// Suma asegurada.
        /// </summary>
        [DataMember(), JsonProperty()] public double InsuredAmount { get; set; }
        /// <summary>
        /// Importe de prima anual.
        /// </summary>
        [DataMember(), JsonProperty()] public double AnnualPremium { get; set; }
    }
}

