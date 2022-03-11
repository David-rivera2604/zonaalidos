using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Notas.
    /// </summary>
    public sealed partial class Notes
    {

        /// <summary>
        /// Crea un registro en la tabla Notes.
        /// </summary>
        /// <param name="notesItem">Instancia de Notes</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Notes notesItem, IDbConnection connection = null)
        {
            if (notesItem.UpdateDate.IsEmpty())
            {
                notesItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Notes (Id, CompanyId, EntityType, EntityId, Note, Private, NoteOwnerId, ParentSequence, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :EntityType, :EntityId, :Note, :Private, :NoteOwnerId, :ParentSequence, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, notesItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, notesItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, notesItem.EntityType)
                            .AddParameter("EntityId", DbType.Decimal, 18, notesItem.EntityId)
                            .AddParameter("Note", DbType.AnsiString, 512, notesItem.Note)
                            .AddParameter("Private", DbType.Decimal, 1, notesItem.Private ? 1 : 0)
                            .AddParameter("NoteOwnerId", DbType.Decimal, 9, notesItem.NoteOwnerId)
                            .AddParameter("ParentSequence", DbType.Decimal, 9, notesItem.ParentSequence)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, notesItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, notesItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Notes.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="notesItems">Lista de instancia de Notes</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Notes> notesItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Notes item in notesItems)
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
        /// Recupera un registro en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Notes</returns>
        public static Architect.API.Core.Contracts.General.Notes Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Notes result = null;
            Database.Select("SELECT Id, Notes.CompanyId, EntityType, EntityId, Note, Private, NoteOwnerId, ParentSequence, Notes.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Notes.UpdateDate " +
                              "FROM Notes LEFT JOIN UserMember um ON um.UserId = Notes.UpdateUserCode " +
                             "WHERE Notes.Id=:Id AND Notes.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToNotes(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Notes.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Notes</returns>
        public static List<Architect.API.Core.Contracts.General.Notes> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Notes> result = new List<Architect.API.Core.Contracts.General.Notes>();
            Database.Select("SELECT Id, Notes.CompanyId, EntityType, EntityId, Note, Private, NoteOwnerId, ParentSequence, Notes.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Notes.UpdateDate " +
                              "FROM Notes LEFT JOIN UserMember um ON um.UserId = Notes.UpdateUserCode " +
                             "WHERE Notes.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToNotes(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Notes.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Notes</returns>
        public static List<Architect.API.Core.Contracts.General.Notes> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Notes> result = new List<Architect.API.Core.Contracts.General.Notes>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Notes.CompanyId, EntityType, EntityId, Note, Private, NoteOwnerId, ParentSequence, Notes.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Notes.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Notes.Id DESC) RowNumber " +
                              "FROM Notes LEFT JOIN UserMember um ON um.UserId = Notes.UpdateUserCode " +
                             "WHERE Notes.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToNotes(reader));
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
        /// Último valor asignado a clave única de la tabla Notes.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM Notes")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <param name="notesItem">Instancia de Notes</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Notes notesItem, IDbConnection connection = null)
        {
            if (notesItem.UpdateDate.IsEmpty())
            {
                notesItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Notes " +
                                      "SET CompanyId=:CompanyId, EntityType=:EntityType, EntityId=:EntityId, Note=:Note, Private=:Private, NoteOwnerId=:NoteOwnerId, ParentSequence=:ParentSequence, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, notesItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, notesItem.EntityType)
                                .AddParameter("EntityId", DbType.Decimal, 18, notesItem.EntityId)
                                .AddParameter("Note", DbType.AnsiString, 512, notesItem.Note)
                                .AddParameter("Private", DbType.Decimal, 1, notesItem.Private ? 1 : 0)
                                .AddParameter("NoteOwnerId", DbType.Decimal, 9, notesItem.NoteOwnerId)
                                .AddParameter("ParentSequence", DbType.Decimal, 9, notesItem.ParentSequence)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, notesItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, notesItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, notesItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="notesItems">Lista de instancia de Notes</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Notes> notesItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Notes item in notesItems)
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
        /// Elimina un registro en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Notes " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Notes por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Notes " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Notes que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Notes " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Notes'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Notes DataReaderToNotes(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Notes item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Notes();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.EntityId = reader.Integer64Value("EntityId");
            item.Note = reader.StringValue("Note");
            item.Private = reader.IntegerValue("Private") == 1;
            item.NoteOwnerId = reader.IntegerValue("NoteOwnerId");
            item.ParentSequence = reader.IntegerValue("ParentSequence");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

