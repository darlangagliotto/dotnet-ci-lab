using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Xunit;

public class PostgresFixture : IAsyncLifetime
{
    public TestcontainersContainer Container { get; }

    public string ConnectionString =>
        $"Host=localhost;Port={Container.GetMappedPublicPort(5432)};Database=catalog;Username=test;Password=test";

    public PostgresFixture()
    {
        Container = new TestcontainersBuilder<TestcontainersContainer>()
            .WithImage("postgres:16-alpine")
            .WithName($"postgres-test-{Guid.NewGuid()}")
            .WithPortBinding(5432, true)
            .WithEnvironment("POSTGRES_DB", "catalog")
            .WithEnvironment("POSTGRES_USER", "test")
            .WithEnvironment("POSTGRES_PASSWORD", "test")
            .WithWaitStrategy(
                Wait.ForUnixContainer().UntilPortIsAvailable(5432)
            )
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
