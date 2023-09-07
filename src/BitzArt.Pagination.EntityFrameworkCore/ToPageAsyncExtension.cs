using BitzArt.Pagination;

namespace Microsoft.EntityFrameworkCore;

public static class ToPageAsyncExtension
{
    public static Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, int offset, int limit, CancellationToken cancellationToken = default)
        => query.ToPageAsync(new PageRequest(offset, limit), cancellationToken);

    public static async Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, PageRequest request, CancellationToken cancellationToken = default)
    {
        if (request.Offset is null) throw new ArgumentException("Offset is null");
        if (request.Limit is null) throw new ArgumentException("Limit is null");

        var data = await query
            .Skip(request.Offset.Value)
            .Take(request.Limit.Value)
            .ToListAsync(cancellationToken);

        var total = await query.CountAsync(cancellationToken);

        return new PageResult<T>(data, request, total);
    }
}
