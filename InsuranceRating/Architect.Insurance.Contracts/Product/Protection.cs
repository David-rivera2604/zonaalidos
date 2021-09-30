using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Elementos de protección.
    /// </summary>
    /// <remarks>VT.TAB_PROTEC</remarks>
    public class Protection
    {
        /// <summary>
        /// Código del elemento de protección. 
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.NELEMENT</remarks>
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
        /// Descripción abreviada o alias del elemento de protección. 
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.SSHORT_DES</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("alias")]
        [DefaultValue("")]
        public string Alias { get; set; }

        /// <summary>
        /// Código de moneda.
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.NCURRENCY</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("currencycode")]
        [DefaultValue(0)]
        public Int16 CurrencyCode { get; set; }

        /// <summary>
        /// Monto de descuento por elemento de protección.
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.NDISCOUNT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("fixedamount")]
        [DefaultValue(0)]
        public decimal FixedAmount { get; set; }

        /// <summary>
        /// Porcentaje de descuento por elemento de protección. 
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.NDISRATE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("percentage")]
        [DefaultValue(0)]
        public decimal Percentage { get; set; }

        /// <summary>
        /// Monto máximo de descuento a aplicar. 
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.NDISMAXIM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("minimum")]
        [DefaultValue(0)]
        public decimal Minimum { get; set; }

        /// <summary>
        /// Monto mínimo de descuento a aplicar.
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.NDISMININ</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("maximum")]
        [DefaultValue(0)]
        public decimal Maximum { get; set; }

        /// <summary>
        /// ...funcionalidad pendiente de ser detallada...
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("billingcode")]
        [DefaultValue(0)]
        public Int32 BillingCode { get; set; }

        /// <summary>
        /// ...funcionalidad pendiente de ser detallada...
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("billingdetailcode")]
        [DefaultValue(0)]
        public Int32 BillingDetailCode { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.TAB_PROTEC.SSTATREGT</remarks>
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
        public Protection()
        {
            Status = 1;
        }
    }
}
