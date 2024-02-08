using Socialite.Application.Exceptions;
using Socialite.Application.Requests.Post;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts.Validators
{
    public class ImpressionValidator : BaseValidator<ImpressionValidationException>,IImpressionValidator
    {
        public void ValidateImpressionOnPut(PutImpressionRequest putImpressionRequest)
        {
            Validate(
                (Rule: IsValidImpressionType(putImpressionRequest.ImpressionType),
                Parameter: nameof(putImpressionRequest.ImpressionType))
                );
        }

        public object IsValidImpressionType(PostImpressionType postImpressionType)
        => new
        {
            Condition = Enum.IsDefined(postImpressionType),
            Message = "Impression type is invalid"
        };

    }
}
