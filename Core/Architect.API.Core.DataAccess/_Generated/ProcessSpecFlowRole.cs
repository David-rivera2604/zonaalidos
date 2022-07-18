using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// ProcessSpecFlowRole
    /// </summary>
    public sealed partial class ProcessSpecFlowRole
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecFlowRole.
        /// </summary>
        /// <param name="processspecflowroleItem">Instancia de ProcessSpecFlowRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecFlowRole processspecflowroleItem, IDbConnection connection = null)
        {
            if (processspecflowroleItem.UpdateDate.IsEmpty())
            {
                processspecflowroleItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecFlowRole (Id, RoleId, CompanyId, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :RoleId, :CompanyId, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspecflowroleItem.Id)
                            .AddParameter("RoleId", DbType.Decimal, 9, processspecflowroleItem.RoleId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspecflowroleItem.CompanyId)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecflowroleItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspecflowroleItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecFlowRole.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecflowroleItems">Lista de instancia de ProcessSpecFlowRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> processspecflowroleItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecFlowRole item in processspecflowroleItems)
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
        /// Recupera un registro en la tabla ProcessSpecFlowRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="roleid">Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecFlowRole</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowRole Retrieve(int id, int roleid, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlowRole result = null;
            Database.Select("SELECT Id, RoleId, ProcessSpecFlowRole.CompanyId, ProcessSpecFlowRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlowRole.UpdateDate " +
                              "FROM ProcessSpecFlowRole LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlowRole.UpdateUserCode " +
                             "WHERE ProcessSpecFlowRole.Id=:Id AND ProcessSpecFlowRole.RoleId=:RoleId AND ProcessSpecFlowRole.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("RoleId", DbType.Decimal, 9, roleid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecFlowRole(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlowRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecFlowRole</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> result = new List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole>();
            Database.Select("SELECT Id, RoleId, ProcessSpecFlowRole.CompanyId, ProcessSpecFlowRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlowRole.UpdateDate " +
                              "FROM ProcessSpecFlowRole LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlowRole.UpdateUserCode " +
                             "WHERE ProcessSpecFlowRole.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecFlowRole(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlowRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecFlowRole</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> result = new List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, RoleId, ProcessSpecFlowRole.CompanyId, ProcessSpecFlowRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlowRole.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecFlowRole.Id DESC) RowNumber " +
                              "FROM ProcessSpecFlowRole LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlowRole.UpdateUserCode " +
                             "WHERE ProcessSpecFlowRole.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecFlowRole(reader));
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


            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla ProcessSpecFlowRole.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(int id, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(RoleId),0) " +
                                     "FROM ProcessSpecFlowRole " +
                                    "WHERE Id=:Id")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecFlowRole por medio de su clave primaria.
        /// </summary>
        /// <param name="processspecflowroleItem">Instancia de ProcessSpecFlowRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecFlowRole processspecflowroleItem, IDbConnection connection = null)
        {
            if (processspecflowroleItem.UpdateDate.IsEmpty())
            {
                processspecflowroleItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecFlowRole " +
                                      "SET CompanyId=:CompanyId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id AND RoleId=:RoleId")
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspecflowroleItem.CompanyId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecflowroleItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspecflowroleItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspecflowroleItem.Id)
                                .AddParameter("RoleId", DbType.Decimal, 9, processspecflowroleItem.RoleId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecFlowRole por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecflowroleItems">Lista de instancia de ProcessSpecFlowRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> processspecflowroleItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecFlowRole item in processspecflowroleItems)
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
        /// Elimina un registro en la tabla ProcessSpecFlowRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="roleid">Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int roleid, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecFlowRole " +
                                    "WHERE Id=:Id AND RoleId=:RoleId AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("RoleId", DbType.Decimal, 9, roleid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecFlowRole por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del proceso.</param>
        /// <param name="roleidList">Lista de Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> idList, List<int> roleidList, int companyId, IDbConnection connection = null)
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
                result.Add(Delete(item, item, companyId, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlowRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="roleid">Identificación Rol.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int roleid, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecFlowRole " +
                                         "WHERE Id=:Id AND RoleId=:RoleId AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("RoleId", DbType.Decimal, 9, roleid)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlowRole que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecFlowRole " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecFlowRole'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowRole DataReaderToProcessSpecFlowRole(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecFlowRole item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecFlowRole();
            }
            item.Id = reader.IntegerValue("Id");
            item.RoleId = reader.IntegerValue("RoleId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

