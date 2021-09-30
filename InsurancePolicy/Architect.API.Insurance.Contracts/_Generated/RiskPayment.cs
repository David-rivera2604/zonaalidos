using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
        /// <summary>
        /// Medio de pago usando en una póliza.
        /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskPayment
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
        /// Medio de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int PaymentMethod { get; set; }
        /// <summary>
        /// Descripción para medio de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public string PaymentMethodDesc { get; set; }
        /// <summary>
        /// Tipo de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int PaymentType { get; set; }
        /// <summary>
        /// Descripción para tipo de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public string PaymentTypeDesc { get; set; }
        /// <summary>
        /// Banco emisor.
        /// </summary>
        [DataMember(), JsonProperty()] public int BankCode { get; set; }
        /// <summary>
        /// Descripción para banco emisor.
        /// </summary>
        [DataMember(), JsonProperty()] public string BankCodeDesc { get; set; }
        /// <summary>
        /// Número de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public string BankAccount { get; set; }
        /// <summary>
        /// Número de tarjeta.
        /// </summary>
        [DataMember(), JsonProperty()] public string CardNumber { get; set; }
        /// <summary>
        /// Titular de la cuenta o tarjeta.
        /// </summary>
        [DataMember(), JsonProperty()] public string Holder { get; set; }
        /// <summary>
        /// Fecha de vencimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Indica si el asegurado es el titular
        /// </summary>
        [DataMember(), JsonProperty()] public bool HolderIsInsured { get; set; }
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

