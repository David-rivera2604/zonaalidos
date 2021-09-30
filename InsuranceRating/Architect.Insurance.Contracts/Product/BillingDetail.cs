using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Recargos/Descuentos/Impuestos.
    /// </summary>
    /// <remarks>VT.DISCO_EXPR</remarks>
    public class BillingDetail
    {
        /// <summary>
        /// Código del recargo/descuento/impuesto. 
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.NDISEXPRC</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("code")]
        [DefaultValue(0)]
        public Int32 Code { get; set; }

        /// <summary>
        /// Descripción del recargo/descuento/impuesto. 
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Descripción abreviada o alias del recargo/descuento/impuesto. 
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("alias")]
        [DefaultValue("")]
        public string Alias { get; set; }

        /// <summary>
        /// Tipo de elemento recargo/descuento/impuesto.
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SDISEXPRI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("type")]
        [DefaultValue(0)]
        public Int32 Type { get; set; }

        /// <summary>
        /// Descripción del tipo de elemento recargo/descuento/impuesto.
        /// </summary>
        /// <remarks>VT.TABLE30.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("typedescription")]
        [DefaultValue("")]
        public string TypeDescription { get; set; }

        /// <summary>
        /// Indicador de seleccionado por defecto durante el tratamiento de pólizas.
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SDEFAULTI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("selected")]
        [DefaultValue(false)]
        public bool Selected { get; set; }

        /// <summary>
        /// Indicador que el recargo/descuento/impuesto es requerido. 
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SREQUIRE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("required")]
        [DefaultValue(false)]
        public bool Required { get; set; }

        /// <summary>
        /// Orden de aplicación/cálculo del recargo, descuento o impuesto.
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.NORDER_APL</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("order")]
        [DefaultValue(0)]
        public Int16 Order { get; set; }

        /// <summary>
        /// Rutina de cálculo y/o validación del monto/tasa de recargo/descuento/impuesto.
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SROUTINE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("routineforcalculation")]
        [DefaultValue("")]
        public string RoutineForCalculation { get; set; }

        /// <summary>
        /// Porcentaje del recargo. 
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.NRATE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("percentage")]
        [DefaultValue(0)]
        public decimal Percentage { get; set; }

        /// <summary>
        /// Monto fijo o a agregar de recargo/descuento.
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.NDISEXPRA</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("fixedamount")]
        [DefaultValue(0)]
        public decimal FixedAmount { get; set; }

        /// <summary>
        /// ...funcionalidad pendiente de ser detallada...
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("protectionelementbehavior")]
        [DefaultValue(false)]
        public bool ProtectionElementBehavior { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.DISCO_EXPR.SSTATREGT</remarks>
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
        /// Condiciones de cálculo de los recargos/descuentos/impuestos.
        /// </summary>
        /// <remarks>VT.DSEX_CONDI</remarks>
        public List<BillingDetailCondition> Conditions { get; set; }

        /// <summary>
        /// Uso interno. Establece una referencia al concepto de facturación.
        /// </summary>
        [IgnoreDataMember]
        [XmlIgnoreAttribute]
        public Product.BillingConcept BillingConcept { get; set; }

        /// <summary>
        /// Constructor por 'default'.
        /// </summary>
        public BillingDetail()
        {
            Status = 1;
        }
    }
}
