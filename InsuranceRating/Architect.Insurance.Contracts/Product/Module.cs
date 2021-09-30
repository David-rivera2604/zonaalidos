using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Módulos.
    /// </summary>
    /// <remarks>VT.TAB_MODUL</remarks>
    public class Module
    {
        /// <summary>
        /// Código del módulo de cobertura.
        /// </summary>
        /// <remarks>VT.TAB_MODUL.NMODULEC</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("modulecode")]
        [DefaultValue(0)]
        public Int32 ModuleCode { get; set; }

        /// <summary>
        /// Descripción del módulo.
        /// </summary>
        /// <remarks>VT.TAB_MODUL.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Descripción abreviada o alias del módulo. 
        /// </summary>
        /// <remarks>VT.TAB_MODUL.SSHORT_DES</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("alias")]
        [DefaultValue("")]
        public string Alias { get; set; }

        /// <summary>
        /// Indicador de seleccionado por defecto.
        /// </summary>
        /// <remarks>VT.TAB_MODUL.SDEFAULTI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("selected")]
        [DefaultValue(false)]
        public bool Selected { get; set; }

        /// <summary>
        /// Indicador de requerimiento del módulo.
        /// </summary>
        /// <remarks>VT.TAB_MODUL.SREQUIRE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("required")]
        [DefaultValue(false)]
        public bool Required { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.TAB_MODUL.SSTATREGT</remarks>
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
        /// Coberturas.
        /// </summary>
        /// <remarks>VT.GEN_COVER,VT.TAB_COVROL,VT.LIFE_COVER</remarks>
        public List<Coverage> Coverages { get; set; }

        /// <summary>
        /// Constructor por 'default'.
        /// </summary>
        public Module()
        {
            Status = 1;
        }

    }
}
