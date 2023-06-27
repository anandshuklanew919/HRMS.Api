using HRMS.Api.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HRMS.Api.Extensions
{
    public static class JwtConfig
    {

        public static void JwtConfiguration(this WebApplicationBuilder builder)
        {
            var serviceProvider =  builder.Services.BuildServiceProvider();
            var jwtSettings = serviceProvider.GetService<IOptions<HRMSAppSettings>>().Value;

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = jwtSettings.AuthSettings.ValidateIssuer,
                    ValidateAudience = jwtSettings.AuthSettings.ValidateAudience,
                    ValidAudience = jwtSettings.AuthSettings.ValidAudience,
                    ValidIssuer = jwtSettings.AuthSettings.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.AuthSettings.Secret)),
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateLifetime = jwtSettings.AuthSettings.ValidateLifetime
                };
            });
        }
    }
}
