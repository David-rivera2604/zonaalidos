namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Código y descripción usado para lista genericas.
    /// </summary>
    public class LookupValue : Architect.Utilities.Helpers.Expando
    {
        /// <summary>
        /// Código.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descripción.
        /// </summary>
        public string Description { get; set; }
    }
}
