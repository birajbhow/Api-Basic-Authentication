using ProductsApi.Models;

namespace ProductsApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>
        {
            new User
            {
                FirstName = "Firstname1",
                LastName = "Lastname1",
                Username = "username1",
                Password = "password1"
            },
            new User
            {
                FirstName = "Firstname2",
                LastName = "Lastname2",
                Username = "admin",
                Password = "admin"
            }
        };

        public async Task<bool> Authenticate(string username, string password)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Username == username && x.Password == password)) != null;
        }
    }
}
