using System;
using System.Xml.Serialization;

namespace Architect.API.Tron.Contracts.Presupuesto
{
    /// <summary>
    ///  Riesgos del presupuesto (P2000031)
    /// </summary>
    public partial class Riesgo
    {
        /// <summary>
        ///  Código de compañía
        /// </summary>
        public int cod_cia { get; set; }

        /// <summary>
        ///  Poliza
        /// </summary>
        public string num_poliza { get; set; }

        /// <summary>
        ///  Número de suplemento
        /// </summary>
        public int num_spto { get; set; }

        /// <summary>
        ///  Número de aplicación
        /// </summary>
        public int num_apli { get; set; }

        /// <summary>
        ///  Suplemento de la aplicacion
        /// </summary>
        public int num_spto_apli { get; set; }

        /// <summary>
        ///  Efecto del riesgo
        /// </summary>
        public DateTime fec_efec_riesgo { get; set; }

        /// <summary>
        ///  Vencimiento del riesgo
        /// </summary>
        public DateTime fec_vcto_riesgo { get; set; }

        /// <summary>
        ///  El riesgo esta dado de baja
        /// </summary>
        public string mca_baja_riesgo { get; set; }

        /// <summary>
        ///  Fila vigente
        /// </summary>
        public string mca_vigente { get; set; }

        /// <summary>
        ///  No se usa
        /// </summary>
        public string mca_exclusivo { get; set; }

        /// <summary>
        ///  Riesgo
        /// </summary>
        public int num_riesgo { get; set; }

        /// <summary>
        ///  Descripcion del riesgo
        /// </summary>
        public string nom_riesgo { get; set; }

        /// <summary>
        ///  Tipo de suplemento
        /// </summary>
        public string tip_spto { get; set; }

        /// <summary>
        ///  Modalidad de vida
        /// </summary>
        public int cod_modalidad { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string cod_usr_exclsivo { get; set; }

        /// <summary>
        ///  Número del certificado
        /// </summary>
        public int num_certificado { get; set; }

        /// <summary>
        ///  Descripcion del certificado (salud)
        /// </summary>
        public string nom_certificado { get; set; }

        /// <summary>
        ///  No usa
        /// </summary>
        [XmlIgnore]
        public string cod_usr_exclusivo { get; set; }

    }
}