using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// RiskBayer
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskBayer
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
        /// N° de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string MainPolicyId { get; set; }
        /// <summary>
        /// Fecha de ingreso a póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        /// <summary>
        /// Nombre del contratante.
        /// </summary>
        [DataMember(), JsonProperty()] public string ContractorName { get; set; }
        /// <summary>
        /// Producto de vida.
        /// </summary>
        [DataMember(), JsonProperty()] public string IsLife { get; set; }
        /// <summary>
        /// Producto de salud.
        /// </summary>
        [DataMember(), JsonProperty()] public string IsHealth { get; set; }
        /// <summary>
        /// Seguro Social.
        /// </summary>
        [DataMember(), JsonProperty()] public string SocialSecurity { get; set; }
        /// <summary>
        /// Miembro dominante.
        /// </summary>
        [DataMember(), JsonProperty()] public int DominantMember { get; set; }
        /// <summary>
        /// Fecha de Ingreso a trabajar.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime DateEntryWork { get; set; }
        /// <summary>
        /// Salario mensual.
        /// </summary>
        [DataMember(), JsonProperty()] public double MonthlySalary { get; set; }
        /// <summary>
        /// Médico de cabecera.
        /// </summary>
        [DataMember(), JsonProperty()] public string Doctor { get; set; }
        /// <summary>
        /// Banco emisor.
        /// </summary>
        [DataMember(), JsonProperty()] public int RefundBankCode { get; set; }
        /// <summary>
        /// Descripción para banco emisor.
        /// </summary>
        [DataMember(), JsonProperty()] public string RefundBankCodeDesc { get; set; }
        /// <summary>
        /// Número de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public string RefundBankAccount { get; set; }
        /// <summary>
        /// Tipo de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public int RefundBankAccountType { get; set; }
        /// <summary>
        /// Descripción para tipo de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public string RefundBankAccountTypeDesc { get; set; }
        /// <summary>
        /// Moneda de la cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public int RefundBankAccountCurrency { get; set; }
        /// <summary>
        /// Descripción para moneda de la cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public string RefundBankAccountCurrencyDesc { get; set; }
        /// <summary>
        /// Tipo de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public int PaymentModeType { get; set; }
        /// <summary>
        /// Descripción para tipo de cuenta.
        /// </summary>
        [DataMember(), JsonProperty()] public string PaymentModeTypeDesc { get; set; }
        /// <summary>
        /// Tarjeta de crédito o cuenta de cargo n°.
        /// </summary>
        [DataMember(), JsonProperty()] public string PaymentBankAccount { get; set; }
        /// <summary>
        /// Número de tarjeta.
        /// </summary>
        [DataMember(), JsonProperty()] public string PaymentCardNumber { get; set; }
        /// <summary>
        /// Fecha de vencimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime PaymentCardExpirationDate { get; set; }
        /// <summary>
        /// Titular de la cuenta o tarjeta.
        /// </summary>
        [DataMember(), JsonProperty()] public string PaymentHolder { get; set; }
        /// <summary>
        /// Banco.
        /// </summary>
        [DataMember(), JsonProperty()] public int PaymentBankCode { get; set; }
        [DataMember(), JsonProperty()] public bool HasDigitalSignature { get; set; }
        /// <summary>
        /// Fecha de continuidad.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime ContinuityDate { get; set; }
        /// <summary>
        /// Número de empleado
        /// </summary>
        [DataMember(), JsonProperty()] public string EmployeeNumber { get; set; }
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

