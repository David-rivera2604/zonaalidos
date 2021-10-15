using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{

    public class plandepagoporfrecuencia
    {
        /// <summary>
        /// Código
        /// </summary>
        [DataMember(), JsonProperty()] public int codigo { get; set; }
        /// <summary>
        /// Frecuencia
        /// </summary>
        [DataMember(), JsonProperty()] public string frecuencia { get; set; }
        /// <summary>
        /// Recargo por fraccionamiento.
        /// </summary>
        [DataMember(), JsonProperty()] public double recardoporfraccionamiento { get; set; }
        /// <summary>
        /// Importe total.
        /// </summary>
        [DataMember(), JsonProperty()] public double importetotal { get; set; }
    }

}
