using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public interface IVariacionData
    {
        /// <summary>
        /// Codigo de compania
        /// </summary>
        [DataMember(), JsonProperty()] int cod_cia { get; set; }

        [DataMember(), JsonProperty()] int cod_ramo { get; set; }

        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] string num_poliza { get; set; }

        /// <summary>
        /// No. de suplemento.
        /// </summary>
        [DataMember(), JsonProperty()] int num_spto { get; set; }
        [DataMember(), JsonProperty()] int cod_fracc_pago { get; set; }
        //[DataMember(), JsonProperty()] string NUM_MATRICULA { get; set; }

        //[DataMember(), JsonProperty()] int COD_COLOR { get; set; }

        [DataMember(), JsonProperty()] string MCA_FEC_EFEC_SYS { get; set; }
        [DataMember(), JsonProperty()] List<Receipt> Recibos { get; set; }
        [DataMember(), JsonProperty()] string Mca_Autoriza_CT { get; set; }

        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] List<CoberturaVariacion> AvailableCoverages { get; set; }
        [DataMember(), JsonProperty()] List<CoberturaVariacion> NewCoverages { get; set; }
        [DataMember(), JsonProperty()] List<g1010031> SumAseguradaRamo { get; set; }
        [DataMember(), JsonProperty()] List<Receipt> plandepagoresumen { get; set; }
        [DataMember(), JsonProperty()] List<Comun.tercero> terceros { get; set; }
        [DataMember(), JsonProperty()] DateTime fec_efec_cancel { get; set; }
        [DataMember(), JsonProperty()] string txt_motivo { get; set; }
        [DataMember(), JsonProperty()] DateTime? fec_efec { get; set; }

    }
}
