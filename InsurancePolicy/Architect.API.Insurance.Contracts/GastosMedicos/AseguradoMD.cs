using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Contracts.GastosMedicos
{
    // <summary>
    /// Información de un asegurado de gastos medicos en Medical.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class AseguradoMD
    {
        /// <summary>
        /// Clase
        /// </summary>
        [DataMember(), JsonProperty()] public string Clase { get; set; }
        /// <summary>
        /// Contratante
        /// </summary>
        [DataMember(), JsonProperty()] public string Contratante { get; set; }
        /// <summary>
        /// Estatus
        /// </summary>
        [DataMember(), JsonProperty()] public string Estatus { get; set; }
        /// <summary>
        /// FechaDeEfectividad
        /// </summary>
        [DataMember(), JsonProperty()] public string FechaDeEfectividad { get; set; }
        /// <summary>
        /// FechaExclusion
        /// </summary>
        [DataMember(), JsonProperty()] public string FechaExclusion { get; set; }
        /// <summary>

        /// <summary>
        /// FinVigencia
        /// </summary>
        [DataMember(), JsonProperty()] public string FechaFinVigencia { get; set; }

        /// Identificacion
        /// </summary>
        [DataMember(), JsonProperty()] public string Identificacion { get; set; }
        /// <summary>
        /// Nombres
        [DataMember(), JsonProperty()] public string Nombres { get; set; }

        /// <summary>
        /// NumeroDeCertificado
        /// </summary>
        [DataMember(), JsonProperty()] public string NumeroDeCertificado { get; set; }

        /// NumeroDePoliza
        /// </summary>
        [DataMember(), JsonProperty()] public string NumeroDePoliza { get; set; }
        /// <summary>
        /// Producto
        [DataMember(), JsonProperty()] public string Producto { get; set; }


    }
}
