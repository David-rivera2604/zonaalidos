using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.GastosMedicos
{
    /// <summary>
    /// Información de beneficios  de un asegurado en gastos medicos.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class DependientesMD
    {

        /// <summary>
        /// Estatus
        /// </summary>
        [DataMember(), JsonProperty()] public string Estatus { get; set; }
        /// <summary>
        /// FechaDeEfectividad.
        /// </summary>
        [DataMember(), JsonProperty()] public string FechaDeEfectividad { get; set; }
        /// <summary>
        /// FechaExclusion.
        /// </summary>
        [DataMember(), JsonProperty()] public string FechaExclusion { get; set; }
        /// <summary>
        /// FechaFinVigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public string FechaFinVigencia { get; set; }
        /// <summary>
        /// identificacion.
        /// </summary>
        [DataMember(), JsonProperty()] public string Identificacion { get; set; }
        /// <summary>
        /// Nombres.
        /// </summary>
        [DataMember(), JsonProperty()] public string Nombres { get; set; }
    }
}
