using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Domain.Entities.PostAggregate
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }

        public List<PostImpression> Impressions { get; set; } = new();

        public List<PostComment> Comments { get; set; } = new();

        public int? MediaId { get; set; }
        public Media? Media { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public void AddComment(PostComment postComment)
        {
            Comments.Add(postComment);
        }
        public void AddImpression(PostImpression postImpression)
        {
            Impressions.Add(postImpression);
        }
    }
}
