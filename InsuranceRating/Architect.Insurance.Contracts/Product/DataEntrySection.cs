using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Secuencia de ventanas para el tratamiento de póliza.
    /// </summary>
    /// <remarks>VT.SEQUEN_POL</remarks>
    public class DataEntrySection
    {

        /// <summary>
        /// Código identificativo de la sección.
        /// </summary>
        /// <remarks>VT.SEQUEN_POL.SCODISPL</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("code")]
        [DefaultValue("")]
        public string Code { get; set; }

        /// <summary>
        /// Descripción de la sección.
        /// </summary>
        /// <remarks>VT.SEQUEN_POL.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Indicador de requerimiento del módulo.
        /// </summary>
        /// <remarks>VT.SEQUEN_POL.SREQUIRE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("required")]
        [DefaultValue(false)]
        public bool Required { get; set; }
    }
}
