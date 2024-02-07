using AutoMapper;
using Socialite.Application.Abstract.Repositories;
using Socialite.Application.Filters;
using Socialite.Application.Queries;
using Socialite.Application.Requests.Post;
using Socialite.Application.Services.Auth;
using Socialite.Application.Specifications.Posts;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Posts
{
    public class PostService : IPostService
    {
        public IPostRepository _postRepository { get; }
        public ICurrentUserService _currentUserService { get; }
        public IPostValidator _postValidator { get; }
        public IMapper _mapper { get; }

        public PostService(
            IPostRepository postRepository,
            ICurrentUserService currentUserService,
            IPostValidator postValidator,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _currentUserService = currentUserService;
            _postValidator = postValidator;
            _mapper = mapper;
        }

        public async Task PostPostsAsync(PostPostRequest postPostRequest)
        {
            _postValidator.ValidatePostOnCreate(postPostRequest);

            var post = _mapper.Map<Post>(postPostRequest);
            post.UserId = _currentUserService.GetCurrentUserId();
            await _postRepository.CreatePostAsync(post);
        }

        public async Task<IQueryResult> GetCurrentUserPostsAsync(params IFilter<Post>[] filters)
        {
            var spec = new GetCurrentUserPostsSpecification(_currentUserService);

            var count = await _postRepository.CountPostsBySpecification(spec);
            var posts = await _postRepository.GetPostsBySpecificationAsync(spec);

            var queryResult = posts.ToQueryResult(filters,count);

            return queryResult;
        }

        public Task<IQueryResult> GetPostCommentsAsync(int postId, params IFilter<Post>[] filters)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryResult> GetPostImpressionsAsync(int postId)
        {
            throw new NotImplementedException();
        }

        

        public Task PostPostCommentsAsync(int postId, PostCommentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task PutPostImpressionsAsync(int postId, PutImpressionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
