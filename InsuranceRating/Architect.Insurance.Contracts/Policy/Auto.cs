using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Policy
{
    /// <summary>
    /// Datos particulares del ramo de automóvil.
    /// </summary>
    /// <remarks>VT.AUTO</remarks>
    public class Auto : Interfaces.IParticularData
    {
        /// <summary>
        /// Año de fabricación del vehículo. 
        /// </summary>
        /// <remarks>VT.AUTO.NYEAR</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("yearofmanufactured")]
        [DefaultValue(0)]
        public Int16 YearOfManufactured { get; set; }

        /// <summary>
        /// Código del vehículo asegurado. 
        /// </summary>
        /// <remarks>VT.AUTO.SVEHCODE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("vehiclecode")]
        [DefaultValue("")]
        public string VehicleCode { get; set; }

        /// <summary>
        /// Monto de capital asegurado. 
        /// </summary>
        /// <remarks>VT.AUTO.NCAPITAL</remarks>
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
