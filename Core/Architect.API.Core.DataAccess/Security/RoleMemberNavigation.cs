using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.Security
{
    /// <summary>
    /// Navegación permitidas por rol de usuario..
    /// </summary>
    public sealed partial class RoleMemberNavigation
    {
        /// <summary>
        /// Recupera una lista simplifica de registros en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="code">Código que identifica el registro de navegación.</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> RetrieveLookUpByCode(int companyId, string code)
        {
            List<Utilities.Contracts.LookUpValue> roles = new List<Utilities.Contracts.LookUpValue>();
            List<Contracts.Security.RoleMemberNavigation> data = RetrieveByCode(companyId,  code);
            if (data.IsNotEmpty())
            {
                foreach (Contracts.Security.RoleMemberNavigation item in data)
                {
                    roles.Add(new Utilities.Contracts.LookUpValue() { Code = item.RoleId.ToString(), Description = item.RoleDesc });
                }
            }
            return roles;
        }


        ///// <summary>
        ///// Recupera una lista de registros en la tabla RoleMemberNavigation por medio del código de la página.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="code">Código que identifica el registro de navegación.</param>
        ///// <param name="connection">Instancia de una conexión compartida</param>
        ///// <returns>Lista de instancias de RoleMemberNavigation</returns>
        //public static List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> RetrieveByCode(int companyId, string code, IDbConnection connection = null)
        //{
        //    List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> result = new List<Architect.API.Core.Contracts.Security.RoleMemberNavigation>();
        //    Architect.API.Core.Contracts.Security.RoleMemberNavigation item = null;
        //    Database.Select(@"SELECT rmn.Id, rmn.CompanyId, rmn.RoleId, rm.RoleName RoleDesc,  rmn.Code, rmn.Allow, rmn.SecurityLevel, rmn.CreateAction, rmn.ReadAction, rmn.UpdateAction, rmn.DeleteAction, rmn.ListAction, rmn.PrintAction, rmn.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, rmn.UpdateDate 
        //                      FROM RoleMemberNavigation rmn
        //                      LEFT JOIN RoleMember rm ON rm.CompanyId=rmn.CompanyId AND rm.RoleId=rmn.RoleId 
        //                      LEFT JOIN UserMember um ON um.UserId = rmn.UpdateUserCode 
        //                     WHERE rmn.CompanyId=:CompanyId AND rmn.Code=:Code")
        //                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
        //                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, code)
        //                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
        //                {
        //                    item = DataReaderToRoleMemberNavigation(reader);
        //                    item.RoleDesc = reader.StringValue("RoleDesc");
        //                    result.Add(item);
        //                }));
        //    return result;
        //}
    }

}

