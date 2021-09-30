using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Pólizas registradas.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Risk
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
        /// Origen o tramite: emisión, variación, migración
        /// </summary>
        [DataMember(), JsonProperty()] public int OriginType { get; set; }
        /// <summary>
        /// Ramo
        /// </summary>
        [DataMember(), JsonProperty()] public int LineOfBusinessCode { get; set; }
        /// <summary>
        /// Descripción para ramo
        /// </summary>
        [DataMember(), JsonProperty()] public string LineOfBusinessCodeDesc { get; set; }
        /// <summary>
        /// Producto.
        /// </summary>
        [DataMember(), JsonProperty()] public int ProductCode { get; set; }
        /// <summary>
        /// Descripción para producto.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProductCodeDesc { get; set; }
        /// <summary>
        /// Número de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int PolicyId { get; set; }
        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int Currency { get; set; }
        /// <summary>
        /// Descripción para moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public string CurrencyDesc { get; set; }
        /// <summary>
        /// Plan.
        /// </summary>
        [DataMember(), JsonProperty()] public int ModuleCode { get; set; }
        /// <summary>
        /// Descripción para plan.
        /// </summary>
        [DataMember(), JsonProperty()] public string ModuleCodeDesc { get; set; }
        /// <summary>
        /// Forma de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int PaymentFrequency { get; set; }
        /// <summary>
        /// Descripción para forma de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public string PaymentFrequencyDesc { get; set; }
        /// <summary>
        /// Fecha de alta.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime IssueDate { get; set; }
        /// <summary>
        /// Inicio de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime EndingDate { get; set; }
        /// <summary>
        /// Suma asegurada base.
        /// </summary>
        [DataMember(), JsonProperty()] public double InsuredAmountBase { get; set; }
        /// <summary>
        /// Suma asegurada complementaria.
        /// </summary>
        [DataMember(), JsonProperty()] public double InsuredAmountComplement { get; set; }
        /// <summary>
        /// Suma asegurada.
        /// </summary>
        [DataMember(), JsonProperty()] public double InsuredAmount { get; set; }
        /// <summary>
        /// Importe de prima anual.
        /// </summary>
        [DataMember(), JsonProperty()] public double AnnualPremium { get; set; }
        /// <summary>
        /// Importe de prima mensual.
        /// </summary>
        [DataMember(), JsonProperty()] public double MonthlyPremium { get; set; }
        /// <summary>
        /// Importe de recargo.
        /// </summary>
        [DataMember(), JsonProperty()] public double Surcharge { get; set; }
        /// <summary>
        /// Estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Status { get; set; }
        /// <summary>
        /// Descripción para estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string StatusDesc { get; set; }
        /// <summary>
        /// Fecha de anulación.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime CancellationDate { get; set; }
        /// <summary>
        /// Razón vinculada al estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int ReasonForStatus { get; set; }
        /// <summary>
        /// Descripción para razón vinculada al estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string ReasonForStatusDesc { get; set; }
        /// <summary>
        /// Número de certificado.
        /// </summary>
        [DataMember(), JsonProperty()] public int CertificateId { get; set; }
        /// <summary>
        /// Observaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string Comments { get; set; }
        /// <summary>
        /// Anotaciones
        /// </summary>
        [DataMember(), JsonProperty()] public string Annotation { get; set; }
        /// <summary>
        /// Identificado de uso genérico.
        /// </summary>
        [DataMember(), JsonProperty()] public string Reference { get; set; }
        /// <summary>
        /// Sucursal a la que pertenece el póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int BranchOffice { get; set; }
        /// <summary>
        /// Descripción para sucursal a la que pertenece el póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string BranchOfficeDesc { get; set; }
        /// <summary>
        /// Ejecutivo orginal de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int ExecutiveUserCode { get; set; }
        /// <summary>
        /// Datos personalizables.
        /// </summary>
        [DataMember(), JsonProperty()] public string CustomData { get; set; }
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

