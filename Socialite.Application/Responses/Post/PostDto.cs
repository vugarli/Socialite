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
        public PostVisibility Visibility{ get; set; }

        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public int UserId { get; set; }
    }
}
