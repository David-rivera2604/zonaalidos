using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
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
        /// Actualiza la fecha de la ultima notificación por concepto de SLA.
        /// </summary>
        /// <param name="activityId">.</param>
        /// <param name="lastOverDueNotify">Last Over Due Notify.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(int activityId, DateTime lastOverDueNotify, IDbConnection connection = null)
        {
            return Database.Update("ProcessInstance", ExecuteMode.CommandBuilder)
                    .Column("LastOverDueNotify", DbType.DateTime, 9, lastOverDueNotify)
                    .Filter("ActivityId", DbType.Decimal, 9, activityId)
                    .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera todas las tareas vencidas a la fecha
        /// </summary>
        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveOverDueSteps(DateTime dueDate, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessInstance> result = new();
            Database.Select("SELECT ActivityId, InstanceId, CaseId, CompanyId, EntityType, EntityId, FlowId, StepId, TaskId, Created, StartDate, DueDate, FinishDate, PreviousActivityId, UserId, Comments, UpdateUserCode, UpdateDate, LastOverDueNotify " +
                              "FROM ProcessInstance " +
                             "WHERE FinishDate IS NULL AND NOT DueDate IS NULL AND DueDate < :DueDate " +
                             "ORDER BY DueDate")
                        .AddParameter("DueDate", DbType.DateTime, 9, dueDate)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.General.ProcessInstance()
                            {
                                ActivityId = reader.IntegerValue("ActivityId"),
                                InstanceId = reader.IntegerValue("InstanceId"),
                                CompanyId = reader.IntegerValue("CompanyId"),
                                EntityType = reader.IntegerValue("EntityType"),
                                EntityId = reader.Integer64Value("EntityId"),
                                CaseId = reader.IntegerValue("CaseId"),
                                FlowId = reader.IntegerValue("FlowId"),
                                StepId = reader.IntegerValue("StepId"),
                                TaskId = reader.IntegerValue("TaskId"),
                                Created = reader.DateTimeValue("Created"),
                                StartDate = reader.DateTimeValue("StartDate"),
                                DueDate = reader.DateTimeValue("DueDate"),
                                FinishDate = reader.DateTimeValue("FinishDate"),
                                PreviousActivityId = reader.IntegerValue("PreviousActivityId"),
                                UserId = reader.IntegerValue("UserId"),
                                Comments = reader.StringValue("Comments"),
                                LastOverDueNotify = reader.DateTimeValue("LastOverDueNotify")
                            });
                        }));
            return result;
        }

        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveByEntity(int entityType, long entityId, int companyId, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessInstance> result = new List<Architect.API.Core.Contracts.General.ProcessInstance>();
            Database.Select("SELECT ActivityId, InstanceId, CaseId, ProcessInstance.CompanyId, EntityType, EntityId, FlowId, StepId, TaskId, Created, StartDate, DueDate, FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, ProcessInstance.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessInstance.UpdateDate " +
                              "FROM ProcessInstance " +
                              "LEFT JOIN UserMember um ON um.UserId = ProcessInstance.UserId " +
                             "WHERE ProcessInstance.CompanyId=:CompanyId AND EntityType=:EntityType AND EntityId=:EntityId " +
                             "ORDER BY ActivityId")
                        .AddParameter("CompanyId", DbType.Double, 5, companyId)
                        .AddParameter("EntityType", DbType.Double, 5, entityType)
                        .AddParameter("EntityId", DbType.Decimal, 18, entityId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.General.ProcessInstance()
                            {
                                ActivityId = reader.IntegerValue("ActivityId"),
                                InstanceId = reader.IntegerValue("InstanceId"),
                                CompanyId = reader.IntegerValue("CompanyId"),
                                EntityType = reader.IntegerValue("EntityType"),
                                EntityId = reader.Integer64Value("EntityId"),
                                CaseId = reader.IntegerValue("CaseId"),
                                FlowId = reader.IntegerValue("FlowId"),
                                StepId = reader.IntegerValue("StepId"),
                                TaskId = reader.IntegerValue("TaskId"),
                                Created = reader.DateTimeValue("Created"),
                                StartDate = reader.DateTimeValue("StartDate"),
                                DueDate = reader.DateTimeValue("DueDate"),
                                FinishDate = reader.DateTimeValue("FinishDate"),
                                PreviousActivityId = reader.IntegerValue("PreviousActivityId"),
                                UserId = reader.IntegerValue("UserId"),
                                UserName = reader.StringValue("UpdateUserName"),
                                Comments = reader.StringValue("Comments")
                            });
                        }));
            return result;
        }

        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveByInstanceId(int instanceId, int companyId, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessInstance> result = new List<Architect.API.Core.Contracts.General.ProcessInstance>();
            Database.Select("SELECT ActivityId, InstanceId, CaseId, ProcessInstance.CompanyId, EntityType, EntityId, FlowId, StepId, TaskId, Created, StartDate, DueDate, FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, ProcessInstance.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessInstance.UpdateDate " +
                              "FROM ProcessInstance " +
                              "LEFT JOIN UserMember um ON um.UserId = ProcessInstance.UserId " +
                             "WHERE ProcessInstance.CompanyId=:CompanyId AND ProcessInstance.InstanceId=:InstanceId " +
                             "ORDER BY ActivityId")
                        .AddParameter("CompanyId", DbType.Double, 5, companyId)
                        .AddParameter("InstanceId", DbType.Double, 5, instanceId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.General.ProcessInstance()
                            {
                                ActivityId = reader.IntegerValue("ActivityId"),
                                InstanceId = reader.IntegerValue("InstanceId"),
                                CompanyId = reader.IntegerValue("CompanyId"),
                                EntityType = reader.IntegerValue("EntityType"),
                                EntityId = reader.Integer64Value("EntityId"),
                                CaseId = reader.IntegerValue("CaseId"),
                                FlowId = reader.IntegerValue("FlowId"),
                                StepId = reader.IntegerValue("StepId"),
                                TaskId = reader.IntegerValue("TaskId"),
                                Created = reader.DateTimeValue("Created"),
                                StartDate = reader.DateTimeValue("StartDate"),
                                DueDate = reader.DateTimeValue("DueDate"),
                                FinishDate = reader.DateTimeValue("FinishDate"),
                                PreviousActivityId = reader.IntegerValue("PreviousActivityId"),
                                UserId = reader.IntegerValue("UserId"),
                                UserName = reader.StringValue("UpdateUserName"),
                                Comments = reader.StringValue("Comments")
                            });
                        }));
            return result;
        }

        public static int RetrieveLastInstanceId(IDbConnection currentConnection = null)
        {

            return Convert.ToInt32(Database.Select("SELECT NVL(MAX(instanceId),0) " +
                                     "FROM ProcessInstance")
                                .QueryScalar<Decimal>(currentConnection, "Research"));
        }

        public static int CountByEntity(int entityType, long entityId, int companyId, IDbConnection connection = null)
        {
            return Count(" WHERE CompanyId=:CompanyId AND EntityType=:EntityType AND EntityId=:EntityId",
                         Database.ParameterList().
                            AddParameter("CompanyId", DbType.Double, 5, companyId)
                            .AddParameter("EntityType", DbType.Double, 5, entityType)
                            .AddParameter("EntityId", DbType.Decimal, 18, entityId).Parameters, connection);
        }

    }

}

