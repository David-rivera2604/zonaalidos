using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Maestro de lista de valores disponibles.
    /// </summary>
    public sealed partial class LookupMaster
    {

        /// <summary>
        /// Crea un registro en la tabla LookupMaster.
        /// </summary>
        /// <param name="lookupmasterItem">Instancia de LookupMaster</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.LookupMaster lookupmasterItem, IDbConnection connection = null)
        {
            if (lookupmasterItem.UpdateDate.IsEmpty())
            {
                lookupmasterItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO LookupMaster (LookupId, Type, Description, Key, Tenant, Statement, IsCached, ConnectionName, IncludeByRole, ExcludeByRole, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:LookupId, :Type, :Description, :Key, :Tenant, :Statement, :IsCached, :ConnectionName, :IncludeByRole, :ExcludeByRole, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("LookupId", DbType.Decimal, 9, lookupmasterItem.LookupId)
                            .AddParameter("Type", DbType.Decimal, 5, lookupmasterItem.Type)
                            .AddParameter("Description", DbType.AnsiString, 50, lookupmasterItem.Description)
                            .AddParameter("Key", DbType.AnsiString, 30, lookupmasterItem.Key)
                            .AddParameter("Tenant", DbType.Decimal, 1, lookupmasterItem.Tenant ? 1 : 0)
                            .AddParameter("Statement", DbType.AnsiString, 2048, lookupmasterItem.Statement)
                            .AddParameter("IsCached", DbType.Decimal, 1, lookupmasterItem.IsCached ? 1 : 0)
                            .AddParameter("ConnectionName", DbType.AnsiString, 80, lookupmasterItem.ConnectionName)
                            .AddParameter("IncludeByRole", DbType.AnsiString, 512, lookupmasterItem.IncludeByRole)
                            .AddParameter("ExcludeByRole", DbType.AnsiString, 512, lookupmasterItem.ExcludeByRole)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, lookupmasterItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, lookupmasterItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, lookupmasterItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla LookupMaster.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="lookupmasterItems">Lista de instancia de LookupMaster</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.LookupMaster> lookupmasterItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.LookupMaster item in lookupmasterItems)
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
        /// Recupera un registro en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupid">Identificación de la lista.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de LookupMaster</returns>
        public static Architect.API.Core.Contracts.General.LookupMaster Retrieve(int lookupid, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.LookupMaster result = null;
            Database.Select("SELECT LookupId, Type, Description, Key, Tenant, StatementType, Statement, Fields, IsCached, ConnectionName, IncludeByRole, ExcludeByRole, LookupMaster.RecordStatus, LookupMaster.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, LookupMaster.UpdateDate, TranslationSrc, TranslationCtx " +
                             " FROM LookupMaster LEFT JOIN UserMember um ON um.UserId = LookupMaster.UpdateUserCode " +
                            " WHERE LookupMaster.LookupId=:LookupId")
                        .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToLookupMaster(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla LookupMaster.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookupMaster</returns>
        public static List<Architect.API.Core.Contracts.General.LookupMaster> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.LookupMaster> result = new List<Architect.API.Core.Contracts.General.LookupMaster>();
            Database.Select(@"SELECT LookupId, Type, Description, Key, Tenant, StatementType, Statement, Fields, IsCached, ConnectionName, IncludeByRole, ExcludeByRole, LookupMaster.RecordStatus, LookupMaster.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, LookupMaster.UpdateDate, TranslationSrc, TranslationCtx
                                FROM LookupMaster LEFT JOIN UserMember um ON um.UserId = LookupMaster.UpdateUserCode" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToLookupMaster(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla LookupMaster.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookupMaster</returns>
        public static List<Architect.API.Core.Contracts.General.LookupMaster> RetrieveAll(string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.LookupMaster> result = new List<Architect.API.Core.Contracts.General.LookupMaster>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT LookupId, Type, Description, Key, Tenant, StatementType, Statement, Fields, IsCached, ConnectionName, IncludeByRole, ExcludeByRole, LookupMaster.RecordStatus, LookupMaster.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, LookupMaster.UpdateDate, TranslationSrc, TranslationCtx " +
                                   ", ROW_NUMBER() OVER (ORDER BY LookupMaster.LookupId DESC) RowNumber " +
                              "FROM LookupMaster LEFT JOIN UserMember um ON um.UserId = LookupMaster.UpdateUserCode" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToLookupMaster(reader));
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
                if (includeWhere)
                {
                    result = " WHERE ";
                }
                else
                {
                    result = " AND ";
                }

                result += "(";
                result += " UPPER(LookupMaster.Description) LIKE '%" + filter.ToUpper() + "%' ";
                result += " AND UPPER(LookupMaster.Key) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla LookupMaster.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(LookupId),0) " +
                                     "FROM LookupMaster")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupmasterItem">Instancia de LookupMaster</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.LookupMaster lookupmasterItem, IDbConnection connection = null)
        {
            if (lookupmasterItem.UpdateDate.IsEmpty())
            {
                lookupmasterItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE LookupMaster " +
                                      "SET Type=:Type, Description=:Description, Key=:Key, Tenant=:Tenant, Statement=:Statement, IsCached=:IsCached, ConnectionName=:ConnectionName, IncludeByRole=:IncludeByRole, ExcludeByRole=:ExcludeByRole, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE LookupId=:LookupId")
                                .AddParameter("Type", DbType.Decimal, 5, lookupmasterItem.Type)
                                .AddParameter("Description", DbType.AnsiString, 50, lookupmasterItem.Description)
                                .AddParameter("Key", DbType.AnsiString, 30, lookupmasterItem.Key)
                                .AddParameter("Tenant", DbType.Decimal, 1, lookupmasterItem.Tenant ? 1 : 0)
                                .AddParameter("Statement", DbType.AnsiString, 2048, lookupmasterItem.Statement)
                                .AddParameter("IsCached", DbType.Decimal, 1, lookupmasterItem.IsCached ? 1 : 0)
                                .AddParameter("ConnectionName", DbType.AnsiString, 80, lookupmasterItem.ConnectionName)
                                .AddParameter("IncludeByRole", DbType.AnsiString, 512, lookupmasterItem.IncludeByRole)
                                .AddParameter("ExcludeByRole", DbType.AnsiString, 512, lookupmasterItem.ExcludeByRole)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, lookupmasterItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, lookupmasterItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, lookupmasterItem.UpdateDate)
                                .AddParameter("LookupId", DbType.Decimal, 9, lookupmasterItem.LookupId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="lookupmasterItems">Lista de instancia de LookupMaster</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.LookupMaster> lookupmasterItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.LookupMaster item in lookupmasterItems)
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
        /// Elimina un registro en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupid">Identificación de la lista.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int lookupid, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM LookupMaster " +
                                    "WHERE LookupId=:LookupId")
                                .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="lookupidList">Lista de Identificación de la lista.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> lookupidList, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in lookupidList)
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
        /// Recupera la cantidad de registros existentes en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <param name="lookupid">Identificación de la lista.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int lookupid, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(LookupId) " +
                                          "FROM LookupMaster " +
                                         "WHERE LookupId=:LookupId")
                               .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla LookupMaster que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(LookupId) " +
                                          "FROM LookupMaster " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla LookupMaster por medio de la columna Key ignorando el registro en tratamiento por medio de la clave primaria.
        /// </summary>
        /// <param name="lookupid">Identificación de la lista.</param>
        /// <param name="key">Clave que identificac la lista.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int CountByKey(int lookupid, string key, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Key) " +
                                     "FROM LookupMaster " +
                                    "WHERE LookupId<>:LookupId " +
                                      "AND Key=:Key")
                               .AddParameter("LookupId", DbType.Decimal, 9, lookupid)
                               .AddParameter("Key", DbType.AnsiString, 30, key)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla LookupMaster.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT LookupId, Description " +
                              "FROM LookupMaster ORDER BY Description")
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("LookupId"),
                                Description = reader.StringValue("Description")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'LookupMaster'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.LookupMaster DataReaderToLookupMaster(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.LookupMaster item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.LookupMaster();
            }
            item.LookupId = reader.IntegerValue("LookupId");
            item.Type = reader.IntegerValue("Type");
            item.Description = reader.StringValue("Description");
            item.Key = reader.StringValue("Key");
            item.Tenant = reader.IntegerValue("Tenant") == 1;
            item.StatementType = reader.IntegerValue("StatementType");
            item.Statement = reader.StringValue("Statement");
            item.Fields = reader.StringValue("Fields");
            item.IsCached = reader.IntegerValue("IsCached") == 1;
            item.ConnectionName = reader.StringValue("ConnectionName");
            item.IncludeByRole = reader.StringValue("IncludeByRole");
            item.ExcludeByRole = reader.StringValue("ExcludeByRole");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            item.TranslationSrc = reader.StringValue("TranslationSrc");
            item.TranslationCtx = reader.StringValue("TranslationCtx");

            return item;
        }

    }

}

