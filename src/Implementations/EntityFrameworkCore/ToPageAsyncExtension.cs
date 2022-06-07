using BitzArt.Pagination.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    public static class ToPageAsyncExtension
    {
        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);
            return await query.ToPageAsync(request);
        }

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageRequest request)
        {
            var data = await query.Skip(request.Offset).Take(request.Limit).ToListAsync();
            var total = await query.CountAsync();

            return new PageResult<T>(data, request, total);
        }
    }
}
