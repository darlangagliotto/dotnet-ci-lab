using CatalogService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
