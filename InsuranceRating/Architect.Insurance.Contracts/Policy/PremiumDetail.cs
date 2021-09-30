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
    /// Detalle o desglose del recibo.
    /// </summary>
    /// <remarks>VT.DETAIL_PRE</remarks>
    public class PremiumDetail
    {
        /// <summary>
        /// Concepto de facturación. 
        /// </summary>
        /// <remarks>VT.DETAIL_PRE.NBILL_ITEM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("billingcode")]
        [DefaultValue(0)]
        public Int32 BillingCode { get; set; }

        /// <summary>
        /// Tipo de elemento recargo/descuento/impuesto.
        /// </summary>
        /// <remarks>VT.DETAIL_PRE.STYPE_DETAI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("type")]
        [DefaultValue(0)]
        public Int32 Type { get; set; }

        /// <summary>
        /// Código del elemento (cobertura) al cual se registra detalle. 
        /// </summary>
        /// <remarks>VT.DETAIL_PRE.NDET_CODE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("coveragecode")]
        [DefaultValue(0)]
        public Int32 CoverageCode { get; set; }

        /// <summary>
        /// Código del elemento (recargo/descuento/impuesto) al cual se registra detalle. 
        /// </summary>
        /// <remarks>VT.DETAIL_PRE.NDET_CODE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("code")]
        [DefaultValue(0)]
        public Int32 Code { get; set; }

        /// <summary>
        /// Monto de capital asegurado. 
        /// </summary>
        /// <remarks>VT.DETAIL_PRE.NCAPITAL</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("insuredamount")]
        [DefaultValue(0)]
        public decimal InsuredAmount { get; set; }

        /// <summary>
        /// Porcentaje aplicado.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("percentage")]
        [DefaultValue(0)]
        public decimal Percentage { get; set; }

        /// <summary>
        /// Monto de prima (incluido en la factura). 
        /// </summary>
        /// <remarks>VT.DETAIL_PRE.NPREMIUM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("premium")]
        [DefaultValue(0)]
        public decimal Premium { get; set; }

        /// <summary>
        /// Prima anual.
        /// </summary>
        /// <remarks>VT.DETAIL_PRE.NPREMANUAL</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("annualpremium")]
        [DefaultValue(0)]
        public decimal AnnualPremium { get; set; }

        /// <summary>
        /// Descripción del concepto de facturación. 
        /// </summary>
        /// <remarks>VT.TAB_BILL_I.SDESCRIPT</remarks>
        //Deberan ser eliminadas
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("billingdescription")]
        [DefaultValue("")]
        public string BillingDescription { get; set; }

        /// <summary>
        /// Descripción del recargo/descuento/impuesto. 
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("sourcedescription")]
        [DefaultValue("")]
        public string SourceDescription { get; set; }

        /// <summary>
        /// Descripción del tipo de elemento recargo/descuento/impuesto.
        /// </summary>
        /// <remarks>VT.TABLE30.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("typedescription")]
        [DefaultValue("")]
        public string TypeDescription { get; set; }
    }
}
