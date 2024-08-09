using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class MultirriesgoSettings
    {

        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_vcto_poliza { get; set; }

        /// <summary>
        /// Suma asegurada de Responsabilidad Civil
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> SumasAseguradasRC { get; set; }

        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> coberturas { get; set; }

    }

}
