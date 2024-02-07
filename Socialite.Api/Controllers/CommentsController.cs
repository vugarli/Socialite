using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialite.Application.Filters;
using Socialite.Application.Requests.Post;
using Socialite.Domain.Entities;

namespace Socialite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetCommentAsync(int commentId)
        {
            return Ok();
        }

        [HttpGet("{commentId}/replies")]
        public async Task<IActionResult> GetRepliesToCommentAsync(
            int commentId,
            [FromQuery] PaginationFilter<ReplyComment> paginationFilter)
        {
            return Ok();
        }

        [HttpPost("{commentId}")]
        public async Task<IActionResult> ReplyToCommentAsync(
            int commentId,
            [FromBody] CommentReplyRequest commentReplyRequest)
        {
            return Ok();
        }
    }
}
