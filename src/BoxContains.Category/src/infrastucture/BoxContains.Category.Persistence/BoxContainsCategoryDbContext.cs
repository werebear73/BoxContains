using BoxContains.Category.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;
using System.Data.Common;

namespace BoxContains.Category.Persistence;

public class BoxContainsCategoryDbContext : DbContext
{
    public BoxContainsCategoryDbContext(DbContextOptions<BoxContainsCategoryDbContext> options) : base(options)
    {
        if (this.Database.CanConnect())
        {
            List<string> migrations = this.Database.GetPendingMigrations().ToList();
            if (migrations.Any())
            {
                this.Database.Migrate();
            }
        }
        else
        {
            this.Database.EnsureCreated();
        }
    }

    public DbSet<Domain.Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
    }

}

public sealed class DBConnectionProvider
{
    private readonly string _connectionString;

    public DBConnectionProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}

public class BoxContainsCategoryDbContextFactory : IDesignTimeDbContextFactory<BoxContainsCategoryDbContext>
{
    public BoxContainsCategoryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BoxContainsCategoryDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=box_contains;Pooling=true; Connection Lifetime=0;User ID=postgres;Password=Fl@bread73");
        return new BoxContainsCategoryDbContext(optionsBuilder.Options);
    }
}
