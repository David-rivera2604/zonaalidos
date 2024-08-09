using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Auditoria de cambios por entidad del sistema.
    /// </summary>
    public sealed partial class ChangeSet
    {

        /// <summary>
        /// Crea un registro en la tabla ChangeSet.
        /// </summary>
        /// <param name="changesetItem">Instancia de ChangeSet</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ChangeSet changesetItem, IDbConnection connection = null)
        {
            if (changesetItem.UpdateDate.IsEmpty())
            {
                changesetItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ChangeSet (Id, CompanyId, EntityType, EntityId, Action, Summary, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :EntityType, :EntityId, :Action, :Summary, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, changesetItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, changesetItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, changesetItem.EntityType)
                            .AddParameter("EntityId", DbType.Decimal, 18, changesetItem.EntityId)
                            .AddParameter("Action", DbType.AnsiString, 40, changesetItem.Action)
                            .AddParameter("Summary", DbType.AnsiString, 256, changesetItem.Summary)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, changesetItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, changesetItem.UpdateDate)
                            .Execute(connection, "Research");
        }
        public static int Create(Architect.API.Core.Contracts.General.ChangeSet changesetItem, Session session)
        {
            if (changesetItem.UpdateDate.IsEmpty())
            {
                changesetItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ChangeSet (Id, CompanyId, EntityType, EntityId, Action, Summary, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :EntityType, :EntityId, :Action, :Summary, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, changesetItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, changesetItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, changesetItem.EntityType)
                            .AddParameter("EntityId", DbType.Decimal, 18, changesetItem.EntityId)
                            .AddParameter("Action", DbType.AnsiString, 40, changesetItem.Action)
                            .AddParameter("Summary", DbType.AnsiString, 256, changesetItem.Summary)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, changesetItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, changesetItem.UpdateDate)
                            .Execute(session);
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ChangeSet.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="changesetItems">Lista de instancia de ChangeSet</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ChangeSet> changesetItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ChangeSet item in changesetItems)
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
        /// Recupera un registro en la tabla ChangeSet por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ChangeSet</returns>
        public static Architect.API.Core.Contracts.General.ChangeSet Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ChangeSet result = null;
            Database.Select("SELECT Id, ChangeSet.CompanyId, EntityType, EntityId, Action, Summary, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate " +
                              "FROM ChangeSet LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode " +
                             "WHERE ChangeSet.Id=:Id AND ChangeSet.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToChangeSet(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ChangeSet.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ChangeSet</returns>
        public static List<Architect.API.Core.Contracts.General.ChangeSet> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ChangeSet> result = new List<Architect.API.Core.Contracts.General.ChangeSet>();
            Database.Select("SELECT Id, ChangeSet.CompanyId, EntityType, EntityId, Action, Summary, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate " +
                              "FROM ChangeSet LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode " +
                             "WHERE ChangeSet.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToChangeSet(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ChangeSet.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ChangeSet</returns>
        public static List<Architect.API.Core.Contracts.General.ChangeSet> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ChangeSet> result = new List<Architect.API.Core.Contracts.General.ChangeSet>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, ChangeSet.CompanyId, EntityType, EntityId, Action, Summary, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ChangeSet.Id DESC) RowNumber " +
                              "FROM ChangeSet LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode " +
                             "WHERE ChangeSet.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToChangeSet(reader));
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
        /// Último valor asignado a clave única de la tabla ChangeSet.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ChangeSet")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        public static int RetrieveLastKey(DataFactory.Session session)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ChangeSet")
                                .QueryScalar<Decimal>(session);
        }

        /// <summary>
        /// Actualiza un registro en la tabla ChangeSet por medio de su clave primaria.
        /// </summary>
        /// <param name="changesetItem">Instancia de ChangeSet</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ChangeSet changesetItem, IDbConnection connection = null)
        {
            if (changesetItem.UpdateDate.IsEmpty())
            {
                changesetItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ChangeSet " +
                                      "SET CompanyId=:CompanyId, EntityType=:EntityType, EntityId=:EntityId, Action=:Action, Summary=:Summary, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, changesetItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, changesetItem.EntityType)
                                .AddParameter("EntityId", DbType.Decimal, 18, changesetItem.EntityId)
                                .AddParameter("Action", DbType.AnsiString, 40, changesetItem.Action)
                                .AddParameter("Summary", DbType.AnsiString, 256, changesetItem.Summary)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, changesetItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, changesetItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, changesetItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ChangeSet por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="changesetItems">Lista de instancia de ChangeSet</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ChangeSet> changesetItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ChangeSet item in changesetItems)
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
        /// Elimina un registro en la tabla ChangeSet por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ChangeSet " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ChangeSet por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ChangeSet por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ChangeSet " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ChangeSet que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ChangeSet " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ChangeSet'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ChangeSet DataReaderToChangeSet(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ChangeSet item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ChangeSet();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.EntityId = reader.Integer64Value("EntityId");
            item.Action = reader.StringValue("Action");
            item.Summary = reader.StringValue("Summary");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

