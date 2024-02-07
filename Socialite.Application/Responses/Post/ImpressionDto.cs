using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Responses.Post
{
    public class ImpressionDto
    {
        public int UserId { get; set; }
        public PostImpressionType ImpressionType { get; set; }
    }
}
