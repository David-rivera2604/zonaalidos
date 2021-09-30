using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Rating
{
    /// <summary>
    /// Resultado del cálculo de primas.
    /// </summary>
    public class RateCalculated
    {
        /// <summary>
        /// Importe de prima anual.
        /// </summary>
        [DataMember(), JsonProperty()] public double AnnualPremium { get; set; }
        /// <summary>
        /// Importe de prima mensual.
        /// </summary>
        [DataMember(), JsonProperty()] public double MonthlyPremium { get; set; }
    }
}
