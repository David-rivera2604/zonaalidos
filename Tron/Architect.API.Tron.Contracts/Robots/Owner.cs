using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Robots
{

    /// <summary>
    ///Calidad(es) del(os) Propietario(s)
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Tipo Identificación
        /// </summary>
        public string IdentificationType { get; set; }

        /// <summary>
        /// Número Identificación
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
    }

}