using Microsoft.Extensions.DependencyInjection;

namespace Datasource.Factories;
public class DbContextFactorySequentialSearch : IServiceScopeFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DbContextFactorySequentialSearch(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public IServiceScope CreateScope()
    {
        return _serviceScopeFactory.CreateScope();
    }
}