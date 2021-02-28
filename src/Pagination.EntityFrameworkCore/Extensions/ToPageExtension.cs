using BitzArt.Pagination.Interfaces;
using BitzArt.Pagination.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BitzArt.Pagination.EntityFrameworkCore
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

        public static PageResult<T> ToPage<T>(this IQueryable<T> query, PageRequest request)
        {
            return query.ToPageAsync(request).Result;
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageRequest request)
        {
            return await query.Paginate(request).ToPageAsync();
        }

        public static PageResult<T> ToPage<T>(this IPagedQueryable<T> query)
        {
            return query.ToPageAsync().Result;
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IPagedQueryable<T> query)
        {
            var data = await query.Query.ToListAsync();
            var total = await query.UnpaginatedQuery.CountAsync();

            return new PageResult<T>(data, query.PageRequest, total);
        }
    }
}
