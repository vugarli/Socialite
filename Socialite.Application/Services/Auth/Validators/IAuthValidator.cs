using Microsoft.AspNetCore.Identity;
using Socialite.Application.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Auth.Validators
{
    public interface IAuthValidator
    {
        public void ValidateUserRegister(RegisterDto dto);
        public void ValidateUserLogin(LoginDto dto);
        public void ValidateRegisterIdentityResult(IdentityResult result);
    }
}
