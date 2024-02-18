using Microsoft.AspNetCore.Components;
using Socialite.Web.Client.Models.Post;
using Socialite.Web.Client.Services.Post;
using Socialite.Web.Client.Services.Users;

namespace Socialite.Web.Client.Components.Post.TextPost
{
    public class TestPostComponentBase : ComponentBase
    {
        [Parameter, EditorRequired]
        public PostModel Model { get; set; } = new();

        [Inject]
        public IPostService PostService { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        public bool CommentsHasNext { get; set; }
        public string CommentsNext { get; set; }

        public string CommentValue { get; set; }

        protected List<CommentModel> Comments { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            await LoadInitialComments();
        }

        public async Task LoadInitialComments()
        {
            var comments = await PostService.GetPaginatedComments(Model.Id);
            CommentsHasNext = comments.HasNext;
            CommentsNext = comments.Next;
            Comments = comments.Data.ToList();
        }

        public async Task LoadMoreComments()
        {
            if (CommentsNext is null) return;
            var additionalComments = await PostService.GetPaginatedCommentsFromUrl(CommentsNext);
            CommentsHasNext = additionalComments.HasNext;
            CommentsNext = additionalComments.Next;
            Comments.AddRange(additionalComments.Data);
        }


        public async Task Comment()
        {
            if (string.IsNullOrEmpty(CommentValue))
                return;

            await PostService.CommentToPostAsync(Model.Id,CommentValue);

            var info = await UserService.GetCurrentUserInfo();

            var commentModel = new CommentModel()
            {
                CommenterName = info.DisplayName,
                CommenterProfilePic = info.ProfileImageUrl,
                Content = CommentValue
            };
            Comments.Add(commentModel); 

            CommentValue = string.Empty;
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
