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
    public static partial class RoleMemberNavigation
    {
        /// <summary>
        /// Recupera una lista simplifica de registros en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
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
                    roles.Add(new Utilities.Contracts.LookUpValue() { Code = item.RoleId.ToString() });
                }
            }
            return roles;
        }


        /// <summary>
        /// Recupera una lista de registros en la tabla RoleMemberNavigation por medio del código de la página.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="code">Código que identifica el registro de navegación.</param>
        /// <returns>Lista de instancias de RoleMemberNavigation</returns>
        public static List<Contracts.Security.RoleMemberNavigation> RetrieveByCode(int companyId, string code)
        {
            return RetrieveAll(companyId,
                                " AND RoleMemberNavigation.Code=:Code",
                    Database.ParameterList().AddParameter("Code", DbType.AnsiStringFixedLength, 8, code).Parameters, null);
        }


    }

}

