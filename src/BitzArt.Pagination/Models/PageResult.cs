namespace BitzArt.Pagination;

/// <inheritdoc/>
public class PageResult : PageResult<object>
{
    /// <inheritdoc cref="PageResult{T}(IEnumerable{T},int,int,int?)"/>"
    public PageResult(IEnumerable<object>? items, int offset, int limit, int? total)
        : this(items, new PageRequest(offset, limit), total) { }

    /// <inheritdoc/>
    public PageResult(IEnumerable<object>? items, IPageRequest? request, int? total)
        : base(items, request, total) { }

    /// <inheritdoc/>
    public PageResult() : base() { }
}
