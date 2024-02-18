using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Common.Endpoints
{
    public static class PostEndpoints
    {
        public const string PostPostEndpoint = "/api/Posts";
        public const string PostImpressionsEndpoint = "/api/Posts/{postId}/impressions";
        public const string PutPostImpressionEndpoint = "/api/Posts/{PostId}/impressions/{ImpressionType}";
        public const string PostCommentsEndpoint = "/api/Posts/{postId}/comments";



    }
}
