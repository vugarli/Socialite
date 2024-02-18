using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialite.Application.Services.File;
using System.Reflection.Emit;

namespace Socialite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private IPresignedUploadUrlGeneratorService _urlGenerator { get; }
        public FileUploadController(IPresignedUploadUrlGeneratorService urlGenerator)
        {
            _urlGenerator = urlGenerator;
        }

        [HttpGet("{type}/{filename}")]
        public async Task<string> GetPresignedUrl(string fileName,string type)
        {
            var url = await _urlGenerator.GenerateUrlAsync(fileName, type);
            return url;
        }


    }
}
