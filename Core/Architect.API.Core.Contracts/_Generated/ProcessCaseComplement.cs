using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// ProcessCaseComplement
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessCaseComplement
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int CaseId { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        [DataMember(), JsonProperty()] public double Fee { get; set; }
        [DataMember(), JsonProperty()] public double Compensation { get; set; }
        [DataMember(), JsonProperty()] public double Deductible { get; set; }
        [DataMember(), JsonProperty()] public double SpareParts { get; set; }
        [DataMember(), JsonProperty()] public double ManPower { get; set; }
        [DataMember(), JsonProperty()] public int Workshop { get; set; }
        [DataMember(), JsonProperty()] public string WorkshopDesc { get; set; }
        /// <summary>
        /// Número de factura de mano de obra
        /// </summary>
        [DataMember(), JsonProperty()] public string ManPowerInvoice { get; set; }
        /// <summary>
        /// Número de factura de respuestos
        /// </summary>
        [DataMember(), JsonProperty()] public string SparePartsInvoice { get; set; }
        /// <summary>
        /// Fecha de la liquidación.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime SettlementDate { get; set; }
        /// <summary>
        /// Fecha de la cita.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// Hola de la cita.
        /// </summary>
        [DataMember(), JsonProperty()] public string AppointmentTime { get; set; }
        /// <summary>
        /// Asesor asignado.
        /// </summary>
        [DataMember(), JsonProperty()] public string AssignedAdvisor { get; set; }
        /// <summary>
        /// Descripción para asesor asignado.
        /// </summary>
        [DataMember(), JsonProperty()] public string AssignedAdvisorDesc { get; set; }
        [DataMember(), JsonProperty()] public DateTime ReportDate { get; set; }
        [DataMember(), JsonProperty()] public double RepairTotalAmount { get; set; }
        /// <summary>
        /// Mano de obra para reparación
        /// </summary>
        [DataMember(), JsonProperty()] public double RepairManPower { get; set; }
        /// <summary>
        /// Repuestos para reparación
        /// </summary>
        [DataMember(), JsonProperty()] public double RepairSpareParts { get; set; }
        [DataMember(), JsonProperty()] public double SetSpaFee { get; set; }
        [DataMember(), JsonProperty()] public double SetSpaCompensation { get; set; }
        [DataMember(), JsonProperty()] public double SetSpaDeductible { get; set; }
        [DataMember(), JsonProperty()] public double SetSpaSpareParts { get; set; }
        [DataMember(), JsonProperty()] public double SetSpaManPower { get; set; }
        /// <summary>
        /// Número de factura de mano de obra
        /// </summary>
        [DataMember(), JsonProperty()] public string SetSpaManPowerInvoice { get; set; }
        /// <summary>
        /// Número de factura de respuestos
        /// </summary>
        [DataMember(), JsonProperty()] public string SetSpaSparePartsInvoice { get; set; }
        /// <summary>
        /// Fecha de la liquidación.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime SetSpaSettlementDate { get; set; }
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

