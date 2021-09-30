using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Policy
{
    /// <summary>
    /// Datos particulares del ramo de vida.
    /// </summary>
    /// <remarks>VT.LIFE</remarks>
    public class Life : Interfaces.IParticularData
    {
        /// <summary>
        /// Monto de capital asegurado. 
        /// </summary>
        /// <remarks>VT.LIFE.NCAPITAL</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("insuredamount")]
        [DefaultValue(0)]
        public decimal InsuredAmount { get; set; }

        /// <summary>
        /// Monto complemento del capital asegurado. 
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("insuredamountcomplement")]
        [DefaultValue(0)]
        public decimal InsuredAmountComplement { get; set; }

    }
}
