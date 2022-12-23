using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class SaldoDeudorSettings
    {
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_vcto_poliza { get; set; }

        /// <summary>
        /// Código de frecuencia de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_fracc_pago { get; set; }


        /// <summary>
        /// Modalidad
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> COD_MODALIDAD_RIESGO { get; set; }

        /// <summary>
        /// Tipo de Negocio
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> TIP_NEGOCIO { get; set; }

        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> coberturas { get; set; }
    }
}
