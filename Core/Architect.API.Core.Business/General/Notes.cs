using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Notas.
    /// </summary>
    public static partial class Notes
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla Notes por medio del tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns>Lista de instancias de Notes</returns>
        public static List<Contracts.General.Notes> RetrieveByEntity(int entityType, Int64 entityId, int companyId)
        {
            return Core.DataAccess.General.Notes.RetrieveByEntity(entityType, entityId, companyId).OrderBy(s => s.Id).ToList();
        }

    }
}
