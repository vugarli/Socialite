using Socialite.Application.Specifications;
using Socialite.Domain.Entities;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Abstract.Repositories
{
    public interface ICommentRepository
    {
        public Task CreatePostCommentAsync(PostComment postComment);
        public Task CreateReplyCommentAsync(ReplyComment replyComment);

        public void UpdatePostCommentAsync(PostComment postComment);
        public void UpdateReplyCommentAsync(ReplyComment replyComment);


        public Task<int> DeletePostCommentBySpecification(
            Specification<PostComment> specification);

        public Task<int> DeleteReplyCommentBySpecification(
            Specification<ReplyComment> specification);

        public Task<PostComment> GetPostCommentBySpecification(
            Specification<PostComment> specification);

        public Task<ReplyComment> GetReplyCommentBySpecification(
            Specification<ReplyComment> specification);


        public Task<IEnumerable<PostComment>> GetPostCommentsBySpecificationAsync(
            Specification<PostComment> specification);
        
        public Task<IEnumerable<ReplyComment>> GetReplyCommentsBySpecificationAsync(
            Specification<ReplyComment> specification);

        public Task<bool> CheckPostCommentBySpecification(
            Specification<PostComment> specification);
        public Task<bool> CheckReplyCommentBySpecification(
            Specification<ReplyComment> specification);

        public Task<int> CountPostCommentsBySpecification(
            Specification<PostComment> specification);
        
        public Task<int> CountReplyCommentsBySpecification(
            Specification<ReplyComment> specification);

    }
}
