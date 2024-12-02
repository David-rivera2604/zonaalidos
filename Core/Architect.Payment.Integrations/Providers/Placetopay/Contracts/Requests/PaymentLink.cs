using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Providers.Placetopay.Contracts.Requests
{
    internal class PaymentLink
    {
        /// <summary>
        /// Estructura que contiene la información de autenticación del sitio generada de acuerdo al WSSE UsernameToken Profile 1.1
        /// </summary>
        public Auth auth { get; set; }
        /// <summary>
        /// Idioma en que sera enviado el link de pago a través de email || Si este campo no se envia el locale se asignara "es" por defecto
        /// </summary>
        public string locale { get; set; }
        /// <summary>
        /// Nombre que sera asociado al link de pago
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Cantidad de pagos que se podran realizar a través del link || Si este campo no se envia, el link quedara configurado con una cantidad ilimitada de pagos permitidos
        /// </summary>
        public int paymentsAllowed { get; set; }
        /// <summary>
        /// Fecha en que el link dejara de estar activo (La fecha debe ser superior a la fecha actual del usuario)
        /// </summary>
        public DateTime expirationDate { get; set; }
        /// <summary>
        /// Cantidad en minutos del tiempo para cada sesion de Checkout
        /// </summary>
        public int paymentExpiration { get; set; }
        /// <summary>
        /// Moneda en que se realizara el cobro del link
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Monto total que tendrá pago que se realizara a través del link
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// Referencia que sera asociada al link
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// Descripcion asociada al link de pago
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Lista de correos a los que sera enviado el link una vez que se haya creado correctamente
        /// </summary>
        public string[] receiverEmails { get; set; }
        /// <summary>
        /// Campos adicionales para link de pago
        /// </summary>
        public Additional additional { get; set; }

    }
    internal class Additional
    {
        public string name { get; set; }
    }

}