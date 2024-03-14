using Datasource.Domain;
using Datasource.Interfaces;
using Services.Interfaces;
using Services.Models;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

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
            var results = new ConcurrentBag<TextSourceResult>();

            //await Parallel.ForEachAsync(repositoryTextSource.SearchAsync(mask, cancellationToken), textSource =>
            //{
            //    var textSourceResult = MapTo(textSource);
            //    results.Add(textSourceResult);
            //});

            foreach (var result in results)
            {
                yield return result;
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