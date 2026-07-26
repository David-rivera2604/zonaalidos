using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Process.DataAccess.General
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


        public static List<Architect.API.Process.Contracts.General.ProcessCase> DataToFix()
        {
            List<Architect.API.Process.Contracts.General.ProcessCase> result = new List<Architect.API.Process.Contracts.General.ProcessCase>();

            Database.Select(
@"SELECT DISTINCT CASEID FROM (
SELECT T1.CASEID FROM ALIADOS.PROCESSINSTANCE T1 JOIN ALIADOS.PROCESSCASE T2 ON T1.CASEID = T2.ID AND T2.STATUS IN ( 3, 6) WHERE T1.COMPANYID =100 AND  T1.STEPID = 0 AND T1.TASKID = 0 AND T1.FINISHDATE IS NULL
UNION
SELECT T2.ID CASEID FROM ALIADOS.PROCESSCASE T2 JOIN ALIADOS.PROCESSINSTANCE T1 ON T1.CASEID = T2.ID AND T1.STEPID = 0 AND T1.TASKID = 0 AND NOT T1.FINISHDATE IS NULL WHERE T2.COMPANYID =100 AND  NOT T2.STATUS IN ( 3, 6)
)")
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Process.Contracts.General.ProcessCase()
                            {
                                Id = reader.IntegerValue("CASEID")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Alerta de posible caso duplicado por asunto/datos obligatorios
        /// </summary>
        public static int CaseExist(int companyId, Architect.API.Process.Contracts.General.ProcessCase processcaseItem, IDbConnection connection = null)
        {
            List<DataFactory.Contracts.Parameter> parameters = new List<DataFactory.Contracts.Parameter>();
            string condition = "";
            Contracts.General.ProcessSpecFlow process = ProcessSpecFlow.Retrieve(processcaseItem.FlowId, companyId, connection);


            FilterReferenceRequired(1, process.ReferenceCaption1, process.ReferenceRequired1, processcaseItem.Reference1, ref parameters, ref condition);
            FilterReferenceRequired(2, process.ReferenceCaption2, process.ReferenceRequired2, processcaseItem.Reference2, ref parameters, ref condition);
            FilterReferenceRequired(3, process.ReferenceCaption3, process.ReferenceRequired3, processcaseItem.Reference3, ref parameters, ref condition);
            FilterReferenceRequired(4, process.ReferenceCaption4, process.ReferenceRequired4, processcaseItem.Reference4, ref parameters, ref condition);
            FilterReferenceRequired(5, process.ReferenceCaption5, process.ReferenceRequired5, processcaseItem.Reference5, ref parameters, ref condition);
            FilterReferenceRequired(6, process.ReferenceCaption6, process.ReferenceRequired6, processcaseItem.Reference6, ref parameters, ref condition);
            FilterReferenceRequired(7, process.ReferenceCaption7, process.ReferenceRequired7, processcaseItem.Reference7, ref parameters, ref condition);
            FilterReferenceRequired(8, process.ReferenceCaption8, process.ReferenceRequired8, processcaseItem.Reference8, ref parameters, ref condition);
            FilterReferenceRequired(9, process.ReferenceCaption9, process.ReferenceRequired9, processcaseItem.Reference9, ref parameters, ref condition);
            FilterReferenceRequired(10, process.ReferenceCaption10, process.ReferenceRequired10, processcaseItem.Reference10, ref parameters, ref condition);


            // AND pc.Priority =:Priority
            // AND LOWER(pc.ContactMainName)=:ContactMainName
            // AND LOWER(pc.ContactMainEmail)=:ContactMainEmail

            int count = (int)Database.Select(
 @"SELECT COUNT(Id)
    FROM ProcessCase pc
   WHERE pc.CompanyId=:CompanyId
     AND pc.FlowId=:FlowId
     AND LOWER(pc.Title) =:Title" + condition)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .AddParameter("FlowId", DbType.Decimal, 9, processcaseItem.FlowId)
                                //.AddParameter("Priority", DbType.Decimal, 3, processcaseItem.Priority)
                                .AddParameter("Title", DbType.AnsiString, 120, processcaseItem.Title.ToLower())
                                //.AddParameter("ContactMainName", DbType.AnsiString, 256, processcaseItem.ContactMainName.ToLower())
                                //.AddParameter("ContactMainEmail", DbType.AnsiString, 256, processcaseItem.ContactMainEmail.ToLower())
                                .AddParameter(parameters)
                                .QueryScalar<Decimal>(connection, "Research");
            return count;
        }

        public static void FilterReferenceRequired(int index, string caption, bool isRequired, string value, ref List<DataFactory.Contracts.Parameter> parameters, ref string condition)
        {
            if (caption.IsNotEmpty() && isRequired)
            {
                condition += $" AND LOWER(Reference{index})=:Reference{index}";

                parameters.Add(new DataFactory.Contracts.Parameter { Name = $"Reference{index}", Type = DbType.AnsiString, Size = 80, Value = value.ToLower(), direction = ParameterDirection.Input });
            }
        }



        /// <summary>
        /// Actualiza unicamente USERASSIGNED y USERASSIGNEDDATE en PROCESSCASE por CaseId.
        /// Se usa cuando cambia de etapa automaticamente para mantener sincronizado el caso.
        /// </summary>
        public static int UpdateUserAssigned(int caseId, int companyId, int userAssigned, DateTime userAssignedDate, IDbConnection connection = null)
        {
            return Database.Update("ProcessCase", ExecuteMode.CommandBuilder)
                .Column("UserAssigned",     DbType.Decimal,  9, userAssigned)
                .Column("UserAssignedDate", DbType.DateTime, 9, userAssignedDate)
                .Column("UpdateDate",       DbType.DateTime, 9, DateTime.Now)
                .Filter("Id",              DbType.Decimal,  9, caseId)
                .Filter("CompanyId",       DbType.Decimal,  5, companyId)
                .Execute(connection, "Research");
        }

    }

}

