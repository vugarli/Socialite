namespace Socialite.Web.Client.Models.Post
{
    public enum PostImpressionType
    {
        Like,
        Love,
        Laugh,
        Surprised,
        Sad
    }
    public class PostModel
    {
        public int Id { get; set; }
        public string OwnerDisplayName { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostVisibility Visibility { get; set; }
        public PostImpressionType? ImpressionType { get; set; }
        public bool Impressed { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public int UserId { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
