using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// ProcessSpecStepRole
    /// </summary>
    public static partial class ProcessSpecStepRole
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="processspecsteproleItem">Instancia de ProcessSpecStepRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessSpecStepRole processspecsteproleItem, IDbConnection connection = null)
        {
            if (processspecsteproleItem.UpdateDate.IsEmpty())
            {
                processspecsteproleItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecStepRole (Id, RoleId, CompanyId, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :RoleId, :CompanyId, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspecsteproleItem.Id)
                            .AddParameter("RoleId", DbType.Decimal, 9, processspecsteproleItem.RoleId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspecsteproleItem.CompanyId)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecsteproleItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspecsteproleItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecsteproleItems">Lista de instancia de ProcessSpecStepRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> processspecsteproleItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecStepRole item in processspecsteproleItems)
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
        /// Recupera un registro en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecStepRole</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepRole Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStepRole result = null;
            Database.Select("SELECT Id, RoleId, ProcessSpecStepRole.CompanyId, ProcessSpecStepRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStepRole.UpdateDate " +
                              "FROM ProcessSpecStepRole LEFT JOIN UserMember um ON um.UserId = ProcessSpecStepRole.UpdateUserCode " +
                             "WHERE ProcessSpecStepRole.Id=:Id AND ProcessSpecStepRole.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecStepRole(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecStepRole</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> result = new List<Architect.API.Core.Contracts.General.ProcessSpecStepRole>();
            Database.Select("SELECT Id, RoleId, ProcessSpecStepRole.CompanyId, ProcessSpecStepRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStepRole.UpdateDate " +
                              "FROM ProcessSpecStepRole LEFT JOIN UserMember um ON um.UserId = ProcessSpecStepRole.UpdateUserCode " +
                             "WHERE ProcessSpecStepRole.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecStepRole(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecStepRole</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> result = new List<Architect.API.Core.Contracts.General.ProcessSpecStepRole>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, RoleId, ProcessSpecStepRole.CompanyId, ProcessSpecStepRole.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecStepRole.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecStepRole.Id DESC) RowNumber " +
                              "FROM ProcessSpecStepRole LEFT JOIN UserMember um ON um.UserId = ProcessSpecStepRole.UpdateUserCode " +
                             "WHERE ProcessSpecStepRole.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecStepRole(reader));
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
        /// Último valor asignado a clave unica de la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecStepRole")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="processspecsteproleItem">Instancia de ProcessSpecStepRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessSpecStepRole processspecsteproleItem, IDbConnection connection = null)
        {
            if (processspecsteproleItem.UpdateDate.IsEmpty())
            {
                processspecsteproleItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecStepRole " +
                                      "SET RoleId=:RoleId, CompanyId=:CompanyId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("RoleId", DbType.Decimal, 9, processspecsteproleItem.RoleId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspecsteproleItem.CompanyId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecsteproleItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspecsteproleItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspecsteproleItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecsteproleItems">Lista de instancia de ProcessSpecStepRole</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> processspecsteproleItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessSpecStepRole item in processspecsteproleItems)
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
        /// Elimina un registro en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecStepRole " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del paso.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del paso.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecStepRole " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecStepRole que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecStepRole " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecStepRole'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepRole DataReaderToProcessSpecStepRole(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessSpecStepRole item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessSpecStepRole();
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

