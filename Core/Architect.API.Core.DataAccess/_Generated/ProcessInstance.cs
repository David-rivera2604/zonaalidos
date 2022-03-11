using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Procesos ejecutados o en ejecución.
    /// </summary>
    public sealed partial class ProcessInstance
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessInstance.
        /// </summary>
        /// <param name="processinstanceItem">Instancia de ProcessInstance</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessInstance processinstanceItem, IDbConnection connection = null)
        {
            if (processinstanceItem.UpdateDate.IsEmpty())
            {
                processinstanceItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessInstance (ActivityId, InstanceId, CompanyId, EntityType, EntityId, CaseId, FlowId, StepId, TaskId, Created, StartDate, DueDate, FinishDate, PreviousActivityId, UserId, Comments, LastOverDueNotify, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:ActivityId, :InstanceId, :CompanyId, :EntityType, :EntityId, :CaseId, :FlowId, :StepId, :TaskId, :Created, :StartDate, :DueDate, :FinishDate, :PreviousActivityId, :UserId, :Comments, :LastOverDueNotify, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("ActivityId", DbType.Decimal, 9, processinstanceItem.ActivityId)
                            .AddParameter("InstanceId", DbType.Decimal, 9, processinstanceItem.InstanceId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processinstanceItem.CompanyId)
                            .AddParameter("EntityType", DbType.Decimal, 5, processinstanceItem.EntityType)
                            .AddParameter("EntityId", DbType.Decimal, 18, processinstanceItem.EntityId)
                            .AddParameter("CaseId", DbType.Decimal, 9, processinstanceItem.CaseId)
                            .AddParameter("FlowId", DbType.Decimal, 9, processinstanceItem.FlowId)
                            .AddParameter("StepId", DbType.Decimal, 9, processinstanceItem.StepId)
                            .AddParameter("TaskId", DbType.Decimal, 9, processinstanceItem.TaskId)
                            .AddParameter("Created", DbType.DateTime, 9, processinstanceItem.Created)
                            .AddParameter("StartDate", DbType.DateTime, 9, processinstanceItem.StartDate)
                            .AddParameter("DueDate", DbType.DateTime, 9, processinstanceItem.DueDate)
                            .AddParameter("FinishDate", DbType.DateTime, 9, processinstanceItem.FinishDate)
                            .AddParameter("PreviousActivityId", DbType.Decimal, 9, processinstanceItem.PreviousActivityId)
                            .AddParameter("UserId", DbType.Decimal, 9, processinstanceItem.UserId)
                            .AddParameter("Comments", DbType.AnsiString, 350, processinstanceItem.Comments)
                            .AddParameter("LastOverDueNotify", DbType.DateTime, 9, processinstanceItem.LastOverDueNotify)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processinstanceItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processinstanceItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessInstance.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processinstanceItems">Lista de instancia de ProcessInstance</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessInstance> processinstanceItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessInstance item in processinstanceItems)
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
        /// Recupera un registro en la tabla ProcessInstance por medio de su clave primaria.
        /// </summary>
        /// <param name="activityid">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessInstance</returns>
        public static Architect.API.Core.Contracts.General.ProcessInstance Retrieve(int activityid, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessInstance result = null;
            Database.Select("SELECT ActivityId, InstanceId, ProcessInstance.CompanyId, EntityType, EntityId, CaseId, FlowId, StepId, TaskId, Created, StartDate, DueDate, FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, LastOverDueNotify, ProcessInstance.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessInstance.UpdateDate " +
                              "FROM ProcessInstance LEFT JOIN UserMember um ON um.UserId = ProcessInstance.UpdateUserCode " +
                             "WHERE ProcessInstance.ActivityId=:ActivityId AND ProcessInstance.CompanyId=:CompanyId")
                        .AddParameter("ActivityId", DbType.Decimal, 9, activityid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessInstance(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessInstance.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessInstance</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessInstance> result = new List<Architect.API.Core.Contracts.General.ProcessInstance>();
            Database.Select("SELECT ActivityId, InstanceId, ProcessInstance.CompanyId, EntityType, EntityId, CaseId, FlowId, StepId, TaskId, Created, StartDate, DueDate, FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, LastOverDueNotify, ProcessInstance.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessInstance.UpdateDate " +
                              "FROM ProcessInstance LEFT JOIN UserMember um ON um.UserId = ProcessInstance.UpdateUserCode " +
                             "WHERE ProcessInstance.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessInstance(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessInstance.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessInstance</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessInstance> result = new List<Architect.API.Core.Contracts.General.ProcessInstance>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT ActivityId, InstanceId, ProcessInstance.CompanyId, EntityType, EntityId, CaseId, FlowId, StepId, TaskId, Created, StartDate, DueDate, FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, LastOverDueNotify, ProcessInstance.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessInstance.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessInstance.ActivityId DESC) RowNumber " +
                              "FROM ProcessInstance LEFT JOIN UserMember um ON um.UserId = ProcessInstance.UpdateUserCode " +
                             "WHERE ProcessInstance.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessInstance(reader));
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
        /// Último valor asignado a clave única de la tabla ProcessInstance.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(ActivityId),0) " +
                                     "FROM ProcessInstance")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessInstance por medio de su clave primaria.
        /// </summary>
        /// <param name="processinstanceItem">Instancia de ProcessInstance</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessInstance processinstanceItem, IDbConnection connection = null)
        {
            if (processinstanceItem.UpdateDate.IsEmpty())
            {
                processinstanceItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessInstance " +
                                      "SET InstanceId=:InstanceId, CompanyId=:CompanyId, EntityType=:EntityType, EntityId=:EntityId, CaseId=:CaseId, FlowId=:FlowId, StepId=:StepId, TaskId=:TaskId, Created=:Created, StartDate=:StartDate, DueDate=:DueDate, FinishDate=:FinishDate, PreviousActivityId=:PreviousActivityId, UserId=:UserId, Comments=:Comments, LastOverDueNotify=:LastOverDueNotify, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE ActivityId=:ActivityId")
                                .AddParameter("InstanceId", DbType.Decimal, 9, processinstanceItem.InstanceId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, processinstanceItem.CompanyId)
                                .AddParameter("EntityType", DbType.Decimal, 5, processinstanceItem.EntityType)
                                .AddParameter("EntityId", DbType.Decimal, 18, processinstanceItem.EntityId)
                                .AddParameter("CaseId", DbType.Decimal, 9, processinstanceItem.CaseId)
                                .AddParameter("FlowId", DbType.Decimal, 9, processinstanceItem.FlowId)
                                .AddParameter("StepId", DbType.Decimal, 9, processinstanceItem.StepId)
                                .AddParameter("TaskId", DbType.Decimal, 9, processinstanceItem.TaskId)
                                .AddParameter("Created", DbType.DateTime, 9, processinstanceItem.Created)
                                .AddParameter("StartDate", DbType.DateTime, 9, processinstanceItem.StartDate)
                                .AddParameter("DueDate", DbType.DateTime, 9, processinstanceItem.DueDate)
                                .AddParameter("FinishDate", DbType.DateTime, 9, processinstanceItem.FinishDate)
                                .AddParameter("PreviousActivityId", DbType.Decimal, 9, processinstanceItem.PreviousActivityId)
                                .AddParameter("UserId", DbType.Decimal, 9, processinstanceItem.UserId)
                                .AddParameter("Comments", DbType.AnsiString, 350, processinstanceItem.Comments)
                                .AddParameter("LastOverDueNotify", DbType.DateTime, 9, processinstanceItem.LastOverDueNotify)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processinstanceItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processinstanceItem.UpdateDate)
                                .AddParameter("ActivityId", DbType.Decimal, 9, processinstanceItem.ActivityId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessInstance por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processinstanceItems">Lista de instancia de ProcessInstance</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessInstance> processinstanceItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessInstance item in processinstanceItems)
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
        /// Elimina un registro en la tabla ProcessInstance por medio de su clave primaria.
        /// </summary>
        /// <param name="activityid">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int activityid, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessInstance " +
                                    "WHERE ActivityId=:ActivityId AND CompanyId=:CompanyId")
                                .AddParameter("ActivityId", DbType.Decimal, 9, activityid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessInstance por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="activityidList">Lista de .</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> activityidList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in activityidList)
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessInstance por medio de su clave primaria.
        /// </summary>
        /// <param name="activityid">.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int activityid, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(ActivityId) " +
                                          "FROM ProcessInstance " +
                                         "WHERE ActivityId=:ActivityId AND CompanyId=:CompanyId")
                               .AddParameter("ActivityId", DbType.Decimal, 9, activityid)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessInstance que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(ActivityId) " +
                                          "FROM ProcessInstance " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessInstance'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessInstance DataReaderToProcessInstance(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessInstance item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessInstance();
            }
            item.ActivityId = reader.IntegerValue("ActivityId");
            item.InstanceId = reader.IntegerValue("InstanceId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.EntityType = reader.IntegerValue("EntityType");
            item.EntityId = reader.Integer64Value("EntityId");
            item.CaseId = reader.IntegerValue("CaseId");
            item.FlowId = reader.IntegerValue("FlowId");
            item.StepId = reader.IntegerValue("StepId");
            item.TaskId = reader.IntegerValue("TaskId");
            item.Created = reader.DateTimeValue("Created");
            item.StartDate = reader.DateTimeValue("StartDate");
            item.DueDate = reader.DateTimeValue("DueDate");
            item.FinishDate = reader.DateTimeValue("FinishDate");
            item.PreviousActivityId = reader.IntegerValue("PreviousActivityId");
            item.UserId = reader.IntegerValue("UserId");
            item.Comments = reader.StringValue("Comments");
            item.LastOverDueNotify = reader.DateTimeValue("LastOverDueNotify");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

