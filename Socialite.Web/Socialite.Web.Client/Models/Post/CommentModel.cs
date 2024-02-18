namespace Socialite.Web.Client.Models.Post
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommenterName { get; set; }
        public string CommenterProfilePic { get; set; }
    }
}
