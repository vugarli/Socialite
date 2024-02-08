using Socialite.Application.Exceptions;
using Socialite.Application.Requests.Post;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts.Validators
{
    public class CommentValidator : BaseValidator<CommentValidationException> ,ICommentValidator
    {
        public void ValidatePostCommentOnPost(PostCommentRequest request)
        {
            Validate(
                (Rule: IsValidContent(request.Content), Parameter:nameof(request.Content))

                );
        }

        public dynamic IsValidContent(string content)
            => new
            {
                Condition = !string.IsNullOrEmpty(content),
                Message = "Content should not be empty or null!"
            };


    }
}
