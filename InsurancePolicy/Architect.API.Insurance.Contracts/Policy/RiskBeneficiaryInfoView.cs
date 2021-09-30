using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Policy
{
    /// <summary>
    /// Beneficiarios asociados a una póliza.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class RiskBeneficiaryInfoView
    {
        /// <summary>
        /// Información del beneficiario 1.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskBeneficiaryView Beneficiary1 { get; set; }
        /// <summary>
        /// Información del beneficiario 2.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskBeneficiaryView Beneficiary2 { get; set; }
        /// <summary>
        /// Información del beneficiario 3.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskBeneficiaryView Beneficiary3 { get; set; }
        /// <summary>
        /// Información del beneficiario 4.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskBeneficiaryView Beneficiary4 { get; set; }
        /// <summary>
        /// Información del beneficiario 5.
        /// </summary>
        [DataMember(), JsonProperty()] public RiskBeneficiaryView Beneficiary5 { get; set; }
    }
}

