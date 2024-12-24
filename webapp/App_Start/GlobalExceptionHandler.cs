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

namespace aliados.App_Start
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            string exceptionType = context.Exception.GetType().FullName;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            if (exceptionType == "Architect.Utilities.Exceptions.CustomException")
            {
                statusCode = HttpStatusCode.BadRequest;
            }

            if (Architect.Utilities.Helpers.Settings.StringValue("Working.Mode", "Development").Equals("Development", StringComparison.CurrentCultureIgnoreCase))
            {
                context.Result = new ResponseMessageResult(
                        context.Request.CreateResponse(statusCode,
                        new
                        {
                            ExceptionMessage = context.Exception.Message,
                            Message = context.Exception.Message,
                            ExceptionType = exceptionType,
                            StackTrace = context.Exception.StackTrace
                        }));
            }
            else
            {
                context.Result = new ResponseMessageResult(
                        context.Request.CreateResponse(statusCode,
                        new
                        {
                            ExceptionMessage = "Ha ocurrido un error inesperado en la aplicación. Por favor, intente nuevamente más tarde. Si el problema persiste, contacte al soporte técnico para obtener asistencia.",
                            Message = "Ha ocurrido un error inesperado en la aplicación. Por favor, intente nuevamente más tarde. Si el problema persiste, contacte al soporte técnico para obtener asistencia.",
                            ExceptionType = exceptionType,
                            StackTrace = string.Empty
                        }));
            }




            return Task.FromResult(0);
        }
    }
}