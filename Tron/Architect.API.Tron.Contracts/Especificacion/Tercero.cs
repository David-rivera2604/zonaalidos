using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Especificacion
{
    /// <summary>
    ///  Información de terceros
    /// </summary>
    public class Tercero
    {

        /// <summary>
        ///  Forma en la que interviene
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
        ///  Direccion de correo electronico
        /// </summary>
        public string email { get; set; }

        /// <summary>
        ///  Número de telefono
        /// </summary>
        public string tlf_numero { get; set; }

        /// <summary>
        ///  Pais, primer nivel de la estructura geografica
        /// </summary>
        public string cod_pais { get; set; }

        /// <summary>
        ///  Segundo nivel de la estructura geografica
        /// </summary>
        public int cod_estado { get; set; }

        /// <summary>
        ///  Tercer nivel de la estructura geografica
        /// </summary>
        public int cod_prov { get; set; }

        /// <summary>
        ///  Cuarto nivel de la estructura geografica
        /// </summary>
        public int cod_localidad { get; set; }

        /// <summary>
        ///  Domicilio (primera linea)
        /// </summary>
        public string nom_domicilio1 { get; set; }

    }
}
