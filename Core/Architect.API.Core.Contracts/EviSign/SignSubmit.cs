using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Core.Contracts.EviSign
{
    /// <summary>
    /// Permite la remisión a EVICERTIA de un contrato EviSign 
    /// </summary>
    public class SignSubmit
    {

        /// <summary>
        /// Identificador [opcional] asignado por el usuario, que puede ser utilizado posteriormente para localizar una evidencia mediante el servicio web de consultas (Query)
        /// </summary>
        public string LookupKey { get; set; }
        /// <summary>
        /// Asunto del contrato que se va a enviar.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Documento o contrato a firmar por las partes (en formato PDF).
        /// </summary>
        public string Document { get; set; }
        /// <summary>
        /// Listado de firmantes del documento, con los siguientes datos por cada firmante
        /// </summary>
        public List<SigningParty> SigningParties { get; set; }
        /// <summary>
        /// Opciones de envío/procesamiento del mensaje
        /// </summary>
        public object Options { get; set; } = new object();

    }
}
