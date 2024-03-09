using Datasource.Interfaces;
using Services.Interfaces;

namespace Services.Api
{
    public class ServiceAuthentification : IServiceAuthentification
    {
        private readonly IRepositoryAuthentication repositoryAuthentication;

        public ServiceAuthentification(IRepositoryAuthentication repositoryAuthentication)
        {
            this.repositoryAuthentication = repositoryAuthentication;
        }

        public bool Login(string username, string password)
        {
            return repositoryAuthentication.Login(username, password);
        }
    }
}