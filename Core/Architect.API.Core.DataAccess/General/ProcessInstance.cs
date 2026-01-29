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
            Database.Select("SELECT ActivityId, ProcessInstance.InstanceId, CaseId, ProcessInstance.CompanyId, EntityType, EntityId, ProcessInstance.FlowId, StepId, TaskId, Created, StartDate, EarlyDueDate, DueDate, FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, pc.SLA, ProcessInstance.UpdateUserCode, ProcessInstance.UpdateDate, LastOverDueNotify " +
                              "FROM ProcessInstance " +
                              "LEFT JOIN ProcessCase pc ON pc.InstanceId = ProcessInstance.InstanceId " +
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
                                EarlyDueDate = reader.DateTimeValue("EarlyDueDate"),
                                FinishDate = reader.DateTimeValue("FinishDate"),
                                PreviousActivityId = reader.IntegerValue("PreviousActivityId"),
                                UserId = reader.IntegerValue("UserId"),
                                Comments = reader.StringValue("Comments"),
                                LastOverDueNotify = reader.DateTimeValue("LastOverDueNotify"),
                                SLA = reader.IntegerValue("SLA")
                            });
                        }));
            return result;
        }

        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveByEntity(int entityType, long entityId, int companyId, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessInstance> result = new List<Architect.API.Core.Contracts.General.ProcessInstance>();
            Database.Select("SELECT ActivityId, ProcessInstance.InstanceId, CaseId, ProcessInstance.CompanyId, EntityType, EntityId, ProcessInstance.FlowId, StepId, TaskId, Created, StartDate, EarlyDueDate, DueDate, FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, pc.SLA, ProcessInstance.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessInstance.UpdateDate " +
                              "FROM ProcessInstance " +
                              "LEFT JOIN UserMember um ON um.UserId = ProcessInstance.UserId " +
                              "LEFT JOIN ProcessCase pc ON pc.InstanceId = ProcessInstance.InstanceId " +
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
                                EarlyDueDate = reader.DateTimeValue("EarlyDueDate"),
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
            List<Contracts.General.ProcessInstance> result = new List<Contracts.General.ProcessInstance>();
            Database.Select("SELECT ActivityId, ProcessInstance.InstanceId, CaseId, ProcessInstance.CompanyId, EntityType, EntityId, ProcessInstance.FlowId, StepId, TaskId, Created, ProcessInstance.StartDate, EarlyDueDate, ProcessInstance.DueDate, ProcessInstance.FinishDate, PreviousActivityId, ProcessInstance.UserId, Comments, pc.SLA, ProcessInstance.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessInstance.UpdateDate, ProcessInstance.UserAssigned, ProcessInstance.UserAssignedDate " +
                              "FROM ProcessInstance " +
                              "LEFT JOIN UserMember um ON um.UserId = ProcessInstance.UserId " +
                              "LEFT JOIN ProcessCase pc ON pc.InstanceId = ProcessInstance.InstanceId " +
                             "WHERE ProcessInstance.CompanyId=:CompanyId AND ProcessInstance.InstanceId=:InstanceId " +
                             "ORDER BY ActivityId")
                        .AddParameter("CompanyId", DbType.Double, 5, companyId)
                        .AddParameter("InstanceId", DbType.Double, 5, instanceId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Contracts.General.ProcessInstance()
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
                                EarlyDueDate = reader.DateTimeValue("EarlyDueDate"),
                                FinishDate = reader.DateTimeValue("FinishDate"),
                                PreviousActivityId = reader.IntegerValue("PreviousActivityId"),
                                UserId = reader.IntegerValue("UserId"),
                                UserName = reader.StringValue("UpdateUserName"),
                                Comments = reader.StringValue("Comments"),
                                SLA = reader.IntegerValue("SLA"),
                                UserAssigned = reader.IntegerValue("UserAssigned"),
                                UserAssignedDate = reader.DateTimeValue("UserAssignedDate")
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

        /// <summary>
        /// Elimina un registro en la tabla ProcessInstance por medio del campo CaseId.
        /// </summary>
        public static int DeleteByCaseId(int caseId, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessInstance " +
                                    "WHERE CaseId=:CaseId AND CompanyId=:CompanyId")
                                .AddParameter("CaseId", DbType.Decimal, 9, caseId)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }


        public static List<Architect.API.Core.Contracts.Security.UserMember> EmailInfoByRoleName(int companyid, string rolename1, string rolename2, string rolename3, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
            Database.Select(
@"SELECT UM.USERID, UM.FIRSTNAME || ' ' || UM.LASTNAME AS NOMBRE_USUARIO, UM.EMAIL, COUNT(PI.ACTIVITYID) AS TOTAL_TAREAS_PENDIENTES
  FROM ALIADOS.ROLEMEMBER RM
  JOIN ALIADOS.USERROLEMEMBER URM ON URM.COMPANYID = 100 AND RM.ROLEID = URM.ROLEID 
  JOIN ALIADOS.USERMEMBER UM ON UM.COMPANYID = :CompanyId AND URM.USERID = UM.USERID 
  LEFT JOIN ALIADOS.PROCESSINSTANCE PI ON PI.COMPANYID = :CompanyId AND UM.USERID = PI.USERASSIGNED AND PI.STEPID > 0 AND PI.TASKID = 0 AND PI.FINISHDATE IS NULL 
 WHERE RM.COMPANYID = :CompanyId AND RM.ROLENAME IN (:Rolename1,:Rolename2,:Rolename3) 
 GROUP BY UM.USERID, UM.FIRSTNAME, UM.LASTNAME, UM.EMAIL
 ORDER BY TOTAL_TAREAS_PENDIENTES ASC, NOMBRE_USUARIO ASC")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .AddParameter("Rolename1", DbType.AnsiString, 255, rolename1)
                .AddParameter("Rolename2", DbType.AnsiString, 255, rolename2)
                .AddParameter("Rolename3", DbType.AnsiString, 255, rolename3)
                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                    result.Add(new Architect.API.Core.Contracts.Security.UserMember()
                    {
                        UserId = reader.IntegerValue("USERID"),
                        FirstName = reader.StringValue("NOMBRE_USUARIO"),
                        FailedPasswordCount = reader.IntegerValue("TOTAL_TAREAS_PENDIENTES"),
                        EMail = reader.StringValue("EMail")
                    });
                }));
            return result;
        }

    }

}

