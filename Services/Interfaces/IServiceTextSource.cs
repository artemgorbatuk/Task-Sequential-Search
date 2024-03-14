using Services.Models;
using System.Runtime.CompilerServices;

namespace Services.Interfaces
{
    public interface IServiceTextSource
    {
        IAsyncEnumerable<TextSourceResult> SearchAsync(string mask, [EnumeratorCancellation] CancellationToken cancellationToken = default);
    }
}