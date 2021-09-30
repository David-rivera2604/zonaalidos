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
    /// Clientes.
    /// </summary>
    /// <remarks>VT.ROLES</remarks>
    public class Role
    {
        /// <summary>
        /// Figura con la que actúa el cliente.
        /// </summary>
        /// <remarks>VT.ROLES.NROLE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("clientrole")]
        [DefaultValue(0)]
        public Int32 ClientRole { get; set; }

        /// <summary>
        /// Fecha de nacimiento del cliente.
        /// </summary>
        /// <remarks>VT.ROLES.DBIRTHDATE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("clientrole")]
        public DateTime BirthDate { get; set; }
    }
}
