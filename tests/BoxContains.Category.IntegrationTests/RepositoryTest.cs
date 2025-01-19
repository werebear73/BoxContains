using BoxContains.Category.Persistence;
using BoxContains.Category.Persistence.Repositories;
using DotNet.Testcontainers.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using Testcontainers.PostgreSql;

namespace BoxContains.Category.IntegrationTests;

public sealed class RepositoryTest : IAsyncLifetime
{
    private const string DATABASE = "integration_test_db";
    private const string USERNAME = "postgres";
    private const string PASSWORD = "hYUmsbdde2n8zByx14gen7T";
    private const ushort PORT = 5432;
    private int hostPort;
    private readonly Random randomPortGenerator = new Random(DateTime.Now.Millisecond);

    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:15.5")
        .WithDatabase(DATABASE)
        .WithUsername(USERNAME)
        .WithPassword(PASSWORD)
        .WithPortBinding(PORT)
        //.WithExposedPort()
        .WithCleanUp(true)
        //.WithReuse(true)
        .Build();

    private readonly CategoryRepository _categoryRepository;
    private readonly BoxContainsCategoryDbContext _dbContext;
    private readonly ILogger<RepositoryTest> _logger = new Logger<RepositoryTest>(new LoggerFactory());

    /// <summary>
    /// Initialize the PGSQL container
    /// </summary>
    public async Task InitializeAsync()
    {

        await _postgreSqlContainer.StartAsync();
        hostPort = _postgreSqlContainer.GetMappedPublicPort(PORT);
        _postgreSqlContainer.ConfigureAwait(true);
        _logger.LogDebug($"Database Connection Information: \n\tContainer Name:{_postgreSqlContainer.Name}\n\tContainer Info:{_postgreSqlContainer.ToString()}\n\tContainer Connection String:{_postgreSqlContainer.GetConnectionString()}");
    }

    /// <summary>
    /// Dispose the PGSQL Container
    /// </summary>
    public Task DisposeAsync()
    {
        return _postgreSqlContainer.DisposeAsync().AsTask();
    }

    //public RepositoryTest()
    //{
    //    _logger.LogInformation("Repository Test Constructor Startup");

    //    //// Check if the Test Instance is Running
    //    //while (_postgreSqlContainer.State != DotNet.Testcontainers.Containers.TestcontainersStates.Running)
    //    //{
    //    //    // Create a Test Instance of the Database
    //    //    _postgreSqlContainer.StartAsync();
    //    //    _postgreSqlContainer.ConfigureAwait(true);
    //    //    Task.Delay(1000);
    //    //}

    //    //_postgreSqlContainer.StartAsync().ConfigureAwait(true);
        
    //    //while (_postgreSqlContainer.State != DotNet.Testcontainers.Containers.TestcontainersStates.Running)
    //    //{
    //    //    _logger.LogDebug("Waiting for Test Container to start");
    //    //    Task.Delay(TimeSpan.FromSeconds(1));
    //    //}

    //    //while (_postgreSqlContainer.Health != DotNet.Testcontainers.Containers.TestcontainersHealthStatus.Healthy)
    //    //{
    //    //    _logger.LogDebug("Waiting for Test Container to be Healthy");
    //    //    Task.Delay(TimeSpan.FromSeconds(1));
    //    //}

    //    var externalPort = _postgreSqlContainer.GetMappedPublicPort(PORT);
    //    // Check if can connect to instance
    //    //using var connection = new NpgsqlConnection(_postgreSqlContainer.GetConnectionString());
    //    using var connection = new NpgsqlConnection($"Host=host.docker.internal;User ID={USERNAME};Password={PASSWORD};Port={externalPort};Database={DATABASE};Connection Lifetime=0; Pooling=true; Timeout=300");
    //    using var command = new NpgsqlCommand();
    //    connection.Open();
    //    command.Connection = connection;
    //    command.CommandText = "SELECT 1";
    //    bool connected = false;
    //    int connectionAttempts = 0;
    //    while (!connected && connectionAttempts > 360)
    //    {
    //        try
    //        {
    //            command.ExecuteReader();
    //            if (connection.State == System.Data.ConnectionState.Open)
    //            {
    //                connected = true;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            _logger.LogWarning($"Startup Exception on Read Test{e.Message}");
    //        }
    //        finally
    //        {
    //            connectionAttempts++;
    //            Task.Delay(1000);
    //        }
    //    }
    //    connection.Close();

    //    // Create DB Context of the Test Instance
    //    _dbContext = new BoxContainsCategoryDbContext(new DbContextOptionsBuilder<BoxContainsCategoryDbContext>()
    //                   .UseNpgsql(_postgreSqlContainer.GetConnectionString())
    //                              .Options);

    //    _dbContext.Database.Migrate();

    //    // Create Repository of the Test Instance to test Features
    //    _categoryRepository = new CategoryRepository(_dbContext);
        
    //}

    [Fact]
    public async Task AddCommandTest_Successful()
    {

        // Arrange

        // Create DB Context of the Test Instance
        _postgreSqlContainer.ConfigureAwait(true);
        var dbContext = new BoxContainsCategoryDbContext(new DbContextOptionsBuilder<BoxContainsCategoryDbContext>()
                       .UseNpgsql(_postgreSqlContainer.GetConnectionString())
                                  .Options);

        dbContext.Database.Migrate();

        // Create Repository of the Test Instance to test Features
        var categoryRepository = new CategoryRepository(dbContext);

        Domain.Category sampleCategory1 = new Domain.Category()
        {
            Name = "Test Category #1"
        };

        List<Domain.Category> categories = new List<Domain.Category>();
        categories.Add(sampleCategory1);

        // Act
        Domain.Category addResult = await categoryRepository.AddCategoryAsync(sampleCategory1);
        await dbContext.SaveChangesAsync();
        _logger.LogInformation($"Add Complete => Category ID: {addResult.CategoryID} - {addResult.Name}");

        // Assert
        Domain.Category? getResult = await dbContext.Categories.FirstOrDefaultAsync();
        if (getResult != null)
        {
            _logger.LogInformation($"Get Complete => Category ID: {getResult.CategoryID} - {getResult.Name}");
        }
        else
        {
            _logger.LogError("Unable to retrieve create Category");
        }

        Assert.NotNull(addResult);
    }
    [Fact]

    public async Task AddCommandTest_Unsuccessful_BadId()
    {
        // Arrange

        // Create DB Context of the Test Instance
        _postgreSqlContainer.ConfigureAwait(true);
        var dbContext = new BoxContainsCategoryDbContext(new DbContextOptionsBuilder<BoxContainsCategoryDbContext>()
                       .UseNpgsql(_postgreSqlContainer.GetConnectionString())
                                  .Options);

        dbContext.Database.Migrate();

        // Create Repository of the Test Instance to test Features
        var categoryRepository = new CategoryRepository(dbContext);

        Domain.Category sampleCategory1 = new Domain.Category()
        {
            Name = "Test Category #1"
        };

        List<Domain.Category> categories = new List<Domain.Category>();
        categories.Add(sampleCategory1);


        // Act
        Action act = () => { throw new ArgumentException(); };
        var ex = Record.Exception(act);
         

        // Assert
        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
    }

}
