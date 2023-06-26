using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Architect.API.Core.Contracts.Security
{
    /// <summary>
    /// Sub Agentes.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class SubAgent
    {

        /// <summary>
        /// Codigo Compania
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_cia { get; set; }
        /// <summary>
        /// Tipo Identificación del subagente.
        /// </summary>
        [DataMember(), JsonProperty()] public string tip_docum { get; set; }
        /// <summary>
        /// Identificación del subagente.
        /// </summary>
        [DataMember(), JsonProperty()] public string cod_docum { get; set; }
        /// <summary>
        /// Nombre del SubAgente.
        /// </summary>
        [DataMember(), JsonProperty()] public string nom1_tercero { get; set; }
        /// <summary>
        ///Apellido 1 del SubAgente.
        /// </summary>
        [DataMember(), JsonProperty()] public string ape1_tercero { get; set; }
        /// <summary>
        ///Apellido 2 del SubAgente.
        /// </summary>
        [DataMember(), JsonProperty()] public string ape2_tercero { get; set; }
        /// <summary>
        /// Email del sub agente.
        /// </summary>
        [DataMember(), JsonProperty()] public string email_com { get; set; }
        /// <summary>
        /// Codigo del agente.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_agt { get; set; }
        /// <summary>
        /// Codigo del subagente.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_emp_agt { get; set; }
        /// <summary>
        /// Marca de Inhabilitado.
        /// </summary>
        [DataMember(), JsonProperty()] public string mca_inh { get; set; }
       
    }
}
