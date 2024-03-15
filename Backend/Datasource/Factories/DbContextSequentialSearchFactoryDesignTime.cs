using Datasource.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace Datasource.Factories;

/// <summary>
/// Фабрика создана исключительно для запуска миграций в докере
/// </summary>
public class DbContextSequentialSearchFactoryDesignTime : IDesignTimeDbContextFactory<DbContextSequentialSearch>
{
    public DbContextSequentialSearch CreateDbContext(string[] args)
    {
        var pathtoApi = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Api"));

        var configuration = new ConfigurationBuilder()
            .SetBasePath(pathtoApi)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Docker");

        var optionsBuilder = new DbContextOptionsBuilder<DbContextSequentialSearch>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DbContextSequentialSearch(optionsBuilder.Options);
    }
}