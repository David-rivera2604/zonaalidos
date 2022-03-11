using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// ProcessSpecStepRole
    /// </summary>
    public sealed partial class ProcessSpecStepRole
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="stepId">Identificación única del paso.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecStepRole</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> RetrieveByStepId(int stepId, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> result = new List<Architect.API.Core.Contracts.General.ProcessSpecStepRole>();
            Database.Select("SELECT Id, ProcessSpecStepRole.RoleId, rm.RoleName, ProcessSpecStepRole.CompanyId, ProcessSpecStepRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStepRole.UpdateDate " +
                              "FROM ProcessSpecStepRole" +
                             " LEFT JOIN UserMember um ON um.UserId = ProcessSpecStepRole.UpdateUserCode" +
                             " LEFT JOIN Rolemember rm ON rm.RoleId = ProcessSpecStepRole.RoleId" +
                            " WHERE ProcessSpecStepRole.Id=:StepId")
                        .AddParameter("StepId", DbType.Double, 9, stepId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.General.ProcessSpecStepRole()
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
        /// Elimina un registro en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="roleId">Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteWithRole(int id, int roleId, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecStepRole " +
                                    "WHERE Id=:Id AND RoleId=:RoleId AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("RoleId", DbType.Decimal, 9, roleId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }
    }

}

