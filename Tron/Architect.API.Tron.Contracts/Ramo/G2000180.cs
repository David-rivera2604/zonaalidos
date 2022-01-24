using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    /// CONCEPTOS DE DESGLOSE DEL RAMO.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class G2000180
    {
        /// <summary>
        /// CODIGO DE COMPAÑIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CIA { get; set; }
        /// <summary>
        /// RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_RAMO { get; set; }
        /// <summary>
        /// MODALIDAD DE VIDA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MODALIDAD { get; set; }
        /// <summary>
        /// COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COB { get; set; }
        /// <summary>
        /// SECUENCIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_SECU { get; set; }
        /// <summary>
        /// CONCEPTO DE DESGLOSE ECONOMICO.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_DESGLOSE { get; set; }
        /// <summary>
        /// NO SE USA.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_BLOQUE_ESTUDIO { get; set; }
        /// <summary>
        /// FORMA DE APLICACION (GENERAL, COBERTURA, RAMO, .).
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_APLICACION { get; set; }
        /// <summary>
        /// FECHA DE VALIDEZ.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_VALIDEZ { get; set; }
        /// <summary>
        /// USUARIO QUE ACTUALIZO LA FILA.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_USR { get; set; }
        /// <summary>
        /// FECHA DE LA ULTIMA ACTUALIZACION DEL REGISTRO.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_ACTU { get; set; }
    }
}

