using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

public class PageResult : PageResult<object>
{
    public PageResult(IEnumerable<object>? items, int? offset, int? limit, int? total)
        : this(items, new PageRequest(offset, limit), total) { }

    public PageResult(IEnumerable<object>? items, PageRequest? request, int? total) : base(items, request, total) { }

    public PageResult() : base() { }
}

public class PageResult<T>
{
    [JsonPropertyName("request")]
    public PageRequest? Request { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("items")]
    public IEnumerable<T>? Items { get; set; }

    public PageResult(IEnumerable<T> items, int? offset, int? limit, int? total)
        : this(items, new PageRequest(offset, limit), total) { }

    public PageResult(IEnumerable<T>? items, PageRequest? request, int? total) : this()
    {
        Items = items;
        Count = items?.Count();
        Request = request;
        Total = total;
    }

    public PageResult() : base() { }
}
