using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Process.DataAccess.General
{
    /// <summary>
    /// ProcessSpecFlowRole
    /// </summary>
    public partial class ProcessSpecFlowRole
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlowRole.
        /// </summary>
        public static List<Architect.API.Process.Contracts.General.ProcessSpecFlowRole> RetrieveByStepId(int flowId, IDbConnection connection = null)
        {
            List<Architect.API.Process.Contracts.General.ProcessSpecFlowRole> result = new List<Architect.API.Process.Contracts.General.ProcessSpecFlowRole>();
            Database.Select("SELECT Id, ProcessSpecFlowRole.RoleId, rm.RoleName, ProcessSpecFlowRole.CompanyId, ProcessSpecFlowRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlowRole.UpdateDate " +
                              "FROM ProcessSpecFlowRole" +
                             " LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlowRole.UpdateUserCode" +
                             " LEFT JOIN Rolemember rm ON rm.RoleId = ProcessSpecFlowRole.RoleId" +
                            " WHERE ProcessSpecFlowRole.Id=:flowId")
                        .AddParameter("flowId", DbType.Double, 9, flowId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Process.Contracts.General.ProcessSpecFlowRole()
                            {
                                Id = reader.IntegerValue("Id"),
                                RoleId = reader.IntegerValue("RoleId"),
                                RoleName = reader.StringValue("RoleName"),
                                CompanyId = reader.IntegerValue("CompanyId"),
                                UpdateUserCode = reader.IntegerValue("UpdateUserCode"),
                                UpdateUserName = reader.StringValue("UpdateUserName"),
                                UpdateDate = reader.DateTimeValue("UpdateDate")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecFlowRole por medio de su clave primaria.
        /// </summary>
        public static int DeleteWithRole(int id, int roleId, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecFlowRole " +
                                    "WHERE Id=:Id AND RoleId=:RoleId AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("RoleId", DbType.Decimal, 9, roleId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }
    }

}

