using Microsoft.EntityFrameworkCore;
using Pagination.Interfaces;
using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination.EntityFrameworkCore
{
    public static class ToPageExtension
    {
        public static PageResult<T> ToPage<T>(this IQueryable<T> query, PageRequest request)
        {
            return ToPageAsync(query, request).Result;
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageRequest request)
        {
            return await ToPageAsync(query.Paginate(request));
        }

        public static PageResult<T> ToPage<T>(this IPagedQueryable<T> query)
        {
            return ToPageAsync(query).Result;
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IPagedQueryable<T> query)
        {
            var data = await query.Query.ToListAsync();
            var total = await query.UnpaginatedQuery.CountAsync();

            return new PageResult<T>(data, query.PageRequest, total);
        }
    }
}
