using System;
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
            string code = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.fffffff");

            Architect.Utilities.Log.ErrorLog("UnhandledExceptionLogger", "LogAsync", context.Exception, string.Empty, true, code);
            try
            {                
                Architect.API.Core.Business.Security.Session.TrackError(context.Request?.Headers?.Authorization?.Parameter, code, context.Exception);
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog("UnhandledExceptionLogger", "LogAsync Fail", ex);
            }

            // this.loggingService.Log(LogLevel.Error, this.GetType().Name, context.Exception, "Ship has just happened");
            return Task.FromResult(true);
        }
    }
}