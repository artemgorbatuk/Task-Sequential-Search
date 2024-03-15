namespace Datasource.Interfaces
{
    public interface IRepositoryAuthentication
    {
        bool Login (string username, string password);
    }
}