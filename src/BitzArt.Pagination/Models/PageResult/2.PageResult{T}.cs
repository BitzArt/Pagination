namespace BitzArt.Pagination;

/// <inheritdoc/>
public class PageResult<T> : PageResult<T, PageRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T,TPageRequest}"/> class.
    /// </summary>
    /// <param name="items">Page items.</param>
    /// <param name="offset">Requested page offset.</param>
    /// <param name="limit">Requested page limit.</param>
    /// <param name="total">Total number of items available.</param>
    public PageResult(IEnumerable<T> items, int offset, int limit, int? total)
        : base(items, new PageRequest(offset, limit), total) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T,TPageRequest}"/> class.
    /// </summary>
    /// <param name="items">Page items.</param>
    /// <param name="request">The request used to generate this page.</param>
    /// <param name="total">Total number of items available.</param>
    public PageResult(IEnumerable<T>? items, PageRequest? request, int? total) : this()
    {
        Items = items;
        Count = items?.Count();
        Request = request;
        Total = total;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T,TPageRequest}"/> class.
    /// </summary>
    public PageResult() { }
}
