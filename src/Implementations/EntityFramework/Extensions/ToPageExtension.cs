using BitzArt.Pagination.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System;

namespace BitzArt.Pagination.EntityFramework
{
    public static class ToPageExtension
    {
        public static PageResult<T> ToPage<T>(this IQueryable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);
            return query.ToPage(request);
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);
            return await query.ToPageAsync(request);
        }

        public static PageResult<T> ToPage<T>(this IQueryable<T> query, PageRequest request = null)
        {
            return query.ToPageAsync(request).Result;
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageRequest request = null)
        {
            var paged = query as PagedQueryable<T>;
            if (paged == null)
            {
                if (request == null) throw new Exception("Unable to make page without page request");
                paged = new PagedQueryable<T>(query, request);
            }

            request = paged.PageRequest;

            var data = await paged.Query.Skip(request.Skip).Take(request.Take).ToListAsync();
            var total = await paged.Query.CountAsync();

            return new PageResult<T>(data, request, total);
        }
    }
}
