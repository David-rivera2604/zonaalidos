using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product.Underwriting
{
    /// <summary>
    /// Define las condiciones para verfiicar si una póliza deeb tener procesos de suscripción.
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Condición.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Condición.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("condition")]
        [DefaultValue("")]
        public string Condition { get; set; }

    }
}
