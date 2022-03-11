using System;
using System.Linq;

namespace Architect.API.Core.Contracts.General
{
    public class CaseComplement
    {
        public double Fee { get; set; }
        public double Compensation { get; set; }
        public double Deductible { get; set; }
        public double SpareParts { get; set; }
        public double ManPower { get; set; }
        public int Workshop { get; set; }
        public string WorkshopDesc { get; set; }

        /// <summary>
        /// Número de factura de mano de obra
        /// </summary>
        public string ManPowerInvoice { get; set; }
        /// <summary>
        /// Número de factura de respuestos
        /// </summary>
        public string SparePartsInvoice { get; set; }

        public DateTime SettlementDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AssignedAdvisor { get; set; }

        public DateTime ReportDate { get; set; }
        public double RepairTotalAmount { get; set; }
        public double RepairManPower { get; set; }
        public double RepairSpareParts { get; set; }


        public double SetSpaFee { get; set; }
        public double SetSpaCompensation { get; set; }
        public double SetSpaDeductible { get; set; }
        public double SetSpaSpareParts { get; set; }
        public double SetSpaManPower { get; set; }
        public string SetSpaManPowerInvoice { get; set; }
        public string SetSpaSparePartsInvoice { get; set; }
        public DateTime SetSpaSettlementDate { get; set; }
    }
}
