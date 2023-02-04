using Quizlet.Api.Extensions;
using Quizlet.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Services.GetApplicationSettings(builder.Configuration);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddUserDefinedServices()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDevelopmentSettings();

app.UseRouting()
    .ConfigureCors()
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .MapControllers()
    .SeedDatabase();

app.Run();