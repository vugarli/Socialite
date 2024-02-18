using Microsoft.AspNetCore.Components.Forms;
using Socialite.Web.Client.Models.Post;
using Socialite.Web.Client.Models.Query;
using System.Net.Http.Json;
using System.Net.WebSockets;

namespace Socialite.Web.Client.Services.Post
{

    public interface IPostService
    {
        public Task<bool> CreatePost(CreatePostRequest request);
        public Task<IEnumerable<PostModel>> GetCurrentUserPosts();
        public Task<bool> CommentToPostAsync(int postId,string commentContent);
        public Task<bool> ReactToPost(PostImpressionType type,int postId);
        public Task<PaginatedQueryResult<CommentModel>> GetPaginatedComments(int postId);
        public Task<PaginatedQueryResult<CommentModel>> GetPaginatedCommentsFromUrl(string url);
    }

    public class PostService : IPostService
    {
        private HttpClient _client { get; set; }

        public const int COMMENTS_PER_PAGE = 3;

        public PostService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("API");
        }

        public async Task<bool> CreatePost(CreatePostRequest request)
        {

            var result = await _client
                .PostAsJsonAsync(
                Common.Endpoints.PostEndpoints.PostPostEndpoint,
                request
                );

            return result.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<PostModel>> GetCurrentUserPosts()
        {
            var posts = (await _client.GetFromJsonAsync<QueryResult<PostModel>>(Common.Endpoints.PostEndpoints.PostPostEndpoint)).Data;

            return posts;
        }

        public async Task<bool> ReactToPost(PostImpressionType type, int postId)
        {
            var url = SmartFormat.Smart.Format(
               Common.Endpoints.PostEndpoints.PutPostImpressionEndpoint, 
               new { PostId = postId, ImpressionType = (int)type});

            var result = await _client
               .PutAsync(
                url,
               null
               );

            return result.IsSuccessStatusCode;
        }

        public async Task<PaginatedQueryResult<CommentModel>> GetPaginatedComments(int postId)
        {
            var url = SmartFormat.Smart.Format(
               Common.Endpoints.PostEndpoints.PostCommentsEndpoint,
               new { postId = postId })+$"?page=1&per_page={COMMENTS_PER_PAGE}";

            var result = await _client.GetFromJsonAsync<PaginatedQueryResult<CommentModel>>(url);

            return result;
        }

        public async Task<PaginatedQueryResult<CommentModel>> GetPaginatedCommentsFromUrl(string url)
        {
            var result = await _client
                .GetFromJsonAsync<PaginatedQueryResult<CommentModel>>(url);
            return result;
        }

        public async Task<bool> CommentToPostAsync(int postId,string commentContent)
        {
            var url = SmartFormat.Smart.Format(
               Common.Endpoints.PostEndpoints.PostCommentsEndpoint,
               new { postId = postId});

            var result = await _client
               .PostAsJsonAsync(
                url,
               new CreatePostCommentRequest(commentContent)
               ) ;

            return result.IsSuccessStatusCode;
        }
    }
}
