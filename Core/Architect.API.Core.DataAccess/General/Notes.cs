using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Notas.
    /// </summary>
    public sealed partial class Notes
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla Notes por medio del tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns>Lista de instancias de Notes</returns>
        public static List<Architect.API.Core.Contracts.General.Notes> RetrieveByEntity(int entityType, Int64 entityId, int companyId)
        {
            return RetrieveAll(companyId,
                    " AND Notes.EntityType=:entityType AND Notes.EntityId=:entityId",
                    Database.ParameterList()
                        .AddParameter("EntityType", DbType.Double, 9, entityType)
                        .AddParameter("EntityId", DbType.Double, 18, entityId).Parameters, null);
        }

    }

}

