using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Socialite.Web.Client.Models.Post;
using Socialite.Web.Client.Services.Post;

namespace Socialite.Web.Client.Dialogs.PostDialogs
{
    public class CreatePostDialogBase : ComponentBase
    {
        [CascadingParameter] public MudDialogInstance MudDialogInstance { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }
        [Inject]
        private IPostService _postService { get; set; }
        
        public CreatePostRequest CreateModel { get; set; } = new();

        public EditForm _editForm { get; set; }

        public async Task Post()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                var result = await _postService.CreatePost(CreateModel);
                if (result)
                {
                    _snackbar.Add("Success", Severity.Success);
                    MudDialogInstance.Close();
                }
                else
                    _snackbar.Add("Failed", Severity.Error);
            }

        }

    }
}
