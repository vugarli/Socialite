using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Socialite.Application.Filters;
using Socialite.Application.Requests.Post;
using Socialite.Domain.Entities;
using Socialite.Domain.Entities.PostAggregate;

namespace Socialite.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : RESTFulController
    {
        [HttpGet("posts")]
        public async Task<IActionResult> GetCurrentUserPostsAsync(
            [FromQuery] PaginationFilter<Post> paginationFilter)
        {
            return Ok();
        }

        [HttpPost("posts")]
        public async Task<IActionResult> PostPostAsync([FromBody]PostPostRequest postPostRequest)
        {
            return Ok();
        }

        [HttpGet("posts/{postId}/impressions")]
        public async Task<IActionResult> GetPostImpressionsAsync(int postId)
        {
            return Ok();
        }

        [HttpPut("posts/{postId}/impressions")]
        public async Task<IActionResult> PostPostImpressionsAsync(int postId)
        {
            return Ok();
        }



        [HttpGet("posts/{postId}/comments")]
        public async Task<IActionResult> GetPostCommentsAsync(
            int postId,
            [FromQuery] PaginationFilter<PostComment> paginationFilter)
        {
            return Ok();
        }

        [HttpPost("posts/{postId}/comments")]
        public async Task<IActionResult> CommentToPostAsync(int postId)
        {
            return Ok();
        }

        [HttpGet("posts/{postId}/comments/{commentId}")]
        public async Task<IActionResult> GetCommentToPostAsync(int postId,int commentId)
        {
            return Ok();
        }

        [HttpPost("posts/{postId}/comments/{commentId}")]
        public async Task<IActionResult> ReplyToCommentAsync(int postId, int commentId)
        {
            return Ok();
        }

        [HttpGet("posts/{postId}/comments/{commentId}/replies")]
        public async Task<IActionResult> GetRepliesToCommentAsync(
            int postId,
            int commentId,
            [FromQuery] PaginationFilter<ReplyComment> paginationFilter)
        {
            return Ok();
        }

    }
}
