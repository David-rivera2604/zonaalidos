using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class WhiteList
    {

        /// <summary>
        /// Crea un registro en la tabla WhiteList.
        /// </summary>
        /// <param name="whitelistItem">Instancia de WhiteList</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.WhiteList whitelistItem, IDbConnection connection = null)
        {
            return Database.Insert("INSERT INTO WhiteList (Id, IPAddress, DateUpdate) " +
                                                 "VALUES(:Id, :IPAddress, :DateUpdate)")
                            .AddParameter("Id", DbType.Decimal, 9, whitelistItem.Id)
                            .AddParameter("IPAddress", DbType.AnsiString, 20, whitelistItem.IPAddress)
                            .AddParameter("DateUpdate", DbType.DateTime, 9, whitelistItem.DateUpdate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla WhiteList.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="whitelistItems">Lista de instancia de WhiteList</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.WhiteList> whitelistItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.WhiteList item in whitelistItems)
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
        /// Recupera un registro en la tabla WhiteList por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de WhiteList</returns>
        public static Architect.API.Core.Contracts.General.WhiteList Retrieve(int id, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.WhiteList result = null;
            Database.Select("SELECT Id, IPAddress, DateUpdate " +
                              "FROM WhiteList " +
                             "WHERE Id=:Id")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToWhiteList(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla WhiteList.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de WhiteList</returns>
        public static List<Architect.API.Core.Contracts.General.WhiteList> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.WhiteList> result = new List<Architect.API.Core.Contracts.General.WhiteList>();
            Database.Select("SELECT Id, IPAddress, DateUpdate " +
                              "FROM WhiteList" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToWhiteList(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla WhiteList.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de WhiteList</returns>
        public static List<Architect.API.Core.Contracts.General.WhiteList> RetrieveAll(string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.WhiteList> result = new List<Architect.API.Core.Contracts.General.WhiteList>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, IPAddress, DateUpdate " +
                                   ", ROW_NUMBER() OVER (ORDER BY WhiteList.Id DESC) RowNumber " +
                              "FROM WhiteList" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToWhiteList(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento de la consulta para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complemento debe incluir el WHERE del comando.</param>
        /// <returns>Complemento de la consulta</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;


            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla WhiteList.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM WhiteList")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla WhiteList por medio de su clave primaria.
        /// </summary>
        /// <param name="whitelistItem">Instancia de WhiteList</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.WhiteList whitelistItem, IDbConnection connection = null)
        {
            return Database.Update("UPDATE WhiteList " +
                                      "SET IPAddress=:IPAddress, DateUpdate=:DateUpdate " +
                                    "WHERE Id=:Id")
                                .AddParameter("IPAddress", DbType.AnsiString, 20, whitelistItem.IPAddress)
                                .AddParameter("DateUpdate", DbType.DateTime, 9, whitelistItem.DateUpdate)
                                .AddParameter("Id", DbType.Decimal, 9, whitelistItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla WhiteList por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="whitelistItems">Lista de instancia de WhiteList</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.WhiteList> whitelistItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.WhiteList item in whitelistItems)
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
        /// Elimina un registro en la tabla WhiteList por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM WhiteList " +
                                    "WHERE Id=:Id")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla WhiteList por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificador único.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla WhiteList por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM WhiteList " +
                                         "WHERE Id=:Id")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla WhiteList que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM WhiteList " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'WhiteList'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.WhiteList DataReaderToWhiteList(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.WhiteList item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.WhiteList();
            }
            item.Id = reader.IntegerValue("Id");
            item.IPAddress = reader.StringValue("IPAddress");
            item.DateUpdate = reader.DateTimeValue("DateUpdate");
            return item;
        }

    }

}

