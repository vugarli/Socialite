using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Socialite.Web.Client.Models.Auth
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(l=>l.Username).NotEmpty().WithMessage("Enter email");
            RuleFor(l=>l.Password).NotEmpty().WithMessage("Enter password");
        }
    }

}
