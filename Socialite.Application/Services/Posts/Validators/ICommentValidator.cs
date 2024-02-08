using Socialite.Application.Requests.Post;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts.Validators
{
    public interface ICommentValidator
    {
        public void ValidatePostCommentOnPost(PostCommentRequest request);
        //public void ValidateReplyCommentOnPost(ReplyCommentRequest request);


    }
}
