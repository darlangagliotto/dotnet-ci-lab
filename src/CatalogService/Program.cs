using CatalogService.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

// health checks
builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

/*
 * ================================
 * API VERSIONADA - v1 (NOVO)
 * ================================
 */
var v1 = app.MapGroup("/api/v1");

v1.MapGet("/catalog", (ILogger<Program> logger) =>
{
    logger.LogInformation("GET /api/v1/catalog chamado");
    return Results.Ok(new[] { "Item1", "Item2" });
});

/*
 * ================================
 * ENDPOINT LEGADO (COMPATIBILIDADE)
 * ================================
 */
app.MapGet("/api/catalog", () =>
{
    return Results.Redirect("/api/v1/catalog");
});

/*
 * ================================
 * HEALTH CHECKS
 * ================================
 */

app.MapHealthChecks("/health/live", new()
{
    Predicate = _ => false
});

app.MapHealthChecks("/health/ready");


/*
 * ================================
 * MIDDLEWARE
 * ================================
 */

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();
app.Run();
