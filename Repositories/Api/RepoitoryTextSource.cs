using Datasource.Contexts;
using Datasource.Domain;
using Datasource.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories.Api
{
    public class RepoitoryTextSource : IRepositoryTextSource
    {
        private readonly IServiceScopeFactory scopeFactory;
        public RepoitoryTextSource(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public async Task<IEnumerable<TextSource>> SearchAsync(string mask)
        {
            using var scope = scopeFactory.CreateAsyncScope();

            var context = scope.ServiceProvider.GetRequiredService<DbContextSequentialSearch>();

            return await context.TextSources.Where(p => p.TextData == mask).ToListAsync();
        }
    }
}