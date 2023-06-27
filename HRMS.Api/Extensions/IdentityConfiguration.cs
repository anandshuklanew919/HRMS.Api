using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace HRMS.Api.Extensions
{
    public static class IdentityConfiguration
    {
        public static void ConfigurationIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<HrmsUser, HrmsRole>()
                            .AddEntityFrameworkStores<AppDbContex>()
                            .AddDefaultTokenProviders();
        }
    }
}
