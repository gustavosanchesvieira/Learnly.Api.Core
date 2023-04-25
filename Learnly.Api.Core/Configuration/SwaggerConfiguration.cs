using Learnly.Api.Core.Auth;
using Microsoft.OpenApi.Models;

namespace Learnly.Api.Core.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection SetUpSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "Autorização via ApiKey",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            return services;
        }
    }
}
