using Socialite.Application.Exceptions;
using Socialite.Application.Requests.Post;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts
{
    public class PostValidator : BaseValidator<PostValidationException>,IPostValidator
    {
        public void ValidatePostOnCreate(PostPostRequest request)
        {
            Validate(
                (Rule: IsValidContent(request), Parameter: "Post body"),

                (Rule: IsValidVisibility(request.Visibility),
                Parameter: nameof(request.Visibility))
                
                );
        }


        public object IsValidContent(PostPostRequest request)
        => new 
        {
            Condition = !(request.Content == null && request.MediaUrl == null),
            Message = "Post body can not be empty!"
        };

        public object IsValidVisibility(PostVisibility postVisibility)
        => new
        {
            Condition = Enum.IsDefined(postVisibility),
            Message = $"PostVisibility with value {postVisibility} is not defined!"
        };
        

    }
}
