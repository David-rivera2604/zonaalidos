using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Contracts.v2
{
    public class DatosTarjetaBase
    {
        /// <summary>
        /// Número Pan
        /// </summary>
        public string number { get; set; }
        //Descripción
        public string holder_name { get; set; }
        /// <summary>
        /// Mes de expiración Numérico
        /// </summary>
        public int expiry_month { get; set; }
        /// <summary>
        /// Año de expiración Numérico
        /// </summary>
        public int expiry_year { get; set; }
        /// <summary>
        /// Indicar tarjeta o cuenta
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// Indicar el tipo de tarjeta o tipo de cuenta
        /// </summary>
        public string typeMethod { get; set; }
    }
}
