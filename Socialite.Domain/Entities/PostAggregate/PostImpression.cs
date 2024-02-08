using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Domain.Entities.PostAggregate
{
    public enum PostImpressionType
    {
        Like,
        Love,
        Laugh,
        Surprised,
        Sad
    }

    public class PostImpression : BaseEntity
    {
        
        public PostImpressionType ImpressionType { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
