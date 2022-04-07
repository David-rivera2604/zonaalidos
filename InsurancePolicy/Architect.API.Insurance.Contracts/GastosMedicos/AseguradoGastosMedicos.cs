using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Contracts.GastosMedicos
{
  
    /// <summary>
    /// Información de un asegurado de gastos medicos.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class AseguradoGastosMedicos
    {
        /// <summary>
        /// Primer nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string nombre { get; set; }
        /// <summary>
        /// Segundo nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string apellido { get; set; }
        /// <summary>
        /// Poliza
        /// </summary>
        [DataMember(), JsonProperty()] public string poliza { get; set; }
        /// <summary>
        /// Certficado
        /// </summary>
        [DataMember(), JsonProperty()] public string certificado { get; set; }
        /// <summary>
        /// InicioVigencia
        /// </summary>
        [DataMember(), JsonProperty()] public string fechaInicioVigencia { get; set; }
        /// <summary>

        /// <summary>
        /// FinVigencia
        /// </summary>
        [DataMember(), JsonProperty()] public string fechaFinVigencia { get; set; }

        /// FechaIngreso
        /// </summary>
        [DataMember(), JsonProperty()] public string fechaIngreso { get; set; }
        /// <summary>
        /// FechaExclusion
        [DataMember(), JsonProperty()] public string fechaExclusion { get; set; }
        /// <summary>
        /// Beneficios
        /// </summary>
        [DataMember(), JsonProperty()] public List<Dependientes> dependientes { get; set; }
        /// <summary>
        /// Dependientes
        /// </summary>
        [DataMember(), JsonProperty()] public List<Beneficios> beneficios { get; set; }
    }
}
