using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Navegación disponible.
    /// </summary>
    public static partial class Navigation
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Navigation</returns>
        public static List<Contracts.Security.NavAllowed> RetrieveNavigationAllowed(string roleNameList, int companyId)
        {
            List<Contracts.Security.NavAllowed> result = new List<Contracts.Security.NavAllowed>();
            Database.Select("SELECT DISTINCT nav.Sequence, nav.ParentCode, rn.Code, nav.Type, nav.MenuTitle, nav.Title, nav.Description, nav.URLPath, nav.SmallImage " +
                              "FROM RoleMember " +
                              "JOIN RoleMemberNavigation rn ON rn.RoleId=RoleMember.RoleId AND rn.CompanyId=RoleMember.CompanyId " +
                              "JOIN Navigation nav ON nav.Code=rn.Code AND nav.CompanyId=RoleMember.CompanyId AND nav.RecordStatus=1 " +
                             "WHERE RoleMember.CompanyId=:CompanyId AND RoleMember.RoleName IN (" + roleNameList + ") " +
                             "ORDER BY nav.Sequence")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Contracts.Security.NavAllowed()
                            {
                                ParentCode = reader.StringValue("ParentCode"), 
                                Code = reader.StringValue("Code"), 
                                Type = reader.IntegerValue("Type"), 
                                MenuTitle = reader.StringValue("MenuTitle"), 
                                Title = reader.StringValue("Title"), 
                                Description = reader.StringValue("Description"), 
                                URLPath = reader.StringValue("URLPath"), 
                                SmallImage = reader.StringValue("SmallImage")
                            });
                        }));
            return result;
        }

    }

}

