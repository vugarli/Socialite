using Microsoft.EntityFrameworkCore;
using Socialite.Application.Abstract.Repositories;
using Socialite.Application.Specifications;
using Socialite.Domain.Entities;
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
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext _dbContext { get; }

        public IQueryable<PostComment> PostCommentQuery 
        { 
            get => _dbContext.Set<PostComment>().AsQueryable();
        }
        public IQueryable<ReplyComment> ReplyCommentQuery 
        { 
            get => _dbContext.Set<ReplyComment>().AsQueryable();
        }

        public DbSet<ReplyComment> ReplyCommentTable 
        { 
            get => _dbContext.Set<ReplyComment>();
        }
        public DbSet<PostComment> PostCommentTable 
        { 
            get => _dbContext.Set<PostComment>();
        }


        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckPostCommentBySpecification
            (Specification<PostComment> specification)
        => await SpecificationEvaluator
            .GetQuery(PostCommentQuery,specification)
            .AnyAsync();

        public async Task<bool> CheckReplyCommentBySpecification
            (Specification<ReplyComment> specification)
        => await SpecificationEvaluator
            .GetQuery(ReplyCommentQuery,specification)
            .AnyAsync();

        public async Task<int> CountPostCommentsBySpecification(Specification<PostComment> specification)
        => await SpecificationEvaluator
            .GetQuery(PostCommentQuery, specification)
            .CountAsync();

        public async Task<int> CountReplyCommentsBySpecification(Specification<ReplyComment> specification)
        => await SpecificationEvaluator
            .GetQuery(ReplyCommentQuery, specification)
            .CountAsync();

        public async Task CreatePostCommentAsync(PostComment postComment)
        {
            await PostCommentTable.AddAsync(postComment);
        }

        public async Task CreateReplyCommentAsync(ReplyComment replyComment)
        {
            await ReplyCommentTable.AddAsync(replyComment);
        }
        public void UpdatePostCommentAsync(PostComment postComment)
        {
            PostCommentTable.Update(postComment);
        }

        public void UpdateReplyCommentAsync(ReplyComment replyComment)
        {
            ReplyCommentTable.Update(replyComment);
        }

        public async Task<int> DeletePostCommentBySpecification
            (Specification<PostComment> specification)
        => await SpecificationEvaluator
            .GetQuery(PostCommentQuery, specification)
            .ExecuteDeleteAsync();

        public async Task<int> DeleteReplyCommentBySpecification
            (Specification<ReplyComment> specification)
        => await SpecificationEvaluator
            .GetQuery(ReplyCommentQuery, specification)
            .ExecuteDeleteAsync();

        public async Task<PostComment> GetPostCommentBySpecification
            (Specification<PostComment> specification)
        => await SpecificationEvaluator
            .GetQuery(PostCommentQuery, specification)
            .FirstOrDefaultAsync();

        public async Task<ReplyComment> GetReplyCommentBySpecification
            (Specification<ReplyComment> specification)
        => await SpecificationEvaluator
            .GetQuery(ReplyCommentQuery, specification)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<PostComment>> GetPostCommentsBySpecificationAsync
            (Specification<PostComment> specification)
        => await SpecificationEvaluator
            .GetQuery(PostCommentQuery, specification)
            .ToListAsync();

        public async Task<IEnumerable<ReplyComment>> GetReplyCommentsBySpecificationAsync(Specification<ReplyComment> specification)
        => await SpecificationEvaluator
            .GetQuery(ReplyCommentQuery, specification)
            .ToListAsync();
    }
}
