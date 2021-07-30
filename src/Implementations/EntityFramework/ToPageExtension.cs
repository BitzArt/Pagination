using BitzArt.Pagination.Models;
using System.Linq;
using System.Threading.Tasks;

namespace System.Data.Entity
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
            var data = await query.Skip(request.Skip).Take(request.Take).ToListAsync();
            var total = await query.CountAsync();

            return new PageResult<T>(data, request, total);
        }
    }
}
