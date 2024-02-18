using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Responses.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string OwnerDisplayName { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostVisibility Visibility{ get; set; }
        public PostImpressionType? ImpressionType { get; set; }
        public bool Impressed { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public int UserId { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
