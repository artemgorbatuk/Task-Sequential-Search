using Datasource.Contexts;
using Datasource.Domain;
using Datasource.Interfaces;
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
            var regex = new Regex(mask, RegexOptions.Compiled);

            using var scope = scopeFactory.CreateAsyncScope();

            var context = scope.ServiceProvider.GetRequiredService<DbContextSequentialSearch>();

            await foreach (var textSource in context.TextSources.AsAsyncEnumerable().WithCancellation(cancellationToken))
            {
                if (regex.IsMatch(textSource.TextData))
                {
                    yield return textSource;
                }
            }
        }
    }
}