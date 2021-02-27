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
        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query)
        {
            var data = await query.ToListAsync();
            //var count = (query as IPagedQueryable<T>).unpa

            return new PageResult<T>();
        }

        public static PageResult<T> ToPage<T>(this IQueryable<T> query)
        {
            return query.ToPageAsync().Result;
        }
    }
}
