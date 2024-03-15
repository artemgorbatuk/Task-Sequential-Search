namespace Services.Interfaces
{
    public interface IServiceAuthentification
    {
        bool Login(string username, string password);
    }
}