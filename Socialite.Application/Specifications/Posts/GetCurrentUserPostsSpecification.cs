using Socialite.Application.Services.Auth;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Specifications.Posts
{
    public class GetCurrentUserPostsSpecification
        : Specification<Post>
    {
        public GetCurrentUserPostsSpecification(ICurrentUserService currentUserService)
            : base(p=>p.UserId == currentUserService.GetCurrentUserId())
        {
            
        }
    }
}
