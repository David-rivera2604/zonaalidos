using System.Collections.Generic;
using System.Data;
using Architect.Common.Extensions;
using Architect.Common.Proxy;

namespace Architect.API.Core.DataAccess.Security
{
    public sealed partial class UserRoleMember
    {


        /// <summary>
        /// Recupera una lista de registros en la tabla UserRoleMember.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="companyId"></param>
        /// <returns>Lista de instancias de UserRoleMember</returns>
        public static List<Utilities.Contracts.LookUpValue> RetrieveByUserId(int userid, int companyId)
        {
            DataTable rows = null;
            var result = new List<Utilities.Contracts.LookUpValue>();
            {
                var withBlock = new DataManagerFactory("SELECT UserRoleMember.RoleId, RoleMember.RoleName " + "FROM UserRoleMember " + "LEFT JOIN RoleMember ON RoleMember.RoleId=UserRoleMember.RoleId " + "WHERE UserId=@:UserId AND UserRoleMember.CompanyId=@:CompanyId", "UserRoleMember", "Research");
                withBlock.AddParameter("UserId", DbType.Decimal, 9, false, userid);
                withBlock.AddParameter("CompanyId", DbType.Decimal, 5, false, companyId);
                rows = withBlock.QueryExecuteToTable(true);
                if (rows.IsNotEmpty() && rows.Rows.Count != 0)
                {
                    Utilities.Contracts.LookUpValue item = null;
                    foreach (DataRow itemRow in rows.Rows)
                    {
                        item = new Utilities.Contracts.LookUpValue() { Code = itemRow.StringValue("RoleId"), Description = itemRow.StringValue("RoleName") };
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla UserRoleMember.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="companyId"></param>
        /// <returns>Lista de instancias de UserRoleMember</returns>
        public static List<Contracts.Security.UserRoleMember> Retrieve(int userid, int companyId)
        {
            DataTable rows = null;
            var result = new List<Contracts.Security.UserRoleMember>();
            {
                var withBlock = new DataManagerFactory("SELECT UserRoleMember.UserId, RoleId, UserRoleMember.CompanyId, UserRoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserRoleMember.UpdateDate " + "FROM UserRoleMember LEFT JOIN UserMember um ON um.UserId = UserRoleMember.UpdateUserCode " + "WHERE UserRoleMember.UserId=@:UserId AND UserRoleMember.CompanyId=@:CompanyId", "UserRoleMember", "Research");
                withBlock.AddParameter("UserId", DbType.Decimal, 9, false, userid);
                withBlock.AddParameter("CompanyId", DbType.Decimal, 5, false, companyId);
                rows = withBlock.QueryExecuteToTable(true);
                if (rows.IsNotEmpty() && rows.Rows.Count != 0)
                {
                    foreach (DataRow itemRow in rows.Rows)
                        result.Add(UserRoleMember.DataRowMapper(itemRow));
                }
            }

            return result;
        }


        /// <summary>
        /// Elimina un registro en la tabla UserRoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByKey(int userId, int roleId)
        {
            int rows = 0;
            {
                var withBlock = new DataManagerFactory("DELETE FROM UserRoleMember " + "WHERE UserId=@:UserId AND RoleId=@:RoleId", "UserRoleMember", "Research");
                withBlock.AddParameter("UserId", DbType.Decimal, 9, false, userId);
                withBlock.AddParameter("RoleId", DbType.Decimal, 9, false, roleId);
                rows = withBlock.CommandExecute();
            }

            return rows;
        }

        /// <summary>
        /// Elimina un registro en la tabla UserRoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByKey(int userId)
        {
            int rows = 0;
            {
                var withBlock = new DataManagerFactory("DELETE FROM UserRoleMember " + "WHERE UserId=@:UserId", "UserRoleMember", "Research");
                withBlock.AddParameter("UserId", DbType.Decimal, 9, false, userId);
                rows = withBlock.CommandExecute();
            }

            return rows;
        }
    }
}