using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Domain.Entities.PostAggregate
{
    public enum MediaType
    {
        Image,
        Video
    }

    public class Media : BaseEntity
    {
        public Media(string mediaUrl, MediaType mediatype)
        {
            MediaUrl = mediaUrl;
            Mediatype = mediatype;
        }

        public MediaType Mediatype { get; set; }
        public string MediaUrl { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
