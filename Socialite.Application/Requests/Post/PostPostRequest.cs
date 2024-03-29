﻿using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Requests.Post
{
    public class PostPostRequest
    {
        public string? Content{ get; set; }
        public string? MediaUrl{ get; set; }
        public PostVisibility Visibility{ get; set; }
    }
}
