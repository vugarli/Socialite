using AutoMapper;
using Socialite.Application.Requests.Post;
using Socialite.Application.Services.Auth;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.MappingProfiles
{
    public class CurrentUserIdResolver<TSrc,TDest> : IValueResolver<TSrc, TDest, int>
    {
        public ICurrentUserService _currentUserService { get; }
        public CurrentUserIdResolver(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public int Resolve(TSrc source, TDest destination, int destMember, ResolutionContext context)
        {
            return _currentUserService.GetCurrentUserId();
        }
    }
}
