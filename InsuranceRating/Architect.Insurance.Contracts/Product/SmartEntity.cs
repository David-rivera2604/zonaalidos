using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Define la forma en que se busca una tarifa en una tabla.
    /// </summary>
    public class SmartEntity
    {
        /// <summary>
        /// Indica el comportamiento en modo offline.
        /// </summary>
        public enum EnumOfflineBehavior
        {
            /// <summary>
            /// No tiene comportamiento offline.
            /// </summary>
            none,
            /// <summary>
            /// Se comporta únicamente offline.
            /// </summary>
            Only,
            /// <summary>
            /// El comportamiento es mixto.
            /// </summary>
            Mix
        }

        /// <summary>
        /// Identificación de la definición.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("id")]
        [DefaultValue("")]
        public string Id { get; set; }

        /// <summary>
        /// Nombre de la entidad o tabla que contiene la tarifa.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("entity")]
        [DefaultValue("")]
        public string Entity { get; set; }

        /// <summary>
        /// Indica que la información de la tarifa tiene compotameinto historico por medio de fecha de efecto.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("ishistorical")]
        [DefaultValue(true)]
        public bool IsHistorical { get; set; }

        /// <summary>
        /// Condición de busqueda de la tarifa.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("filter")]
        [DefaultValue("")]
        public string Filter { get; set; }

        /// <summary>
        /// Tasa de cálculo de la prima de la cobertura.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("rate")]
        [DefaultValue("")]
        public string Rate { get; set; }

        /// <summary>
        /// Monto de prima fija o monto a agregar a la prima.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("fixpremium")]
        [DefaultValue("")]
        public string FixPremium { get; set; }

        /// <summary>
        /// Define la lista de dependencia hacia propiedades del modelo.
        /// </summary>
        /// <remarks>
        /// Esta lista permite deteminar las propiedades que son requeridas para poder obtener la tarifa.
        /// </remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("requirements")]
        [DefaultValue("")]
        public string Requirements { get; set; }

        /// <summary>
        /// Indica que la tabla ha sido extradida y debe ser usado de forma offline.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("extracted")]
        [DefaultValue(false)]
        public bool Extracted { get; set; }

        // Requisitos: Auto.VehicleCode
        // tabla: TAR_AUTO
        // Filtro: nBranch = {0} AND nProduct = {1} AND nModulec = {2} AND nCover = {3} AND nCurrency = {4} AND sVehcode = {5}
        // Historical? = AND dEffecDate <= '{0}' AND (dNullDate IS NULL OR  dNullDate > '{0}'
        // Rate: TAR_AUTO.NRATE
        // Complement: TAR_AUTO.NPREM_FIX
        // Premium: (InsuredAmount * TAR_AUTO.NRATE/ 1000) + TAR_AUTO.NPREM_FIX
    }
}
