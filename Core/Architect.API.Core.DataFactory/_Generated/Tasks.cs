using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Lista de tareas o chequeo.
    /// </summary>
    public static partial class Tasks
    {

        /// <summary>
        /// Crea un registro en la tabla Tasks.
        /// </summary>
        /// <param name="tasksItem">Instancia de Tasks</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.Tasks tasksItem, IDbConnection connection = null)
        {
            if (tasksItem.UpdateDate.IsEmpty())
            {
                tasksItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO Tasks (Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, CompanyId, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :Sequence, :Title, :Description, :CreatedDate, :DueDate, :AssignedTo, :Type, :CompletedDate, :Status, :EntityType, :EntityId, :CompanyId, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, tasksItem.Id)
                            .AddParameter("Sequence", DbType.Decimal, 9, tasksItem.Sequence)
                            .AddParameter("Title", DbType.AnsiString, 120, tasksItem.Title)
                            .AddParameter("Description", DbType.AnsiString, 512, tasksItem.Description)
                            .AddParameter("CreatedDate", DbType.DateTime, 9, tasksItem.CreatedDate)
                            .AddParameter("DueDate", DbType.DateTime, 9, tasksItem.DueDate)
                            .AddParameter("AssignedTo", DbType.Decimal, 9, tasksItem.AssignedTo)
                            .AddParameter("Type", DbType.Decimal, 5, tasksItem.Type)
                            .AddParameter("CompletedDate", DbType.DateTime, 9, tasksItem.CompletedDate)
                            .AddParameter("Status", DbType.Decimal, 5, tasksItem.Status)
                            .AddParameter("EntityType", DbType.Decimal, 5, tasksItem.EntityType)
                            .AddParameter("EntityId", DbType.Decimal, 18, tasksItem.EntityId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, tasksItem.CompanyId)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, tasksItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, tasksItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Tasks.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="tasksItems">Lista de instancia de Tasks</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.Tasks> tasksItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Tasks item in tasksItems)
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
        /// Recupera un registro en la tabla Tasks por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="sequence">Identificación secuencial asociada al identificador único del registro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Tasks</returns>
        public static Architect.API.Core.Contracts.General.Tasks Retrieve(int id, int sequence, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.Tasks result = null;
            Database.Select("SELECT Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, Tasks.CompanyId, Tasks.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Tasks.UpdateDate " +
                              "FROM Tasks LEFT JOIN UserMember um ON um.UserId = Tasks.UpdateUserCode " +
                             "WHERE Tasks.Id=:Id AND Tasks.Sequence=:Sequence")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("Sequence", DbType.Decimal, 9, sequence)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToTasks(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Tasks.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Tasks</returns>
        public static List<Architect.API.Core.Contracts.General.Tasks> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Tasks> result = new List<Architect.API.Core.Contracts.General.Tasks>();
            Database.Select("SELECT Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, Tasks.CompanyId, Tasks.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Tasks.UpdateDate " +
                              "FROM Tasks LEFT JOIN UserMember um ON um.UserId = Tasks.UpdateUserCode" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToTasks(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Tasks.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Tasks</returns>
        public static List<Architect.API.Core.Contracts.General.Tasks> RetrieveAll(string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.Tasks> result = new List<Architect.API.Core.Contracts.General.Tasks>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, Tasks.CompanyId, Tasks.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Tasks.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY Tasks.Id DESC) RowNumber " +
                              "FROM Tasks LEFT JOIN UserMember um ON um.UserId = Tasks.UpdateUserCode" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToTasks(reader));
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
        /// Último valor asignado a clave unica de la tabla Tasks.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(int id, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Sequence),0) " +
                                     "FROM Tasks " +
                                    "WHERE Id=:Id")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Tasks por medio de su clave primaria.
        /// </summary>
        /// <param name="tasksItem">Instancia de Tasks</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.Tasks tasksItem, IDbConnection connection = null)
        {
            if (tasksItem.UpdateDate.IsEmpty())
            {
                tasksItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE Tasks " +
                                      "SET Title=:Title, Description=:Description, CreatedDate=:CreatedDate, DueDate=:DueDate, AssignedTo=:AssignedTo, Type=:Type, CompletedDate=:CompletedDate, Status=:Status, EntityType=:EntityType, EntityId=:EntityId, CompanyId=:CompanyId, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id AND Sequence=:Sequence")
                                .AddParameter("Title", DbType.AnsiString, 120, tasksItem.Title)
                                .AddParameter("Description", DbType.AnsiString, 512, tasksItem.Description)
                                .AddParameter("CreatedDate", DbType.DateTime, 9, tasksItem.CreatedDate)
                                .AddParameter("DueDate", DbType.DateTime, 9, tasksItem.DueDate)
                                .AddParameter("AssignedTo", DbType.Decimal, 9, tasksItem.AssignedTo)
                                .AddParameter("Type", DbType.Decimal, 5, tasksItem.Type)
                                .AddParameter("CompletedDate", DbType.DateTime, 9, tasksItem.CompletedDate)
                                .AddParameter("Status", DbType.Decimal, 5, tasksItem.Status)
                                .AddParameter("EntityType", DbType.Decimal, 5, tasksItem.EntityType)
                                .AddParameter("EntityId", DbType.Decimal, 18, tasksItem.EntityId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, tasksItem.CompanyId)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, tasksItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, tasksItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, tasksItem.Id)
                                .AddParameter("Sequence", DbType.Decimal, 9, tasksItem.Sequence)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Tasks por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="tasksItems">Lista de instancia de Tasks</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.Tasks> tasksItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.Tasks item in tasksItems)
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
        /// Elimina un registro en la tabla Tasks por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="sequence">Identificación secuencial asociada al identificador único del registro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int sequence, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Tasks " +
                                    "WHERE Id=:Id AND Sequence=:Sequence")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("Sequence", DbType.Decimal, 9, sequence)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla Tasks por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del registro.</param>
        /// <param name="sequenceList">Lista de Identificación secuencial asociada al identificador único del registro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> idList, List<int> sequenceList, IDbConnection connection = null)
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
                result.Add(Delete(item, item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Tasks por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="sequence">Identificación secuencial asociada al identificador único del registro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int sequence, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Tasks " +
                                         "WHERE Id=:Id AND Sequence=:Sequence")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("Sequence", DbType.Decimal, 9, sequence)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Tasks que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM Tasks " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'Tasks'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.Tasks DataReaderToTasks(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.Tasks item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.Tasks();
            }
            item.Id = reader.IntegerValue("Id");
            item.Sequence = reader.IntegerValue("Sequence");
            item.Title = reader.StringValue("Title");
            item.Description = reader.StringValue("Description");
            item.CreatedDate = reader.DateTimeValue("CreatedDate");
            item.DueDate = reader.DateTimeValue("DueDate");
            item.AssignedTo = reader.IntegerValue("AssignedTo");
            item.Type = reader.IntegerValue("Type");
            item.CompletedDate = reader.DateTimeValue("CompletedDate");
            item.Status = reader.IntegerValue("Status");
            item.EntityType = reader.IntegerValue("EntityType");
            item.EntityId = reader.Integer64Value("EntityId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

