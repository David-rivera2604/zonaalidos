using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Vías de pago permitidas.
    /// </summary>
    /// <remarks>VT.WAY_PAY_PROD</remarks>
    public class PaymentMethodAllowed
    {
        /// <summary>
        /// Código de la vía de pago.
        /// </summary>
        /// <remarks>VT.WAY_PAY_PROD.NWAY_PAY</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("paymentwaycode")]
        [DefaultValue(0)]
        public Int16 PaymentMethodCode { get; set; }

        /// <summary>
        /// Descripción de la vía de pago.
        /// </summary>
        /// <remarks>VT.TABLE5002.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Porcentaje de recargo por vía de pago. 
        /// </summary>
        /// <remarks>VT.WAY_PAY_PROD.NRATE_EX</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("surchargerate")]
        [DefaultValue(0)]
        public decimal SurchargeRate { get; set; }

        /// <summary>
        /// Porcentaje de descuento por vía de pago.
        /// </summary>
        /// <remarks>VT.WAY_PAY_PROD.NRATE_DISC</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("discountrate")]
        [DefaultValue(0)]
        public decimal DiscountRate { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.WAY_PAY_PROD.SSTATREGT</remarks>
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
        public PaymentMethodAllowed()
        {
            Status = 1;
        }
    }
}
