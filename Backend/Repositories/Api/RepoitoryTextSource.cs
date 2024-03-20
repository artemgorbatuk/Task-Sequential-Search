using Datasource.Contexts;
using Datasource.Domain;
using Datasource.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Repositories.Api
{
    public class RepoitoryTextSource : IRepositoryTextSource
    {
        private readonly IServiceScopeFactory scopeFactory;
        public RepoitoryTextSource(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public async IAsyncEnumerable<TextSource> SearchAsync(string mask, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var scope = scopeFactory.CreateAsyncScope();

            var context = scope.ServiceProvider.GetRequiredService<DbContextSequentialSearch>();

            // EF.Functions.FreeText(textSource.TextData, mask)

            await foreach (var textSource in context.TextSources
                .Where(p => p.TextData.Contains(mask))
                .AsAsyncEnumerable()
                .WithCancellation(cancellationToken))
            {
                await Task.Delay(100, cancellationToken);

                yield return textSource;
            }
        }
    }
}