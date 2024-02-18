using AutoMapper;
using Socialite.Application.Services.Auth;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.MappingProfiles
{
    public class ImpressionResolver<TSrc, TDest> : IValueResolver<TSrc, TDest, PostImpressionType> where TSrc : Post
    {
        public ICurrentUserService _currentUserService { get; }
        public ImpressionResolver(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public PostImpressionType Resolve(TSrc source, TDest destination, PostImpressionType destMember, ResolutionContext context)
        {
            var userId = _currentUserService.GetCurrentUserId();
            var Impressions = source.Impressions;
            return Impressions.FirstOrDefault(c=>c.UserId == userId).ImpressionType;
        }
    }
}
