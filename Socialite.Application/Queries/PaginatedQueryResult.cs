﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Socialite.Application.Queries
{
    public class PaginatedQueryResult<T> : QueryResult<T>,IQueryResult
    {
        public PaginatedQueryResult(IEnumerable<T> data, int page, int per_page, int rowCount) :base(data)
        {
            Page = page;
            Per_Page = per_page;
            RowCount = rowCount;
        }
        
        public int Page { get; init; }
        public int Per_Page { get; init; }
        public int RowCount { get; init; }
        public int TotalPages { get => (int) Math.Ceiling(RowCount * 1.0d /Per_Page); }

        public string? Previous { get; set; }
        public string? Next { get; set; }
    }

    public static class PaginatedQueryResultExtensions
    {
        public static IQueryResult ToPaginatedQueryResult<T>(
            this IEnumerable<T> data,
            int page,
            int per_page,
            int row_count)
            => new PaginatedQueryResult<T>(data,page,per_page,row_count);
    }

}
