using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Policy
{
    /// <summary>
    /// Monedas.
    /// </summary>
    /// <remarks>VT.CURREN_POL</remarks>    
    public class Currency
    {
        /// <summary>
        /// Código de la moneda.
        /// </summary>
        /// <remarks>VT.CURREN_POL.</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("currencycode")]
        [DefaultValue(0)]
        public Int16 CurrencyCode { get; set; }
    }
}
