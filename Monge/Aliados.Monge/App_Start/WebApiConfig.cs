using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using Architect.Utilities.Helpers;
using Asp.Versioning.Routing;

namespace Aliados.Monge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
            {
                ["apiVersion"] = typeof( ApiVersionRouteConstraint )
            }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            // Web API routes
            //config.MapHttpAttributeRoutes();

            //Registering GlobalExceptionHandler
            config.Services.Replace(typeof(IExceptionLogger), new App_Start.UnhandledExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new App_Start.GlobalExceptionHandler());

            // Enable CORS with support for credentials
            // Read allowed origins from Web.config
            EnableCorsAttribute cors = new EnableCorsAttribute(
                origins: "CORS.AllowedOrigins".StringValue("https://localhost:44341,https://app.mapfrecr.com"),
                headers: "*",
                methods: "*"
            )
            {
                SupportsCredentials = true
            };

            config.EnableCors(cors);
            config.AddApiVersioning();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new Architect.API.Core.Security.AuthorizeExtendAttribute());
        }
    }
}