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
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext _dbContext { get; }
        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IQueryable<Post> Queryable { get => _dbContext.Set<Post>().AsQueryable(); }

        public async Task CreatePostAsync(Post post)
        {
            await _dbContext.Set<Post>().AddAsync(post);
        }

        public void UpdatePostAsync(Post post)
        {
            _dbContext.Attach(post);
            _dbContext.Entry(post).State = EntityState.Modified;
        }

        public async Task<bool> CheckPostBySpecification(Specification<Post> specification)
        => await SpecificationEvaluator.GetQuery(Queryable,specification).AnyAsync();

        public async Task<bool> CheckPostsBySpecification(Specification<Post> specification, int count) 
            => await SpecificationEvaluator
            .GetQuery(Queryable, specification)
            .CountAsync() == count;

        public async Task<int> CountPostsBySpecification(Specification<Post> specification)
        => await SpecificationEvaluator
            .GetQuery(Queryable,specification)
            .CountAsync();

        public async Task<Post> GetPostBySpecification(Specification<Post> specification)
        => await SpecificationEvaluator
            .GetQuery(Queryable,specification)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Post>> GetPostsBySpecificationAsync(Specification<Post> specification)
        => await SpecificationEvaluator
            .GetQuery(Queryable, specification)
            .ToListAsync();
    }
}
