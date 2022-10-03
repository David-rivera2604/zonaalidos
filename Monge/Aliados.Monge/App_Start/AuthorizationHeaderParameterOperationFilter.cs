using Swashbuckle.Swagger;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace Aliados.Monge.App_Start
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter

    {
        void IOperationFilter.Apply(Swashbuckle.Swagger.Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            var isAuthorized = filterPipeline
                                   .Select(filterInfo => filterInfo.Instance)
                                   .Any(filter => filter is IAuthorizationFilter);

            var allowAnonymous = apiDescription.ActionDescriptor
                .GetCustomAttributes<AllowAnonymousAttribute>()
                .Any();

            if (allowAnonymous)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "clienteID",
                    @in = "header",
                    description = "clienteID",
                    required = true,
                    type = "string"
                }); operation.parameters.Add(new Parameter
                {
                    name = "secretID",
                    @in = "header",
                    description = "secretID",
                    required = true,
                    type = "string"
                });
            }
            if (isAuthorized && !allowAnonymous)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "Bearer token (e.g. BEARER enterbearertokenhere)",
                    required = true,
                    type = "string"
                });
            }
        }
    }
}