using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Frecuencias de pago permitidas y recargo por fraccionamiento del pago.
    /// </summary>
    /// <remarks>VT.PAY_FRACTI</remarks>
    public class PaymentFrequencyAllowed
    {
        /// <summary>
        /// Frecuencia de pago de la prima.
        /// </summary>
        /// <remarks>VT.PAY_FRACTI.PAYFREQ</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("paymentfrequencycode")]
        [DefaultValue(0)]
        public Int16 PaymentFrequencyCode { get; set; }

        /// <summary>
        /// Descripción de la frecuencia de pago de la prima.
        /// </summary>
        /// <remarks>VT.TABLE36.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Porcentaje de recargo por fraccionamiento de pago. 
        /// </summary>
        /// <remarks>VT.PAY_FRACTI.NRATEPAYF</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("surchargerate")]
        [DefaultValue(0)]
        public decimal SurchargeRate { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.PAY_FRACTI.SSTATREGT</remarks>
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
        public PaymentFrequencyAllowed()
        {
            Status = 1;
        }
    }
}
