using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socialite.Domain.Entities.PostAggregate;

namespace Socialite.Domain.Entities
{
    public abstract class Comment : BaseEntity
    {
        public string Content { get; set; }
        public List<ReplyComment> Replies { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Comment(string content)
        {
            Content = content;
        }

        public void AddReply(ReplyComment replyComment)
        { 
            Replies.Add(replyComment);
        }
    }

    public class PostComment : Comment
    {
        // ef core stuff
        private PostComment() : base(null) { }

        public PostComment(string comment)
            :base(comment)
        {
            
        }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }

    public class ReplyComment : Comment
    {
        // ef core stuff
        private ReplyComment() : base(null) { }

        public ReplyComment(string content)
            :base(content)
        {
            
        }

        public int ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
    }
}
