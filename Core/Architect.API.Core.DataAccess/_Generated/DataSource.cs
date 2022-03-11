using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Fuentes de datos.
    /// </summary>
    public sealed partial class DataSource
    {

        /// <summary>
        /// Crea un registro en la tabla DataSource.
        /// </summary>
        /// <param name="datasourceItem">Instancia de DataSource</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.DataSource datasourceItem, IDbConnection connection = null)
        {
            if (datasourceItem.UpdateDate.IsEmpty())
            {
                datasourceItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO DataSource (Id, Key, Description, Specification, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :Key, :Description, :Specification, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, datasourceItem.Id)
                            .AddParameter("Key", DbType.AnsiString, 50, datasourceItem.Key)
                            .AddParameter("Description", DbType.AnsiString, 256, datasourceItem.Description)
                            .AddParameter("Specification", DbType.AnsiString, 4000, datasourceItem.Specification)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, datasourceItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, datasourceItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, datasourceItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla DataSource.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="datasourceItems">Lista de instancia de DataSource</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.DataSource> datasourceItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.DataSource item in datasourceItems)
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
        /// Recupera un registro en la tabla DataSource por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la plantilla.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de DataSource</returns>
        public static Architect.API.Core.Contracts.General.DataSource Retrieve(int id, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.DataSource result = null;
            Database.Select("SELECT Id, Key, Description, Specification, DataSource.RecordStatus, DataSource.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, DataSource.UpdateDate " +
                              "FROM DataSource LEFT JOIN UserMember um ON um.UserId = DataSource.UpdateUserCode " +
                             "WHERE DataSource.Id=:Id")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToDataSource(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla DataSource.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de DataSource</returns>
        public static List<Architect.API.Core.Contracts.General.DataSource> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.DataSource> result = new List<Architect.API.Core.Contracts.General.DataSource>();
            Database.Select("SELECT Id, Key, Description, Specification, DataSource.RecordStatus, DataSource.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, DataSource.UpdateDate " +
                              "FROM DataSource LEFT JOIN UserMember um ON um.UserId = DataSource.UpdateUserCode" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToDataSource(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla DataSource.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de DataSource</returns>
        public static List<Architect.API.Core.Contracts.General.DataSource> RetrieveAll(string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.DataSource> result = new List<Architect.API.Core.Contracts.General.DataSource>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Key, Description, Specification, DataSource.RecordStatus, DataSource.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, DataSource.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY DataSource.Id DESC) RowNumber " +
                              "FROM DataSource LEFT JOIN UserMember um ON um.UserId = DataSource.UpdateUserCode" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToDataSource(reader));
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
        /// Último valor asignado a clave única de la tabla DataSource.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM DataSource")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla DataSource por medio de su clave primaria.
        /// </summary>
        /// <param name="datasourceItem">Instancia de DataSource</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.DataSource datasourceItem, IDbConnection connection = null)
        {
            if (datasourceItem.UpdateDate.IsEmpty())
            {
                datasourceItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE DataSource " +
                                      "SET Key=:Key, Description=:Description, Specification=:Specification, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("Key", DbType.AnsiString, 50, datasourceItem.Key)
                                .AddParameter("Description", DbType.AnsiString, 256, datasourceItem.Description)
                                .AddParameter("Specification", DbType.AnsiString, 4000, datasourceItem.Specification)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, datasourceItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, datasourceItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, datasourceItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, datasourceItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla DataSource por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="datasourceItems">Lista de instancia de DataSource</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.DataSource> datasourceItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.DataSource item in datasourceItems)
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
        /// Elimina un registro en la tabla DataSource por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la plantilla.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM DataSource " +
                                    "WHERE Id=:Id")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla DataSource por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única de la plantilla.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> idList, IDbConnection connection = null)
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
                result.Add(Delete(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla DataSource por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la plantilla.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM DataSource " +
                                         "WHERE Id=:Id")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla DataSource que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM DataSource " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'DataSource'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.DataSource DataReaderToDataSource(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.DataSource item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.DataSource();
            }
            item.Id = reader.IntegerValue("Id");
            item.Key = reader.StringValue("Key");
            item.Description = reader.StringValue("Description");
            item.Specification = reader.StringValue("Specification");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

