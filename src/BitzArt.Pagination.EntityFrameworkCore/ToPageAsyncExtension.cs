using BitzArt.Pagination;

namespace Microsoft.EntityFrameworkCore;

/// <summary>
/// Extension methods for converting an <see cref="IQueryable"/> to a page of items
/// </summary>
public static class ToPageAsyncExtension
{
    /// <summary>
    /// Converts a query to a page of items
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    /// <param name="query">The dataset to build the page from.</param>
    /// <param name="offset">Requested page offset.</param>
    /// <param name="limit">Requested page limit.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Offset is null or Limit is null.</exception>
    public static Task<PageResult<T>> ToPageAsync<T>(this IQueryable<T> query, int offset, int limit, CancellationToken cancellationToken = default)
        => query.ToPageAsync(new PageRequest(offset, limit), cancellationToken);

    /// <summary>
    /// Converts a query to a page of items
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    /// <param name="query">The dataset to build the page from.</param>
    /// <param name="request">Page request.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Offset is null or Limit is null.</exception>
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
