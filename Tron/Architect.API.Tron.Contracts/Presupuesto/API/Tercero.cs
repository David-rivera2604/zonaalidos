using System;
using System.Xml.Serialization;

namespace Architect.API.Tron.Contracts.Presupuesto.API
{
    /// <summary>
    ///  Terceros del presupuesto (P2000060)
    /// </summary>
    public class Tercero
    {

        /// <summary>
        ///  Forma en la que interviene.
        /// </summary>
        public string tip_benef { get; set; }

        /// <summary>
        ///  Tipo del documento del tercero
        /// </summary>
        public string tip_docum { get; set; }

        /// <summary>
        ///  Documento del tercero
        /// </summary>
        public string cod_docum { get; set; }

        /// <summary>
        ///  Nombre del tercero
        /// </summary>
        public string nom_tercero { get; set; }

        /// <summary>
        ///  Primer apellido del tercero
        /// </summary>
        public string ape1_tercero { get; set; }

        /// <summary>
        ///  Segundo apellido del tercero
        /// </summary>
        public string ape2_tercero { get; set; }

        /// <summary>
        ///  Fecha de nacimiento
        /// </summary>
        public DateTime fec_nacimiento { get; set; }

        /// <summary>
        ///  Sexo
        /// </summary>
        public string mca_sexo { get; set; }

        /// <summary>
        ///  Estado civil
        /// </summary>
        public string cod_est_civil { get; set; }

        /// <summary>
        ///  Numero de teléfono
        /// </summary>
        public string tlf_numero { get; set; }

        /// <summary>
        ///  País, primer nivel de la estructura geográfica
        /// </summary>
        public string cod_pais { get; set; }

        /// <summary>
        ///  Segundo nivel de la estructura geográfica
        /// </summary>
        public int cod_estado { get; set; }

        /// <summary>
        ///  Tercer nivel de la estructura geográfica
        /// </summary>
        public int cod_prov { get; set; }

        /// <summary>
        ///  Cuarto nivel de la estructura geográfica
        /// </summary>
        public int cod_localidad { get; set; }

        /// <summary>
        ///  Domicilio (primera linea)
        /// </summary>
        public string nom_domicilio1 { get; set; }

        /// <summary>
        ///  Dirección de correo electrónico
        /// </summary>
        public string email { get; set; }

    }
}