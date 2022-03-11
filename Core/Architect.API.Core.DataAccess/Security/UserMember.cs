using Architect.DataFactory;
using System;
using System.Data;

namespace Architect.API.Core.DataAccess.Security
{
    public sealed partial class UserMember
    {
        ///// <summary>
        ///// Recupera una lista de registros en la tabla UserMember.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="filter">Filtro personalizado.</param>
        ///// <param name="recordStatus"></param>
        ///// <returns>Lista de instancias de UserMember</returns>
        //public static List<Contracts.Security.UserMember> RetrieveAll(int companyId, int securityLevel, string filter, string recordStatus, IDbConnection connection = null)
        //{
        //    List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
        //    Database.Select(@"SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate,
        //                            (SELECT LISTAGG(RM.ROLENAME , ', ') WITHIN GROUP (ORDER BY RM.ROLENAME )
        //                       FROM USERROLEMEMBER urm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = urm.RoleId WHERE urm.UserId = UserMember.UserId) Roles
        //                       FROM UserMember LEFT JOIN UserMember um ON um.UserId = UserMember.UpdateUserCode
        //                      WHERE UserMember.CompanyId=:CompanyId AND UserMember.SecurityLevel<=:SecurityLevel" + BuildFilter(filter, recordStatus))
        //                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
        //                .AddParameter("SecurityLevel", DbType.Decimal, 3, securityLevel)
        //                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
        //                {
        //                    Architect.API.Core.Contracts.Security.UserMember item = DataReaderToUserMember(reader);
        //                    item.RoleList = reader.StringValue("Roles");
        //                    result.Add(item);
        //                }));
        //    return result;
        //}

        //public static string BuildFilter(string filter, string recordStatus)
        //{
        //    string result = string.Empty;
        //    if (filter.IsNotEmpty())
        //    {
        //        result = " AND (UPPER(UserMember.UserName) LIKE '%" + filter.ToUpper() + "%' " + "OR UPPER(UserMember.FirstName) LIKE '%" + filter.ToUpper() + "%' " + "OR UPPER(UserMember.LastName) LIKE '%" + filter.ToUpper() + "%' " + "OR UPPER(UserMember.EMail) LIKE '%" + filter.ToUpper() + "%') ";
        //    }

        //    if (recordStatus.IsNotEmpty())
        //    {
        //        result = " AND UserMember.RecordStatus IN (" + recordStatus + ") ";
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// Recupera una lista con la información de correo electrónico de los usuario asociados a un rol.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="roleName">Nombre del rol usando para filtrar la lista</param>
        ///// <returns>Lista de instancias de UserMember</returns>
        //public static List<Contracts.Security.UserMember> EmailInfoByRoleName(int companyId, string roleName, IDbConnection connection = null)
        //{
        //    List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
        //    roleName += ",,,";

        //    Database.Select(Properties.Resources.UserMember_EmailInfoByRoleName)
        //        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
        //        .AddParameter("RoleName1", DbType.AnsiString, 80, roleName.Split(',')[0].Trim().ToLower())
        //        .AddParameter("RoleName2", DbType.AnsiString, 80, roleName.Split(',')[1].Trim().ToLower())
        //        .AddParameter("RoleName3", DbType.AnsiString, 80, roleName.Split(',')[2].Trim().ToLower())
        //        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
        //        {
        //            result.Add(new Contracts.Security.UserMember()
        //            {
        //                EMail = reader.StringValue("EMail"),
        //                FirstName = reader.StringValue("FirstName"),
        //                LastName = reader.StringValue("LastName")
        //            });
        //        }));
        //    return result;
        //}

        /// <summary>
        /// Último valor asignado a clave única de la tabla UserMember.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKeyCustom(IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(MAX(UserId),0) " +
                                     "FROM UserMember WHERE UserId < 999999000")
                                .QueryScalar<Decimal>(connection, "Research");
        }
    }
}