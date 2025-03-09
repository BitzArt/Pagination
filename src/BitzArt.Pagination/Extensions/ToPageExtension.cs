using BitzArt.Pagination;

namespace System.Linq;

/// <summary>
/// Extension methods for converting a query to a page of items
/// </summary>
public static class ToPageExtension
{
    /// <inheritdoc cref="ToPage{T,TRequest}(IEnumerable{T}, TRequest)"/>
    /// <param name="query">Dataset to build the page from.</param>
    /// <param name="offset">Requested page offset.</param>
    /// <param name="limit">Requested page limit.</param>
    public static PageResult<T, PageRequest> ToPage<T>(this IEnumerable<T> query, int offset, int limit)
        => query.ToPage(new PageRequest(offset, limit));

    /// <summary>
    /// Converts a query to a page of items
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    /// <typeparam name="TRequest">Page request type.</typeparam>
    /// <param name="query">Dataset to build the page from.</param>
    /// <param name="request">Page request.</param>
    /// <returns>A <see cref="PageResult{T}"/> containing the requested items</returns>
    public static PageResult<T, TRequest> ToPage<T, TRequest>(this IEnumerable<T> query, TRequest request)
        where TRequest : IPageRequest
    {
        var data = request.ApplyConstraints(query);
        var total = query.Count();

        return new PageResult<T, TRequest>(data, request, total);
    }
}
