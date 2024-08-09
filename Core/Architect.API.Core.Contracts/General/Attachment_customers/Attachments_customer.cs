using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Contracts.General.Attachment_customers
{
    /// <summary>
    /// Documentos a ser asociados a una póliza.
    /// </summary>
    public class Attachments_customer
    {
        /// <summary>
        /// Número de póliza que se relaciona con los documentos.
        /// </summary>
        public string entity_id { get; set; }
        /// <summary>
        /// Lista de documentos.
        /// </summary>
        public Attachment_customer[] attachments_list { get; set; }
    }
}
