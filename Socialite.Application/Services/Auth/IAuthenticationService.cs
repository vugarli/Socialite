using Socialite.Application.Requests.Auth;
using Socialite.Application.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Auth
{
    public interface IAuthenticationService
    {
        public Task<AuthResponse> LoginAsync(LoginDto dto);
        public Task RegisterAsync(RegisterDto dto);
    }
}
