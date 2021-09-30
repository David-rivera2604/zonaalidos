using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Policy
{
    /// <summary>
    /// Coberturas.
    /// </summary>
    /// <remarks>VT.COVER</remarks>
    public class Coverage
    {
        /// <summary>
        /// Código de la cobertura. 
        /// </summary>
        /// <remarks>VT.COVER.NCOVER</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("coveragecode")]
        [DefaultValue(0)]
        public Int32 CoverageCode { get; set; }

        /// <summary>
        /// Figura con la que actúa el cliente.
        /// </summary>
        /// <remarks>VT.COVER.NROLE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("clientrole")]
        [DefaultValue(0)]
        public Int32 ClientRole { get; set; }

        /// <summary>
        /// Descripción de la cobertura. 
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Indicador de seleccionado.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("selected")]
        [DefaultValue(false)]
        public bool Selected { get; set; }

        /// <summary>
        /// Código de moneda. 
        /// </summary>
        /// <remarks>VT.COVER.NCURRENCY</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("currencycode")]
        [DefaultValue(0)]
        public Int16 CurrencyCode { get; set; }

        /// <summary>
        /// Monto de capital asegurado de la cobertura. 
        /// </summary>
        /// <remarks>VT.COVER.NCAPITAL</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("insuredamount")]
        [DefaultValue(0)]
        public decimal InsuredAmount { get; set; }

        /// <summary>
        /// Tasa de cálculo de la prima de la cobertura. 
        /// </summary>
        /// <remarks>VT.COVER.NRATECOVE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("rate")]
        [DefaultValue(0)]
        public decimal Rate { get; set; }

        /// <summary>
        /// Monto de prima anual de la cobertura. 
        /// </summary>
        /// <remarks>VT.COVER.NPREMIUM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("premium")]
        [DefaultValue(0)]
        public decimal Premium { get; set; }

        /// <summary>
        /// Uso interno. Establece una referencia a la definicion de la covertura.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [IgnoreDataMember]
        [XmlIgnoreAttribute]
        public Product.Coverage CoverageDefinition { get; set; }

    }
}
