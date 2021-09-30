using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Conceptos de facturación.
    /// </summary>
    /// <remarks>VT.TAB_BILL_I</remarks>
    public class BillingConcept
    {
        /// <summary>
        /// Código del concepto de facturación.
        /// </summary>
        /// <remarks>VT.TAB_BILL_I.NBILL_ITEM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("billingcode")]
        [DefaultValue(0)]
        public Int32 BillingCode { get; set; }

        /// <summary>
        /// Descripción del concepto de facturación. 
        /// </summary>
        /// <remarks>VT.TAB_BILL_I.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Descripción abreviada o alias del concepto de facturación. 
        /// </summary>
        /// <remarks>VT.TAB_BILL_I.SSHORT_DES</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("alias")]
        [DefaultValue("")]
        public string Alias { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.TAB_BILL_I.SSTATREGT</remarks>
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
        /// Recargos/Descuentos/Impuestos.
        /// </summary>
        /// <remarks>VT.DISCO_EXPR</remarks>
        public List<BillingDetail> Details { get; set; }

        /// <summary>
        /// Constructor por 'default'.
        /// </summary>
        public BillingConcept()
        {
            Status = 1;
        }
    }
}
