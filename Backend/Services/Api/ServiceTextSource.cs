using Datasource.Domain;
using Datasource.Interfaces;
using Services.Interfaces;
using Services.Models;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Services.Api
{
    public class ServiceTextSource : IServiceTextSource
    {
        private readonly IRepositoryTextSource repositoryTextSource;
        public ServiceTextSource(IRepositoryTextSource repositoryTextSource)
        {
            this.repositoryTextSource = repositoryTextSource;
        }
        public async IAsyncEnumerable<TextSourceResult> SearchAsync(string mask, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await foreach (var textSource in repositoryTextSource.SearchAsync(mask, cancellationToken))
            {
                yield return MapTo(textSource);
            }
        }
        private static TextSourceResult MapTo(TextSource textSource)
        {
            return new TextSourceResult
            {
                Id = textSource.Id,
                TextData = textSource.TextData,
            };
        }
    }
}