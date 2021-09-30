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
        /// Crea un registro en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="rolemembernavigationItem">Instancia de RoleMemberNavigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.Security.RoleMemberNavigation rolemembernavigationItem, IDbConnection connection = null)
        {
            if (rolemembernavigationItem.UpdateDate.IsEmpty())
            {
                rolemembernavigationItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO RoleMemberNavigation (Id, CompanyId, RoleId, Code, Allow, SecurityLevel, CreateAction, ReadAction, UpdateAction, DeleteAction, ListAction, PrintAction, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :RoleId, :Code, :Allow, :SecurityLevel, :CreateAction, :ReadAction, :UpdateAction, :DeleteAction, :ListAction, :PrintAction, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, rolemembernavigationItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, rolemembernavigationItem.CompanyId)
                            .AddParameter("RoleId", DbType.Decimal, 9, rolemembernavigationItem.RoleId)
                            .AddParameter("Code", DbType.AnsiStringFixedLength, 8, rolemembernavigationItem.Code)
                            .AddParameter("Allow", DbType.Decimal, 1, rolemembernavigationItem.Allow ? 1 : 0)
                            .AddParameter("SecurityLevel", DbType.Decimal, 3, rolemembernavigationItem.SecurityLevel)
                            .AddParameter("CreateAction", DbType.Decimal, 1, rolemembernavigationItem.CreateAction ? 1 : 0)
                            .AddParameter("ReadAction", DbType.Decimal, 1, rolemembernavigationItem.ReadAction ? 1 : 0)
                            .AddParameter("UpdateAction", DbType.Decimal, 1, rolemembernavigationItem.UpdateAction ? 1 : 0)
                            .AddParameter("DeleteAction", DbType.Decimal, 1, rolemembernavigationItem.DeleteAction ? 1 : 0)
                            .AddParameter("ListAction", DbType.Decimal, 1, rolemembernavigationItem.ListAction ? 1 : 0)
                            .AddParameter("PrintAction", DbType.Decimal, 1, rolemembernavigationItem.PrintAction ? 1 : 0)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, rolemembernavigationItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, rolemembernavigationItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla RoleMemberNavigation.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="rolemembernavigationItems">Lista de instancia de RoleMemberNavigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> rolemembernavigationItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.RoleMemberNavigation item in rolemembernavigationItems)
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
        /// Recupera un registro en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de RoleMemberNavigation</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberNavigation Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.RoleMemberNavigation result = null;
            Database.Select("SELECT Id, RoleMemberNavigation.CompanyId, RoleId, Code, Allow, RoleMemberNavigation.SecurityLevel, CreateAction, ReadAction, UpdateAction, DeleteAction, ListAction, PrintAction, RoleMemberNavigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMemberNavigation.UpdateDate " +
                              "FROM RoleMemberNavigation LEFT JOIN UserMember um ON um.UserId = RoleMemberNavigation.UpdateUserCode " +
                             "WHERE RoleMemberNavigation.Id=:Id AND RoleMemberNavigation.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToRoleMemberNavigation(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de RoleMemberNavigation</returns>
        public static List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> result = new List<Architect.API.Core.Contracts.Security.RoleMemberNavigation>();
            Database.Select("SELECT Id, RoleMemberNavigation.CompanyId, RoleId, Code, Allow, RoleMemberNavigation.SecurityLevel, CreateAction, ReadAction, UpdateAction, DeleteAction, ListAction, PrintAction, RoleMemberNavigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMemberNavigation.UpdateDate " +
                              "FROM RoleMemberNavigation LEFT JOIN UserMember um ON um.UserId = RoleMemberNavigation.UpdateUserCode " +
                             "WHERE RoleMemberNavigation.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRoleMemberNavigation(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de RoleMemberNavigation</returns>
        public static List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> result = new List<Architect.API.Core.Contracts.Security.RoleMemberNavigation>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, RoleMemberNavigation.CompanyId, RoleId, Code, Allow, RoleMemberNavigation.SecurityLevel, CreateAction, ReadAction, UpdateAction, DeleteAction, ListAction, PrintAction, RoleMemberNavigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMemberNavigation.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY RoleMemberNavigation.Id DESC) RowNumber " +
                              "FROM RoleMemberNavigation LEFT JOIN UserMember um ON um.UserId = RoleMemberNavigation.UpdateUserCode " +
                             "WHERE RoleMemberNavigation.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRoleMemberNavigation(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento del query para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complement debe incluir el WHERE del comando.</param>
        /// <returns>Complemento del query</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;


            return result;
        }

        /// <summary>
        /// Último valor asignado a clave unica de la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM RoleMemberNavigation")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <param name="rolemembernavigationItem">Instancia de RoleMemberNavigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.Security.RoleMemberNavigation rolemembernavigationItem, IDbConnection connection = null)
        {
            if (rolemembernavigationItem.UpdateDate.IsEmpty())
            {
                rolemembernavigationItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE RoleMemberNavigation " +
                                      "SET CompanyId=:CompanyId, RoleId=:RoleId, Code=:Code, Allow=:Allow, SecurityLevel=:SecurityLevel, CreateAction=:CreateAction, ReadAction=:ReadAction, UpdateAction=:UpdateAction, DeleteAction=:DeleteAction, ListAction=:ListAction, PrintAction=:PrintAction, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, rolemembernavigationItem.CompanyId)
                                .AddParameter("RoleId", DbType.Decimal, 9, rolemembernavigationItem.RoleId)
                                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, rolemembernavigationItem.Code)
                                .AddParameter("Allow", DbType.Decimal, 1, rolemembernavigationItem.Allow ? 1 : 0)
                                .AddParameter("SecurityLevel", DbType.Decimal, 3, rolemembernavigationItem.SecurityLevel)
                                .AddParameter("CreateAction", DbType.Decimal, 1, rolemembernavigationItem.CreateAction ? 1 : 0)
                                .AddParameter("ReadAction", DbType.Decimal, 1, rolemembernavigationItem.ReadAction ? 1 : 0)
                                .AddParameter("UpdateAction", DbType.Decimal, 1, rolemembernavigationItem.UpdateAction ? 1 : 0)
                                .AddParameter("DeleteAction", DbType.Decimal, 1, rolemembernavigationItem.DeleteAction ? 1 : 0)
                                .AddParameter("ListAction", DbType.Decimal, 1, rolemembernavigationItem.ListAction ? 1 : 0)
                                .AddParameter("PrintAction", DbType.Decimal, 1, rolemembernavigationItem.PrintAction ? 1 : 0)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, rolemembernavigationItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, rolemembernavigationItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, rolemembernavigationItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="rolemembernavigationItems">Lista de instancia de RoleMemberNavigation</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> rolemembernavigationItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.RoleMemberNavigation item in rolemembernavigationItems)
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
        /// Elimina un registro en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM RoleMemberNavigation " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> idList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in idList)
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
        /// Recupera la cantidad de registros existentes en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM RoleMemberNavigation " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RoleMemberNavigation que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM RoleMemberNavigation " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'RoleMemberNavigation'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberNavigation DataReaderToRoleMemberNavigation(System.Data.IDataReader reader, Architect.API.Core.Contracts.Security.RoleMemberNavigation item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.Security.RoleMemberNavigation();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.RoleId = reader.IntegerValue("RoleId");
            item.Code = reader.StringValue("Code");
            item.Allow = reader.IntegerValue("Allow") == 1;
            item.SecurityLevel = reader.IntegerValue("SecurityLevel");
            item.CreateAction = reader.IntegerValue("CreateAction") == 1;
            item.ReadAction = reader.IntegerValue("ReadAction") == 1;
            item.UpdateAction = reader.IntegerValue("UpdateAction") == 1;
            item.DeleteAction = reader.IntegerValue("DeleteAction") == 1;
            item.ListAction = reader.IntegerValue("ListAction") == 1;
            item.PrintAction = reader.IntegerValue("PrintAction") == 1;
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

