using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Filters
{
    public static class FilterExtensions
    {
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, params IFilter<T>[] filters)
        {
            foreach (var filter in filters)
            {
                query = filter.Filter(query);
            }
            return query;
        }

    }
}
