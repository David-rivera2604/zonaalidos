using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Tareas vinculadas a un paso o estado de un proceso.
    /// </summary>
    public static partial class ProcessSpecTask
    {
       
        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecTask.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecTask> RetrieveFull(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecTask> result = Architect.API.Core.DataAccess.General.ProcessSpecTask.RetrieveFull(companyId, Architect.API.Core.DataAccess.General.ProcessSpecTask.FilterBuilderFull(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecTask item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }


        private static bool Rule_IsFinishStep(int companyId, int stepId)
        {
            bool result = false;
            Architect.API.Core.Contracts.General.ProcessSpecStep step = DataAccess.General.ProcessSpecStep.Retrieve(stepId, companyId);

            if (step?.ProcessStatus == 3 ||
                step?.ProcessStatus == 6 ||
                step?.ProcessStatus == 7 ||
                step?.ProcessStatus == 8 ||
                step?.ProcessStatus == 90)
            {
                result = true;
            }
            return result;
        }
    }
}
