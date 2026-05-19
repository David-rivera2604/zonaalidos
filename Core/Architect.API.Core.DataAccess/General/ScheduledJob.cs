using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Acceso a datos para la tabla ScheduledJob.
    /// </summary>
    public static class ScheduledJob
    {
        private const string ConnectionName = "Research";

        /// <summary>
        /// Recupera los Jobs activos.
        /// </summary>
        public static List<Contracts.General.ScheduledJob> RetrieveActive(IDbConnection connection = null)
        {
            List<Contracts.General.ScheduledJob> result = new List<Contracts.General.ScheduledJob>();
            Database.Select(
@"SELECT ID, JOB_NAME, JOB_TYPE, EXECUTION_TIME, REPORT_ID, REPORT_PARAMS,
         OUTPUT_FILE_NAME, MAIL_TEMPLATE, IS_ACTIVE, LAST_RUN_AT, LAST_STATUS, LAST_ERROR
    FROM ScheduledJob
   WHERE IS_ACTIVE = 1
   ORDER BY EXECUTION_TIME, ID")
                .Query(connection, ConnectionName, new Action<IDataReader>((reader) =>
                {
                    result.Add(new Contracts.General.ScheduledJob()
                    {
                        JobId = reader.IntegerValue("ID"),
                        JobName = reader.StringValue("JOB_NAME"),
                        JobType = reader.StringValue("JOB_TYPE"),
                        ExecutionTime = reader.StringValue("EXECUTION_TIME"),
                        ReportId = reader.StringValue("REPORT_ID"),
                        ReportParams = reader.StringValue("REPORT_PARAMS"),
                        OutputFileName = reader.StringValue("OUTPUT_FILE_NAME"),
                        MailTemplate = reader.StringValue("MAIL_TEMPLATE"),
                        IsActive = reader.IntegerValue("IS_ACTIVE") == 1,
                        LastRunAt = reader.DateTimeNullableValue("LAST_RUN_AT"),
                        LastStatus = reader.StringValue("LAST_STATUS"),
                        LastError = reader.StringValue("LAST_ERROR")
                    });
                }));
            return result;
        }

        /// <summary>
        /// Actualiza el resultado de la última ejecución del Job.
        /// </summary>
        public static int UpdateLastRun(int jobId, DateTime lastRunAt, string status, string error, IDbConnection connection = null)
        {
            if (error.IsNotEmpty() && error.Length > 2000)
            {
                error = error.Substring(0, 2000);
            }

            return Database.Update(
@"UPDATE ScheduledJob
     SET LAST_RUN_AT = :LAST_RUN_AT,
         LAST_STATUS = :LAST_STATUS,
         LAST_ERROR  = :LAST_ERROR,
         UPDATEDATE  = SYSDATE
   WHERE ID = :ID")
                .AddParameter("LAST_RUN_AT", DbType.DateTime, 0, lastRunAt)
                .AddParameter("LAST_STATUS", DbType.AnsiString, 20, status)
                .AddParameter("LAST_ERROR", DbType.AnsiString, 2000, error ?? string.Empty)
                .AddParameter("ID", DbType.Decimal, 9, jobId)
                .Execute(connection, ConnectionName);
        }
    }
}
