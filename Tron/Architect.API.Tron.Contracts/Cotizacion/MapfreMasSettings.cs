using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class MapfreMasSettings
    {

        /// <summary>
        /// Código de frecuencia de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_fracc_pago { get; set; }

        [DataMember(), JsonProperty()] public DateTime fec_vcto_poliza { get; set; }

        /// <summary>
        /// Fin de vigencia de la póliza grupo.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime? fec_vcto_poliza_grupo { get; set; }

        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> cod_marca { get; set; }
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> cod_tip_vehi { get; set; }

        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> PLAN_AUTO { get; set; }

        /// <summary>
        /// Suma asegurada de Responsabilidad Civil
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> IMP_AUTO_RC { get; set; }
        /// <summary>
        /// Suma asegurada de Gastos Médicos
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> IMP_AUTO_GMO { get; set; }
        /// <summary>
        /// Suma asegurada de Accidentes al conductor
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> IMP_AUTO_ACO { get; set; }
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> IMP_AUTO_NEUM { get; set; }
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> IMP_AUTO_MECA { get; set; }
        /// <summary>
        /// Suma asegurada de Rotura de Cristales
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> IMP_AUTO_CRI { get; set; }

        /// <summary>
        /// Deducible DEDUC_3001
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> DED_AUTO_RC { get; set; }
        /// <summary>
        /// Deducible PLAN_3004
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> DED_AUTO_CYV { get; set; }
        /// <summary>
        /// Deducible PLAN_3007
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> DED_AUTO_EQESP { get; set; }
        /// <summary>
        /// Deducible PLAN_3005
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> DED_AUTO_RAD { get; set; }
        /// <summary>
        /// Deducible PLAN_3006
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> DED_AUTO_ROB { get; set; }
        /// <summary>
        /// Deducible PLAN_3009
        /// </summary>
        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> DED_AUTO_CRI { get; set; }

        [DataMember(), JsonProperty()] public List<Architect.API.Core.Contracts.General.LookupValue> COD_TIP_COM_VEHI { get; set; }

    }
}
