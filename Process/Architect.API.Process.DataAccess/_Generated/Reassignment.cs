using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Process.DataAccess.General
{
    /// <summary>
    /// Reasignaciones de actividades del proceso.
    /// </summary>
    public sealed partial class Reassignment
    { /// <summary>
      /// Obtiene el historial de reasignaciones de un caso,
      /// uniendo con UserMember para obtener el nombre del usuario asignado.
      /// Ordenado por fecha de asignacion descendente (mas reciente primero).
      /// </summary>
        public static List<Architect.API.Process.Contracts.General.Reassignment> RetrieveByCaseId(
            int companyId, int caseId)
        {
            var result = new List<Architect.API.Process.Contracts.General.Reassignment>();

            Database.Select(@"
SELECT R.ID,
       R.ACTIVITYID,
       R.USERASSIGNED,
       UM.FIRSTNAME || ' ' || UM.LASTNAME  AS USERNAME,
       R.USERASSIGNEDDATE,
       R.STATE
  FROM Reassignments R
  JOIN PROCESSINSTANCE PI
       ON PI.ACTIVITYID = R.ACTIVITYID
  JOIN PROCESSCASE PC
       ON PC.INSTANCEID = PI.INSTANCEID
      AND PC.COMPANYID  = :CompanyId
  LEFT JOIN USERMEMBER UM
       ON UM.USERID    = R.USERASSIGNED
      AND UM.COMPANYID = :CompanyId
 WHERE PC.ID = :CaseId
 ORDER BY R.USERASSIGNEDDATE ASC")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("CaseId", DbType.Decimal, 9, caseId)
                .Query(null, "Research", reader =>
                {
                    var item = new Architect.API.Process.Contracts.General.Reassignment
                    {
                        Id = reader.IntegerValue("ID"),
                        ActivityId = reader.IntegerValue("ACTIVITYID"),
                        UserAssigned = reader.IntegerValue("USERASSIGNED"),
                        UserAssignedDate = reader.DateTimeValue("USERASSIGNEDDATE"),
                        State = (Architect.API.Process.Contracts.General.ReassignmentState)
                                           reader.IntegerValue("STATE")
                    };
                    // Guardar el nombre en StateDesc temporalmente para no crear otro campo
                    item.StateDesc = reader.StringValue("USERNAME");
                    result.Add(item);
                });

            return result;
        }

        /// <summary>
        /// Crea un registro en la tabla Reassignments.
        /// </summary>
        /// <param name="reassignmentItem">Instancia de Reassignment</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Process.Contracts.General.Reassignment reassignmentItem, IDbConnection connection = null)
        {
            return Database.Insert(
                    "INSERT INTO Reassignments (Id, ActivityId, UserAssigned, UserAssignedDate, State) " +
                    "VALUES (:Id, :ActivityId, :UserAssigned, :UserAssignedDate, :State)")
                .AddParameter("Id", DbType.Decimal, 9, reassignmentItem.Id)
                .AddParameter("ActivityId", DbType.Decimal, 9, reassignmentItem.ActivityId)
                .AddParameter("UserAssigned", DbType.Decimal, 9, reassignmentItem.UserAssigned)
                .AddParameter("UserAssignedDate", DbType.DateTime, 0, reassignmentItem.UserAssignedDate)
                .AddParameter("State", DbType.Decimal, 9, (int)reassignmentItem.State)
                .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla Reassignments.
        /// </summary>
        /// <param name="reassignmentItems">Lista de instancias de Reassignment</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Process.Contracts.General.Reassignment> reassignmentItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Process.Contracts.General.Reassignment item in reassignmentItems)
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
        /// Último valor asignado a la clave única de la tabla Reassignments.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(MAX(Id), 0) FROM Reassignments")
                                .QueryScalar<decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera un registro en la tabla Reassignments por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Reassignment</returns>
        public static Architect.API.Process.Contracts.General.Reassignment Retrieve(int id, IDbConnection connection = null)
        {
            Architect.API.Process.Contracts.General.Reassignment result = null;
            Database.Select(
                    "SELECT Id, ActivityId, UserAssigned, UserAssignedDate, State " +
                    "FROM Reassignments " +
                    "WHERE Id = :Id")
                .AddParameter("Id", DbType.Decimal, 9, id)
                .Query(connection, "Research", new System.Action<IDataReader>((reader) =>
                {
                    result = DataReaderToReassignment(reader);
                }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Reassignments por ActivityId.
        /// </summary>
        /// <param name="activityId">Identificación de la actividad.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Reassignment</returns>
        public static List<Architect.API.Process.Contracts.General.Reassignment> RetrieveByActivityId(int activityId, IDbConnection connection = null)
        {
            List<Architect.API.Process.Contracts.General.Reassignment> result = new List<Architect.API.Process.Contracts.General.Reassignment>();
            Database.Select(
                    "SELECT Id, ActivityId, UserAssigned, UserAssignedDate, State " +
                    "FROM Reassignments " +
                    "WHERE ActivityId = :ActivityId")
                .AddParameter("ActivityId", DbType.Decimal, 9, activityId)
                .Query(connection, "Research", new System.Action<IDataReader>((reader) =>
                {
                    result.Add(DataReaderToReassignment(reader));
                }));
            return result;
        }

        /// <summary>
        /// Recupera todos los registros de la tabla Reassignments con filtro opcional.
        /// </summary>
        /// <param name="filter">Filtro personalizado (ej: " AND ActivityId = :ActivityId").</param>
        /// <param name="parameters">Lista de parámetros para el filtro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de Reassignment</returns>
        public static List<Architect.API.Process.Contracts.General.Reassignment> RetrieveAll(string filter = "", List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Process.Contracts.General.Reassignment> result = new List<Architect.API.Process.Contracts.General.Reassignment>();
            Database.Select(
                    "SELECT Id, ActivityId, UserAssigned, UserAssignedDate, State " +
                    "FROM Reassignments" + filter)
                .AddParameter(parameters)
                .Query(connection, "Research", new System.Action<IDataReader>((reader) =>
                {
                    result.Add(DataReaderToReassignment(reader));
                }));
            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Reassignments por medio de su clave primaria.
        /// </summary>
        /// <param name="reassignmentItem">Instancia de Reassignment</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Process.Contracts.General.Reassignment reassignmentItem, IDbConnection connection = null)
        {
            return Database.Update(
                    "UPDATE Reassignments " +
                    "SET ActivityId = :ActivityId, UserAssigned = :UserAssigned, UserAssignedDate = :UserAssignedDate, State = :State " +
                    "WHERE Id = :Id")
                .AddParameter("ActivityId", DbType.Decimal, 9, reassignmentItem.ActivityId)
                .AddParameter("UserAssigned", DbType.Decimal, 9, reassignmentItem.UserAssigned)
                .AddParameter("UserAssignedDate", DbType.DateTime, 0, reassignmentItem.UserAssignedDate)
                .AddParameter("State", DbType.Decimal, 9, (int)reassignmentItem.State)
                .AddParameter("Id", DbType.Decimal, 9, reassignmentItem.Id)
                .Execute(connection, "Research");
        }

        /// <summary>
        /// Elimina un registro en la tabla Reassignments por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, IDbConnection connection = null)
        {
            return Database.Delete(
                    "DELETE FROM Reassignments WHERE Id = :Id")
                .AddParameter("Id", DbType.Decimal, 9, id)
                .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros en la tabla Reassignments que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para el filtro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter = "", List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select(
                    "SELECT COUNT(Id) FROM Reassignments" + filter)
                .AddParameter(parameters)
                .QueryScalar<decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un DataReader a una clase de tipo Reassignment.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del DataReader</returns>
        public static Architect.API.Process.Contracts.General.Reassignment DataReaderToReassignment(IDataReader reader, Architect.API.Process.Contracts.General.Reassignment item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Process.Contracts.General.Reassignment();
            }
            item.Id = reader.IntegerValue("Id");
            item.ActivityId = reader.IntegerValue("ActivityId");
            item.UserAssigned = reader.IntegerValue("UserAssigned");
            item.UserAssignedDate = reader.DateTimeValue("UserAssignedDate");
            item.State = (Contracts.General.ReassignmentState)reader.IntegerValue("State");
            return item;
        }
    }
}
