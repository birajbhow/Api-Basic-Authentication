using System.Text.Json.Serialization;

namespace ProductsApi.Models
{
    public class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public string Password { get; set; } = string.Empty;
    }
}
