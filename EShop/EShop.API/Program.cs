using EShop.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Services.GetApplicationSettings(builder.Configuration);

builder
    .Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddJwtAuthentication(settings)
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddApplicationServices()
    .AddApplicationProviders()
    .AddApiControllers();

var app = builder.Build();

app
    .UseSwagger()
    .UseSwaggerUI()
    .UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader())
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .ApplyMigrations();

app.MapControllers();

app.Run();