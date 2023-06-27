using HRMS.Api.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Extensions
{
    public static class DbConfiguration
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContex>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AppConn"));
            });
        }
    }
}
