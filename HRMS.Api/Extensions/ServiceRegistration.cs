using HRMS.Api.AppSettings;
using HRMS.Api.Business.CompanyManagement.CompanyRepository;
using HRMS.Api.Business.UserManagement.UserRepository;

namespace HRMS.Api.Extensions
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var appSettingsSection = builder.Configuration.GetSection("AppSettings");
            builder.Services.Configure<HRMSAppSettings>(
                                        builder.Configuration.GetSection(
                                        key: nameof(HRMSAppSettings))
                                        );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
