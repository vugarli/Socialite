using FluentValidation;
using Socialite.Web.Client.Models.Auth;

namespace Socialite.Web.Client.Models.Post
{
    public class CreatePostRequest
    {
        public string Content { get; set; }
        public string MediaUrl { get; set; }
        public PostVisibility Visibility { get; set; }
    }
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(l => l.Content).NotEmpty().WithMessage("Enter content");
        }
    }
}
