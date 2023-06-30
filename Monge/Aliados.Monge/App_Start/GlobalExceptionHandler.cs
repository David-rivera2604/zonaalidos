using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Aliados.Monge.App_Start
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            string code = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.fffffff");
            if (Architect.Utilities.Helpers.Settings.StringValue("Working.Mode", "Development").Equals("Development", StringComparison.CurrentCultureIgnoreCase))
            {
                response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                        new
                        {
                            code = code,
                            ExceptionMessage = context.Exception.Message,
                            Message = context.Exception.Message,
                            ExceptionType = context.Exception.GetType().FullName,
                            StackTrace = context.Exception.StackTrace
                        });
            }
            else
            {
                Architect.Utilities.Log.ErrorLog("UnhandledExceptionLogger", "LogAsync", context.Exception, string.Empty, true, code);
                try
                {
                    Architect.API.Core.Security.Session.TrackError(context.Request?.Headers?.Authorization?.Parameter, code, context.Exception);
                }
                catch (Exception ex)
                {
                    Architect.Utilities.Log.ErrorLog("UnhandledExceptionLogger", "LogAsync Fail", ex);
                }
                response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                        new
                        {
                            code = code
                        });
            }
            context.Result = new ResponseMessageResult(response);
            return Task.FromResult(0);
        }
    }
}