using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Permite definir variables especificas para un producto.
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Nombre de la variable.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("name")]
        [DefaultValue("")]
        public string Name { get; set; }

        /// <summary>
        /// Descripción de la variable.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Valor asignado a la variable. 
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("value")]
        [DefaultValue("")]
        public string Value { get; set; }

    }
}
