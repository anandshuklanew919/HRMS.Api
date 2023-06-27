using HRMS.Api.Extensions;
using HRMS.Api.Middleware;
using HRMS.Api.Migrations;


var builder = WebApplication.CreateBuilder(args);

builder.ConfigurEnvironmentConfiguration();
builder.ConfigureSwagger();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.RegisterServices();
builder.ConfigureDatabase();
builder.ConfigurationIdentity();
builder.JwtConfiguration();



var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//create admin user on start if it does not exist
using (var scope = app.Services.CreateScope())
{
    await SeedAdminUser.Initializer(scope.ServiceProvider);

}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
