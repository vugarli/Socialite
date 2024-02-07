using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Specifications.Posts
{
    public class GetPostByIdSpecification 
        : Specification<Post>
    {
        public GetPostByIdSpecification(int Id)
            :base(p=>p.Id == Id)
        {
            
        }

    }
}
