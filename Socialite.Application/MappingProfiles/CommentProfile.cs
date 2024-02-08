using AutoMapper;
using Socialite.Application.Requests.Post;
using Socialite.Application.Responses.Comments;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<PostComment,PostCommentDto>();

            //CreateMap<ReplyComment,ReplyCommentDto>();

            CreateMap<PostCommentRequest,PostComment>()
                .ForMember(c => c.UserId,
                    opt => 
                        opt.MapFrom<CurrentUserIdResolver<PostCommentRequest,PostComment>>()
                        );

        }
    }
}
