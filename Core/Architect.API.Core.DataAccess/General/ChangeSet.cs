using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public sealed partial class ChangeSet
    {

        public static List<Contracts.General.ChangeSetView> RetrieveByEntity(int entityType, long entityId, int companyId, string filter, IDbConnection connection = null)
        {
            DataTable rows = null;
            var result = new List<Contracts.General.ChangeSetView>();
            string condition = " AND EntityId=:EntityId";
            if (entityId.IsEmpty())
            {
                condition = string.Empty;
            }

            {
                List<DataFactory.Contracts.Parameter> parameters = new List<DataFactory.Contracts.Parameter>();


                parameters.Add(new DataFactory.Contracts.Parameter { Name = "EntityType", Type = DbType.Decimal, Size = 5, Value = entityType, direction = ParameterDirection.Input });
                if (entityId.IsNotEmpty())
                {
                    parameters.Add(new DataFactory.Contracts.Parameter { Name = "EntityId", Type = DbType.Decimal, Size = 9, Value = entityId, direction = ParameterDirection.Input });
                }
                parameters.Add(new DataFactory.Contracts.Parameter { Name = "CompanyId", Type = DbType.Decimal, Size = 5, Value = companyId, direction = ParameterDirection.Input });

                Database.Select(@"SELECT Id, Action, Summary, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate 
                                    FROM ChangeSet 
                               LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode 
                                   WHERE EntityType=:EntityType" + condition + BuildFilter(filter) + " AND ChangeSet.companyId=:companyId ORDER BY Id DESC")
                            .AddParameter(parameters)
                            .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                            {
                                result.Add(DataRowMapperView(reader));
                            }));
            }

            return result;
        }

        private static Contracts.General.ChangeSetView DataRowMapperView(System.Data.IDataReader reader)
        {
            return new Contracts.General.ChangeSetView()
            {
                Id = (int)Math.Round(reader.NumericValue("Id")),
                Action = reader.StringValue("Action"),
                Summary = reader.StringValue("Summary"),
                UpdateUserCode = (int)Math.Round(reader.NumericValue("UpdateUserCode")),
                UpdateUserName = reader.StringValue("UpdateUserName"),
                UpdateDate = reader.DateTimeValue("UpdateDate")
            };
        }

        public static string BuildFilter(string filter)
        {
            string result = string.Empty;
            if (filter.IsNotEmpty())
            {
                result = " AND UPPER(ChangeSet.Summary) LIKE '%" + filter.ToUpper() + "%' ";
            }

            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla ChangeSet.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static Int64 RetrieveLastEntityId(int entityType, int companyId, IDbConnection connection = null)
        {

            return (Int64)Database.Select("SELECT NVL(MAX(EntityId),0) " +
                                          "FROM ChangeSet" +
                                        " WHERE companyId =:companyId AND EntityType=:EntityType")
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                                .QueryScalar<Decimal>(connection, "Research");
        }
    }
}