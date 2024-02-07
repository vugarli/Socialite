using AutoMapper;
using Socialite.Application.Requests.Post;
using Socialite.Application.Responses.Post;
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
            CreateMap<PostPostRequest, Post>();
            CreateMap<Post,PostDto>();


        }


    }
}
