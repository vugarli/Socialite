using Socialite.Application.Filters;
using Socialite.Application.Queries;
using Socialite.Application.Requests.Post;
using Socialite.Application.Responses.Post;
using Socialite.Domain.Entities;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts
{
    public interface IPostService
    {
        public Task<IQueryResult> GetCurrentUserPostsAsync(params IFilter<Post>[] filters);
        public Task PostPostsAsync(PostPostRequest postPostRequest);

        public Task<IQueryResult> GetPostImpressionsAsync(int postId);
        public Task PutPostImpressionsAsync(int postId,PutImpressionRequest request);

        public Task<IQueryResult> GetPostCommentsAsync(int postId, params IFilter<PostComment>[] filters);
        public Task PostPostCommentsAsync(PostCommentRequest request);
    }
}
