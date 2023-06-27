namespace HRMS.Api.Extensions
{
    public static class EnvironmentVariableConfiguration
    {
        public static void ConfigurEnvironmentConfiguration(this WebApplicationBuilder builder)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
            builder.Configuration.AddJsonFile("appsettings.json", false);
            builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json", true);
            builder.Configuration.AddEnvironmentVariables();
        }
    }
}
