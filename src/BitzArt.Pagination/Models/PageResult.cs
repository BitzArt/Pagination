using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

/// <summary>
/// A page of items
/// </summary>
public class PageResult : PageResult<object>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T}"/> class.
    /// </summary>
    /// <param name="items">Page items</param>
    /// <param name="offset">Requested page offset</param>
    /// <param name="limit">Requested page limit</param>
    /// <param name="total">Total number of items available</param>
    public PageResult(IEnumerable<object>? items, int? offset, int? limit, int? total)
        : this(items, new PageRequest(offset, limit), total) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T}"/> class.
    /// </summary>
    /// <param name="items">Page items</param>
    /// <param name="request">Page request used to generate this page</param>
    /// <param name="total">Total number of items available</param>
    public PageResult(IEnumerable<object>? items, PageRequest? request, int? total) : base(items, request, total) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult"/> class.
    /// </summary>
    public PageResult() : base() { }
}

/// <summary>
/// A page of items
/// </summary>
/// <typeparam name="T">Item type</typeparam>
public class PageResult<T>
{
    /// <summary>
    /// The request used to generate this page
    /// </summary>
    [JsonPropertyName("request")]
    public PageRequest? Request { get; set; }

    /// <summary>
    /// The number of items in this page
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    /// <summary>
    /// The total number of items available
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// The items in this page
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<T>? Items { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T}"/> class.
    /// </summary>
    /// <param name="items">Page items</param>
    /// <param name="offset">Requested page offset</param>
    /// <param name="limit">Requested page limit</param>
    /// <param name="total">Total number of items available</param>
    public PageResult(IEnumerable<T> items, int? offset, int? limit, int? total)
        : this(items, new PageRequest(offset, limit), total) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T}"/> class.
    /// </summary>
    /// <param name="items">Page items</param>
    /// <param name="request">Page request used to generate this page</param>
    /// <param name="total">Total number of items available</param>
    public PageResult(IEnumerable<T>? items, PageRequest? request, int? total) : this()
    {
        Items = items;
        Count = items?.Count();
        Request = request;
        Total = total;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T}"/> class.
    /// </summary>
    public PageResult() : base() { }
}
