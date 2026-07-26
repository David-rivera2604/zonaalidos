namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Niveles de profundidad para recuperar instancias de pasos.
    /// </summary>
    public enum StepRetrievalLevel
    {
        /// <summary>Solo el paso activo (iniciado y sin finalizar).</summary>
        ActiveOnly  = 1,
        /// <summary>Todos los pasos que han iniciado.</summary>
        AllStarted  = 2,
        /// <summary>Todos los pasos sin filtro de fechas.</summary>
        All         = 3
    }

    /// <summary>
    /// Modo de progreso de una etapa: como se completa en presencia de tareas.
    /// </summary>
    public enum StepProgressMode
    {
        /// <summary>Completar una tarea finaliza la etapa y cancela las restantes.</summary>
        SingleChoice  = 1,
        /// <summary>Todas las tareas deben completarse para finalizar la etapa.</summary>
        AllRequired   = 2
    }

    /// <summary>
    /// Modo de notificacion por correo (MailToContact / MailToStepResponsible).
    /// </summary>
    public enum MailNotificationMode
    {
        /// <summary>No enviar correo.</summary>
        Never    = 2,
        /// <summary>Siempre enviar correo.</summary>
        Always   = 1,
        /// <summary>Enviar solo cuando el usuario lo solicita explicitamente.</summary>
        OnDemand = 3
    }

    /// <summary>
    /// Tipo de tarea dentro de una etapa.
    /// </summary>
    public enum ProcessTaskType
    {
        /// <summary>Tarea de salto: el campo Action contiene el StepId destino.</summary>
        JumpToStep = 10
    }

    /// <summary>
    /// Estados terminales de una etapa que cierran toda la instancia del proceso.
    /// </summary>
    public enum TerminalProcessStatus
    {
        Finalizado = 3,
        Cerrado    = 6,
        Aprobado   = 7,
        Rechazado  = 8,
        Terminado  = 90
    }

    /// <summary>
    /// Constantes generales del motor de procesos.
    /// </summary>
    public static class ProcessDefaults
    {
        /// <summary>Indica que no hay caso asociado (crear uno nuevo).</summary>
        public const int NoCaseId = 0;

        /// <summary>Indica que no hay actividad (sistema / anonimo).</summary>
        public const int SystemUserId = 0;

        /// <summary>Usar el servidor de correo por defecto del flujo.</summary>
        public const int DefaultMailServer = 1;

        /// <summary>Usar la plantilla de correo configurada en AppSettings.</summary>
        public const int DefaultMailTemplate = 1;

        /// <summary>Porcentaje de progreso completo.</summary>
        public const int FullProgress = 100;

        /// <summary>Limite inferior del rango de estado "Iniciado" (1-10).</summary>
        public const int StatusStartedMax = 10;

        /// <summary>Valor de estado asignado al entrar en "En progreso".</summary>
        public const int StatusInProgress = 11;

        /// <summary>Limite desde el cual el estado se considera "Finalizado" (>= 90).</summary>
        public const int StatusFinishedMin = 90;
    }
}