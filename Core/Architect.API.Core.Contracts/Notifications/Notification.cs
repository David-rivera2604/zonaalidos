using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.Notifications
{
    /// <summary>
    /// Notificacion del sistema dirigida a un usuario.
    /// Generica y reutilizable para todos los modulos.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class Notification
    {
        /// <summary>Identificacion unica del registro.</summary>
        [DataMember(), JsonProperty()] public int NotificationId { get; set; }
        /// <summary>Identificacion de la compania (multi-tenant).</summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>Usuario destinatario — el asignado o afectado por el evento.</summary>
        [DataMember(), JsonProperty()] public int UserId { get; set; }
        /// <summary>Titulo corto de la notificacion.</summary>
        [DataMember(), JsonProperty()] public string Title { get; set; }
        /// <summary>Cuerpo del mensaje.</summary>
        [DataMember(), JsonProperty()] public string Message { get; set; }
        /// <summary>Tipo de evento: PROCESS_REASSIGN, PAYMENT_FAILED, POLICY_ISSUED, etc.</summary>
        [DataMember(), JsonProperty()] public string Type { get; set; }
        /// <summary>Agrupacion visual: PROCESS, INSURANCE, PAYMENT, SYSTEM.</summary>
        [DataMember(), JsonProperty()] public string Category { get; set; }
        /// <summary>Tipo de entidad origen (1=Proceso, 2=Poliza, 3=Pago, 4=Firma).</summary>
        [DataMember(), JsonProperty()] public int EntityType { get; set; }
        /// <summary>Id de la entidad origen.</summary>
        [DataMember(), JsonProperty()] public long EntityId { get; set; }
        /// <summary>JSON libre para datos adicionales segun modulo.</summary>
        [DataMember(), JsonProperty()] public string Metadata { get; set; }
        /// <summary>Indica si el usuario ya leyo la notificacion.</summary>
        [DataMember(), JsonProperty()] public bool IsRead { get; set; }
        /// <summary>Fecha en que fue leida.</summary>
        [DataMember(), JsonProperty()] public DateTime? ReadAt { get; set; }
        [DataMember(), JsonProperty()] public int UpdateUserCode { get; set; }
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }
        [DataMember(), JsonProperty()] public DateTime CreatedAt { get; set; }
    }
}