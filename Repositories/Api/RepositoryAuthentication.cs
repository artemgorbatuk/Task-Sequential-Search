using Datasource.Interfaces;

namespace Repositories.Api
{
    public class RepositoryAuthentication : IRepositoryAuthentication
    {
        public bool Login(string username, string password)
        {
            return username == "admin" && password == "admin";
        }
    }
}