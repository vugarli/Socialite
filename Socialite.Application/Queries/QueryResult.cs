using Socialite.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Socialite.Application.Queries
{
    [JsonPolymorphic()]
    [JsonDerivedType(typeof(QueryResult<>))]
    [JsonDerivedType(typeof(PaginatedQueryResult<>))]
    public interface IQueryResult
    { 
        
    }

    public class QueryResult<T> : IQueryResult
    {
        public IEnumerable<T> Data { get; init; }

        public QueryResult(IEnumerable<T> data)
        {
            Data = data;
        }
    }


    public static class QueryResultExtensions
    {
        public static IQueryResult ToQueryResult<Tdto,Tent>(
            this IEnumerable<Tdto> data,
            IFilter<Tent>[] filters,int count)
        {
            IQueryResult queryResult;

            if (filters.Any(f => f is PaginationFilter<Tent>))
            {
                var pFilter = (PaginationFilter<Tent>)filters.FirstOrDefault(c => c is PaginationFilter<Tent>);

                if (pFilter != null && pFilter.per_page != null && pFilter.page != null)
                    queryResult = new PaginatedQueryResult<Tdto>(data, (int)pFilter.page, (int)pFilter.per_page, count);
                else
                    queryResult = new QueryResult<Tdto>(data);
            }
            else
                queryResult = new QueryResult<Tdto>(data);

            return queryResult;
        }
            
    }
}
