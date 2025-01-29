using BitzArt.Pagination;

namespace System.Linq;

/// <summary>
/// Extension methods for converting a query to a page of items
/// </summary>
public static class ToPageExtension
{
    /// <summary>
    /// Converts a query to a page of items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query">Dataset to build the page from</param>
    /// <param name="offset">Requested page offset</param>
    /// <param name="limit">Requested page limit</param>
    /// <returns>A <see cref="PageResult{T}"/> containing the requested items</returns>
    public static PageResult<T> ToPage<T>(this IEnumerable<T> query, int offset, int limit)
        => query.ToPage(new PageRequest(offset, limit));

    /// <summary>
    /// Converts a query to a page of items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query">Dataset to build the page from</param>
    /// <param name="request">Page request</param>
    /// <returns>A <see cref="PageResult{T}"/> containing the requested items</returns>
    public static PageResult<T> ToPage<T>(this IEnumerable<T> query, PageRequest request)
    {
        if (request.Offset is null) throw new ArgumentException("Offset is null");
        if (request.Limit is null) throw new ArgumentException("Limit is null");

        var data = query.Skip(request.Offset.Value).Take(request.Limit.Value);
        var total = query.Count();

        return new PageResult<T>(data, request, total);
    }
}
