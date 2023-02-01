using Microsoft.EntityFrameworkCore;
using Quizlet.Infrastructure.Data;
using Quizlet.Api.Extensions;
using Quizlet.Infrastructure.Data.Seeders;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Services.GetApplicationSettings(builder.Configuration);

builder.Services.AddDbContext<QuizletContext>(options =>
    options.UseSqlServer(builder.Configuration.GetDefaultConnectionString()))
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage()
        .UseSwagger()
        .UseSwaggerUI();
}

app.UseRouting()
    .UseCors(options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

Seeder.Seed(app);
app.Run();