using Socialite.Application.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socialite.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Socialite.Application.Exceptions.Auth;
using System.Data;
using System.Diagnostics;

namespace Socialite.Application.Services.Auth.Validators
{
    public class AuthValidator : 
        BaseValidator<AuthenticationValidationException>,
        IAuthValidator
    {
        public UserManager<ApplicationUser> UserManager { get; }

        public AuthValidator(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        

        public void ValidateUserLogin(LoginDto dto)
        {
            Validate(
                (Rule: IsValidUsername(dto.Username), Parameter: nameof(dto.Username)),
                (Rule: IsValidPassword(dto.Password),Parameter: nameof(dto.Password))
                );
        }

        public void ValidateUserRegister(RegisterDto dto)
        {
            Validate(
                (Rule: IsValidDisplayname(dto.DisplayName), Parameter: nameof(dto.DisplayName)),
                (Rule: IsValidPassword(dto.Password), Parameter: nameof(dto.Password)),
                (Rule: IsValidEmail(dto.Email), Parameter: nameof(dto.Email))
                );
        }
        public void ValidateRegisterIdentityResult(IdentityResult result)
        {
            Validate((Rule: IsValidIdentityResult(result), "Auth validation"));
        }

        public dynamic IsValidIdentityResult(IdentityResult result) => new
        {
            Condition = result.Succeeded && result.Errors.Count() == 0,
            Message = "Errors : "+string.Join(' ',result.Errors.Select(e=>e.Description))
        };

        public dynamic IsValidEmail(string email) => new
        {
            Condition = (!string.IsNullOrEmpty(email)) && email.Contains("@"),
            Message = "Email is invalid"
        };

        public dynamic IsValidUsername(string username) => new
        {
            Condition = !string.IsNullOrEmpty(username),
            Message = "Username is invalid"
        };

        public dynamic IsValidDisplayname(string displayName) => new
        {
            Condition = !string.IsNullOrEmpty(displayName),
            Message = "Display name is invalid"
        };

        public dynamic IsValidPassword(string password) => new
        {
            Condition = !string.IsNullOrEmpty(password),
            Message = "Password is invalid"
        };

        
    }
}
