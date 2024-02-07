using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Filters
{
    public interface IPaginationFilter { }
    public class PaginationFilter<T> : IFilter<T>, IPaginationFilter
    {
        public int? page { get; set; }
        public int? per_page { get; set; }

        public IQueryable<T> Filter(IQueryable<T> query)
        {
            if (page is null || per_page is null) return query;
            return query.Skip((int)((page - 1) * per_page)).Take((int)per_page);
        }
    }
}
