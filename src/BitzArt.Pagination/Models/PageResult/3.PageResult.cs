using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

/// <inheritdoc cref="PageResult{T}"/>
public abstract class PageResult
{
    /// <inheritdoc/>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    /// <inheritdoc/>
    [JsonPropertyName("total")]
    public int? Total { get; set; }
}
