using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.General
{
    /// <summary>
    /// Notificaciones.
    /// </summary>
    /// <remarks>VT.NONE</remarks>
    public class Notify
    {
        /// <summary>
        /// Nivel de severidad
        /// </summary>
        public enum EnumSeverity
        {
            /// <summary>
            /// Indica que la notificación representa un mensaje
            /// </summary>
            Message,
            /// <summary>
            /// Indica que la notificación representa un error
            /// </summary>
            Error,
            /// <summary>
            /// Indica que la notificación representa una advertencia
            /// </summary>
            Warning
        }

        /// <summary>
        /// Severidad de la notificación.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("severity")]
        [DefaultValue(EnumSeverity.Message)]
        public EnumSeverity Severity { get; set; }

        /// <summary>
        /// Indentificación de la notificación.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("id")]
        [DefaultValue(0)]
        public Int32 Id { get; set; }

        /// <summary>
        /// Texto de la notificación.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("message")]
        [DefaultValue("")]
        public string Message { get; set; }
    }
}
