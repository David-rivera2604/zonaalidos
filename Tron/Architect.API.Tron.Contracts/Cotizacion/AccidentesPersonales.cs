using Newtonsoft.Json;
using System.Runtime.Serialization;
using System;
namespace Architect.API.Tron.Contracts.Cotizacion
{
    /// <summary>
    /// Información de una cotización de Estudiantil.
    /// </summary>
    public class AccidentesPersonales : GenericQuote
    {
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SEXO { get; set; }
        /// <summary>
        /// Plan.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_PLAN_AP { get; set; }
        [DataMember(), JsonProperty()] public string NOM_PLAN_AP { get; set; }
        ///// <summary>
        ///// Credencial Estudiantil.
        ///// </summary>
        //[DataMember(), JsonProperty()] public string TXT_CRED_ESTUD { get; set; }
        /// <summary>
        /// Código de modalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_MODALIDAD { get; set; }
        [DataMember(), JsonProperty()] public string NOM_MODALIDAD { get; set; }
        /// <summary>
        /// Código de ocupación.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_OCUPACION { get; set; }
        [DataMember(), JsonProperty()] public string NOM_OCUPACION { get; set; }
        /// <summary>
        /// Código Días de Deducible Renta Diaria.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_DEDUCIBLE { get; set; }
        [DataMember(), JsonProperty()] public string NOM_DEDUCIBLE { get; set; }
    }
}