using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Specifications.Posts
{
    public class GetPostByIdWithImpressionsSpecification
        : Specification<Post>
    {
        public GetPostByIdWithImpressionsSpecification(int Id)
            :base(p=>p.Id == Id)
        {
            AddInclude(p=>p.Impressions);
            AddInclude(p=>p.Media);
            AddInclude(p => p.User); //
        }
    }
}
