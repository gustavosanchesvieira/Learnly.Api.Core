using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Learnly.Api.Core.Auth
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

            if (!allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "ApiKey",
                    In = ParameterLocation.Header,
                    Description = "Username",
                    Required = true
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "SecretKey",
                    In = ParameterLocation.Header,
                    Description = "Password",
                    Required = true
                });

            }
        }
    }
}
