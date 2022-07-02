using BitzArt.Pagination.Models;
using System.Linq;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public static class ToPageAsyncExtension
    {
        public static Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, int skip, int take)
            => query.ToPageAsync(new PageRequest(skip, take));

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageRequest request)
        {
            var data = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            var total = await query.CountAsync();

            return new PageResult<T>(data, request, total);
        }
    }
}
