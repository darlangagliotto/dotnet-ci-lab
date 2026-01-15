using CatalogService.Repositories;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Repositório em memória
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

// Health checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Endpoint de health (liveness)
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => true
});

// Endpoint da API
app.MapGet("/api/v1/catalog", () =>
{
    return Results.Ok(new[] { "Item1", "Item2" });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
