using Socialite.Application.Requests.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts
{
    public interface IPostValidator
    {
        public void ValidatePostOnCreate(PostPostRequest request);

    }
}
