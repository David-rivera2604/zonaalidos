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
    /// Información general de un riesgo. Este contrato representa la tabla principal o raíz que contiene la infomación del riesgo a ser evaluado.
    /// </summary>
    /// <remarks>VT.CERTIFICAT</remarks>
    public class Risk
    {
        /// <summary>
        /// Frecuencia de pago de la prima.
        /// </summary>
        /// <remarks>VT.CERTIFICAT.CERTIFICAT</remarks>
        public Int16 PaymentFrequencyCode { get; set; }

        /// <summary>
        /// Asegurado principal.
        /// </summary>
        /// <remarks>VT.ROLES</remarks>
        public Role PrimaryInsured { get; set; }

        /// <summary>
        /// Otros clientes.
        /// </summary>
        /// <remarks>VT.ROLES</remarks>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Monedas.
        /// </summary>
        /// <remarks>VT.CURREN_POL</remarks>    
        public List<Currency> Currencies { get; set; }

        /// <summary>
        /// Datos particulares.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        public ParticularData ParticularData { get; set; }

        /// <summary>
        /// Elementos de protección.
        /// </summary>
        /// <remarks>VT.PROTECTION</remarks>
        public List<Protection> Protections { get; set; }

        /// <summary>
        /// Módulos.
        /// </summary>
        /// <remarks>VT.MODULES</remarks>
        public List<Module> Modules { get; set; }

        /// <summary>
        /// Recibo o factura.
        /// </summary>
        /// <remarks>VT.PREMIUM</remarks>
        public Premium Premium { get; set; }

        /// <summary>
        /// Notificaciones.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        public List<General.Notify> Notify { get; set; }

        /// <summary>
        /// Tiempo consumido para el cálculo de coberturas
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("RatingTiming")]
        [DefaultValue(0)]
        public long RatingTiming { get; set; }

        /// <summary>
        /// Tiempo consumido para el cálculo del recibo
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("BillingTiming")]
        [DefaultValue(0)]
        public long BillingTiming { get; set; }

    }
}
