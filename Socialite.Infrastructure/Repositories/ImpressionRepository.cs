using Microsoft.EntityFrameworkCore;
using Socialite.Application.Abstract.Repositories;
using Socialite.Application.Specifications;
using Socialite.Domain.Entities.PostAggregate;
using Socialite.Infrastructure.Data;
using Socialite.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Repositories
{
    public class ImpressionRepository : IImpressionRepository
    {
        public ApplicationDbContext _dbContext { get; }
        public ImpressionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<PostImpression> Table { get => _dbContext.Set<PostImpression>(); }

        public async Task<IEnumerable<PostImpression>> GetImpressionsBySpecificationAsync(Specification<PostImpression> specification)
        => await SpecificationEvaluator.GetQuery(Table, specification).ToListAsync();

        public async Task PutImpressionAsync(PostImpression impression)
        {
            var maybeImpression = await Table.FirstOrDefaultAsync
                (pi => pi.UserId == impression.UserId && pi.PostId == impression.PostId);

            if (maybeImpression is null)
            {
                await _dbContext.Set<PostImpression>().AddAsync(impression);
            }
            else
            {
                if (maybeImpression.ImpressionType != impression.ImpressionType)
                    maybeImpression.ImpressionType = impression.ImpressionType;
                else
                    _dbContext.Set<PostImpression>().Remove(maybeImpression);

            }
        }
    }
}
