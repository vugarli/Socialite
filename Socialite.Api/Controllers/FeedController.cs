using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Socialite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFeedAsync()
        {
            return Ok();
        }
    }
}
