using Socialite.Application.Filters;
using Socialite.Application.Services.Auth;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Specifications.Posts
{
    public class GetCurrentUserPostsWithFiltersSpecification
        : Specification<Post>
    {
        public GetCurrentUserPostsWithFiltersSpecification(ICurrentUserService currentUserService, params IFilter<Post>[] filters)
            : base(p=>p.UserId == currentUserService.GetCurrentUserId())
        {
            SetFilters(filters);
        }
    }
}
