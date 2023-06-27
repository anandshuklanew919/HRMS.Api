using HRMS.Api.Filters;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace HRMS.Api.Extensions
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiPlayground", Version = "v1" });
                c.AddSecurityDefinition("token", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Name = HeaderNames.Authorization,
                    Scheme = "Bearer"
                });
                // dont add global security requirement
                // c.AddSecurityRequirement(/*...*/);
                c.OperationFilter<SecureEndpointAuthRequirementFilter>();
            });
        }
    }
}
