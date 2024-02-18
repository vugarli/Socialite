using Microsoft.AspNetCore.Components;
using Socialite.Web.Client.Models.Post;
using Socialite.Web.Client.Services.Post;

namespace Socialite.Web.Client.Components.Post.TextPost
{
    public class TestPostComponentBase : ComponentBase
    {
        [Parameter, EditorRequired]
        public PostModel Model { get; set; } = new();

        [Inject]
        public IPostService PostService { get; set; }

        protected List<CommentModel> Comments { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            await LoadComments();
        }

        public async Task LoadComments()
        {
            var comments = await PostService.GetComments(Model.Id);
            Comments = comments.ToList();
        }


        public async Task Impress(PostImpressionType type)
        {
            if (type == Model.ImpressionType)
            {
                Model.ImpressionType = null;
                Model.LikeCount -= 1;
            }
            else 
            {
                if (Model.ImpressionType == null)
                    Model.LikeCount += 1;
                Model.ImpressionType = type;
            }
            var result = await PostService.ReactToPost(type,Model.Id);
        }

    }
}
