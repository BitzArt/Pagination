using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

/// <summary>
/// A page of items.
/// </summary>
/// <typeparam name="T">Item type.</typeparam>
/// <typeparam name="TRequest">Page request type.</typeparam>
public class PageResult<T, TRequest>
    where TRequest : IPageRequest
{
    /// <summary>
    /// The request used to generate this page.
    /// </summary>
    [JsonPropertyName("request")]
    public TRequest? Request { get; set; }

    /// <summary>
    /// The number of items in this page.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    /// <summary>
    /// The total number of items available.
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// The items in this page.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<T>? Items { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T,TPageRequest}"/> class.
    /// </summary>
    /// <param name="items">Page items.</param>
    /// <param name="request">The request used to generate this page.</param>
    /// <param name="total">Total number of items available.</param>
    public PageResult(IEnumerable<T>? items, TRequest? request, int? total) : this()
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
