using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// ProcessCase
    /// </summary>
    public sealed partial class ProcessCase
    {

        public static int Update(int caseId, int activityId, int status, string label, int substatus, string sublabel, int currentStepId, IDbConnection currentConnection = null)
        {
            return Database.Update("UPDATE ProcessCase " +
                                      "SET InstanceId=:InstanceId, Status=:Status, Label=:Label, SubStatus=:SubStatus, SubLabel=:SubLabel, CurrentStepId=:CurrentStepId " +
                                    "WHERE Id=:Id")
                                .AddParameter("InstanceId", DbType.Decimal, 9, activityId)
                                .AddParameter("Status", DbType.Decimal, 3, status)
                                .AddParameter("Label", DbType.AnsiString, 80, label)
                                .AddParameter("SubStatus", DbType.Decimal, 3, substatus)
                                .AddParameter("SubLabel", DbType.AnsiString, 80, sublabel)
                                .AddParameter("CurrentStepId", DbType.Decimal, 9, currentStepId)
                                .AddParameter("Id", DbType.Decimal, 9, caseId)
                                .Execute(currentConnection, "Research");
        }

        public static int ProgressUpdate(Contracts.General.ProcessCase processCase, IDbConnection currentConnection = null)
        {
            return Database.Update("ProcessCase", ExecuteMode.CommandBuilder)
                                .Column("InstanceId", DbType.Decimal, 9, processCase.InstanceId)
                                .Column("Status", DbType.Decimal, 3, processCase.Status)
                                .Column("Label", DbType.AnsiString, 80, processCase.Label)
                                .Column("SubStatus", DbType.Decimal, 3, processCase.SubStatus)
                                .Column("SubLabel", DbType.AnsiString, 80, processCase.SubLabel)
                                .Column("CurrentStepId", DbType.Decimal, 9, processCase.CurrentStepId)

                                .Column("UserAssigned", DbType.Decimal, 9, processCase.UserAssigned)
                                .Column("UserAssignedDate", DbType.DateTime, 9, processCase.UserAssignedDate)
                                .Column("StepCurrent", DbType.Decimal, 9, processCase.StepCurrent)
                                .Column("FinishDate", DbType.DateTime, 9, processCase.FinishDate)
                                .Column("Progress", DbType.Decimal, 5, processCase.Progress)
                                .Filter("Id", DbType.Decimal, 9, processCase.Id)
                    .Execute(currentConnection, "Research");
        }

        public static int FirstUpdate( Contracts.General.ProcessCase processCase, IDbConnection currentConnection = null)
        {

            return Database.Update("ProcessCase", ExecuteMode.CommandBuilder)
                                .Column("InstanceId", DbType.Decimal, 9, processCase.InstanceId)
                                .Column("Status", DbType.Decimal, 3, processCase.Status)
                                .Column("Label", DbType.AnsiString, 80, processCase.Label)
                                .Column("SubStatus", DbType.Decimal, 3, processCase.SubStatus)
                                .Column("SubLabel", DbType.AnsiString, 80, processCase.SubLabel)
                                .Column("CurrentStepId", DbType.Decimal, 9, processCase.CurrentStepId)
                                .Column("UserAssigned", DbType.Decimal, 9, processCase.UserAssigned)
                                .Column("UserAssignedDate", DbType.DateTime, 9, processCase.UserAssignedDate)
                                .Column("StepCurrent", DbType.Decimal, 9, processCase.StepCurrent)
                                .Column("StepTotal", DbType.Decimal, 9, processCase.StepTotal)
                                .Column("StartDate", DbType.DateTime, 9, processCase.StartDate)
                                .Column("DueDate", DbType.DateTime, 9, processCase.DueDate)
                                .Column("Progress", DbType.Decimal, 5, processCase.Progress)
                                .Filter("Id", DbType.Decimal, 9, processCase.Id)
                    .Execute(currentConnection, "Research");
        }


        public static List<Architect.API.Core.Contracts.General.ProcessCase> DataToFix()
        {
            List<Architect.API.Core.Contracts.General.ProcessCase> result = new List<Architect.API.Core.Contracts.General.ProcessCase>();

            Database.Select(
@"SELECT DISTINCT CASEID FROM (
SELECT T1.CASEID FROM ALIADOS.PROCESSINSTANCE T1 JOIN ALIADOS.PROCESSCASE T2 ON T1.CASEID = T2.ID AND T2.STATUS IN ( 3, 6) WHERE T1.COMPANYID =100 AND  T1.STEPID = 0 AND T1.TASKID = 0 AND T1.FINISHDATE IS NULL
UNION
SELECT T2.ID CASEID FROM ALIADOS.PROCESSCASE T2 JOIN ALIADOS.PROCESSINSTANCE T1 ON T1.CASEID = T2.ID AND T1.STEPID = 0 AND T1.TASKID = 0 AND NOT T1.FINISHDATE IS NULL WHERE T2.COMPANYID =100 AND  NOT T2.STATUS IN ( 3, 6)
)")
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.General.ProcessCase()
                            {
                                Id = reader.IntegerValue("CASEID")
                            });
                        }));
            return result;
        }

    }

}

