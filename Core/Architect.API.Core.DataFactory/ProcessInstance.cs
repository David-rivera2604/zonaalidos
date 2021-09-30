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
    public static partial class ProcessInstance
    {
        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveByEntity2(int entityType, long entityId, int companyId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                               " AND EntityType=:EntityType AND EntityId=:EntityId ",
                               Database.ParameterList().AddParameter("EntityType", DbType.Double, 5, entityType)
                                                       .AddParameter("EntityId", DbType.Decimal, 18, entityId).Parameters, connection);
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

        public static List<Architect.API.Core.Contracts.General.ProcessInstance> RetrieveByInstanceId2(int instanceId, int companyId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                               " AND ProcessInstance.InstanceId=:InstanceId ",
                               Database.ParameterList().AddParameter("InstanceId", DbType.Double, 5, instanceId).Parameters, connection);
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

        public static int CountByEntity2(int entityType, long entityId, int companyId, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(ActivityId) " +
                                     "FROM ProcessInstance " +
                                    "WHERE CompanyId=:CompanyId AND EntityType=:EntityType AND EntityId=:EntityId")
                  .AddParameter("CompanyId", DbType.Double, 5, companyId)
                        .AddParameter("EntityType", DbType.Double, 5, entityType)
                        .AddParameter("EntityId", DbType.Decimal, 18, entityId)
                               .QueryScalar<Decimal>(connection, "Research");
        }
    }

}

