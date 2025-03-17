using ChatApp.EntityFrameworkCore.Data;
using ChatApp.EntityFrameworkCore.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Postgres");

services
    .AddFastEndpoints()
    .SwaggerDocument()
    .AddPersistence(connectionString!);

services.AddHealthChecks();

var app = builder.Build();

app
    .UseFastEndpoints()
    .UseSwaggerGen();

app.UseHttpsRedirection();
app.UseHealthChecks("/health");

// await using var scope = app.Services.CreateAsyncScope();
//
// var initializer = scope.ServiceProvider.GetRequiredService<DbContextInitializer>();
// await initializer.InitializeDatabaseAsync();

await app.RunAsync();

