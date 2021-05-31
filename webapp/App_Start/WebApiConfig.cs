using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Web.Http.Routing;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.ExceptionHandling;
using aliados.App_Start;

namespace aliados
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
            {
                ["apiVersion"] = typeof( ApiVersionRouteConstraint )
            }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            

            //Registering GlobalExceptionHandler
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.AddApiVersioning();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new Architect.API.Core.Utils.AuthorizeExtendAttribute());
        }
    }
}
