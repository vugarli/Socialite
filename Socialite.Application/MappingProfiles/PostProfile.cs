using AutoMapper;
using Socialite.Application.Requests.Post;
using Socialite.Application.Responses.Post;
using Socialite.Application.Services.Auth;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.MappingProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostPostRequest, Post>()
                .ForMember(c => c.UserId, opt => 
                opt.MapFrom<CurrentUserIdResolver<PostPostRequest,Post>>());

            // passed as argument in projectto
            int currentUser = 0;

            CreateMap<Post, PostDto>()

                .ForMember(pd => pd.MediaUrl, opt => opt.MapFrom(p => p.Media.MediaUrl))
                .ForMember(pd => pd.CommentCount,
                    opt => opt.MapFrom(p => p.Comments.Count()))
                .ForMember(pd => pd.LikeCount, opt => opt.MapFrom(p => p.Impressions.Count()))
                .ForMember(pd =>
                    pd.OwnerDisplayName,
                        opt =>
                            opt.MapFrom(p => p.User.DisplayName))
                .ForMember(pd => pd.Impressed, opt =>
                opt.MapFrom(p => p.Impressions.Any(c => c.UserId == currentUser)))
                .ForMember(pd => pd.ImpressionType, opt =>
                {
                    opt.NullSubstitute(null);
                    opt.MapFrom(p => p.Impressions.FirstOrDefault(c => c.UserId == currentUser).ImpressionType);
                });



        }


    }
}
