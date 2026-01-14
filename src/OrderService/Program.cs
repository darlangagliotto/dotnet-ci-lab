using OrderService.Repositories;
using OrderService.Integration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

var catalogBaseUrl =
    builder.Configuration["CATALOG_SERVICE_BASE_URL"]
    ?? "http://localhost:5055";

builder.Services.AddHttpClient<ICatalogClient, CatalogHttpClient>(client =>
{
    client.BaseAddress = new Uri(catalogBaseUrl);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
