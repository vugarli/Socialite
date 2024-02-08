using Microsoft.AspNetCore.Mvc;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Requests.Post
{
    public class PutImpressionRequest
    {
        public PostImpressionType ImpressionType { get; set; }

        public int PostId { get; set; }
    }
}
