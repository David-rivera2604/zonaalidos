using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Identifica los flujos de completado aprobados en servidor.
    /// El identificador impide que una ruta de navegador amplíe por sí sola los permisos de la sesión técnica.
    /// </summary>
    public static class CompletionFlow
    {
        /// <summary>Flujo que permite completar una solicitud de póliza previamente almacenada.</summary>
        public const string PolicyProposal = "PolicyProposal";

        /// <summary>
        /// Determina si un flujo pertenece al catálogo de flujos aprobados por la aplicación.
        /// </summary>
        /// <param name="completionFlow">Código de flujo que se desea asociar a la invitación.</param>
        /// <returns><c>true</c> solo para flujos registrados explícitamente.</returns>
        public static bool IsKnown(string completionFlow)
        {
            return string.Equals(completionFlow, PolicyProposal, StringComparison.Ordinal);
        }
    }
}
