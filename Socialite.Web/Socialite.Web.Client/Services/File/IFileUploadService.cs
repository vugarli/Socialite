using Microsoft.AspNetCore.Components.Forms;

namespace Socialite.Web.Client.Services.File
{
    public interface IFileUploadService
    {
        public Task<string> UploadFileAndProvideNameAsync(IBrowserFile e);
    }
}
