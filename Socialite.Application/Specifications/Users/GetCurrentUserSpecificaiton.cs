using Socialite.Application.Services.Auth;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Specifications.Users
{
    public class GetCurrentUserSpecificaiton : Specification<User>
    {
        public GetCurrentUserSpecificaiton(ICurrentUserService currentUserService)
            :base(u=>u.Id == currentUserService.GetCurrentUserId())
        {
            
        }
    }
}
