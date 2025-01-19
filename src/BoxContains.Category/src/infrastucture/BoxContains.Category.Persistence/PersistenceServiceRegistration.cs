using BoxContains.Category.Application.Contracts;
using BoxContains.Category.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;
using System.Data.Common;

namespace BoxContains.Category.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Check if Logger if not create a console logger
        ILogger _logger;
        var _provider = services.BuildServiceProvider();
        var serviceLoggerFactory = _provider.GetService<ILoggerFactory>();
        if (serviceLoggerFactory == null)
        {
            // No logger factory found, create a console logger
            var _loggerFactory = LoggerFactory.Create(builder => {
                builder.AddConsole();
            });
            _logger = _loggerFactory.CreateLogger("IdVerification.Module.Persistence");
        } else
        {
            // Create logger from Logger Factory
            _logger = serviceLoggerFactory.CreateLogger("AddPersistenceServices");
        }

        //Set Database Connection Information
        string? host = configuration.GetSection($"{configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value}_Database:host").Value;
        string? port = configuration.GetSection($"{configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value}_Database:port").Value;
        string? dbname = configuration.GetSection($"{configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value}_Database:dbname").Value;
        string? username = configuration.GetSection($"{configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value}_Database:username").Value;
        string? password = configuration.GetSection($"{configuration.GetSection("ASPNETCORE_ENVIRONMENT").Value}_Database:password").Value;

        services.AddDbContext<BoxContainsCategoryDbContext>(options =>
        {
            options.UseLoggerFactory(serviceLoggerFactory);
            options.UseNpgsql($"Host={host};Port={port};Database={dbname};Username={username};Password={password};Pooling=true",
                sqlOptions => sqlOptions.EnableRetryOnFailure()
            );
        });

        var dbContext = services.BuildServiceProvider().GetService<BoxContainsCategoryDbContext>();

        if (dbContext != null)
        {
            _logger.LogInformation("Database Setup:");
            _logger.LogInformation($"Database Context - Database Name: {dbContext.Database.GetDbConnection().Database}");
            _logger.LogInformation($"Database Context - Provider:  {dbContext.Database.ProviderName}");
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        } else
        {
            _logger.LogError("Unable to create Database Context");
            throw new Exception("Unable to create Database Context");
        }

        

        return services;
    }

}
