using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Policy
{
    /// <summary>
    /// Módulos.
    /// </summary>
    /// <remarks>VT.MODULES</remarks>
    public class Module
    {
        /// <summary>
        /// Código del módulo de cobertura. 
        /// </summary>
        /// <remarks>VT.MODULES.</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("modulecode")]
        [DefaultValue(0)]
        public Int32 ModuleCode { get; set; }

        /// <summary>
        /// Descripción del módulo.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Coberturas.
        /// </summary>
        /// <remarks>VT.COVER</remarks>
        public List<Coverage> Coverages { get; set; }

    }
}
