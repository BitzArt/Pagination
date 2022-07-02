using BitzArt.Pagination.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    public static class ToPageAsyncExtension
    {
        public static Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, int skip, int take, CancellationToken cancellationToken = default)
            => query.ToPageAsync(new PageRequest(skip, take), cancellationToken);

        public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageRequest request, CancellationToken cancellationToken = default)
        {
            var data = await query.Skip(request.Offset).Take(request.Limit).ToListAsync(cancellationToken);
            var total = await query.CountAsync(cancellationToken);

            return new PageResult<T>(data, request, total);
        }
    }
}
