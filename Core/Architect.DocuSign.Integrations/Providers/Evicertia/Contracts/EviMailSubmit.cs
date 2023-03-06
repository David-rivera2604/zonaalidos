using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.DocuSign.Integrations.Providers.Evicertia.Contracts
{
    /// <summary>
    ///  Mensaje EviMail.
    /// </summary>
    public class EviMailSubmit
    {
        /// <summary>
        /// Identificador asignado por el usuario. Puede ser utilizado posteriormente para localizar una evidencia mediante el servicio web de consultas (Query).
        /// </summary>
        public string LookupKey { get; set; }
        /// <summary>
        /// Asunto del mensaje a enviar.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Cuerpo (en HTML) del mensaje a enviar.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Nombre o razón social del emisor del mensaje (pe. El nombre y NIF de la empresa emisora).
        /// </summary>
        public string IssuerName { get; set; }
        /// <summary>
        /// Datos relativos al destinatario del mensaje
        /// </summary>
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Lista [opcional] con los anexos del mensaje
        /// </summary>
        public List<Attachments> Attachments { get; set; }
        /// <summary>
        /// Opciones de envío/procesamiento del mensaje.
        /// </summary>
        public Options Options { get; set; }
    }
    /// <summary>
    /// Datos relativos al destinatario del mensaje
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Nombre o razón social del destinatario del mensaje (pe. El nombre y NIF de la empresa destinataria).
        /// </summary>
        public string LegalName { get; set; }
        /// <summary>
        /// Dirección e-mail del destinatario del mensaje.
        /// </summary>
        public string EmailAddress { get; set; }
    }
    /// <summary>
    /// Anexos del mensaje
    /// </summary>
    public class Attachments
    {
        public string UniqueId { get; set; }
        public string CreationDate { get; set; }
        public string EvidenceUniqueId { get; set; }
        /// <summary>
        /// Nombre del anexo.
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Nombre del fichero.
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// Contenido (bytes) del fichero a anexar.
        /// </summary>
        public string Data { get; set; }
    }
}
