using Socialite.Application.Specifications;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Abstract.Repositories
{
    public interface IImpressionRepository
    {
        public Task PutImpressionAsync(PostImpression impression);

        public Task<IEnumerable<PostImpression>> GetImpressionsBySpecificationAsync(
            Specification<PostImpression> specification);

    }
}
