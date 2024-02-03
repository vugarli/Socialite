
using Socialite.Web.Client.Services.Authentication;

namespace Socialite.Web.Client.Authentication
{
    public class TokenProvider : ITokenProvider
    {
        public IAuthenticationServicee _authenticationService { get; }

        public TokenProvider(IAuthenticationServicee authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<string> GetToken()
        {
            var token = await _authenticationService.GetToken();
            if (token == null)
            {
                await _authenticationService.Logout();
            }
            return token;
        }
    }
}
