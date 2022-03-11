using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.Security
{
    public sealed partial class UserRoleMember
    {

        /// <summary>
        /// Crea un registro en la tabla UserRoleMember.
        /// </summary>
        /// <param name="userrolememberItem">Instancia de UserRoleMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int CreateCustom(Architect.API.Core.Contracts.Security.UserRoleMember userrolememberItem, IDbConnection connection = null)
        {
            if (userrolememberItem.UpdateDate.IsEmpty())
            {
                userrolememberItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("UserRoleMember", ExecuteMode.CommandBuilder)
                    .Column("CompanyId", DbType.Decimal, 5, userrolememberItem.CompanyId)
                    .Column("UserId", DbType.Decimal, 9, userrolememberItem.UserId)
                    .Column("RoleId", DbType.Decimal, 9, userrolememberItem.RoleId)
                    .Column("UpdateUserCode", DbType.Decimal, 9, userrolememberItem.UpdateUserCode)
                    .Column("UpdateDate", DbType.DateTime, 0, userrolememberItem.UpdateDate)
                    .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla UserRoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userrolememberItem">Instancia de UserRoleMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int UpdateCustom(Architect.API.Core.Contracts.Security.UserRoleMember userrolememberItem, IDbConnection connection = null)
        {
            if (userrolememberItem.UpdateDate.IsEmpty())
            {
                userrolememberItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UserRoleMember", ExecuteMode.CommandBuilder)
                    .Column("CompanyId", DbType.Decimal, 5, userrolememberItem.CompanyId)
                    .Column("UserId", DbType.Decimal, 9, userrolememberItem.UserId)
                    .Column("RoleId", DbType.Decimal, 9, userrolememberItem.RoleId)
                    .Column("UpdateUserCode", DbType.Decimal, 9, userrolememberItem.UpdateUserCode)
                    .Column("UpdateDate", DbType.DateTime, 0, userrolememberItem.UpdateDate)
                    .Filter("Id", DbType.Decimal, 9, userrolememberItem.Id)
                    .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla UserRoleMember.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="companyId"></param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de UserRoleMember</returns>
        public static List<Architect.API.Core.Contracts.Security.RoleMember> RetrieveLookByUserId(int userid, int companyId, IDbConnection connection = null)
        {
            var result = new List<Architect.API.Core.Contracts.Security.RoleMember>();
            Database.Select(@"SELECT UserRoleMember.RoleId, RoleMember.RoleName, RoleMember.InitialNavigationCode
                                FROM UserRoleMember
                           LEFT JOIN RoleMember ON RoleMember.RoleId=UserRoleMember.RoleId
                               WHERE UserId=:UserId AND UserRoleMember.CompanyId=:CompanyId
                            ORDER BY RoleMember.SecurityLevel DESC")
                        .AddParameter("UserId", DbType.Decimal, 9, userid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.Security.RoleMember() { RoleId = reader.IntegerValue("RoleId"), Description = reader.StringValue("RoleName"), InitialNavigationCode = reader.StringValue("InitialNavigationCode") });
                        }));
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla UserRoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByKey(int userId, int roleId, IDbConnection connection = null)
        {
            return Database.Delete("UserRoleMember", ExecuteMode.CommandBuilder)
                    .Filter("UserId", DbType.Decimal, 9,  userId)
                    .Filter("RoleId", DbType.Decimal, 9,  roleId)
                    .Execute(connection, "Research");
          
        }

        /// <summary>
        /// Elimina un registro en la tabla UserRoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByKey(int userId, IDbConnection connection = null)
        {
            return Database.Delete(@"DELETE FROM UserRoleMember 
                                           WHERE UserId=:UserId")
                             .AddParameter("UserId", DbType.Decimal, 9, userId) 
                             .Execute(connection, "Research"); 
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla UserRoleMember.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de UserRoleMember</returns>
        public static List<Architect.API.Core.Contracts.Security.UserRoleMember> RetrieveByUserId(int userid, int companyId, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.UserRoleMember> result = new List<Architect.API.Core.Contracts.Security.UserRoleMember>();
            Database.Select("SELECT Id, UserRoleMember.CompanyId, UserRoleMember.UserId, RoleId, UserRoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserRoleMember.UpdateDate " +
                              "FROM UserRoleMember LEFT JOIN UserMember um ON um.UserId = UserRoleMember.UpdateUserCode " +
                             "WHERE UserRoleMember.UserId=:UserId AND UserRoleMember.CompanyId=:CompanyId")
                        .AddParameter("UserId", DbType.Decimal, 9, userid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToUserRoleMember(reader));
                        }));
            return result;
        }
 
    }
}