using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Socialite.Application.Exceptions;
using Socialite.Application.Filters;
using Socialite.Application.Queries;
using Socialite.Application.Requests.Post;
using Socialite.Application.Services.Posts;
using Socialite.Domain.Entities;
using Socialite.Domain.Entities.PostAggregate;

namespace Socialite.Api.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : RESTFulController
    {
        public IPostService _postService { get; }
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet()]
        public async Task<IQueryResult> GetCurrentUserPostsAsync(
            [FromQuery] PaginationFilter<Post> paginationFilter)
        {
            return await _postService.GetCurrentUserPostsAsync(paginationFilter);
        }

        [HttpPost()]
        public async Task<IActionResult> PostPostAsync(
            [FromBody] PostPostRequest postPostRequest)
        {
            try
            {
                await _postService.PostPostsAsync(postPostRequest);
                return Ok();
            }
            catch (PostValidationException ex) 
            {
                return BadRequest(ex);
            }
            //catch(Exception ex) 
            //{ 
            //    return InternalServerError("Something bad happended");
            //}
        }

        [HttpGet("{postId}/impressions")]
        public async Task<IActionResult> GetPostImpressionsAsync(int postId)
        {
            return Ok();
        }

        [HttpPut("{postId}/impressions")]
        public async Task<IActionResult> PutPostImpressionsAsync(
            int postId, 
            [FromBody] PutImpressionRequest impressionRequest)
        {
            return Ok();
        }


        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetPostCommentsAsync(
            int postId,
            [FromQuery] PaginationFilter<PostComment> paginationFilter)
        {
            return Ok();
        }

        [HttpPost("{postId}/comments")]
        public async Task<IActionResult> CommentToPostAsync(
            int postId,
            [FromBody] PostCommentRequest postCommentRequest)
        {
            return Ok();
        }
    }
}
