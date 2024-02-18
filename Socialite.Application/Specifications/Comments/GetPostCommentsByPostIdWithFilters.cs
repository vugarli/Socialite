using Socialite.Application.Filters;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Specifications.Comments
{
    public class GetPostCommentsByPostIdWithFilters
        : Specification<PostComment>
    {
        public GetPostCommentsByPostIdWithFilters(int postId,params IFilter<PostComment>[] filters)
            : base(c=>c.PostId == postId)
        {
            SetFilters(filters);
            AddInclude(c=>c.User);
        }
    }
}
