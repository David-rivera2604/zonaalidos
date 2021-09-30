using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Monedas permitidas.
    /// </summary>
    /// <remarks>VT.CUR_ALLOW</remarks>
    public class CurrencyAllowed
    {
        /// <summary>
        /// Código de moneda.
        /// </summary>
        /// <remarks>VT.CUR_ALLOW.NCURRENCY</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("currencycode")]
        [DefaultValue(0)]
        public Int16 CurrencyCode { get; set; }

        /// <summary>
        /// Descripción de la moneda.
        /// </summary>
        /// <remarks>VT.TABLE11.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Indicador de seleccionado por defecto.
        /// </summary>
        /// <remarks>VT.CUR_ALLOW.SDEFAULTI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("selected")]
        [DefaultValue(false)]
        public bool Selected { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.CUR_ALLOW.SSTATREGT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("status")]
        [DefaultValue(1)]
        public Int16 Status { get; set; }

        /// <summary>
        /// Descripción del estado del registro. 
        /// </summary>
        /// <remarks>VT.TABLE26.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("statusdescription")]
        [DefaultValue("")]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Constructor por 'default'.
        /// </summary>
        public CurrencyAllowed()
        {
            Status = 1;
        }
    }
}
