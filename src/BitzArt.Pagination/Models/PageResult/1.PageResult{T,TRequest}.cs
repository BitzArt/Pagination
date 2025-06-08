using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

/// <summary>
/// A page of items.
/// </summary>
/// <typeparam name="T">Item type.</typeparam>
/// <typeparam name="TRequest">Page request type.</typeparam>
public class PageResult<T, TRequest> : PageResult<T>
    where TRequest : IPageRequest
{
    /// <summary>
    /// The request used to generate this page.
    /// </summary>
    [JsonPropertyName("request")]
    public TRequest? Request { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T,TPageRequest}"/> class.
    /// </summary>
    /// <param name="items">Page items.</param>
    /// <param name="request">An <typeparamref name="TRequest"/> instance used to generate this page.</param>
    /// <param name="total">Total number of items available.</param>
    /// <param name="count">Number of items in this page. If <see langword="null"/> is provided, will use <paramref name="items"/> count.</param>
    public PageResult(IEnumerable<T>? items, TRequest? request, int? total, int? count = null)
        : base(items, total, count)
    {
        Request = request;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T,TPageRequest}"/> class.
    /// </summary>
    [JsonConstructor]
    protected PageResult() { }
}
