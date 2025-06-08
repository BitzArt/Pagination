using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

/// <summary>
/// A request for a page of items.
/// </summary>
public class PageRequest : IPageRequest
{
    /// <summary>
    /// Default limit if not specified in the request.
    /// </summary>
    protected virtual int DefaultLimit => 100;

    /// <summary>
    /// Requested page offset.
    /// </summary>
    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

    /// <summary>
    /// Requested page limit.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageRequest"/> class.
    /// </summary>
    /// <param name="offset">Requested page offset. If <see langword="null"/>, defaults to <c>0</c>.</param>
    /// <param name="limit">Requested page limit. If <see langword="null"/>, defaults to <see cref="DefaultLimit"/>.</param>
    public PageRequest(int? offset = null, int? limit = null)
    {
        Offset = offset;
        Limit = limit;
    }

    /// <inheritdoc/>
    public IEnumerable<TSource> ApplyConstraints<TSource>(IEnumerable<TSource> query)
    {
        if (Offset is not null)
        {
            query = query.Skip(Offset!.Value);
        }

        query = Limit is not null
            ? query.Take(Limit!.Value)
            : query.Take(DefaultLimit);

        return query;
    }

    /// <inheritdoc/>
    public IQueryable<TSource> ApplyConstraints<TSource>(IQueryable<TSource> query)
    {
        if (Offset is not null)
        {
            query = query.Skip(Offset!.Value);
        }

        query = Limit is not null
            ? query.Take(Limit!.Value)
            : query.Take(DefaultLimit);

        return query;
    }

    /// <inheritdoc/>
    public override string ToString() => $"Offset: {Offset}, Limit: {Limit}";
}
