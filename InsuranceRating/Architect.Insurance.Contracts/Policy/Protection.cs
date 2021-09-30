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
    /// Elementos de protección.
    /// </summary>
    /// <remarks>VT.PROTECTION</remarks>
    public class Protection
    {
        /// <summary>
        /// Código del elemento de protección. 
        /// </summary>
        /// <remarks>VT.PROTECTION.NELEMENT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("elementcode")]
        [DefaultValue(0)]
        public Int32 ElementCode { get; set; }

        /// <summary>
        /// Descripción del elemento de protección. 
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Código de la moneda.
        /// </summary>
        /// <remarks>VT.PROTECTION.NCURRENCY</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("currencycode")]
        [DefaultValue(0)]
        public Int16 CurrencyCode { get; set; }

        /// <summary>
        /// Monto de descuento por elemento de protección.
        /// </summary>
        /// <remarks>VT.PROTECTION.NDISCOUNT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("fixedamount")]
        [DefaultValue(0)]
        public decimal FixedAmount { get; set; }

        /// <summary>
        /// Porcentaje de descuento por elemento de protección. 
        /// </summary>
        /// <remarks>VT.PROTECTION.NDISRATE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("percentage")]
        [DefaultValue(0)]
        public decimal Percentage { get; set; }
        
    }
}
