namespace Socialite.Web.Client.Models.Query
{
    public class PaginatedQueryResult<T> : QueryResult<T>
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int RowCount { get; set; }
        public int TotalPages { get; set; }

        public string? Previous { get; set; }
        public string? Next { get; set; }
    }
}
