using Npgsql;
using Testcontainers.PostgreSql;

namespace BoxContains.Category.IntegrationTests;

public class PostgreSqlTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:15.5")
        .WithDatabase("integration_test_db")
        .WithUsername("postgres")
        .WithPassword("hYUmsbdde2n8zB!yx1")
        .WithCleanUp(true)
        .Build();

    /// <summary>
    /// Initialize the PGSQL container
    /// </summary>
    public Task InitializeAsync()
    {
        return _postgreSqlContainer.StartAsync();
    }

    /// <summary>
    /// Dispose the PGSQL Container
    /// </summary>
    public Task DisposeAsync()
    {
        return _postgreSqlContainer.DisposeAsync().AsTask();
    }

    [Fact]
    public void ExecuteCommandTest()
    {
        using var connection = new NpgsqlConnection(_postgreSqlContainer.GetConnectionString());
        using var command = new NpgsqlCommand();
        connection.Open();
        command.Connection = connection;
        command.CommandText = "SELECT 1";
        command.ExecuteReader();
    }
}