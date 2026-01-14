using OrderService.Repositories;
using OrderService.Integration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

builder.Services.AddHttpClient<ICatalogClient, CatalogHttpClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5055");
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
