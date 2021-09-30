using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Clientes permitidos.
    /// </summary>
    /// <remarks>VT.CLIALLOPRO</remarks>
    public class ClientAllowed
    {
        /// <summary>
        /// Figura con la que actúa el cliente en la póliza.
        /// </summary>
        /// <remarks>VT.CLIALLOPRO.NROLE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("clientrole")]
        [DefaultValue(0)]
        public Int32 ClientRole { get; set; }

        /// <summary>
        /// Indicador de seleccionado por defecto.
        /// </summary>
        /// <remarks>VT.CLIALLOPRO.SDEFAULTI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("selected")]
        [DefaultValue(false)]
        public bool Selected { get; set; }

        /// <summary>
        /// Indicador de que la figura es requerida.
        /// </summary>
        /// <remarks>VT.CLIALLOPRO.SREQUIRE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("required")]
        [DefaultValue(false)]
        public bool Required { get; set; }

        /// <summary>
        /// Cantidad máxima de clientes con esta figura.
        /// </summary>
        /// <remarks>VT.CLIALLOPRO.NMAX_ROLE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("maximumnumber")]
        [DefaultValue(0)]
        public Int32 MaximumNumber { get; set; }

        /// <summary>
        /// Estado del registro. 
        /// </summary>
        /// <remarks>VT.CLIALLOPRO.SSTATREGT</remarks>
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
        public ClientAllowed()
        {
            Status = 1;
        }

    }
}
