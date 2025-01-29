using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

/// <summary>
/// A request for a page of items
/// </summary>
public class PageRequest
{
    /// <summary>
    /// Requested page offset
    /// </summary>
    [JsonPropertyName("offset")]
    public virtual int? Offset { get; set; }

    /// <summary>
    /// Requested page limit
    /// </summary>
    [JsonPropertyName("limit")]
    public virtual int? Limit { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageRequest"/> class.
    /// </summary>
    public PageRequest() : this(0, 100) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageRequest"/> class.
    /// </summary>
    /// <param name="offset">Requested page offset</param>
    /// <param name="limit">Requested page limit</param>
    public PageRequest(int? offset, int? limit)
    {
        Offset = offset;
        Limit = limit;
    }
}
