using Architect.DataFactory;
using System;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Archivos adjuntos.
    /// </summary>
    public static partial class AttachmentEx
    {

        /// <summary>
        /// Permite cambiar la entidad y su identificación a un grupo de adjuntos.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="entityType">Tipo de entidad actual.</param>
        /// <param name="entityId">Identificación de la entidad actual.</param>
        /// <param name="newEntityType">Tipo de entidad nueva.</param>
        /// <param name="newEntityId">Identificación de la entidad nueva.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(int companyId, int entityType, Int64 entityId, int newEntityType, Int64 newEntityId, int userId)
        {
            return Database.Update("UPDATE Attachments " +
                                      "SET EntityType=:NewEntityType, EntityId=:NewEntityId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE CompanyId=:CompanyId AND EntityType=:EntityType AND EntityId=:EntityId")
                                .AddParameter("NewEntityType", DbType.Decimal, 5, newEntityType)
                                .AddParameter("NewEntityId", DbType.Decimal, 18, newEntityId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, userId)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, DateTime.Now)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                                .AddParameter("EntityId", DbType.Decimal, 18, entityId)
                                .Execute(null, "Research");
        }



    }

}

