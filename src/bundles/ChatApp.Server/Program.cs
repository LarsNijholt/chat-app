using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddFastEndpoints()
    .SwaggerDocument();

services.AddHealthChecks();

var app = builder.Build();

app
    .UseFastEndpoints()
    .UseSwaggerGen();

app.UseHttpsRedirection();
app.UseHealthChecks("/health");

await app.RunAsync();

