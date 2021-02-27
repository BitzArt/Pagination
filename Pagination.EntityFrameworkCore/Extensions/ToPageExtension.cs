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
        public static PageResult<T> ToPage<T>(this IPagedQueryable<T> query)
        {
            return query.ToPageAsync().Result;
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IPagedQueryable<T> query)
        {
            var data = await query.ToListAsync();

            var total = await query.UnpaginatedQuery.CountAsync();
            return new PageResult<T>(data, query.PageRequest, total);
        }
    }
}
