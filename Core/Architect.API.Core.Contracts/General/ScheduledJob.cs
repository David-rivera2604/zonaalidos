using System;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Definición de un Job programado para ejecución diaria a una hora específica.
    /// Por ahora solo se soporta el tipo REPORT_EMAIL: ejecuta una consulta y envía el
    /// resultado en Excel mediante un template de correo.
    /// </summary>
    public class ScheduledJob
    {
        /// <summary>
        /// Identificador único del Job. Generado por la secuencia <c>SEQ_ScheduledJob</c>.
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// Nombre lógico del Job. Se utiliza solo para identificación y trazabilidad
        /// (logs, monitoreo). Debe ser único y descriptivo, ej.: "Reporte_Domiciliacion_Diario".
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// Tipo de Job que determina cómo se ejecuta. Valores soportados:
        /// <list type="bullet">
        ///   <item><description><c>REPORT_EMAIL</c>: genera un Excel a partir de un reporte y lo envía por correo.</description></item>
        /// </list>
        /// </summary>
        public string JobType { get; set; }

        /// <summary>
        /// Hora del día a la que debe ejecutarse el Job, en formato <c>HH:mm</c> (24 horas).
        /// El dispatcher lo encolará en la primera revisión posterior a esta hora si aún
        /// no se ha ejecutado en el día corriente.
        /// </summary>
        public string ExecutionTime { get; set; }

        /// <summary>
        /// Identificador del reporte a generar (parámetro <c>reportId</c> de
        /// <c>Architect.Data.Source.Business.ExcelExport.GenerateFile</c>).
        /// Aplica para <see cref="JobType"/> = <c>REPORT_EMAIL</c>.
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// Parámetros del reporte en el formato esperado por <c>ExcelExport.GenerateFile</c>
        /// (ej.: <c>"id=ReporteDomiciliacion:processid=ABC"</c>).
        /// Soporta tokens dinámicos resueltos en tiempo de ejecución:
        /// <list type="bullet">
        ///   <item><description><c>{guid}</c>: nuevo Guid.</description></item>
        ///   <item><description><c>{date:formato}</c>: fecha actual con el formato indicado, ej. <c>{date:yyyyMMdd}</c>.</description></item>
        /// </list>
        /// </summary>
        public string ReportParams { get; set; }

        /// <summary>
        /// Nombre visible del archivo adjunto en el correo (incluyendo extensión).
        /// Si es nulo o vacío se usa <see cref="ReportId"/> + ".xlsx".
        /// </summary>
        public string OutputFileName { get; set; }

        /// <summary>
        /// Código del template de correo a utilizar para enviar el resultado.
        /// Los destinatarios (TO/CC/BCC) se toman del propio template, por lo que
        /// no se almacenan en esta tabla.
        /// </summary>
        public string MailTemplate { get; set; }

        /// <summary>
        /// Indica si el Job está habilitado. Solo los Jobs activos son evaluados
        /// por el dispatcher.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Fecha y hora de la última ejecución (exitosa o fallida). Es <c>null</c>
        /// si el Job nunca ha corrido. El dispatcher la usa para evitar disparar
        /// dos veces el mismo Job en el día.
        /// </summary>
        public DateTime? LastRunAt { get; set; }

        /// <summary>
        /// Estado de la última ejecución. Valores típicos: <c>"OK"</c>, <c>"ERROR"</c>.
        /// </summary>
        public string LastStatus { get; set; }

        /// <summary>
        /// Mensaje de error de la última ejecución cuando <see cref="LastStatus"/> es
        /// <c>"ERROR"</c>. Truncado a 2000 caracteres por la capa de acceso a datos.
        /// </summary>
        public string LastError { get; set; }
    }
}
