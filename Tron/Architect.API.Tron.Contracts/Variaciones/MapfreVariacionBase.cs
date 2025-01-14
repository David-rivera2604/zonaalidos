using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public class MapfreVariacionBase : Cotizacion.MapfreMas
    {
        /// <summary>
        /// Codigo de compania
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_cia { get; set; }

        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }

        /// <summary>
        /// No. de suplemento.
        /// </summary>
        [DataMember(), JsonProperty()] public int num_spto { get; set; }

        [DataMember(), JsonProperty()] public int COD_COLOR { get; set; }

        [DataMember(), JsonProperty()] public string MCA_FEC_EFEC_SYS { get; set; } = "N";
        [DataMember(), JsonProperty()] public List<Receipt> Recibos { get; set; }
        [DataMember(), JsonProperty()] public string Mca_Autoriza_CT { get; set; }
        [DataMember(), JsonProperty()] public string DED_AUTO_CYV_Desc { get; set; }
        [DataMember(), JsonProperty()] public string DED_AUTO_ROB_Desc { get; set; }
        [DataMember(), JsonProperty()] public string DED_AUTO_RAD_Desc { get; set; }

        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<CoberturaVariacion> AvailableCoverages { get; set; }
        [DataMember(), JsonProperty()] public List<CoberturaVariacion> NewCoverages { get; set; }
        [DataMember(), JsonProperty()] public bool AUTO_RC { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_CYV { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_ROB { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_GMO { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_ACO { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_RAD { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_CRI { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_EQESP { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_NEUM { get; set; } = false;
        [DataMember(), JsonProperty()] public bool AUTO_MECA { get; set; } = false;
        [DataMember(), JsonProperty()] public List<g1010031> SumAseguradaRamo { get; set; }
    }
}
