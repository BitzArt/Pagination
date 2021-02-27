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
        public static PageResult<T> ToPage<T>(this IQueryable<T> query)
        {
            return query.ToPageAsync().Result;
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query)
        {
            var data = await query.ToListAsync();

            if ((data is IPagedQueryable<T>) == false) return new PageResult<T>(data, null, await query.CountAsync());

            var pagedQuery = query as IPagedQueryable<T>;
            var total = await pagedQuery.UnpaginatedQuery.CountAsync();
            return new PageResult<T>(data, pagedQuery.PageRequest, total);
        }
    }
}
