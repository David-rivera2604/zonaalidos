using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Comun
{
    /// <summary>
    /// Certificado de Poliza.
    /// </summary>
    public class Certificado
    {
        /// <summary>
        /// Nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string certificado { get; set; }
    }
}
