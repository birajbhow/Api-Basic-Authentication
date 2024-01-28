namespace ProductsApi.Services
{
    public interface IUserRepository
    {
        Task<bool> Authenticate(string username, string password);
    }
}
