using Architect.Utilities.Extensions;
using Architect.Utilities.Helpers;
using Hangfire;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IdentityModel.Metadata;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Despachador de Jobs programados definidos en la tabla ScheduledJob.
    /// Está pensado para ejecutarse periódicamente desde Hangfire (ej.: cada hora).
    /// El comportamiento es:
    /// 1. Lee los Jobs activos de la tabla.
    /// 2. Para cada Job calcula la hora programada de hoy a partir de EXECUTION_TIME ('HH:mm').
    /// 3. Si esa hora ya pasó y el Job aún no se ha ejecutado hoy, lo encola.
    /// Esto permite que un Job programado a las 08:00 que no corrió aún (porque el dispatcher
    /// se ejecuta a las 09:00) se dispare en la siguiente corrida.
    /// </summary>
    public static class ScheduledJobs
    {
        private const string LogCategory = "ScheduledJobs";
        public const string TypeReportEmail = "REPORT_EMAIL";

        /// <summary>
        /// Punto de entrada llamado por Hangfire.
        /// </summary>
        [AutomaticRetry(Attempts = 0)]
        public static void ExecuteDue()
        {
            DateTime now = DateTime.Now;
            Architect.Utilities.Log.TraceLog(LogCategory, $"Inicio - Revisión de Jobs programados ({now:yyyy-MM-dd HH:mm})", LogCategory);

            List<Architect.API.Core.Contracts.General.ScheduledJob> jobs;
            try
            {
                jobs = Architect.API.Core.DataAccess.General.ScheduledJob.RetrieveActive();
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(LogCategory, "Error al recuperar Jobs activos", ex);
                return;
            }

            foreach (Architect.API.Core.Contracts.General.ScheduledJob job in jobs)
            {
                try
                {
                    DateTime? scheduledToday = ResolveScheduledToday(job.ExecutionTime, now);
                    if (!scheduledToday.HasValue)
                    {
                        Architect.Utilities.Log.WarningLog(LogCategory, $"Job '{job.JobName}' tiene EXECUTION_TIME inválido: '{job.ExecutionTime}'", LogCategory);
                        continue;
                    }

                    if (now < scheduledToday.Value)
                    {
                        // Aún no es hora de ejecutar.
                        continue;
                    }

                    if (job.LastRunAt.HasValue && job.LastRunAt.Value >= scheduledToday.Value)
                    {
                        // Ya se ejecutó hoy a la hora programada (o después).
                        continue;
                    }

                    Architect.Utilities.Log.TraceLog(LogCategory, $"Encolando Job '{job.JobName}' (id={job.JobId})", LogCategory);
                    BackgroundJob.Enqueue(() => Run(job.JobId));
                }
                catch (Exception ex)
                {
                    Architect.Utilities.Log.ErrorLog(LogCategory, $"Error al evaluar Job '{job.JobName}'", ex);
                }
            }

            Architect.Utilities.Log.TraceLog(LogCategory, "Fin - Revisión de Jobs programados", LogCategory);
        }

        /// <summary>
        /// Ejecuta un Job individual. Es invocado por Hangfire.
        /// </summary>
        [AutomaticRetry(Attempts = 0)]
        public static void Run(int jobId)
        {
            DateTime startedAt = DateTime.Now;
            Architect.API.Core.Contracts.General.ScheduledJob job = null;

            // Recuperar definición.
            try
            {
                List<Architect.API.Core.Contracts.General.ScheduledJob> all = Architect.API.Core.DataAccess.General.ScheduledJob.RetrieveActive();
                job = all.Find(j => j.JobId == jobId);
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(LogCategory, $"No se pudo cargar el Job id={jobId}", ex);
                return;
            }

            if (job == null)
            {
                Architect.Utilities.Log.WarningLog(LogCategory, $"El Job id={jobId} ya no está activo o no existe", LogCategory);
                return;
            }

            Architect.Utilities.Log.TraceLog(LogCategory, $"Ejecutando Job '{job.JobName}' (tipo={job.JobType})", LogCategory);

            string status = "ERROR";
            string error = null;

            try
            {
                if (string.Equals(job.JobType, TypeReportEmail, StringComparison.OrdinalIgnoreCase))
                {
                    ExecuteReportEmail(job);
                }
                else
                {
                    throw new NotSupportedException($"JOB_TYPE no soportado: '{job.JobType}'");
                }

                // Si llegamos aquí, la ejecución fue exitosa
                status = "OK";
                Architect.Utilities.Log.TraceLog(LogCategory, $"Job '{job.JobName}' finalizado correctamente", LogCategory);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Architect.Utilities.Log.ErrorLog(LogCategory, $"Falla en Job '{job.JobName}'", ex);
            }
            finally
            {
                // Siempre actualizar el estado del Job, sea éxito o fallo
                try
                {
                    Architect.API.Core.DataAccess.General.ScheduledJob.UpdateLastRun(job.JobId, startedAt, status, error);
                }
                catch (Exception exu)
                {
                    Architect.Utilities.Log.ErrorLog(LogCategory, $"Error al actualizar estado del Job '{job.JobName}'", exu);
                }
            }
        }

        /// <summary>
        /// Ejecuta una consulta (definida por REPORT_ID/REPORT_PARAMS), genera un Excel
        /// y lo envía por correo usando MAIL_TEMPLATE.
        /// </summary>
        private static void ExecuteReportEmail(Architect.API.Core.Contracts.General.ScheduledJob job)
        {
            if (job.ReportId.IsEmpty())
            {
                throw new InvalidOperationException("REPORT_ID es requerido para JOB_TYPE='REPORT_EMAIL'");
            }
            if (job.MailTemplate.IsEmpty())
            {
                throw new InvalidOperationException("MAIL_TEMPLATE es requerido para JOB_TYPE='REPORT_EMAIL'");
            }

            string outputFileName = job.OutputFileName.IsEmpty() ? job.ReportId + ".xlsx" : job.OutputFileName;
            string reportParams = ResolveTokens(job.ReportParams);

            string title = string.Empty;
            string tempPath = "Attachments.Path".StringValue();
            string targetPath = tempPath + outputFileName;

            string attachFileName = Architect.Data.Source.Business.ExcelExport.GenerateFile(
                job.ReportId, 0, reportParams,
                new Architect.API.Core.Contracts.Security.Token(),
                ref title,
                targetPath);

            Mail.EnqueueSend(
                "Default", 0, 0, 0, job.MailTemplate, null, null, null, null,
                new[] { string.Format("{0};{1}", attachFileName, outputFileName) }, true);
        }

        /// <summary>
        /// Reemplaza tokens dinámicos dentro de REPORT_PARAMS:
        ///   {guid}             -> nuevo Guid
        ///   {date:yyyyMMdd}    -> fecha actual con el formato indicado
        /// </summary>
        private static string ResolveTokens(string source)
        {
            if (source.IsEmpty())
            {
                return string.Empty;
            }

            string result = source.Replace("{guid}", Guid.NewGuid().ToString());

            int idx;
            while ((idx = result.IndexOf("{date:", StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                int end = result.IndexOf('}', idx);
                if (end < 0) break;
                string format = result.Substring(idx + 6, end - idx - 6);
                string value;
                try { value = DateTime.Now.ToString(format); }
                catch { value = DateTime.Now.ToString("yyyyMMdd"); }
                result = result.Substring(0, idx) + value + result.Substring(end + 1);
            }

            return result;
        }

        /// <summary>
        /// Convierte una hora 'HH:mm' en un DateTime de hoy.
        /// </summary>
        private static DateTime? ResolveScheduledToday(string executionTime, DateTime now)
        {
            if (executionTime.IsEmpty())
            {
                return null;
            }

            string[] parts = executionTime.Trim().Split(':');
            if (parts.Length < 2) return null;

            int hour, minute;
            if (!int.TryParse(parts[0], out hour) || !int.TryParse(parts[1], out minute))
            {
                return null;
            }
            if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
            {
                return null;
            }
            return new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);
        }
    
    }
}
