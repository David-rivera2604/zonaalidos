using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Policy
{
    /// <summary>
    /// Recibo o factura.
    /// </summary>
    /// <remarks>VT.PREMIUM</remarks>
    public class Premium
    {

        /// <summary>
        /// Monto de prima. 
        /// </summary>
        /// <remarks>VT.PREMIUM.NPREMIUM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("billpremium")]
        [DefaultValue(0)]
        public decimal BillPremium{ get; set; }


        /// <summary>
        /// Monto de prima anual. 
        /// </summary>
        /// <remarks>VT.X.X</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("annualpremium")]
        [DefaultValue(0)]
        public decimal AnnualPremium { get; set; }
        

        /// <summary>
        /// Detalle o desglose del recibo.
        /// </summary>
        /// <remarks>VT.DETAIL_PRE</remarks>
        public List<PremiumDetail> PremiumDetails { get; set; }
    }
}
