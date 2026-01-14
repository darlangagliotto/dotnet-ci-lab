using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Xunit;

public class PostgresFixture : IAsyncLifetime
{
    public PostgreSqlContainer Container { get; }

    public PostgresFixture()
    {
        Container = new PostgreSqlBuilder()
        .WithDatabase("catalog")
        .WithUserName("test")
        .WithPassword("test")
        .Build();
    }

    public async Task InitializeAsync()
    {
        await Container.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await Container.DisposeAsync();
    }
}