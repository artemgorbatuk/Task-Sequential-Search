using Microsoft.Extensions.DependencyInjection;

namespace Datasource.Factories;
public class DbContextSequentialSearchFactoryScope : IServiceScopeFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DbContextSequentialSearchFactoryScope(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public IServiceScope CreateScope()
    {
        return _serviceScopeFactory.CreateScope();
    }
}