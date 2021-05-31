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
            context.Result = new ResponseMessageResult(
                context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    ExceptionMessage = context.Exception.Message,
                    Message = context.Exception.Message,
                    ExceptionType = context.Exception.GetType().FullName,
                    StackTrace = context.Exception.StackTrace
                }));


            return Task.FromResult(0);
        }
    }
}