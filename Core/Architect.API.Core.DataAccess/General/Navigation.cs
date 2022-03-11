using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Navegación disponible.
    /// </summary>
    public sealed partial class Navigation
    {

        /// <summary>
        /// Recupera un registro en la tabla Navigation por medio ruta física de la página.
        /// </summary>
        /// <param name="urlPath">Ruta física de la página a ser ejecutada.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Navigation</returns>
        public static Architect.API.Core.Contracts.General.Navigation RetrieveByURLPath(string urlPath, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Navigation result = null;
            Database.Select("SELECT NavigationId, Code FROM Navigation " +
                             "WHERE Navigation.CompanyId=:CompanyId AND LOWER(URLPath)=:URLPath")                             
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("URLPath", DbType.AnsiString, 255, urlPath.ToLower())
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Architect.API.Core.Contracts.General.Navigation()
                            {
                                NavigationId = reader.IntegerValue("NavigationId"),
                                Code = reader.StringValue("Code")
                            };
                        }));
            return result;
        }

        /// <summary>
        /// Permite recuperar un registra de navegación por medio del campo código.
        /// </summary>
        /// <param name="code">Código que identifica el registro de navegación.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Navigation</returns>
        public static Contracts.General.Navigation RetrieveByCode(string code, int companyId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId, " AND CODE=:CODE",
                    Database.ParameterList()
                            .AddParameter("Code", DbType.AnsiStringFixedLength, 8, code).Parameters, connection).FirstOrDefault();
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Navigation.
        /// </summary>
        /// <param name="roleNameList"></param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
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


        /// <summary>
        /// Recupera una lista de registros en la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Navigation</returns>
        public static List<Contracts.General.Navigation> RetrieveCustom(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Navigation> result = new List<Architect.API.Core.Contracts.General.Navigation>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT NavigationId, Navigation.CompanyId, ParentCode, Code, Type, Title, Description, MenuTitle, URLPath, URLHelp, SmallImage, BigImage, Sequence, Navigation.RecordStatus, Navigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Navigation.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Navigation.Sequence ASC) RowNumber " +
                              "FROM Navigation LEFT JOIN UserMember um ON um.UserId = Navigation.UpdateUserCode " +
                             "WHERE Navigation.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToNavigation(reader));
                        }));
            return result;
        }

    }

}

