using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Requests
{
    /// <summary>
    /// Permite realizar cobros sin la intervención del usuario usando medios de pago previamente suscritos.
    /// </summary>
    internal class Collect
    {

        /// <summary>
        /// Estructura que contiene la información de autenticación del sitio generada de acuerdo al WSSE UsernameToken Profile 1.1
        /// </summary>
        public Auth auth { get; set; }

        /// <summary>
        /// Datos del usuario pagador, hace referencia al dueño del medio de pago o usuario que pagó el monto solicitado.
        /// </summary>
        //public Person payer { get; set; }

        /// <summary>
        /// Información del pago solicitado.
        /// </summary>
        public PaymentRequest payment { get; set; }

        /// <summary>
        /// Estructura que contiene la información acerca del medio de pago a usar en una transacción, esta estructura es variable de acuerdo a la solicitud que se genere, cada servicio requiere que se usen unos u otros datos.
        /// </summary>
        public Instrument instrument { get; set; }

        /// <summary>
        /// Idioma en el que se tratará la petición y la sesión
        /// </summary>
        public string locale { get; set; }


        public DateTime expiration { get; set; }
        public string returnUrl { get; set; }

        /// <summary>
        /// Dirección IP del usuario que realizará el proceso.
        /// </summary>
        public string ipAddress { get; set; }
        /// <summary>
        /// User Agent del navegador del usuario que realizará el proceso.
        /// </summary>
        public string userAgent { get; set; }

    }
}
