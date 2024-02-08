using HybridModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Requests.Post
{
    public class PostCommentRequest
    {
        [HybridBindProperty(new[] { Source.Body}, order: 10)]

        public string Content { get; set; }

        [HybridBindProperty(new[] { Source.Route }, order: 10)]
        public int PostId { get; set; }
    }
}
