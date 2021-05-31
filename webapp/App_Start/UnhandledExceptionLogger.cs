using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace aliados.App_Start
{

    /// <summary>
    /// Represents an unhandled exception logger.
    /// </summary>
    public class UnhandledExceptionLogger : IExceptionLogger
    {
        /// <summary>
        /// When overridden in a derived class, logs the exception asynchronously.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            Architect.Common.Helpers.LogHandler.ErrorLog("UnhandledExceptionLogger", "LogAsync", context.Exception);
            // this.loggingService.Log(LogLevel.Error, this.GetType().Name, context.Exception, "Ship has just happened");
            return Task.FromResult(true);
        }
    }
}