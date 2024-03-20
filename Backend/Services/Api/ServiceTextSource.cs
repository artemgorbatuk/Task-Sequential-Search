using Datasource.Domain;
using Datasource.Interfaces;
using Services.Interfaces;
using Services.Models;
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
            await foreach (var textSource in repositoryTextSource.SearchAsync(mask, cancellationToken))
            {
                yield return MapTo(textSource);
            }
        }
        private static TextSourceResult MapTo(TextSource textSource)
        {
            /// Мог бы реализовать это с помощью Automapper
            /// Посчитал что в данном случае это будет не уместно
            /// С Automapper работал, выполняя разной сложности задачи
            return new TextSourceResult
            {
                Id = textSource.Id,
                TextData = textSource.TextData,
            };
        }
    }
}