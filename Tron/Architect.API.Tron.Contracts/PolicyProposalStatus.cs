namespace Architect.API.Tron.Contracts
{
    /// <summary>
    /// Define los estados reutilizados del ciclo de vida de una solicitud de póliza.
    /// </summary>
    public static class PolicyProposalStatus
    {
        /// <summary>Solicitud guardada como borrador editable por agente o empleado.</summary>
        public const int Incompleta = 1;

        /// <summary>Solicitud enviada al asegurado para complementar datos.</summary>
        public const int PendientePorComplementos = 5;

        /// <summary>Solicitud congelada mientras se prepara o reintenta el envío a firma.</summary>
        public const int PendientePorFirma = 6;

        /// <summary>Solicitud aceptada por el proveedor y pendiente de firma.</summary>
        public const int PorAceptar = 4;

        /// <summary>Firma confirmada y solicitud disponible para emisión automática.</summary>
        public const int ParaEmitir = 33;

        /// <summary>Solicitud reclamada por el emisor técnico o pendiente de revisión de Mapfre.</summary>
        public const int EnRevisionPorMapfre = 34;

        /// <summary>Póliza emitida exitosamente.</summary>
        public const int Alta = 10;

        /// <summary>Firma no completada antes de su vencimiento.</summary>
        public const int DeclinadaPorExpiracion = 31;

        /// <summary>Firma rechazada por el firmante.</summary>
        public const int Rechazada = 32;
    }
}
