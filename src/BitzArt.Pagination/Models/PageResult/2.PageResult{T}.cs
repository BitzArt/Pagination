using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

/// <inheritdoc cref="PageResult{T, TRequest}"/>
public class PageResult<T> : PageResult
{
    /// <summary>
    /// The items in this page.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<T>? Items { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T}"/> class.
    /// </summary>
    /// <param name="items">Page items.</param>
    /// <param name="total">Total number of items available.</param>
    /// <param name="count">Number of items in this page. If <see langword="null"/> is provided, will use <paramref name="items"/> count.</param>
    public PageResult(IEnumerable<T>? items, int? total, int? count = null) : this()
    {
        Items = items;
        Count = count ?? items?.Count();
        Total = total;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageResult{T,TPageRequest}"/> class.
    /// </summary>
    [JsonConstructor]
    protected PageResult() { }
}
