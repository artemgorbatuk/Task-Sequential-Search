using Services.Models;

namespace Services.Interfaces
{
    public interface IServiceTextSource
    {
        Task<IEnumerable<TextSourceResult>> SearchAsync(string mask);
    }
}