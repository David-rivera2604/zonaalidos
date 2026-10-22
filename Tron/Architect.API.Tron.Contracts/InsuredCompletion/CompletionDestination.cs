using System;

namespace Architect.API.Tron.Contracts.InsuredCompletion
{
    /// <summary>
    /// Valida el destino interno que se conserva para una invitación de completado.
    /// El destino nunca contiene secretos y no puede sacar al navegador del portal actual.
    /// </summary>
    public static class CompletionDestination
    {
        /// <summary>Longitud máxima compatible con la columna Oracle que conserva el destino.</summary>
        public const int MaximumLength = 512;

        /// <summary>
        /// Verifica y devuelve una ruta relativa interna, incluidos sus parámetros de consulta cuando existan.
        /// </summary>
        /// <param name="completionPath">Ruta relativa creada por el flujo servidor que emite la invitación.</param>
        /// <returns>La misma ruta relativa, sin espacios exteriores.</returns>
        /// <exception cref="ArgumentException">Se produce cuando el valor no representa un destino interno seguro.</exception>
        public static string Validate(string completionPath)
        {
            if (string.IsNullOrWhiteSpace(completionPath))
            {
                throw new ArgumentException("Debe indicar el destino relativo de completado.", nameof(completionPath));
            }

            string value = completionPath.Trim();
            if (value.Length > MaximumLength ||
                !value.StartsWith("/", StringComparison.Ordinal) ||
                value.StartsWith("//", StringComparison.Ordinal) ||
                value.IndexOf('#') >= 0 ||
                value.IndexOf('\\') >= 0 ||
                value.IndexOf('\r') >= 0 ||
                value.IndexOf('\n') >= 0 ||
                Uri.IsWellFormedUriString(value, UriKind.Absolute))
            {
                throw new ArgumentException("El destino debe ser una ruta relativa segura.", nameof(completionPath));
            }

            return value;
        }
    }
}
