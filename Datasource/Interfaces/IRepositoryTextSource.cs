using Datasource.Domain;

namespace Datasource.Interfaces
{
    public interface IRepositoryTextSource
    {
        Task<IEnumerable<TextSource>> SearchAsync(string mask);
    }
}