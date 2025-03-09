namespace BitzArt.Pagination;

/// <summary>
/// Extension methods for converting PageResult data
/// </summary>
public static class ConvertExtension
{
    /// <summary>
    /// Converts the Data of a PageResult using a selector
    /// </summary>
    public static PageResult<TResult, TRequest> Convert<TSource, TRequest, TResult>(this PageResult<TSource, TRequest> initial, Func<TSource, TResult> selector)
        where TRequest : IPageRequest
    {
        var data = initial.Items!.Select(selector);
        return new PageResult<TResult, TRequest>(data, initial.Request, initial.Total);
    }
}
