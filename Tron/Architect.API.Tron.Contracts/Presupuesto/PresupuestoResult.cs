using System.Collections.Generic;

namespace Architect.API.Tron.Contracts.Presupuesto
{
    /// <summary>
    /// Clase para el resultado de operaciones de presupuestos
    /// </summary>
    public class PresupuestoResult
    {
        /// <summary>
        /// Indica si la operación fue exitosa
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje descriptivo del resultado de la operación
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Lista de errores de la operación
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public PresupuestoResult()
        {
            Errors = new List<Core.Contracts.General.Error>();
            Success = false;
            Message = string.Empty;
        }
    }
}
