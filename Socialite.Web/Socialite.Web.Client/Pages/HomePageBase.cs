using Microsoft.AspNetCore.Components;
using MudBlazor;
using Socialite.Web.Client.Dialogs.PostDialogs;
using Socialite.Web.Client.Models.Post;
using Socialite.Web.Client.Services.Post;

namespace Socialite.Web.Client.Pages
{
    public class HomePageBase : ComponentBase
    {
        [Inject]
        IDialogService DialogService { get; set; }

        [Inject]
        IPostService PostService { get; set; }

        public IEnumerable<PostModel> Posts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Posts = await PostService.GetCurrentUserPosts();
        }
        

        public readonly MudTheme _customTheme = new()
        {
            Palette = new Palette
            {
                Primary = "#7955DC"
            },

            ZIndex = new ZIndex() { Dialog=9999}
    };

        public void OpenCreatePostDialog()
        {
            var options = new DialogOptions 
            { 
                CloseOnEscapeKey = true,
                NoHeader=true,
                Position = DialogPosition.Center
            };


            DialogService.Show<CreatePostDialog>(null,options);
        }

    }
}
