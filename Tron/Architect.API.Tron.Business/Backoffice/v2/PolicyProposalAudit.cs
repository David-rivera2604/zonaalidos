using System;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Registra la traza funcional de solicitudes de póliza sin incluir datos sensibles.
    /// </summary>
    public static class PolicyProposalAudit
    {
        private const int EntityType = 2100;

        /// <summary>
        /// Crea un evento de auditoría asociado a la clave técnica de una solicitud.
        /// </summary>
        /// <param name="proposal">Solicitud a la que pertenece el evento.</param>
        /// <param name="actor">Actor autenticado o cuenta técnica que ejecutó la acción.</param>
        /// <param name="action">Nombre funcional de la acción.</param>
        /// <param name="summary">Resumen que no puede contener secretos ni datos personales completos.</param>
        public static void Create(Contracts.PolicyProposal proposal, Core.Contracts.Security.Token actor, string action, string summary)
        {
            if (proposal == null || actor == null)
            {
                return;
            }

            // No se entrega la instantánea de la solicitud al motor genérico porque contiene datos personales.
            Core.Business.General.ChangeSet.Create(EntityType, proposal.Id, proposal.CompanyId, action, summary, actor.UserId,
                new { ProposalId = proposal.Id, Status = proposal.Status });
        }
    }
}
