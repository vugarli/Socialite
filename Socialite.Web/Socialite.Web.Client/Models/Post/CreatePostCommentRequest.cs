namespace Socialite.Web.Client.Models.Post
{
    public class CreatePostCommentRequest
    {
        public string Content { get; set; }

        public CreatePostCommentRequest(string comment)
        {
            Content = comment;
        }
    }

}
