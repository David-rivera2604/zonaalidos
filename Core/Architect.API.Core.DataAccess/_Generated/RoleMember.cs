using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.Security
{
    /// <summary>
    /// Roles de seguridad.
    /// </summary>
    public sealed partial class RoleMember
    {

        /// <summary>
        /// Crea un registro en la tabla RoleMember.
        /// </summary>
        /// <param name="rolememberItem">Instancia de RoleMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.Security.RoleMember rolememberItem, IDbConnection connection = null)
        {
            if (rolememberItem.UpdateDate.IsEmpty())
            {
                rolememberItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO RoleMember (RoleId, CompanyId, RoleName, Description, SecurityLevel, InitialNavigationCode, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:RoleId, :CompanyId, :RoleName, :Description, :SecurityLevel, :InitialNavigationCode, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("RoleId", DbType.Decimal, 9, rolememberItem.RoleId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, rolememberItem.CompanyId)
                            .AddParameter("RoleName", DbType.AnsiString, 80, rolememberItem.RoleName)
                            .AddParameter("Description", DbType.AnsiString, 120, rolememberItem.Description)
                            .AddParameter("SecurityLevel", DbType.Decimal, 3, rolememberItem.SecurityLevel)
                            .AddParameter("InitialNavigationCode", DbType.AnsiStringFixedLength, 8, rolememberItem.InitialNavigationCode)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, rolememberItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, rolememberItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, rolememberItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla RoleMember.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="rolememberItems">Lista de instancia de RoleMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.Security.RoleMember> rolememberItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.RoleMember item in rolememberItems)
            {
                result.Add(Create(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="roleid">Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de RoleMember</returns>
        public static Architect.API.Core.Contracts.Security.RoleMember Retrieve(int roleid, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = null;
            Database.Select("SELECT RoleId, RoleMember.CompanyId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.InitialNavigationCode, RoleMember.RecordStatus, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " +
                              "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " +
                             "WHERE RoleMember.RoleId=:RoleId AND RoleMember.CompanyId=:CompanyId")
                        .AddParameter("RoleId", DbType.Decimal, 9, roleid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToRoleMember(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RoleMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de RoleMember</returns>
        public static List<Architect.API.Core.Contracts.Security.RoleMember> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.RoleMember> result = new List<Architect.API.Core.Contracts.Security.RoleMember>();
            Database.Select("SELECT RoleId, RoleMember.CompanyId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.InitialNavigationCode, RoleMember.RecordStatus, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " +
                              "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " +
                             "WHERE RoleMember.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRoleMember(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RoleMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de RoleMember</returns>
        public static List<Architect.API.Core.Contracts.Security.RoleMember> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.RoleMember> result = new List<Architect.API.Core.Contracts.Security.RoleMember>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }

            string filter1 = " AND ";
            filter1 += "(";
            filter1 += " UPPER(RoleMember.RoleName) LIKE :filter ";
            filter1 += " OR UPPER(RoleMember.Description) LIKE :filter ";
            filter1 += ")";


            Database.Select("SELECT * FROM (" +
                            "SELECT RoleId, RoleMember.CompanyId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.InitialNavigationCode, RoleMember.RecordStatus, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY RoleMember.RoleId DESC) RowNumber " +
                              "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " +
                             "WHERE RoleMember.CompanyId=:CompanyId" + filter1 +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(Database.ParameterList()
                            .AddParameter("filter", DbType.AnsiString, 80, "%" + filter.IfEmpty("").ToUpper() + "%")
                            .AddParameter("filter", DbType.AnsiString, 120, "%" + filter.IfEmpty("").ToUpper() + "%").Parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRoleMember(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento de la consulta para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="includeWhere">Indica que el complemento debe incluir el WHERE del comando.</param>
        /// <returns>Complemento de la consulta</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;

            if (filter.IsNotEmpty())
            {
                string condition = string.Empty;
                if (filter.IndexOf("|") > -1)
                {
                    condition = filter.Substring(filter.IndexOf("|"));
                    filter = filter.Substring(0, filter.IndexOf("|"));
                }
                if (includeWhere)
                {
                    result = " WHERE ";
                }
                else
                {
                    result = " AND ";
                }

                result += "(";
                result += " UPPER(RoleMember.RoleName) LIKE '%" + filter.ToUpper() + "%' ";
                result += " OR UPPER(RoleMember.Description) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
                if (condition.IsNotEmpty())
                {
                    result += Database.FilterFactory(condition, "RoleMember");
                }
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla RoleMember.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(RoleId),0) " +
                                     "FROM RoleMember")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="rolememberItem">Instancia de RoleMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.Security.RoleMember rolememberItem, IDbConnection connection = null)
        {
            if (rolememberItem.UpdateDate.IsEmpty())
            {
                rolememberItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE RoleMember " +
                                      "SET CompanyId=:CompanyId, RoleName=:RoleName, Description=:Description, SecurityLevel=:SecurityLevel, InitialNavigationCode=:InitialNavigationCode, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE RoleId=:RoleId")
                                .AddParameter("CompanyId", DbType.Decimal, 5, rolememberItem.CompanyId)
                                .AddParameter("RoleName", DbType.AnsiString, 80, rolememberItem.RoleName)
                                .AddParameter("Description", DbType.AnsiString, 120, rolememberItem.Description)
                                .AddParameter("SecurityLevel", DbType.Decimal, 3, rolememberItem.SecurityLevel)
                                .AddParameter("InitialNavigationCode", DbType.AnsiStringFixedLength, 8, rolememberItem.InitialNavigationCode)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, rolememberItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, rolememberItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, rolememberItem.UpdateDate)
                                .AddParameter("RoleId", DbType.Decimal, 9, rolememberItem.RoleId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="rolememberItems">Lista de instancia de RoleMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.Security.RoleMember> rolememberItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.RoleMember item in rolememberItems)
            {
                result.Add(Update(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="roleid">Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int roleid, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM RoleMember " +
                                    "WHERE RoleId=:RoleId AND CompanyId=:CompanyId")
                                .AddParameter("RoleId", DbType.Decimal, 9, roleid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="roleidList">Lista de Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> roleidList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in roleidList)
            {
                result.Add(Delete(item, companyId, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="roleid">Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int roleid, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(RoleId) " +
                                          "FROM RoleMember " +
                                         "WHERE RoleId=:RoleId AND CompanyId=:CompanyId")
                               .AddParameter("RoleId", DbType.Decimal, 9, roleid)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RoleMember que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(RoleId) " +
                                          "FROM RoleMember " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla RoleMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT RoleId, RoleName " +
                              "FROM RoleMember WHERE CompanyId=:CompanyId ORDER BY RoleName")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("RoleId"),
                                Description = reader.StringValue("RoleName")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'RoleMember'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.Security.RoleMember DataReaderToRoleMember(System.Data.IDataReader reader, Architect.API.Core.Contracts.Security.RoleMember item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.Security.RoleMember();
            }
            item.RoleId = reader.IntegerValue("RoleId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.RoleName = reader.StringValue("RoleName");
            item.Description = reader.StringValue("Description");
            item.SecurityLevel = reader.IntegerValue("SecurityLevel");
            item.InitialNavigationCode = reader.StringValue("InitialNavigationCode");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

        #region Custom Methods

        /// <summary>
        /// Recupera una lista para selección de la tabla RoleMember.
        /// </summary>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="securitylevel">Nivel de seguridad.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de RoleMember</returns>
        public static List<Architect.Utilities.Contracts.LookUpValue> LookUp(int companyid, int securitylevel, IDbConnection connection = null)
        {
            List<Architect.Utilities.Contracts.LookUpValue> result = new List<Architect.Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT RoleId, RoleName FROM RoleMember WHERE RoleMember.CompanyId=:CompanyId AND RoleMember.SecurityLevel<=:SecurityLevel ORDER BY RoleName")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, securitylevel)
                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                    result.Add(new Architect.Utilities.Contracts.LookUpValue()
                    {
                        Code = reader.StringValue("RoleId"),
                        Description = reader.StringValue("RoleName")
                    });
                }));
            return result;
        }

        #endregion  Custom Methods

    }

}

