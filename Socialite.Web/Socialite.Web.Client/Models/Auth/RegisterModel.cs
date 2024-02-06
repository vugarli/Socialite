using FluentValidation;
using System.Reflection.Metadata.Ecma335;

namespace Socialite.Web.Client.Models.Auth
{
    public class RegisterModel
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(l => l.DisplayName)
                .NotEmpty()
                .WithMessage("Enter displayname");
            
            RuleFor(l => l.Email)
                .NotEmpty()
                .WithMessage("Enter email");
            
            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Enter password");
            
            RuleFor(l => l.RePassword)
                .Equal(c=>c.Password)
                .WithMessage("Passwords should match");
        }
    }
}
