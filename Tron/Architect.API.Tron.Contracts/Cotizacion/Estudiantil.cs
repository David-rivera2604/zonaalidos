using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    /// <summary>
    /// Información de una cotización de Estudiantil.
    /// </summary>
    public class Estudiantil : GenericQuote
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
        /// <summary>
        /// Credencial Estudiantil.
        /// </summary>
        [DataMember(), JsonProperty()] public string TXT_CRED_ESTUD { get; set; }
        
    }

   
}
