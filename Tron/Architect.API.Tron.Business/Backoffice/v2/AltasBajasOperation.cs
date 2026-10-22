namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Identifica la acción de servidor autorizada por una solicitud de altas o bajas antes de realizar efectos persistentes.
    /// </summary>
    public enum AltasBajasOperation
    {
        /// <summary>Emite una póliza mediante el flujo de alta.</summary>
        Issue,

        /// <summary>Aplica el flujo de cancelación a una póliza existente.</summary>
        Cancel,

        /// <summary>Guarda una solicitud y envía al asegurado una invitación restringida de completado.</summary>
        SendInvitation,

        /// <summary>Guarda un borrador sin emitir ni cancelar una póliza.</summary>
        Draft,
        /// <summary>Envía una solicitud completa al proveedor de firma electrónica.</summary>
        SendSignature,

        /// <summary>Confirma los datos definitivos entregados por el asegurado invitado.</summary>
        Complete
    }

    /// <summary>
    /// Resuelve los modos del cliente en una acción explícita para que un alta no siga accidentalmente la ruta de baja.
    /// </summary>
    public static class AltasBajasOperationResolver
    {
        /// <summary>
        /// Determina la única operación que el endpoint puede ejecutar con el indicador de alta o baja y el modo suministrado.
        /// </summary>
        /// <param name="alta"><c>true</c> para una solicitud de alta; <c>false</c> para una cancelación.</param>
        /// <param name="mode">Modo opcional reconocido únicamente para solicitudes de alta.</param>
        /// <returns>Operación explícita que conserva la semántica de baja, emisión, borrador, firma e invitación.</returns>
        public static AltasBajasOperation Resolve(bool alta, string mode)
        {
            if (!alta)
            {
                return AltasBajasOperation.Cancel;
            }

            switch (mode)
            {
                case "SendLink":
                    return AltasBajasOperation.SendInvitation;
                case "Draft":
                    return AltasBajasOperation.Draft;
                case "SendSignature":
                    return AltasBajasOperation.SendSignature;
                case "Complete":
                    return AltasBajasOperation.Complete;
                case "Issue":
                default:
                    return AltasBajasOperation.Issue;
            }
        }
    }
}
