using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.EviSign
{
    /// <summary>
    /// firmantes del documento
    /// </summary>
    public class SigningParty
    {       
        /// <summary>
        /// Nombre completo de la persona que debe firmar el documento/contrato.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Dirección e-mail o número de teléfono del firmante, al cual se le remitirá la solicitud de firma.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Tipo de firma a solicitar. [Más información en el apartado "Ejemplos y más información de los parámetros"]
        /// </summary>
        /// <remarks>
        ///   Challenge: Desafío pregunta/respuesta. La operación se realiza si se responde correctamente a la pregunta planteada como desafío por el emisor.
        ///   EmailPin: Código de seguridad PIN enviado a email.La operación se realiza tras identificar al usuario que accede o firma, 
        ///             solicitando un PIN aleatorio enviado a su dirección de email.
        ///   Handwriting: Firma digitalizada.Firma manuscrita ditigalizada o firma biométrica dinámica (en tablet), según sea el dispositivo de captura.
        ///   MobilePin: Código de seguridad PIN enviado a móvil.La operación se realiza tras identificar al usuario que accede o firma, 
        ///              solicitando un PIN aleatorio enviado a su teléfono móvil.
        ///   WebClick: Click en web mediante enlace o localizador seguro. La operación se realiza si se conoce la referencia o localizador del mensaje.
        /// </remarks>
        public string SigningMethod { get; set; }
        
        ///// <summary>
        ///// El rol del firmante. Puede ser: Signer: Firmante, Reviewer: Revisor. Puede aceptar o rechazar el EviSign, pero no aparece como firmante.
        ///// </summary>
        //public string Role { get; set; }
    }

}
