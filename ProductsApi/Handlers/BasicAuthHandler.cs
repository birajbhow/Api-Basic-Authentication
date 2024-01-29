using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using ProductsApi.Services;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace ProductsApi.Handlers
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserRepository userRepository;

        public BasicAuthHandler(
            IUserRepository userRepository,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            this.userRepository = userRepository;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(authorizationHeader) ||
                !authorizationHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var token = authorizationHeader.Substring(6);
            var credentialsAsString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialsAsString.Split(":", 2);

            if (credentials.Length != 2)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var username = credentials[0];
            var password = credentials[1];
            var authenticated = await userRepository.Authenticate(username, password);
            if (!authenticated)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, username) };
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Basic"));

            return AuthenticateResult.Success(new AuthenticationTicket(claimPrincipal, Scheme.Name));
        }
    }
}
