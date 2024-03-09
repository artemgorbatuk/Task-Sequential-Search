using Datasource.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services.Api
{
    public class ServiceTextSource : IServiceTextSource
    {
        private readonly IRepositoryTextSource repositoryTextSource;

        public ServiceTextSource(IRepositoryTextSource repositoryTextSource)
        {
            this.repositoryTextSource = repositoryTextSource;
        }

        public Task<IEnumerable<TextSourceResult>> SearchAsync(string mask)
        {
            throw new NotImplementedException();
        }
    }
}