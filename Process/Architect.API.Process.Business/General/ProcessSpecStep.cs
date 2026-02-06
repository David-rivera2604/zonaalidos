using System;
using System.Collections.Generic;

namespace Architect.API.Process.Business.General
{
    /// <summary>
    /// Pasos o estados de un proceso.
    /// </summary>
    public static partial class ProcessSpecStep
    {
        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecStep.</returns>
        public static List<Architect.API.Process.Contracts.General.ProcessSpecStep> RetrieveFull(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Process.Contracts.General.ProcessSpecStep> result = Architect.API.Process.DataAccess.General.ProcessSpecStep.RetrieveFull(companyId, Architect.API.Process.DataAccess.General.ProcessSpecStep.FilterBuilderFull(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Process.Contracts.General.ProcessSpecStep item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

    }
}
