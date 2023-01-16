namespace BitzArt.Pagination;

public static class ConvertExtension
{
    /// <summary>
    /// Converts the Data of a PageResult using a selector
    /// </summary>
    public static PageResult<TResult> Convert<TSource, TResult>(this PageResult<TSource> source, Func<TSource, TResult> selector)
    {
        var data = source.Data!.Select(selector);
        return new PageResult<TResult>(data, source.Request, source.Total);
    }
}
