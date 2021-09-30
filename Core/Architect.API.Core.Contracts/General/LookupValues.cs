using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Lista de valores generica.
    /// </summary>
    public class LookupValues
    {
        /// <summary>
        /// Clave que identifica la lista.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Lista de valores.
        /// </summary>
        public List<LookupValue> Lkp { get; set; }
    }
}
