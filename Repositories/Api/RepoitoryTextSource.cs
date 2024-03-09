using Datasource.Contexts;
using Datasource.Domain;
using Datasource.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Api
{
    public class RepoitoryTextSource : IRepositoryTextSource
    {
        public async Task<IEnumerable<TextSource>> SearchAsync(string mask)
        {
            using var context = new DbContextSequentialSearch();

            return await context.TextSources.Where(p => p.TextData == mask).ToListAsync();
        }
    }
}