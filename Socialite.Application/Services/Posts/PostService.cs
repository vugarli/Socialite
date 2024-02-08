using AutoMapper;
using Socialite.Application.Abstract.Repositories;
using Socialite.Application.Filters;
using Socialite.Application.Queries;
using Socialite.Application.Requests.Post;
using Socialite.Application.Responses.Post;
using Socialite.Application.Services.Auth;
using Socialite.Application.Specifications.Posts;
using Socialite.Domain.Abstract;
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
        public IImpressionRepository _impressionRepository { get; }
        public ICurrentUserService _currentUserService { get; }
        public IPostValidator _postValidator { get; }
        public IMapper _mapper { get; }
        public IUnitOfWork _unitOfWork { get; }

        public PostService(
            IPostRepository postRepository,
            IImpressionRepository impressionRepository,
            ICurrentUserService currentUserService,
            IPostValidator postValidator,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _impressionRepository = impressionRepository;
            _currentUserService = currentUserService;
            _postValidator = postValidator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task PostPostsAsync(PostPostRequest postPostRequest)
        {
            _postValidator.ValidatePostOnCreate(postPostRequest);

            var post = _mapper.Map<Post>(postPostRequest);
            post.UserId = _currentUserService.GetCurrentUserId();
            await _postRepository.CreatePostAsync(post);
            await _unitOfWork.SaveChangesAsync(default);
        }

        public async Task<IQueryResult> GetCurrentUserPostsAsync(params IFilter<Post>[] filters)
        {
            var spec = new GetCurrentUserPostsWithFiltersSpecification(_currentUserService,filters);

            var specWithoutPaginationFilter = new GetCurrentUserPostsWithFiltersSpecification(_currentUserService,filters.WithoutPagination());
            
            //TODO add pagination filter to spec !! 

            var count = await _postRepository.CountPostsBySpecification(specWithoutPaginationFilter);
            var posts = await _postRepository.GetPostsBySpecificationAsync(spec);
            var dtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            var queryResult = dtos.ToQueryResult(filters,count);

            return queryResult;
        }

        public async Task<IQueryResult> GetPostImpressionsAsync(int postId)
        {
            var spec = new GetPostByIdWithImpressionsSpecification(postId);
            var post = await _postRepository.GetPostBySpecification(spec);

            _postValidator.ValidatePostOnGet(post);

            var dtos = _mapper.Map<IEnumerable<ImpressionDto>>(post.Impressions);

            return dtos.ToQueryResult<ImpressionDto, PostImpression>(default,default);
        }

        public async Task PutPostImpressionsAsync(int postId, PutImpressionRequest request)
        {
            // validate impression 

            var spec = new GetPostByIdSpecification(postId);
            var post = await _postRepository.GetPostBySpecification(spec);
            _postValidator.ValidatePostOnGet(post);

            var impression = _mapper.Map<PostImpression>(request);

            await _impressionRepository.PutImpressionAsync(impression);
            await _unitOfWork.SaveChangesAsync(default);
        }


        public Task<IQueryResult> GetPostCommentsAsync(int postId, params IFilter<Post>[] filters)
        {
            throw new NotImplementedException();
        }

        
        public Task PostPostCommentsAsync(int postId, PostCommentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
