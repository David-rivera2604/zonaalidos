using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Roles de seguridad.
    /// </summary>
    public static partial class CustomData
    {

        public static Architect.API.Core.Contracts.General.CustomDataResult CreateOrUpdateByEntityType(int companyId, int userId, Architect.API.Core.Contracts.General.CustomData item)
        {
            Architect.API.Core.Contracts.General.CustomData current = Architect.API.Core.Business.General.CustomData.RetrieveByEntity(item.EntityType, item.Key1);
            if (current == null)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                item.Id = current.Id;
                return Update(companyId, userId, current.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla CustomData.
        /// </summary>
        public static Architect.API.Core.Contracts.General.CustomDataResult Create(Core.Contracts.Security.Token token, int entityType, Int64 entityId, string data, string key1, string key2)
        {
            return Core.Business.General.CustomData.Create(token.CompanyId, token.UserId, new Core.Contracts.General.CustomData()
            {
                EntityType = entityType,
                EntityId = entityId,
                Data = data,
                Key1 = key1,
                Key2 = key2
            });
        }
        /// <summary>
        /// Recupera un registro en la tabla CustomData por medio de su identificador y tipo de entidad.
        /// </summary>
        public static Architect.API.Core.Contracts.General.CustomData RetrieveByEntity(int entityType, Int64 entityId, int companyId)
        {
            return Core.DataAccess.General.CustomData.Retrieve(entityType, entityId, companyId);
        }

        /// <summary>
        /// Recupera un registro en la tabla CustomData por medio de su identificador y tipo de entidad.
        /// </summary>
        public static Architect.API.Core.Contracts.General.CustomData RetrieveByEntity(int entityType, Int64 entityId)
        {
            return Core.DataAccess.General.CustomData.Retrieve(entityType, entityId);
        }

        public static bool Delete(int entityType, Int64 entityId)
        {
            return Core.DataAccess.General.CustomData.Delete(entityType, entityId) > 0;
        }


        public static Architect.API.Core.Contracts.General.CustomData RetrieveByEntity(int entityType, string key)
        {
            return Core.DataAccess.General.CustomData.Retrieve(entityType, key);
        }

    }
}
