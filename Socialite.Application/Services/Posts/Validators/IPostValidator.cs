using Socialite.Application.Requests.Post;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts.Validators
{
    public interface IPostValidator
    {
        public void ValidatePostOnCreate(PostPostRequest request);
        public void ValidatePostOnGet(Post post);

    }
}
