using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{

    /// <summary>
    /// Condiciones de cálculo de los recargos/descuentos/impuestos.
    /// </summary>
    /// <remarks>VT.DSEX_CONDI</remarks>
    public class BillingDetailCondition
    {
        /// <summary>
        /// Código del módulo de la cobertura sobre la cual se aplica el rec/desc/imp. 
        /// </summary>
        /// <remarks>VT.DSEX_CONDI.NMODULEC</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("modulecode")]
        [DefaultValue(0)]
        public Int32 ModuleCode { get; set; }

        /// <summary>
        /// Tipo de registro sobre quien aplica el recargo/descuento/impuesto.
        /// </summary>
        /// <remarks>VT.DSEX_CONDI.NAPLICATION</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("applieson")]
        [DefaultValue(0)]
        public Int32 AppliesOn { get; set; }

        /// <summary>
        /// Código del elemento (recargo/dcto/impuesto/cobertura/capital básico) sobre el que aplica el recargo/dcto/impuesto registrado.
        /// </summary>
        /// <remarks>VT.DSEX_CONDI.NCODE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("applyoncode")]
        [DefaultValue(0)]
        public Int32 ApplyOnCode { get; set; }

        /// <summary>
        /// Figura con la que actúa el cliente en la póliza.
        /// </summary>
        /// <remarks>VT.DSEX_CONDI.NROLE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("clientrole")]
        [DefaultValue(0)]
        public Int32 ClientRole { get; set; }

        /// <summary>
        /// Porcentaje de recargo/descuento/impuesto.
        /// </summary>
        /// <remarks>VT.DSEX_CONDI.NRATE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("percentage")]
        [DefaultValue(0)]
        public decimal Percentage { get; set; }
    }
}
