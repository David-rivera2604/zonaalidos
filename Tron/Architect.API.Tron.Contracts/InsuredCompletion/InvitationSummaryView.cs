using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Resume una invitación para seguimiento interno sin exponer secretos ni sesiones.
    /// </summary>
    public sealed class InvitationSummaryView
    {
        /// <summary>Identificador técnico de la invitación.</summary>
        public int Id { get; set; }
        /// <summary>Estado de la invitación.</summary>
        public InvitationStatus Status { get; set; }
        /// <summary>Fecha UTC de creación.</summary>
        public DateTime CreatedAtUtc { get; set; }
        /// <summary>Fecha UTC de vencimiento.</summary>
        public DateTime ExpiresAtUtc { get; set; }
        /// <summary>Fecha UTC de completado, si aplica.</summary>
        public DateTime? CompletedAtUtc { get; set; }
        /// <summary>Fecha UTC de anulación, si aplica.</summary>
        public DateTime? RevokedAtUtc { get; set; }
        /// <summary>Cantidad de envíos asociados a la invitación.</summary>
        public int SendCount { get; set; }
        /// <summary>Correo enmascarado para evitar exponer información personal.</summary>
        public string RecipientEmailMasked { get; set; }
    }
}
