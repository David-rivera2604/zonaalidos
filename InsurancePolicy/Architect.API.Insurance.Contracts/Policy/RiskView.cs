using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Pólizas registradas.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskView
    {
        /// <summary>
        /// Identificación única de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Ramo
        /// </summary>
        [DataMember(), JsonProperty()] public int LineOfBusinessCode { get; set; }
        /// <summary>
        /// Descripción para ramo
        /// </summary>
        [DataMember(), JsonProperty()] public string LineOfBusinessDesc { get; set; }
        /// <summary>
        /// Producto.
        /// </summary>
        [DataMember(), JsonProperty()] public int ProductCode { get; set; }
        /// <summary>
        /// Descripción para producto.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProductDesc { get; set; }
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
        [DataMember(), JsonProperty()] public string ModuleDesc { get; set; }
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
        /// Porcentaje del recargo.
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
        [DataMember(), JsonProperty()] public DateTime? CancellationDate { get; set; }
        /// <summary>
        /// Razón vinculada al estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public int ReasonForStatus { get; set; }
        /// <summary>
        /// Descripción para razón vinculada al estado de la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string ReasonForStatusDesc { get; set; }
        /// <summary>
        /// Alias del producto.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProductAlias { get; set; }
        /// <summary>
        /// Prefijo usando para el nombre del reporte usando en la impresión del certificado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Prefix { get; set; }
        /// <summary>
        /// Observaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string Comments { get; set; }

        /// <summary>
        /// Nombre del tomandor de la póliza matriz.
        /// </summary>
        [DataMember(), JsonProperty()] public string OwnerName { get; set; }

        /// <summary>
        /// Identificador del tomandor de la póliza matriz.
        /// </summary>
        [DataMember(), JsonProperty()] public string OwnerId { get; set; }

        /// <summary>
        /// Información del asegurado principal.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskRolesView PrimaryInsured { get; set; }

        /// <summary>
        /// Información de los prestamos vinculados a una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskOverdraftView Overdraft { get; set; }

        /// <summary>
        /// Cuestionarios vinculados a una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskQuestionaryView Questionary { get; set; }

        /// <summary>
        /// Diagnósticos asociados a las respuesta del cuestionario de salud vinculado a la póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public List<RiskQuestionDiagnosisView> Diagnosis { get; set; }
        /// <summary>
        /// Información de los beneficiarios vinculados a una póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskBeneficiaryInfoView Beneficiaries { get; set; }

        /// <summary>
        /// Uso interno.
        /// </summary>
        [DataMember(), JsonProperty()] public string Behavior { get; set; }
    }
}

