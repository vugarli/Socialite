using AutoMapper;
using Socialite.Application.Responses.Users;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserInfoDto>()
                .ForMember(d=>d.DisplayName,opt=>opt.MapFrom(u=>u.DisplayName))
                .ForMember(d=>d.ProfileImageUrl,opt=>opt.MapFrom(u=>u.ProfileImage));

        }
    }
}
