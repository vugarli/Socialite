using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Responses.Comments
{
    public class PostCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommenterName { get; set; }
        public string CommenterProfilePic { get; set; }
    }
}
