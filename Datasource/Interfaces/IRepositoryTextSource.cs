using Datasource.Domain;
using System.Runtime.CompilerServices;

namespace Datasource.Interfaces
{
    public interface IRepositoryTextSource
    {
        IAsyncEnumerable<TextSource> SearchAsync(string mask, [EnumeratorCancellation] CancellationToken cancellationToken = default);
    }
}